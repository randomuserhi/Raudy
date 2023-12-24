using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using AngleSharp.Html.Parser;
using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

public partial class Skythewood {
    private const string domain = "skythewood.blogspot.com";
    private const string baseUrl = $"https://{domain}";

    private HttpClient client;
    private HtmlParser parser = new HtmlParser();

    public void Dispose() {
        client.Dispose();
    }

    public Skythewood() {
        client = new HttpClient();
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

    private Regex r = new Regex(@"(\.[a-zA-Z0-9]+(\?|\#|$))");
    private string GetExtensionFromURL(string url) {
        Match token = r.Match(url);
        if (!token.Success) return "";
        return token.Value;
    }

    private class State {
        public string path;
        public StringBuilder epub = new StringBuilder();
        public static int image = 0;

        public State(string path) {
            this.path = path;
        }
    }

    private async Task Process(IElement parent, State state) {
        foreach (IElement el in parent.Children) {
            string identifier = $"{el.TagName.Trim()}";
            switch (identifier) {
            case "P": {
                string content = HttpUtility.HtmlEncode(el.TextContent).Trim().Replace("Previous Chapter | Main Page | Next Chapter", "").Replace("Previous Chapter&#160;|&#160;Main Page&#160;| Next Chapter", "");
                if (content != "") {
                    state.epub.AppendLine($"<p>{content}</p>");
                } else {
                    goto cont;
                }
                break;
            }
            case "I": {
                if (el.ChildElementCount == 0) {
                    state.epub.AppendLine($"<p><i>{HttpUtility.HtmlEncode(el.InnerHtml)}</i></p>");
                } else {
                    goto cont;
                }
                break;
            }
            case "A": {
                if (!el.HasAttribute("href")) goto cont;
                if (el.QuerySelector("img") == null) goto cont;
                string imgurl = el.GetAttribute("href")!;
                string ext = GetExtensionFromURL(imgurl);
                int id = State.image++;
                ext = await DownloadImage(imgurl, Path.Join(state.path, "Images", $"{id}{ext}"), ext);
                state.epub.AppendLine($"<div><img src=\"../Images/{id}{ext}\" alt=\"\" /></div>");
                break;
            }
            default:
            cont:
                await Process(el, state);
                break;
            }
        }
    }

    public async Task DownloadBlog(string url, string path, string filename) {
        try {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get,
                url);

            State state = new State(path);
            state.epub.AppendLine("<?xml version=\"1.0\" encoding=\"utf-8\"?><!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.1//EN\" \"http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd\"><html xmlns=\"http://www.w3.org/1999/xhtml\"><head><title></title><link href=\"../Styles/stylesheet.css\" type=\"text/css\" rel=\"stylesheet\" /></head><body>");

            using (HttpResponseMessage res = await client.SendAsync(request)) {
                if (res.IsSuccessStatusCode) {
                    using (HttpContent content = res.Content) {
                        IHtmlDocument document = parser.ParseDocument(await content.ReadAsStringAsync());
                        IElement blog = document.QuerySelector(".post.hentry.uncustomized-post-template")!;

                        IElement title = blog.QuerySelector(".post-title.entry-title")!;
                        state.epub.AppendLine($"<h1>{title.InnerHtml.Trim()}</h1>");
                        state.epub.AppendLine($"<p><a href=\"{url}\">Original</a></p>");

                        IElement body = blog.QuerySelector(".post-body.entry-content")!;
                        await Process(body, state);
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
}
