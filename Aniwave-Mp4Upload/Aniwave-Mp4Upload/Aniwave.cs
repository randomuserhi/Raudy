using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using AngleSharp.Html.Parser;
using Raudy.Url;
using Newtonsoft.Json;

// TODO(randomuserhi): Better exception handling => need to write to a log file etc...
// TODO(randomuserhi): A method to get information from aniwave filter => e.g latest, newest etc...

public partial class Aniwave : IDisposable
{
    private const string baseUrl = "https://aniwave.to"; 

    private HttpClient client;
    private HtmlParser parser = new HtmlParser();
    private Dictionary<string, ISource> embedScrapers = new Dictionary<string, ISource>();

    public void Dispose()
    {
        client.Dispose();
    }

    public Aniwave()
    {
        // Supported sources
        embedScrapers.Add("mp4upload", new Mp4Upload());

        client = new HttpClient();
        client.BaseAddress = new Uri(baseUrl);
        client.DefaultRequestHeaders.Referrer = new Uri(baseUrl);

        // Imitate request from chrome
        client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/113.0.0.0 Safari/537.36");
        client.DefaultRequestHeaders.Add("X-Requested-With", "XMLHttpRequest");
        client.DefaultRequestHeaders.Add("sec-ch-ua", "\"Google Chrome\";v=\"113\", \"Chromium\";v=\"113\", \"Not-A.Brand\";v=\"24\"");
        client.DefaultRequestHeaders.Add("sec-ch-ua-mobile", "?0");
        client.DefaultRequestHeaders.Add("sec-ch-ua-platform", "\"Windows\"");
    }

    private void DebugRequestHeaders(HttpRequestMessage request)
    {
        foreach (KeyValuePair<string, IEnumerable<string>> h in client.DefaultRequestHeaders)
        {
            Console.WriteLine($"{h.Key}: {string.Join(", ", h.Value)}");
        }
        foreach (KeyValuePair<string, IEnumerable<string>> h in request.Headers)
        {
            Console.WriteLine($"{h.Key}: {string.Join(", ", h.Value)}");
        }
    }

    public async Task<Anime?> GetFullAnimeDetails(AnimeInfo info)
    {
        return await GetFullAnimeDetails(info.link);
    }
    public async Task<Anime?> GetFullAnimeDetails(string url)
    {
        try
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get,
                url);

            using (HttpResponseMessage res = await client.SendAsync(request))
            {
                if (res.IsSuccessStatusCode)
                {
                    using (HttpContent content = res.Content)
                    {
                        string data = await content.ReadAsStringAsync();
                        Response<string> resp = JsonConvert.DeserializeObject<Response<string>>(data);
                        IHtmlDocument document = parser.ParseDocument(resp.result);
                        IElement infoEl = document.GetElementById("w-info")!;

                        Anime anime = new Anime();
                        anime.id = document.GetElementById("watch-main")!.GetAttribute("data-id")!;
                        anime.link = url;
                        anime.enTitle = infoEl.QuerySelector(".info>.title")!.InnerHtml;
                        anime.jpTitle = infoEl.QuerySelector(".info>.title")!.GetAttribute("data-jp")!;
                        anime.alternativeTitles = infoEl.QuerySelector(".info>.names")!.InnerHtml.Split(";");
                        for (int i = 0; i < anime.alternativeTitles.Length; ++i)
                        {
                            anime.alternativeTitles[i] = anime.alternativeTitles[i].Trim();
                        }
                        anime.thumbnail = infoEl.QuerySelector("img")!.GetAttribute("src")!;
                        anime.description = infoEl.QuerySelector(".content")!.InnerHtml;

                        return anime;
                    }
                }
            }

