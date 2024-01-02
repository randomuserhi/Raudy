using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using AngleSharp.Html.Parser;
using Newtonsoft.Json;
using Raudy.Url;

// TODO(randomuserhi): Better exception handling => need to write to a log file etc...

public partial class Aniwave : IDisposable {
    private const string domain = "aniwave.to";
    private const string baseUrl = $"https://{domain}";

    private HttpClient client;
    private HtmlParser parser = new HtmlParser();
    public Dictionary<string, ISource> embedScrapers = new Dictionary<string, ISource>(); //TODO(randomuserhi): Change to private

    public void Dispose() {
        client.Dispose();
    }

    public Aniwave() {
        // Supported sources
        embedScrapers.Add("mp4upload", new Mp4Upload());

        client = new HttpClient();
        client.BaseAddress = new Uri(baseUrl);
        client.DefaultRequestHeaders.Referrer = new Uri(baseUrl);

        // Imitate request from chrome
        client.DefaultRequestHeaders.Add("Host", domain);
        client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/113.0.0.0 Safari/537.36");
        client.DefaultRequestHeaders.Add("X-Requested-With", "XMLHttpRequest");
        client.DefaultRequestHeaders.Add("sec-ch-ua", "\"Google Chrome\";v=\"113\", \"Chromium\";v=\"113\", \"Not-A.Brand\";v=\"24\"");
        client.DefaultRequestHeaders.Add("sec-ch-ua-mobile", "?0");
        client.DefaultRequestHeaders.Add("sec-ch-ua-platform", "\"Windows\"");
    }

    private void DebugRequestHeaders(HttpRequestMessage request) {
        foreach (KeyValuePair<string, IEnumerable<string>> h in client.DefaultRequestHeaders) {
            Console.WriteLine($"{h.Key}: {string.Join(", ", h.Value)}");
        }
        foreach (KeyValuePair<string, IEnumerable<string>> h in request.Headers) {
            Console.WriteLine($"{h.Key}: {string.Join(", ", h.Value)}");
        }
    }

