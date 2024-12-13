// Project > Properties > Change from Console Application to Windows Application when moving to production

namespace Source {
    internal class Program {
        static int Main(string[] args) {
            Task.Run(async void () => {
                Valhalla valhalla = new Valhalla();

                int current = 149;
                string url = "https://valhallatls.blogspot.com/2024/12/evil-avalon_8.html";

                while (url != string.Empty) {
                    Console.WriteLine($"{current} - {url}");
                    int volume = (int)Math.Ceiling(current / 50.0);
                    if (volume < 1) volume = 1;
                    url = await valhalla.DownloadBlog(url, @"D:\Visual Novels\[Self-Sourced] [Ongoing] Evil Avalon\Raw\" + $"Volume {volume}", $"{(current--).ToString("D4")}.xhtml");
                }

                Console.WriteLine("Done!");
            });

            Console.ReadLine();

            return 0;
        }
    }
}