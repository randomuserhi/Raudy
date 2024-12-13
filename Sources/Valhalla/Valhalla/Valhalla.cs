using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using AngleSharp.Html.Parser;
using System.Text;
using System.Web;

public partial class Valhalla {
    private const string domain = "valhallatls.blogspot.com";
    private const string baseUrl = $"https://{domain}";

    private HttpClient client;
    private HtmlParser parser = new HtmlParser();

    public void Dispose() {
        client.Dispose();
    }

    public Valhalla() {
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

        public State(string path) {
            this.path = path;
        }
    }

    private static string[] validIdentifiers = new string[] { "p", "i", "b", "u", "em" };
    private static string[] ignoreIdentifiers = new string[] { "script" };
    private async Task Process(INode node, State state, bool inParagraph = false) {
        if (node.NodeType == NodeType.Element) {

            IElement el = (IElement)node;
            string identifier = $"{el.TagName.Trim().ToLower()}";

            if (ignoreIdentifiers.Contains(identifier)) return;
            if (el.TextContent.Trim() == string.Empty) return;

            bool isValid = validIdentifiers.Contains(identifier);
            if (identifier == "div") {
                // NOTE(randomuserhi): Special case where div should be a paragraph
                if (el.QuerySelectorAll("*:not(p):not(i):not(b):not(u):not(em)").Length == 0) {
                    isValid = true;
                    identifier = "p";
                }
            }

            bool isInParagraph = inParagraph || (identifier == "p");

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

    // NOTE(randomuserhi): returns the link to the previous post
    //                     this is done because the site doesn't have an index of URLs...
    public async Task<string> DownloadBlog(string url, string path, string filename) {
        string prevURL = string.Empty;

        try {
            State state = new State(path);
            state.epub.AppendLine("<?xml version=\"1.0\" encoding=\"utf-8\"?><!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.1//EN\" \"http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd\"><html xmlns=\"http://www.w3.org/1999/xhtml\"><head><title></title><link href=\"../Styles/stylesheet.css\" type=\"text/css\" rel=\"stylesheet\" /></head><body>");

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get,
                url);

            using (HttpResponseMessage res = await client.SendAsync(request)) {
                if (res.IsSuccessStatusCode) {
                    using (HttpContent content = res.Content) {
                        IHtmlDocument document = parser.ParseDocument(await content.ReadAsStringAsync());
                        IElement body = document.QuerySelector(".post-body.entry-content.float-container")!;
                        state.epub.AppendLine($"<p><a href=\"{url}\">Original</a></p>");

                        await Process(body, state);

                        //IElement? next = body.QuerySelectorAll("a[href]").FirstOrDefault(a => a.TextContent.Trim().Equals("next", StringComparison.OrdinalIgnoreCase));
                        IElement? prev = body.QuerySelectorAll("a[href]").FirstOrDefault(a => a.TextContent.Trim().Equals("prev", StringComparison.OrdinalIgnoreCase));

                        if (prev != null) {
                            prevURL = prev.GetAttribute("href")!;
                        }
                    }
                }
            }

            state.epub.AppendLine("</body></html>");
            File.WriteAllText(Path.Join(path, "Text", filename), state.epub.ToString());
        } catch (Exception exception) {
            Console.WriteLine($"Error trying to obtain blog: {url}");
            Console.WriteLine(exception);
        }

        return prevURL;
    }
}