    public async Task<Anime?> GetFullAnimeDetails(AnimeInfo info) {
        return await GetFullAnimeDetails(info.link);
    }
    public async Task<Anime?> GetFullAnimeDetails(string url) {
        try {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get,
                url);

            using (HttpResponseMessage res = await client.SendAsync(request)) {
                if (res.IsSuccessStatusCode) {
                    using (HttpContent content = res.Content) {
                        string data = await content.ReadAsStringAsync();
                        Response<string> resp = JsonConvert.DeserializeObject<Response<string>>(data);
                        IHtmlDocument document = parser.ParseDocument(resp.result);
                        IElement infoEl = document.GetElementById("w-info")!;

                        Anime anime = new Anime();
                        anime.id = document.GetElementById("watch-main")!.GetAttribute("data-id")!;
                        anime.link = url;
                        // TODO(randomuserhi) => Check compatability with chinese titles (data-jp may be missing)
                        List<PackedString> titles = new List<PackedString> {
                            new PackedString(infoEl.QuerySelector(".info>.title")!.InnerHtml, "language=en; primary"),
                            new PackedString(infoEl.QuerySelector(".info>.title")!.GetAttribute("data-jp")!, "language=jp; primary")
                        };
                        string[] alternativeTitles = infoEl.QuerySelector(".info>.names")!.InnerHtml.Split(";");
                        for (int i = 0; i < alternativeTitles.Length; ++i) {
                            titles.Add(new PackedString(alternativeTitles[i].Trim()));
                        }
                        anime.titles = titles.ToArray();
                        anime.thumbnail = infoEl.QuerySelector("img")!.GetAttribute("src")!;
                        anime.description = infoEl.QuerySelector(".content")!.InnerHtml;
                        anime.categories = Category.None;

                        return anime;
                    }
                }
            }

            return null;
        } catch (Exception exception) {
            Console.WriteLine($"Error trying to obtain episode list: {url}");
            Console.WriteLine(exception);
            return null;
        }
    }

    public async Task<Query?> ShortSearch(string keyword) {
        string url = $"{baseUrl}/ajax/anime/search?keyword={keyword}";
        try {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get,
                url);
            request.Headers.Add("Accept", "application/json, text/javascript, */*; q=0.01");

            using (HttpResponseMessage res = await client.SendAsync(request)) {
                if (res.IsSuccessStatusCode) {
                    using (HttpContent content = res.Content) {
                        Query query = new Query();
                        query.filter = new Filter();
                        query.filter.keyword = keyword;
                        List<AnimeInfo> results = new List<AnimeInfo>();

                        string data = await content.ReadAsStringAsync();
                        Response<WebpageSnippet> resp = JsonConvert.DeserializeObject<Response<WebpageSnippet>>(data);

                        IHtmlDocument dom = parser.ParseDocument(string.Empty);
                        INodeList nodes = parser.ParseFragment(resp.result.html, dom.Body!);
                        foreach (IElement el in nodes.QuerySelectorAll(".item")) {
                            AnimeInfo anime = new AnimeInfo();

                            anime.link = UrlUtilities.Combine(baseUrl, el.GetAttribute("href")!);
                            anime.thumbnail = el.QuerySelector("img")!.GetAttribute("src")!.Replace("-w100", "");

                            // TODO(randomuserhi) => Check compatability with chinese titles (data-jp may be missing)
                            anime.titles = new PackedString[] {
                                new PackedString(el.QuerySelector(".d-title")!.InnerHtml, "language=en; primary"),
                                new PackedString(el.QuerySelector(".d-title")!.GetAttribute("data-jp")!, "language=jp; primary")
                            };

                            results.Add(anime);
                        }

                        query.results = results.ToArray();
                        return query;
                    }
                }
            }

            return null;
        } catch (Exception exception) {
            Console.WriteLine($"Error trying to obtain search query: {url}");
            Console.WriteLine(exception);
            return null;
        }
    }

    // TODO(randomuserhi): Add various filter properties
    public async Task<Anime[]> Search(string keyword, int page = 1) {
        string url = $"{baseUrl}/filter?sort=recently_updated&keyword={keyword}&page={page}";

        // NOTE(randomuserhi): These 3 are shorthand for filters url => E.g for "completed" => /ajax/anime/filter?status%5B%5D=completed
        //string url = $"{baseUrl}/newest?page=1";
        //string url = $"{baseUrl}/added?page=1";
        //string url = $"{baseUrl}/completed?page=1";

        // NOTE(randomuserhi): These 3 are shorthand for filters url as well!
        //string url = $"{baseUrl}/ajax/home/widget/updated-dub?page=1";
        //string url = $"{baseUrl}/ajax/home/widget/updated-sub?page=1";
        //string url = $"{baseUrl}/ajax/home/widget/updated-all?page=1";
        List<Anime> results = new List<Anime>();
        try {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get,
                url);
            request.Headers.Add("Accept", "application/json, text/javascript, */*; q=0.01");

            using (HttpResponseMessage res = await client.SendAsync(request)) {
                if (res.IsSuccessStatusCode) {
                    using (HttpContent content = res.Content) {
                        string data = await content.ReadAsStringAsync();
                        Response<string> response = JsonConvert.DeserializeObject<Response<string>>(data);
                        IHtmlDocument dom = parser.ParseDocument(response.result);

                        IElement list = dom.GetElementById("list-items")!;
                        foreach (IElement item in list.QuerySelectorAll(".item")) {
                            IElement poster = item.QuerySelector(".ani.poster.tip")!;
                            //string tooltipID = poster.GetAttribute("data-tip")!;
                            //Anime anime = (await GetTooltip(tooltipID)).Value;
                            Anime anime = new Anime();

                            IElement info = item.QuerySelector(".name.d-title")!;
                            anime.link = $"{baseUrl}{info.GetAttribute("href")!}";

                            anime.titles = new PackedString[] {
                                new PackedString(info.InnerHtml, "language=en; primary"),
                                new PackedString(info.GetAttribute("data-jp")!, "language=jp; primary")
                            };

                            anime.thumbnail = item.QuerySelector("img")!.GetAttribute("src")!;

                            anime.categories = Category.None;
                            if (item.QuerySelectorAll(".ep-status.sub").Length == 1) {
                                anime.categories |= Category.Sub;
                            } else if (item.QuerySelectorAll(".ep-status.dub").Length == 1) {
                                anime.categories |= Category.Dub;
                            }

                            results.Add(anime);
                        }
                    }
                }
            }
        } catch (Exception exception) {
            Console.WriteLine($"Error trying to obtain filter query: {url}");
            Console.WriteLine(exception);
        }

        return results.ToArray();
    }

    // NOTE(randomuserhi): Special case for aniwave tooltip for additional information about animes
    public async Task<Anime?> GetTooltip(string id) {
        string url = $"{baseUrl}/ajax/anime/tooltip/{id}";

        try {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get,
                url);
            request.Headers.Add("Accept", "application/json, text/javascript, */*; q=0.01");

            using (HttpResponseMessage res = await client.SendAsync(request)) {
                if (res.IsSuccessStatusCode) {
                    using (HttpContent content = res.Content) {
                        string data = await content.ReadAsStringAsync();
                        IHtmlDocument dom = parser.ParseDocument(string.Empty);
                        INodeList nodes = parser.ParseFragment(data, dom.Body!);

                        Anime anime = new Anime();

                        IElement titleEl = nodes.QuerySelector(".title.d-title")!;
                        // TODO(randomuserhi) => Check compatability with chinese titles (data-jp may be missing)
                        List<PackedString> titles = new List<PackedString>() {
                            new PackedString(titleEl.InnerHtml, "language=en; primary"),
                            new PackedString(titleEl.GetAttribute("data-jp")!, "language=jp; primary")
                        };
                        string[] otherTitles = nodes.QuerySelector(".meta-bl")!.ChildNodes[1].ChildNodes[1].TextContent.Split(";");
                        foreach (string title in otherTitles) {
                            titles.Add(new PackedString(title.Trim()));
                        }
                        anime.titles = titles.ToArray();
                        anime.description = nodes.QuerySelector(".synopsis")!.InnerHtml;
                        anime.id = nodes.QuerySelector(".favourite.dropup")!.GetAttribute("data-id")!;
                        anime.link = $"{baseUrl}{nodes.QuerySelector(".watch")!.GetAttribute("href")!}";
                        anime.categories = Category.None;
                        if (nodes.QuerySelectorAll(".ep-status.sub").Length == 1) {
                            anime.categories |= Category.Sub;
                        } else if (nodes.QuerySelectorAll(".ep-status.dub").Length == 1) {
                            anime.categories |= Category.Dub;
                        }

                        // No thumbnail

                        return anime;
                    }
                }
            }

            return null;
        } catch (Exception exception) {
            Console.WriteLine($"Error trying to obtaining tooltip: {url}");
            Console.WriteLine(exception);
            return null;
        }
    }

    public async Task<EpisodeList?> GetEpisodes(Anime anime, Category categories) {
        string url = $"{baseUrl}/ajax/episode/list/{anime.id}?vrf={Decoder.GetVrf(anime.id)}";
        try {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get,
               url);
            request.Headers.Referrer = new Uri(anime.link); // NOTE(randomuserhi): Important to set the referrer to imitate that we are from the site
            request.Headers.Add("Accept", "application/json, text/javascript, */*; q=0.01");

            using (HttpResponseMessage res = await client.SendAsync(request)) {
                if (res.IsSuccessStatusCode) {
                    using (HttpContent content = res.Content) {
                        string data = await content.ReadAsStringAsync();
                        Response<string> resp = JsonConvert.DeserializeObject<Response<string>>(data);

                        IHtmlDocument dom = parser.ParseDocument(string.Empty);
                        INodeList nodes = parser.ParseFragment(resp.result, dom.Body!);

                        EpisodeList list = new EpisodeList();
                        list.category = categories;
                        list.anime = anime;
                        List<Episode> episodes = new List<Episode>();

                        Action<IElement, IElement, string, Category> parseEpisode = delegate (IElement li, IElement a, string id, Category category) {
                            Episode ep = new Episode();

                            ep.anime = anime;
                            ep.id = id;
                            ep.epNum = int.Parse(a.GetAttribute("data-num")!);
                            ep.category = category;
                            IElement? title = li.QuerySelector(".d-title");
                            if (title != null) {
                                // TODO(randomuserhi) => Check compatability with chinese titles (data-jp may be missing)
                                ep.titles = new PackedString[] {
                                    new PackedString(title.InnerHtml, "language=en; primary"),
                                    new PackedString(title.GetAttribute("data-jp")!, "language=jp; primary")
                                };
                            }

                            if (categories.HasFlag(category)) {
                                episodes.Add(ep);
                            }
                        };

                        foreach (IElement li in nodes.QuerySelectorAll("li")) {
                            IElement a = li.QuerySelector("a")!;
                            string[] ids = a.GetAttribute("data-ids")!.Split(",");
                            for (int i = 0; i < ids.Length; ++i) {
                                ids[i] = ids[i].Trim();
                            }

                            if (ids.Length == 1) {
                                // If there is only 1 id, check data-sub and data-dub
                                string sub = a.GetAttribute("data-sub")!;
                                string dub = a.GetAttribute("data-dub")!;

                                Category category = Category.Sub;
                                if (sub == "0" && dub == "1")
                                    category = Category.Dub;

                                parseEpisode(li, a, ids[0], category);
                            } else if (ids.Length == 2) {
                                // If there are 2, check for dub
                                // If dub is available, first is sub, second is dub
                                // Otherwise first is sub and second is soft sub
                                string dub = a.GetAttribute("data-dub")!;
                                if (dub == "1") {
                                    parseEpisode(li, a, ids[0], Category.Sub);
                                    parseEpisode(li, a, ids[1], Category.Dub);
                                } else {
                                    parseEpisode(li, a, ids[0], Category.Sub);
                                    parseEpisode(li, a, ids[1], Category.SSub);
                                }
                            } else if (ids.Length == 3) {
                                // If there are 3, then sub, soft sub and dub are available
                                parseEpisode(li, a, ids[0], Category.Sub);
                                parseEpisode(li, a, ids[1], Category.SSub);
                                parseEpisode(li, a, ids[2], Category.Dub);
                            }
                        }

                        list.episodes = episodes.ToArray();
                        return list;
                    }
                }
            }

            return null;
        } catch (Exception exception) {
            Console.WriteLine($"Error trying to obtain episode: {url}");
            Console.WriteLine(exception);
            return null;
        }
    }

    public async Task<SourceList?> GetSources(Episode ep) {
        string url = $"{baseUrl}/ajax/server/list/{ep.id}?vrf={Decoder.GetVrf(ep.id)}";
        try {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get,
                url);
            request.Headers.Referrer = new Uri(ep.anime.link); // NOTE(randomuserhi): Important to set the referrer to imitate that we are from the site
            request.Headers.Add("Accept", "application/json, text/javascript, */*; q=0.01");

            using (HttpResponseMessage res = await client.SendAsync(request)) {
                if (res.IsSuccessStatusCode) {
                    using (HttpContent content = res.Content) {
                        string data = await content.ReadAsStringAsync();
                        Response<string> resp = JsonConvert.DeserializeObject<Response<string>>(data);

                        SourceList sourceList = new SourceList();
                        sourceList.episode = ep;
                        List<Source> sources = new List<Source>();

                        IHtmlDocument dom = parser.ParseDocument(string.Empty);
                        INodeList nodes = parser.ParseFragment(resp.result, dom.Body!);
                        IElement servers = nodes.QuerySelector(".servers")!;

                        foreach (IElement li in servers.QuerySelectorAll("li")) {
                            Source source = new Source();
                            source.episode = ep;
                            source.name = li.InnerHtml.ToLower().Trim();
                            source.id = li.GetAttribute("data-link-id")!;

                            if (embedScrapers.ContainsKey(source.name)) {
                                sources.Add(source);
                            } else Console.WriteLine($"\tDon't support source: {source.name}");
                        }

                        sourceList.sources = sources.ToArray();
                        return sourceList;
                    }
                }
            }

            return null;
        } catch (Exception exception) {
            Console.WriteLine($"Error trying to obtain sources: {url}");
            Console.WriteLine(exception);
            return null;
        }
    }

    public async Task<VideoEmbed?> GetEmbed(Source source) {
        string url = $"{baseUrl}/ajax/server/{source.id}?vrf={Decoder.GetVrf(source.id)}";
        try {
            if (!embedScrapers.ContainsKey(source.name)) {
                Console.WriteLine("Unsupported source");
                return null;
            }

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get,
                url);
            request.Headers.Referrer = new Uri(source.episode.anime.link); // NOTE(randomuserhi): Important to set the referrer to imitate that we are from the site
            request.Headers.Add("Accept", "application/json, text/javascript, */*; q=0.01");

            using (HttpResponseMessage res = await client.SendAsync(request)) {
                if (res.IsSuccessStatusCode) {
                    using (HttpContent content = res.Content) {
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
        } catch (Exception exception) {
            Console.WriteLine($"Error trying to obtain video embed: {url}");
            Console.WriteLine(exception);
            return null;
        }
    }
}
