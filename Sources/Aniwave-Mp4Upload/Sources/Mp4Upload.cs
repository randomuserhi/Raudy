using System.Net.Http.Headers;
using System.Text;

// For console use -> remove later
internal class ConsoleUtility {
    const char _block = '■';
    const string _back = "\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b";
    const string _twirl = "-\\|/";

    public static void WriteProgressBar(int percent, bool update = false) {
        if (update)
            Console.Write(_back);
        Console.Write("[");
        var p = (int)((percent / 10f) + .5f);
        for (var i = 0; i < 10; ++i) {
            if (i >= p)
                Console.Write(' ');
            else
                Console.Write(_block);
        }
        Console.Write("] {0,3:##0}%", percent);
    }

    public static void WriteProgress(int progress, bool update = false) {
        if (update)
            Console.Write("\b");
        Console.Write(_twirl[progress % _twirl.Length]);
    }
}

public partial class Aniwave {
    public class Mp4Upload : ISource, IDisposable {
        private HttpClient client = new HttpClient();

        public void Dispose() {
            client.Dispose();
        }

        public Mp4Upload() {
            client.DefaultRequestHeaders.Referrer = new Uri("https://www.mp4upload.com");
            client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/113.0.0.0 Safari/537.36");
            client.DefaultRequestHeaders.Add("X-Requested-With", "XMLHttpRequest");
            client.DefaultRequestHeaders.Add("sec-ch-ua", "\"Google Chrome\";v=\"113\", \"Chromium\";v=\"113\", \"Not-A.Brand\";v=\"24\"");
            client.DefaultRequestHeaders.Add("sec-ch-ua-mobile", "?0");
            client.DefaultRequestHeaders.Add("sec-ch-ua-platform", "\"Windows\"");
        }

        // TODO(randomuserhi): Cleanup or write proper API / design => This is test code to check if I can spoof Host and Origin to get file from mp4upload
        public async Task DownloadVideo(string url, string path) {
            try {
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get,
                    url);
                request.Headers.Add("Host", "www4.mp4upload.com:183");
                request.Headers.Add("Origin", "www.mp4upload.com");
                request.Headers.Add("Accept", "*/*");
                request.Headers.Add("Accept-Encoding", "identity;q=1, *;q=0");
                request.Headers.Add("Accept-Language", "en-GB,en-US;q=0.9,en;q=0.8");
                request.Headers.Add("Range", "bytes=0-");

                // NOTE(randomuserhi): HttpCompletionOption.ResponseHeadersRead is needed to ensure only the response header is read
                //                     Since otherwise it downloads the entire mp4 content from mp4upload causin sendasync to hang forever
                //                     until the mp4 completes downloading then writes to file.
                //
                //                     Once the response header is read, we read the mp4 bytes as it is being downloaded and write them to a file
                //                     https://www.stevejgordon.co.uk/using-httpcompletionoption-responseheadersread-to-improve-httpclient-performance-dotnet
                //                     
                //                     We can create a progress bar using the response header Content-Length property
                using (HttpResponseMessage res = await client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead)) {
                    if (res.IsSuccessStatusCode) {
                        using (HttpContent content = res.Content) {
                            HttpHeaders headers = content.Headers;
                            float contentLength;
                            if (headers.TryGetValues("Content-Length", out IEnumerable<string>? values)) {
                                contentLength = int.Parse(values.First());
                            } else throw new Exception("No 'Content-Length' header");

                            Stream data = await content.ReadAsStreamAsync();
                            // NOTE(randomuserhi): Allow reading for other applications to read a partially downloaded video
                            FileStream writer = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.Read);
                            byte[] buffer = new byte[16 * 1024];
                            float total = 0;
                            int read;
                            while ((read = data.Read(buffer, 0, buffer.Length)) > 0) {
                                writer.Write(buffer, 0, read);
                                total += read;
                                ConsoleUtility.WriteProgressBar((int)(total / contentLength * 100), true);
                            }
                            writer.Dispose();
                        }
                    }
                }

                ConsoleUtility.WriteProgressBar(100, true);
                return;
            } catch (Exception exception) {
                Console.WriteLine("Error trying to download episode:");
                Console.WriteLine(exception);
                return;
            }
        }

        public async Task<Video?> GetMp4Link(VideoEmbed embed) {
            try {
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get,
                    embed.url);
                request.Headers.Add("Host", "www.mp4upload.com");
                request.Headers.Add("Origin", "www.mp4upload.com");

                using (HttpResponseMessage res = await client.SendAsync(request)) {
                    if (res.IsSuccessStatusCode) {
                        using (HttpContent content = res.Content) {
                            string data = await content.ReadAsStringAsync();
                            int index = data.IndexOf("src: \"") + 6;
                            if (index >= 0) {
                                StringBuilder link = new StringBuilder();
                                for (char c; (c = data[index]) != '\"'; ++index) {
                                    link.Append(c);
                                }
                                Video video;
                                video.url = link.ToString();
                                video.type = Video.Type.File;
                                return video;
                            } else return null;
                        }
                    }
                }

                return null;
            } catch (Exception exception) {
                Console.WriteLine("Error trying to obtain episode list:");
                Console.WriteLine(exception);
                return null;
            }
        }
    }
}
