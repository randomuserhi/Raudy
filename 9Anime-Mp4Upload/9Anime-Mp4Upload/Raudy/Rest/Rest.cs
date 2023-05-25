using System.Net.Http;
using System.Text.Json;

namespace Raudy.Rest
{
    public static class Rest
    {
        public static async Task<T?> Get<T>(string url) where T : struct
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    using (HttpResponseMessage res = await client.GetAsync(url))
                    {
                        using (HttpContent content = res.Content)
                        {
                            string data = await content.ReadAsStringAsync();
                            return JsonSerializer.Deserialize<T>(data);
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine("Exception Hit------------");
                Console.WriteLine(exception);
                return null;
            }
        }
    }
}
