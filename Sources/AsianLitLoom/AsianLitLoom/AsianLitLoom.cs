using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using AngleSharp.Html.Parser;
using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using WebSocketSharp;

public partial class AsianLitLoom {
    private const string domain = "www.asianlitloom.com";
    private const string baseUrl = $"https://{domain}";

    private HttpClient client;
    private HtmlParser parser = new HtmlParser();

    public void Dispose() {
        client.Dispose();
    }

    public AsianLitLoom() {
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
            string text = HttpUtility.HtmlEncode(node.TextContent).Trim();
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

    public async Task DownloadChapter(string url, string path, string filename) {
        try {
            State state = new State(path);
            state.epub.AppendLine("<?xml version=\"1.0\" encoding=\"utf-8\"?><!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.1//EN\" \"http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd\"><html xmlns=\"http://www.w3.org/1999/xhtml\"><head><title></title><link href=\"../Styles/stylesheet.css\" type=\"text/css\" rel=\"stylesheet\" /></head><body>");

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get,
                url);
            request.Headers.Add("Sec-Fetch-Site", "Same-Origin");

            using (HttpResponseMessage res = await client.SendAsync(request)) {
                if (res.IsSuccessStatusCode) {
                    using (HttpContent content = res.Content) {
                        IHtmlDocument document = parser.ParseDocument(await content.ReadAsStringAsync());

                        IElement title = document.QuerySelector(".post-body.post.chapter")!.QuerySelector("b")!;
                        state.epub.AppendLine($"<h1>{title.InnerHtml.Trim()}</h1>");
                        state.epub.AppendLine($"<p><a href=\"{url}\">Original</a></p>");
                        state.epub.AppendLine($"<div class=\"content\">");

                        IElement body = document.QuerySelector(".post-body.post.chapter")!;
                        await Process(body, state);

                        state.epub.AppendLine($"</div>");
                    }
                }
            }

            state.epub.AppendLine("</body></html>");
            File.WriteAllText(Path.Join(path, "Text", filename), state.epub.ToString());
        } catch (Exception exception) {
            Console.WriteLine($"Error trying to obtain chapter: {url}");
            Console.WriteLine(exception);
        }
    }
}