            return null;
        }
        catch (Exception exception)
        {
            Console.WriteLine($"Error trying to obtain episode list: {url}");
            Console.WriteLine(exception);
            return null;
        }
    }

    public async Task<EpisodeList?> GetEpisodes(Anime anime, Category categories) 
    {
        string url = $"{baseUrl}/ajax/episode/list/{anime.id}?vrf={Decoder.GetVrf(anime.id)}";
        Console.WriteLine(url);
        try
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get,
               url);
            request.Headers.Referrer = new Uri(anime.link); // NOTE(randomuserhi): Important to set the referrer to imitate that we are from the site
            request.Headers.Add("Accept", "application/json, text/javascript, */*; q=0.01");

            using (HttpResponseMessage res = await client.SendAsync(request))
            {
                if (res.IsSuccessStatusCode)
                {
                    using (HttpContent content = res.Content)
                    {
                        string data = await content.ReadAsStringAsync();
                        Response<string> resp = JsonConvert.DeserializeObject<Response<string>>(data);

                        IHtmlDocument dom = parser.ParseDocument(string.Empty);
                        INodeList nodes = parser.ParseFragment(resp.result, dom.Body!);

                        EpisodeList list = new EpisodeList();
                        list.category = categories;
                        list.anime = anime;
                        List<Episode> episodes = new List<Episode>();

                        Action<IElement, IElement, string, Category> parseEpisode = delegate(IElement li, IElement a, string id, Category category)
                        {
                            Episode ep = new Episode();

                            ep.anime = anime;
                            ep.id = id;
                            ep.epNum = a.GetAttribute("data-num")!;
                            ep.category = category;
                            IElement? title = li.QuerySelector(".d-title");
                            if (title != null)
                            {
                                ep.enTitle = title.InnerHtml;
                                ep.jpTitle = title.GetAttribute("data-jp")!;
                            }

                            episodes.Add(ep);
                        };

                        foreach (IElement li in nodes.QuerySelectorAll("li"))
                        {
                            IElement a = li.QuerySelector("a")!;
                            string[] ids = a.GetAttribute("data-ids")!.Split(",");
                            for (int i = 0; i < ids.Length; ++i)
                            {
                                ids[i] = ids[i].Trim();
                            }

                            // If there is only 1 id, check data-sub and data-dub
                            if (ids.Length == 1)
                            {
                                string sub = a.GetAttribute("data-sub")!;
                                string dub = a.GetAttribute("data-dub")!;

                                Category category = Category.Sub;
                                if (sub == "0" && dub == "1") 
                                    category = Category.Dub;

                                if (categories.HasFlag(category))
                                {
                                    parseEpisode(li, a, ids[0], category);
                                }
                            }
                            // if there are 2, assume first is sub, and second is dub
                            else if (ids.Length == 2)
                            {
                                for (int i = 0; i < ids.Length; ++i) 
                                {
                                    Category category = i == 1 ? Category.Dub : Category.Sub;

                                    if (categories.HasFlag(category))
                                    {
                                        parseEpisode(li, a, ids[i], category);
                                    }
                                }
                            }
                        }

                        list.episodes = episodes.ToArray();
                        return list;
                    }
                }
            }

            return null;
        }
        catch (Exception exception)
        {
            Console.WriteLine($"Error trying to obtain episode: {url}");
            Console.WriteLine(exception);
            return null;
        }
    }

    public async Task<Query?> Search(string keyword)
    {
        string url = $"{baseUrl}/ajax/anime/search?keyword={keyword}";
        try
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get,
                url);
            request.Headers.Add("Accept", "application/json, text/javascript, */*; q=0.01");

            using (HttpResponseMessage res = await client.SendAsync(request))
            {
                if (res.IsSuccessStatusCode)
                {
                    using (HttpContent content = res.Content)
                    {
                        Query query = new Query();
                        query.filter = new Filter();
                        query.filter.keyword = keyword;
                        List<AnimeInfo> results = new List<AnimeInfo>();

                        string data = await content.ReadAsStringAsync();
                        Response<WebpageSnippet> resp = JsonConvert.DeserializeObject<Response<WebpageSnippet>>(data);

                        IHtmlDocument dom = parser.ParseDocument(string.Empty);
                        INodeList nodes = parser.ParseFragment(resp.result.html, dom.Body!);
                        foreach (IElement el in nodes.QuerySelectorAll(".item"))
                        {
                            AnimeInfo anime = new AnimeInfo();

                            anime.link = UrlUtilities.Combine(baseUrl, el.GetAttribute("href")!);
                            anime.thumbnail = el.QuerySelector("img")!.GetAttribute("src")!;
                            anime.enTitle = el.QuerySelector(".d-title")!.InnerHtml;
                            anime.jpTitle = el.QuerySelector(".d-title")!.GetAttribute("data-jp")!;

                            results.Add(anime);
                        }

                        query.results = results.ToArray();
                        return query;
                    }
                }
            }

            return null;
        }
        catch (Exception exception)
        {
            Console.WriteLine($"Error trying to obtain search query: {url}");
            Console.WriteLine(exception);
            return null;
        }
    }

    public async Task<SourceList?> GetSources(Episode ep)
    {
        string url = $"{baseUrl}/ajax/server/list/{ep.id}?vrf={Decoder.GetVrf(ep.id)}";
        try
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get,
                url);
            request.Headers.Referrer = new Uri(ep.anime.link); // NOTE(randomuserhi): Important to set the referrer to imitate that we are from the site
            request.Headers.Add("Accept", "application/json, text/javascript, */*; q=0.01");

            using (HttpResponseMessage res = await client.SendAsync(request))
            {
                if (res.IsSuccessStatusCode)
                {
                    using (HttpContent content = res.Content)
                    {
                        string data = await content.ReadAsStringAsync();
                        Response<string> resp = JsonConvert.DeserializeObject<Response<string>>(data);

                        SourceList sourceList = new SourceList();
                        sourceList.episode = ep;
                        List<Source> sources = new List<Source>();

                        IHtmlDocument dom = parser.ParseDocument(string.Empty);
                        INodeList nodes = parser.ParseFragment(resp.result, dom.Body!);
                        IElement servers = nodes.QuerySelector(".servers")!;

                        foreach (IElement li in servers.QuerySelectorAll("li"))
                        {
                            Source source = new Source();
                            source.episode = ep;
                            source.name = li.InnerHtml.ToLower().Trim();
                            source.id = li.GetAttribute("data-link-id")!;

                            if (embedScrapers.ContainsKey(source.name))
                            {
                                sources.Add(source);
                            }
                            else Console.WriteLine($"Don't support source: {source.name}");
                        }

                        sourceList.sources = sources.ToArray();
                        return sourceList;
                    }
                }
            }

            return null;
        }
        catch (Exception exception)
        {
            Console.WriteLine($"Error trying to obtain sources: {url}");
            Console.WriteLine(exception);
            return null;
        }
    }

    public async Task<VideoEmbed?> GetEmbed(Source source)
    {
        string url = $"{baseUrl}/ajax/server/{source.id}?vrf={Decoder.GetVrf(source.id)}";
        try
        {
            if (!embedScrapers.ContainsKey(source.name))
            {
                Console.WriteLine("Unsupported source");
                return null;
            }

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get,
                url);
            request.Headers.Referrer = new Uri(source.episode.anime.link); // NOTE(randomuserhi): Important to set the referrer to imitate that we are from the site
            request.Headers.Add("Accept", "application/json, text/javascript, */*; q=0.01");

            using (HttpResponseMessage res = await client.SendAsync(request))
            {
                if (res.IsSuccessStatusCode)
                {
                    using (HttpContent content = res.Content)
                    {
                        string data = await content.ReadAsStringAsync();
                        Response<EncodedVideoEmbed> resp = JsonConvert.DeserializeObject<Response<EncodedVideoEmbed>>(data);

                        VideoEmbed embed = new VideoEmbed();
                        embed.url = Decoder.DecodeVideoData(resp.result.url);
                        embed.skip_data = JsonConvert.DeserializeObject<Dictionary<string, int[]>>(Decoder.DecodeSkipData(resp.result.skip_data));
                        embed.video = await embedScrapers[source.name].GetMp4Link(embed);

                        return embed;
                    }
                }
            }

            return null;
        }
        catch (Exception exception)
        {
            Console.WriteLine($"Error trying to obtain video embed: {url}");
            Console.WriteLine(exception);
            return null;
        }
    }
}
