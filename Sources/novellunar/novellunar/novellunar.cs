using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using AngleSharp.Html.Parser;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using WebSocketSharp;

public partial class novellunar : IDisposable {
    private const string domain = "novellunar.com";
    private const string baseUrl = $"https://{domain}";

    private HttpClient client;
    private HtmlParser parser = new HtmlParser();

    public void Dispose() {
        client.Dispose();
    }

    public novellunar(string? cookieHeader = null, string? userAgent = null) {
        // Handle Gzip compression and redirects
        HttpClientHandler handler = new HttpClientHandler();
        handler.AllowAutoRedirect = true;
        handler.AutomaticDecompression = System.Net.DecompressionMethods.GZip | System.Net.DecompressionMethods.Deflate;
        handler.CookieContainer = CreateCookies(cookieHeader);

        // Disable SSL check (with it on, we throw exception on fetching website)
        /*handler.ServerCertificateCustomValidationCallback =
                (HttpRequestMessage message, X509Certificate2? cert, X509Chain? chain, SslPolicyErrors errors) => true;*/

        client = new HttpClient(handler);
        client.BaseAddress = new Uri(baseUrl);
        client.DefaultRequestHeaders.Referrer = new Uri(baseUrl);

        // Use the User-Agent from the same browser request as the cookies.
        try {
            client.DefaultRequestHeaders.UserAgent.ParseAdd(string.IsNullOrWhiteSpace(userAgent)
                ? "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/120.0.0.0 Safari/537.36"
                : userAgent);
        } catch (FormatException) {
            client.Dispose();
            throw new ArgumentException("NOVELLUNAR_USER_AGENT must contain only the browser's User-Agent header value.");
        }
    }

    private static CookieContainer CreateCookies(string? cookieHeader) {
        CookieContainer cookies = new CookieContainer { PerDomainCapacity = 300 };
        if (string.IsNullOrWhiteSpace(cookieHeader)) return cookies;

        const string invalidCookie = "NOVELLUNAR_COOKIE must be one Cookie request header value, for example: cf_clearance=VALUE; session=VALUE.";
        if (cookieHeader.Contains('\r') || cookieHeader.Contains('\n')) {
            throw new ArgumentException(invalidCookie);
        }

        cookieHeader = cookieHeader.Trim();
        if (cookieHeader.StartsWith("Cookie:", StringComparison.OrdinalIgnoreCase)) {
            cookieHeader = cookieHeader["Cookie:".Length..].Trim();
        }

        try {
            foreach (string pair in cookieHeader.Split(';', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)) {
                int separator = pair.IndexOf('=');
                if (separator <= 0) throw new ArgumentException(invalidCookie);
                string name = pair[..separator].Trim();
                if (!Regex.IsMatch(name, @"\A[!#$%&'*+.^_`|~0-9A-Za-z-]+\z")) {
                    throw new ArgumentException(invalidCookie);
                }

                // An implicit domain binds imported cookies to this host only.
                // CookieContainer also prevents sending them to external image hosts or redirects.
                cookies.Add(new Uri(baseUrl), new Cookie(name, pair[(separator + 1)..].Trim(), "/") {
                    Secure = true
                });
            }
        } catch (CookieException) {
            // CookieException can include the secret value; do not log or retain it.
            throw new ArgumentException(invalidCookie);
        }

        if (cookies.Count == 0) throw new ArgumentException(invalidCookie);
        return cookies;
    }

    private static void EnsureContentResponse(HttpResponseMessage response) {
        if (response.Headers.TryGetValues("cf-mitigated", out IEnumerable<string>? values)
            && values.Any(value => value.Equals("challenge", StringComparison.OrdinalIgnoreCase))) {
            throw new HttpRequestException("Cloudflare returned a challenge. Open the page in your browser, complete the challenge, and refresh NOVELLUNAR_COOKIE and NOVELLUNAR_USER_AGENT. Browser cookies may still be rejected by HttpClient.");
        }
        if (response.StatusCode == HttpStatusCode.Forbidden) {
            throw new HttpRequestException("The site returned HTTP 403. Check access in your browser and refresh the session values; cookie reuse may not be sufficient.");
        }
        if (response.StatusCode == HttpStatusCode.TooManyRequests) {
            throw new HttpRequestException("The site returned HTTP 429 (rate limited). Stop and wait before trying again.");
        }
        response.EnsureSuccessStatusCode();
    }

    private class State {
        public string path;
        public StringBuilder epub = new StringBuilder();
        public static int image = 0;

        public State(string path) {
            this.path = path;
        }
    }

    private string CleanUnicode(string input) {
        // AngleSharp has already decoded entities in DOM text and attributes.
        return input.Replace("\u200B", "")  // Zero width space
                                            .Replace("\u200C", "")  // Zero width non-joiner
                                            .Replace("\u200D", "")  // Zero width joiner
                                            .Replace("\u2060", "")  // Word joiner
                                            .Replace("\uFEFF", ""); // Zero width no-break space (BOM);
    }

