using System.Text;
using Newtonsoft.Json;

public partial class Aniwave
{
    public class Mp4Upload : ISource, IDisposable
    {
        private HttpClient client = new HttpClient();

        public void Dispose()
        {
            client.Dispose();
        }

        public Mp4Upload()
        {
            client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/113.0.0.0 Safari/537.36");
            client.DefaultRequestHeaders.Add("X-Requested-With", "XMLHttpRequest");
            client.DefaultRequestHeaders.Add("sec-ch-ua", "\"Google Chrome\";v=\"113\", \"Chromium\";v=\"113\", \"Not-A.Brand\";v=\"24\"");
            client.DefaultRequestHeaders.Add("sec-ch-ua-mobile", "?0");
            client.DefaultRequestHeaders.Add("sec-ch-ua-platform", "\"Windows\"");
        }

        public async Task<Video?> GetMp4Link(VideoEmbed embed)
        {
            try
            {
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get,
                    embed.url);

                using (HttpResponseMessage res = await client.SendAsync(request))
                {
                    if (res.IsSuccessStatusCode)
                    {
                        using (HttpContent content = res.Content)
                        {
                            string data = await content.ReadAsStringAsync();
                            int index = data.IndexOf("src: \"") + 6;
                            if (index >= 0)
                            {
                                StringBuilder link = new StringBuilder();
                                for (char c; (c = data[index]) != '\"'; ++index)
                                {
                                    link.Append(c);
                                }
                                Video video;
                                video.url = link.ToString();
                                video.type = Video.Type.File;
                                return video;
                            }
                            else return null;
                        }
                    }
                }

                return null;
            }
            catch (Exception exception)
            {
                Console.WriteLine("Error trying to obtain episode list:");
                Console.WriteLine(exception);
                return null;
            }
        }
    }
}
