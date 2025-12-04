using AngleSharp.Dom;
using AngleSharp.Html.Parser;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using WebSocketSharp;

public partial class Novelpia {
    private const string domain = "global.novelpia.com";
    private const string baseUrl = $"https://{domain}";

    private HttpClient client;
    private HtmlParser parser = new HtmlParser();

    public struct SessionInfo {
        public string cookie;
        public string JWT;
    }

    public void Dispose() {
        client.Dispose();
    }

    public Novelpia() {
        // Handle Gzip compression and redirects
        HttpClientHandler handler = new HttpClientHandler();
        handler.AllowAutoRedirect = true;
        handler.AutomaticDecompression = System.Net.DecompressionMethods.GZip | System.Net.DecompressionMethods.Deflate;

        client = new HttpClient(handler);
        client.BaseAddress = new Uri(baseUrl);
        client.DefaultRequestHeaders.Referrer = new Uri(baseUrl);

        // Imitate request from chrome
        client.DefaultRequestHeaders.Add("Host", domain);
        client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/120.0.0.0 Safari/537.36");
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

    private class State {
        public string path;
        public StringBuilder epub = new StringBuilder();
        public static int image = 0;

        public State(string path) {
            this.path = path;
        }
    }

    private static string[] validIdentifiers = new string[] { "p", "br", "i", "b", "u", "em", "hr", "img" };
    private static string[] ignoreIdentifiers = new string[] { "script" };
    private async Task Process(INode node, State state, bool inParagraph = false) {
        if (node.NodeType == NodeType.Element) {

            IElement el = (IElement)node;
            string identifier = $"{el.TagName.Trim().ToLower()}";

            if (ignoreIdentifiers.Contains(identifier)) return;
            if (identifier != "br" && identifier != "hr" && identifier != "img" && el.TextContent.Trim() == string.Empty && el.QuerySelector("img") == null) return;

            bool isValid = validIdentifiers.Contains(identifier);
            if (identifier == "div") {
                // NOTE(randomuserhi): Special case where div should be a paragraph
                if (el.QuerySelectorAll("*:not(p):not(i):not(b):not(u):not(em)").Length == 0) {
                    isValid = true;
                    identifier = "p";
                }
            } else if (identifier == "img") {
                string imgurl = el.GetAttribute("src")!;
                string ext = GetExtensionFromURL(imgurl);
                int id = State.image++;
                ext = await DownloadImage(imgurl, Path.Join(state.path, "Images", $"{id}{ext}"), ext);
                state.epub.AppendLine($"<div><img src=\"../Images/{id}{ext}\" alt=\"\" /></div>");

                return;
            }

            bool isInParagraph = inParagraph || (identifier == "p");

            if (identifier == "br") {
                state.epub.AppendLine(isInParagraph ? "</p><p>" : "<br/>");
                return;
            }

            if (isValid) {
                if (!isInParagraph) state.epub.Append($"\n<p><{identifier}>");
                else state.epub.Append($"{(identifier == "p" ? "\n" : string.Empty)}<{identifier}>");
            }

            foreach (INode child in node.ChildNodes) {
                await Process(child, state, inParagraph || isValid);
            }

            if (isValid) {
                if (!isInParagraph) state.epub.Append($"</{identifier}></p>\n");
                else state.epub.Append($"</{identifier}>{(identifier == "p" ? "\n" : string.Empty)}");
            }

        } else if (node.NodeType == NodeType.Text) {
            string text = HttpUtility.HtmlEncode(node.TextContent);
            if (text == string.Empty) return;

            if (inParagraph) state.epub.Append($"{text}");
            else state.epub.Append($"<p>{text}</p>");
        }
    }

    private Regex r = new Regex(@"(\.[a-zA-Z0-9]+)(\?|\#|$)");
    private string GetExtensionFromURL(string url) {
        Match token = r.Match(url);
        if (!token.Success) return "";
        return token.Groups[1].Value;
    }

    private async Task<string> DownloadImage(string url, string path, string ext) {
        //return ext;
        try {
            client.DefaultRequestHeaders.Remove("Host");
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get,
            url);
            request.Headers.Add("Referer", $"{baseUrl}");
            request.Headers.Add("httpVersion", "h3");

            using (HttpResponseMessage res = await client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead)) {
                if (res.IsSuccessStatusCode) {
                    using (HttpContent content = res.Content) {
                        HttpHeaders headers = content.Headers;
                        if (ext == "") {
                            if (headers.TryGetValues("Content-Type", out IEnumerable<string>? values)) {
                                string mimeType = values.First();
                                switch (mimeType) {
                                case "image/jpeg":
                                    ext = ".jpg";
                                    break;
                                case "image/png":
                                    ext = ".png";
                                    break;
                                }
                            }
                            path += ext;
                        }

                        string? directory = Path.GetDirectoryName(path);
                        if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory)) {
                            Directory.CreateDirectory(directory);
                        }

                        Stream data = await content.ReadAsStreamAsync();
                        FileStream writer = new FileStream(path, FileMode.Create);
                        byte[] buffer = new byte[16 * 1024];
                        int read;
                        while ((read = data.Read(buffer, 0, buffer.Length)) > 0) {
                            writer.Write(buffer, 0, read);
                        }
                        writer.Dispose();
                    }
                }
            }
        } catch (Exception exception) {
            Console.WriteLine($"Error trying to download image: {url}");
            Console.WriteLine(exception);
        } finally {
            client.DefaultRequestHeaders.Add("Host", domain);
        }

        return ext;
    }

    public async Task<SessionInfo> GetSession(string email, string password) {
        SessionInfo session = new SessionInfo();

        // Login
        HttpRequestMessage loginRequest = new HttpRequestMessage(HttpMethod.Post,
                    $"https://api-global.novelpia.com/v1/member/login") {
            Content = new StringContent($"{{\"email\":\"{email}\",\"passwd\":\"{password}\"}}", Encoding.UTF8, "application/json")
        };
        using (HttpResponseMessage loginResult = await client.SendAsync(loginRequest)) {
            if (loginResult.IsSuccessStatusCode) {
                using (HttpContent loginContent = loginResult.Content) {
                    JObject response = JObject.Parse(await loginContent.ReadAsStringAsync());
                    JObject result = response.Value<JObject>("result")!;
                    string JWT = result.Value<string>("LOGINAT")!;

                    session.JWT = JWT;
                }

                // Obtain cookie
                HttpRequestMessage cookieRequest = new HttpRequestMessage(HttpMethod.Get, baseUrl);
                cookieRequest.Headers.Add("Sec-Fetch-Site", "Same-Origin");
                cookieRequest.Headers.Add("Login-At", session.JWT);

                using (HttpResponseMessage res = await client.SendAsync(cookieRequest)) {
                    if (res.IsSuccessStatusCode) {
                        if (res.Headers.TryGetValues("Set-Cookie", out IEnumerable<string>? values)) {
                            foreach (string s in values) {
                                if (s.StartsWith("USERKEY")) {
                                    session.cookie = s;
                                    return session;
                                }
                            }
                        }
                    }
                }
            }
        }

        throw new Exception("Unable to obtain session!");
    }

    public async Task<SessionInfo> UpdateSession(SessionInfo session) {
        string[] jwtParts = session.JWT.Split(".");
        JObject content = JObject.Parse(Encoding.UTF8.GetString(Convert.FromBase64String(jwtParts[1])));
        long expiration = content.Value<long>("exp");

        long currentTime = DateTimeOffset.UtcNow.ToUnixTimeSeconds();

        // Session has not expired yet
        if (currentTime < expiration) return session;

        HttpRequestMessage refreshRequest = new HttpRequestMessage(HttpMethod.Get, "https://api-global.novelpia.com/v1/login/refresh");
        refreshRequest.Headers.Add("Sec-Fetch-Site", "Same-Origin");
        refreshRequest.Headers.Add("Cookie", session.cookie);
        refreshRequest.Headers.Add("Login-At", session.JWT);

        using (HttpResponseMessage refreshResult = await client.SendAsync(refreshRequest)) {
            if (refreshResult.IsSuccessStatusCode) {
                using (HttpContent refreshContent = refreshResult.Content) {
                    JObject response = JObject.Parse(await refreshContent.ReadAsStringAsync());
                    JObject result = response.Value<JObject>("result")!;
                    string JWT = result.Value<string>("LOGINAT")!;

                    session.JWT = JWT;

                    return session;
                }
            }
        }

        throw new Exception("Unable to update session!");
    }

    // NOTE(randomuserhi): Not perfect... Logic somehow differs from real version causing ad chapters to not log on website
    //                     But it does let me pull episode content...
    public async Task WatchAd(SessionInfo session, string novelNo, string episodeNo, int fakeWatchTime = 5000) {
        await UpdateSession(session);

        HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post,
            $"https://api-global.novelpia.com/v1/temp_access") {
            Content = new StringContent($"{{\"url\":\"https://global.novelpia.com/viewer/{episodeNo}\",\"referrer\":\"https://global.novelpia.com/viewer/{episodeNo}\"}}", Encoding.UTF8, "application/json")
        };
        request.Headers.Add("Sec-Fetch-Site", "Same-Origin");
        request.Headers.Add("Cookie", session.cookie);
        request.Headers.Add("Login-At", session.JWT);

        using (HttpResponseMessage res = await client.SendAsync(request)) {
            if (res.IsSuccessStatusCode) {
                HttpRequestMessage request2 = new HttpRequestMessage(HttpMethod.Get,
                    $"https://api-global.novelpia.com/v1/ad/reward/token?novel_no={novelNo}&episode_no={episodeNo}");
                request2.Headers.Add("Sec-Fetch-Site", "Same-Origin");
                request2.Headers.Add("Cookie", session.cookie);
                request2.Headers.Add("Login-At", session.JWT);
                using (HttpResponseMessage res2 = await client.SendAsync(request2)) {
                    if (res2.IsSuccessStatusCode) {
                        using (HttpContent res2Content = res2.Content) {
                            JObject result = JObject.Parse(await res2Content.ReadAsStringAsync()).Value<JObject>("result")!;
                            string adToken = result.Value<string>("token")!;

                            if (fakeWatchTime > 0) Thread.Sleep(fakeWatchTime);

                            HttpRequestMessage request3 = new HttpRequestMessage(HttpMethod.Post,
                                $"https://api-global.novelpia.com/v1/ad/reward/grant") {
                                Content = new StringContent($"{{\"novel_no\":{novelNo},\"episode_no\":{episodeNo},\"flag_success\":1,\"token\":\"{adToken}\"}}", Encoding.UTF8, "application/json")
                            };
                            request3.Headers.Add("Sec-Fetch-Site", "Same-Origin");
                            request3.Headers.Add("Cookie", session.cookie);
                            request3.Headers.Add("Login-At", session.JWT);
                            using (HttpResponseMessage res3 = await client.SendAsync(request3)) {
                                if (res3.IsSuccessStatusCode) {
                                    HttpRequestMessage request4 = new HttpRequestMessage(HttpMethod.Get,
                                                    $"https://api-global.novelpia.com/v1/ad/log/novel_guest?novel_no={novelNo}&episode_no={episodeNo}");
                                    request4.Headers.Add("Sec-Fetch-Site", "Same-Origin");
                                    request4.Headers.Add("Cookie", session.cookie);
                                    request4.Headers.Add("Login-At", session.JWT);
                                    using (HttpResponseMessage res4 = await client.SendAsync(request4)) {
                                        if (res4.IsSuccessStatusCode) {
                                            return;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        throw new Exception("Unable to watch ad!");
    }

    public async Task DownloadChapter(SessionInfo session, string novelNo, string episodeNo, string path, string filename) {
        await UpdateSession(session);

        try {
            State state = new State(path);
            state.epub.AppendLine("<?xml version=\"1.0\" encoding=\"utf-8\"?><!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.1//EN\" \"http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd\"><html xmlns=\"http://www.w3.org/1999/xhtml\"><head><title></title><link href=\"../Styles/stylesheet.css\" type=\"text/css\" rel=\"stylesheet\" /></head><body>");

            for (int i = 0; i < 2; ++i) {
                HttpRequestMessage episodeRequest = new HttpRequestMessage(HttpMethod.Get,
                    $"https://api-global.novelpia.com/v1/novel/episode?episode_no={episodeNo}");
                episodeRequest.Headers.Add("Sec-Fetch-Site", "Same-Origin");
                episodeRequest.Headers.Add("Cookie", session.cookie);
                episodeRequest.Headers.Add("Login-At", session.JWT);

                using (HttpResponseMessage episodeRes = await client.SendAsync(episodeRequest)) {
                    if (episodeRes.IsSuccessStatusCode) {
                        using (HttpContent episodeContent = episodeRes.Content) {
                            JObject episodeData = JObject.Parse(await episodeContent.ReadAsStringAsync());
                            JObject episodeDataResult = episodeData.Value<JObject>("result")!;
                            string token = episodeDataResult.Value<string>("_t")!;

                            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get,
                                $"https://api-global.novelpia.com/v1/novel/episode/content?_t={token}");
                            request.Headers.Add("Sec-Fetch-Site", "Same-Origin");
                            request.Headers.Add("Cookie", session.cookie);
                            request.Headers.Add("Login-At", session.JWT);

                            using (HttpResponseMessage res = await client.SendAsync(request)) {
                                if (res.IsSuccessStatusCode) {
                                    using (HttpContent content = res.Content) {
                                        JObject chapter = JObject.Parse(await content.ReadAsStringAsync());
                                        JObject chapterContent = chapter.Value<JObject>("result")!.Value<JObject>("data")!;
                                        StringBuilder html = new StringBuilder("<html><head></head><body><div class='content'>");
                                        foreach (var kv in chapterContent) {
                                            html.Append(WebUtility.HtmlDecode(kv.Value!.Value<string>()));
                                        }
                                        html.Append("</div><body></html>");

                                        state.epub.AppendLine($"<h1>{episodeDataResult.Value<JObject>("data")!.Value<string>("epi_title")}</h1>");
                                        state.epub.AppendLine($"<p><a href=\"https://global.novelpia.com/viewer/{episodeNo}\">Original</a></p>");
                                        state.epub.AppendLine($"<div class=\"content\">");

                                        IElement body = parser.ParseDocument(html.ToString()).QuerySelector(".content")!;
                                        await Process(body, state);

                                        state.epub.AppendLine($"</div>");
                                    }
                                }
                            }
                        }
                    } else {
                        using (HttpContent episodeContent = episodeRes.Content) {
                            JObject episodeData = JObject.Parse(await episodeContent.ReadAsStringAsync());
                            JObject episodeDataResult = episodeData.Value<JObject>("result")!;
                            string error = episodeDataResult.Value<string>("message")!;
                            if (error == "novel.ADVERTISEMENT_EPISODE") {
                                await WatchAd(session, novelNo, episodeNo);
                            } else {
                                Console.WriteLine(error);
                                break;
                            }
                        }
                    }
                }
            }

            state.epub.AppendLine("</body></html>");

            string filepath = Path.Join(path, "Text", filename);

            string? directory = Path.GetDirectoryName(filepath);
            if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory)) {
                Directory.CreateDirectory(directory);
            }

            File.WriteAllText(filepath, state.epub.ToString());

        } catch (Exception exception) {
            Console.WriteLine($"Error trying to obtain novel '{novelNo}', chapter '{episodeNo}'");
            Console.WriteLine(exception);
        }
    }
}
