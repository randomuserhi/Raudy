using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using AngleSharp.Html.Parser;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

public partial class Wattpad {
    private const string domain = "www.wattpad.com";
    private const string baseUrl = $"https://{domain}";

    private HttpClient client;
    private HtmlParser parser = new HtmlParser();

    public void Dispose() {
        client.Dispose();
    }

    public Wattpad() {
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

    private async Task Process(IElement parent, State state) {
        foreach (IElement el in parent.Children) {
            string identifier = $"{el.TagName.Trim()}";
            switch (identifier) {
            case "P": {
                if (el.ChildElementCount == 0) {
                    state.epub.AppendLine($"<p>{HttpUtility.HtmlEncode(el.TextContent).Trim()}</p>");
                } else {
                    goto cont;
                }
                break;
            }
            case "I": {
                if (el.ChildElementCount == 0) {
                    state.epub.AppendLine($"<p><i>{HttpUtility.HtmlEncode(el.TextContent).Trim()}</i></p>");
                } else {
                    goto cont;
                }
                break;
            }
            case "B": {
                if (el.ChildElementCount == 0) {
                    state.epub.AppendLine($"<p><b>{HttpUtility.HtmlEncode(el.TextContent).Trim()}</b></p>");
                } else {
                    goto cont;
                }
                break;
            }
            default:
            cont:
                await Process(el, state);
                break;
            }
        }
    }

    private Regex r = new Regex(@"\d+");
    public string GetStoryIdFromURL(string url) {
        Match match = r.Match(url);
        if (match.Success) return match.Value;
        else throw new Exception("Invalid url.");
    }

    public async Task DownloadBlog(string url, string path, string filename) {
        try {
            string storyId = GetStoryIdFromURL(url);
            State state = new State(path);
            state.epub.AppendLine("<?xml version=\"1.0\" encoding=\"utf-8\"?><!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.1//EN\" \"http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd\"><html xmlns=\"http://www.w3.org/1999/xhtml\"><head><title></title><link href=\"../Styles/stylesheet.css\" type=\"text/css\" rel=\"stylesheet\" /></head><body>");

            HttpRequestMessage titleRequest = new HttpRequestMessage(HttpMethod.Get,
                url);

            using (HttpResponseMessage res = await client.SendAsync(titleRequest)) {
                if (res.IsSuccessStatusCode) {
                    using (HttpContent content = res.Content) {
                        IHtmlDocument document = parser.ParseDocument(await content.ReadAsStringAsync());
                        IElement title = document.QuerySelector(".h2")!;
                        state.epub.AppendLine($"<h1>{title.InnerHtml.Trim()}</h1>");
                        state.epub.AppendLine($"<p><a href=\"{url}\">Original</a></p>");
                    }
                }
            }

            HttpRequestMessage contentRequest = new HttpRequestMessage(HttpMethod.Get,
                $"{baseUrl}/apiv2/?m=storytext&id={storyId}");

            using (HttpResponseMessage res = await client.SendAsync(contentRequest)) {
                if (res.IsSuccessStatusCode) {
                    using (HttpContent content = res.Content) {
                        IHtmlDocument document = parser.ParseDocument($"<html><body>{await content.ReadAsStringAsync()}</body></html>");
                        await Process(document.Body!, state);
                    }
                }
            }

            state.epub.AppendLine("</body></html>");
            File.WriteAllText(Path.Join(path, "Text", filename), state.epub.ToString());
        } catch (Exception exception) {
            Console.WriteLine($"Error trying to obtain blog: {url}");
            Console.WriteLine(exception);
        }
    }
}