    private static readonly HashSet<string> contentIdentifiers = new HashSet<string> {
        "div", "p", "span", "i", "b", "u", "em", "strong", "s", "del", "sub", "sup",
        "code", "pre", "blockquote", "h1", "h2", "h3", "h4", "h5", "h6",
        "ul", "ol", "li", "dl", "dt", "dd", "table", "caption", "thead", "tbody", "tfoot", "tr", "th", "td"
    };
    private static readonly HashSet<string> blockContainers = new HashSet<string> {
        "article", "section", "main", "header", "footer", "nav", "aside", "figure", "figcaption"
    };
    private static readonly HashSet<string> ignoreIdentifiers = new HashSet<string> {
        "script", "style", "noscript", "template"
    };

    private static string WhitespaceStyle(IElement element) {
        // Keep the standard CSS whitespace rule, including overrides on nested elements.
        // Other styling is left to the EPUB stylesheet.
        MatchCollection declarations = Regex.Matches(element.GetAttribute("style") ?? "",
            @"(?:^|;)\s*white-space\s*:\s*(normal|nowrap|pre-wrap|pre-line|pre|break-spaces)\s*(!\s*important\s*)?(?=;|$)",
            RegexOptions.IgnoreCase);
        Match? selected = null;
        foreach (Match declaration in declarations) {
            if (selected == null || !selected.Groups[2].Success || declaration.Groups[2].Success) {
                selected = declaration;
            }
        }
        return selected == null ? "" : $" style=\"white-space: {selected.Groups[1].Value.ToLowerInvariant()}\"";
    }

    private async Task Process(INode node, State state) {
        if (node.NodeType == NodeType.Element) {

            IElement el = (IElement)node;
            string identifier = el.LocalName;

            if (ignoreIdentifiers.Contains(identifier)) return;

            // Specific to Yukikitsuneko
            if (el.GetAttribute("class")?.Contains("anti-scrape") == true) {
                return;
            }
            if (el.GetAttribute("href")?.Contains("https://www.patreon.com/YukiKitsunekoFanTL") == true) {
                return;
            }

            if (identifier == "img") {
                string? imgurl = el.GetAttribute("src");

                if (imgurl != null) {
                    string ext = GetExtensionFromURL(imgurl);
                    int id = State.image++;
                    ext = await DownloadImage(imgurl, Path.Join(state.path, "Images", $"{id}{ext}"), ext);
                    state.epub.Append($"<img src=\"../Images/{id}{ext}\" alt=\"{HttpUtility.HtmlEncode(CleanUnicode(el.GetAttribute("alt") ?? imgurl))}\" />");
                }

                return;
            }

            if (identifier == "br" || identifier == "hr") {
                state.epub.Append($"<{identifier} />");
                return;
            }

            // Retain HTML block/inline boundaries instead of inventing a paragraph per text node.
            // Map HTML5 sectioning containers to their XHTML-compatible block equivalent.
            if (blockContainers.Contains(identifier)) identifier = "div";
            string whitespaceStyle = WhitespaceStyle(el);
            if (!contentIdentifiers.Contains(identifier)) {
                identifier = whitespaceStyle.Length > 0 ? "span" : "";
            }
            if (identifier.Length > 0) state.epub.Append($"<{identifier}{whitespaceStyle}>");

            foreach (INode child in node.ChildNodes) {
                await Process(child, state);
            }

            if (identifier.Length > 0) state.epub.Append($"</{identifier}>");

        } else if (node.NodeType == NodeType.Text) {
            // Preserve source whitespace. The inherited CSS rule determines how it renders.
            // Trimming each node loses word spacing and discards preformatted line breaks.
            state.epub.Append(HttpUtility.HtmlEncode(CleanUnicode(node.TextContent)));
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
            using HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get,
            url);
            request.Headers.Add("Referer", $"{baseUrl}");
            request.Headers.Add("httpVersion", "h3");

            using (HttpResponseMessage res = await client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead)) {
                EnsureContentResponse(res);
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
        } catch (Exception) {
            Console.Error.WriteLine($"Error trying to download image: {url}");
            throw;
        }

        return ext;
    }

    public async Task DownloadChapter(string url, string path, string filename) {
        try {
            State state = new State(path);
            state.epub.AppendLine("<?xml version=\"1.0\" encoding=\"utf-8\"?><!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.1//EN\" \"http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd\"><html xmlns=\"http://www.w3.org/1999/xhtml\"><head><title></title><link href=\"../Styles/stylesheet.css\" type=\"text/css\" rel=\"stylesheet\" /></head><body>");

            using HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get,
                url);

            using (HttpResponseMessage res = await client.SendAsync(request)) {
                EnsureContentResponse(res);
                if (res.IsSuccessStatusCode) {
                    using (HttpContent content = res.Content) {
                        IHtmlDocument document = parser.ParseDocument(await content.ReadAsStringAsync());

                        IElement? title = document.QuerySelector(".entry-title");
                        if (title != null) {
                            state.epub.AppendLine($"<h1>{HttpUtility.HtmlEncode(CleanUnicode(title.TextContent).Trim())}</h1>");
                            title.RemoveFromParent();
                        }

                        state.epub.AppendLine($"<p><a href=\"{HttpUtility.HtmlEncode(url)}\">Original</a></p>");

                        IElement body = document.QuerySelector("article")
                            ?? throw new InvalidOperationException("No chapter article was found. The page may require login, show a challenge, or have changed its layout. No chapter file was written.");
                        await Process(body, state);
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
        } catch (Exception) {
            Console.Error.WriteLine($"Error trying to obtain chapter: {url}");
            throw;
        }
    }
}
