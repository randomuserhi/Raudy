using AngleSharp.Html.Parser;
using System.Collections;
using System.Net;
using System.Net.Http.Headers;
using System.Reflection;

public partial class Aniwave {
    private const string domain = "9animetv.to";
    private const string baseUrl = $"https://{domain}";

    private HttpClient client;
    private CookieContainer cookieContainer;
    private HtmlParser parser = new HtmlParser();

    public void Dispose() {
        client.Dispose();
    }

    public Aniwave() {
        // Handle cookies
        cookieContainer = new CookieContainer();

        // Handle Gzip compression and redirects
        HttpClientHandler handler = new HttpClientHandler();
        handler.AllowAutoRedirect = true;
        handler.AutomaticDecompression = System.Net.DecompressionMethods.GZip | System.Net.DecompressionMethods.Deflate;
        handler.CookieContainer = cookieContainer;
        handler.UseCookies = true;

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

    // For debugging
    private static List<Cookie> DumpAllCookies(CookieContainer cookieJar) {
        var cookies = new List<Cookie>();

        var table = (Hashtable)cookieJar.GetType()
            .InvokeMember("m_domainTable",
                BindingFlags.NonPublic | BindingFlags.GetField | BindingFlags.Instance,
                null, cookieJar, new object[] { })!;

        foreach (var key in table.Keys) {
            string? domain = key as string;
            if (domain == null)
                continue;

            SortedList? pathList = table[key]!
                .GetType()
                .InvokeMember("m_list",
                    BindingFlags.NonPublic | BindingFlags.GetField | BindingFlags.Instance,
                    null, table[key], new object[] { }) as SortedList;

            if (pathList == null)
                continue;

            foreach (var pathKey in pathList.Keys) {
                var cookieCollection = pathList[pathKey] as CookieCollection;
                if (cookieCollection != null) {
                    foreach (Cookie cookie in cookieCollection) {
                        cookies.Add(cookie);
                    }
                }
            }
        }

        return cookies;
    }

    private Cookie? ParseCookie(string header, Uri uri) {
        var parts = header.Split(';');
        if (parts.Length == 0) return null;

        var nameValue = parts[0].Split('=', 2);
        if (nameValue.Length != 2) return null;

        var cookie = new Cookie(nameValue[0].Trim(), nameValue[1].Trim());

        // Optional attributes
        foreach (var p in parts.Skip(1)) {
            var segment = p.Trim();
            if (segment.StartsWith("Path=", StringComparison.OrdinalIgnoreCase))
                cookie.Path = segment.Substring(5);
            else if (segment.StartsWith("Domain=", StringComparison.OrdinalIgnoreCase))
                cookie.Domain = segment.Substring(7);
            else if (segment.StartsWith("Expires=", StringComparison.OrdinalIgnoreCase)
                  && DateTime.TryParse(segment.Substring(8), out var expires))
                cookie.Expires = expires;
            else if (segment.Equals("Secure", StringComparison.OrdinalIgnoreCase))
                cookie.Secure = true;
            else if (segment.Equals("HttpOnly", StringComparison.OrdinalIgnoreCase))
                cookie.HttpOnly = true;
        }

        // Default domain if missing
        if (string.IsNullOrEmpty(cookie.Domain))
            cookie.Domain = uri.Host;

        return cookie;
    }

    private void UpdateCookies(HttpRequestMessage req, HttpResponseHeaders headers) {
        if (headers.TryGetValues("Set-Cookie", out IEnumerable<string>? values)) {
            foreach (string header in values) {
                var cookie = ParseCookie(header, req.RequestUri!);
                if (cookie != null) {
                    cookieContainer.Add(req.RequestUri!, cookie);
                }
            }
        }
    }

    public async Task Test() {
        HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, "https://windytrail24.online/_v7/872bb86f622dc4bd725fb40c1d6668875d01f37f26ee600b6c876115b44e71a690770e6d8f957a6c6f7752ec1a3268e1c7bf056faac5f905dc5465e449f7bd96afc76c49c39ea185aae63a1ce3bba942c46e90effd75781fbb7bab56f519483e6319896487adf3e9bfc33adfbe652d8d8fed488882c2c45abde98c6ff75661a8/seg-195-f2-v1-a1.css");
        request.Headers.Add("accept", "*/*");
        request.Headers.Add("accept-language", "en-GB,en-US;q=0.9,en;q=0.8");
        request.Headers.Add("priority", "u=1, i");
        request.Headers.Add("accept-language", "en-GB,en-US;q=0.9,en;q=0.8");
        request.Headers.Add("priority", "u=1, i");
        request.Headers.Add("sec-ch-ua", "\"Google Chrome\";v=\"143\", \"Chromium\";v=\"143\", \"Not A(Brand\";v=\"24\"");
        request.Headers.Add("sec-ch-ua-mobile", "?0");
        request.Headers.Add("sec-ch-ua-platform", "\"Windows\"");
        request.Headers.Add("sec-fetch-dest", "empty");
        request.Headers.Add("sec-fetch-mode", "cors");
        request.Headers.Add("sec-fetch-site", "cross-site");
        request.Headers.Add("Referer", "https://rapid-cloud.co/");


        DebugRequestHeaders(request);

        using (HttpResponseMessage result = await client.SendAsync(request)) {
            if (result.IsSuccessStatusCode) {
                await using Stream responseStream = await result.Content.ReadAsStreamAsync();

                await using FileStream fileStream = new FileStream(
                    "D:/output.bin",
                    FileMode.Create,
                    FileAccess.Write,
                    FileShare.None,
                    bufferSize: 81920,
                    useAsync: true
                );

                await responseStream.CopyToAsync(fileStream);

                return;
            }
        }

        throw new Exception("Failed");
    }
}
