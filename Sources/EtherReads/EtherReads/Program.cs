// Project > Properties > Change from Console Application to Windows Application when moving to production

namespace Source {
    internal class Program {
        static int Main(string[] args) {
            Task.Run(async void () => {
                EtherReads etherReads = new EtherReads();

                string _url = "https://etherreads.com/the-yellow-haired-villain-in-soaring-phoenixs-novels-also-desires-happiness-v1c";
                List<string> urls = new List<string>();
                for (int i = 1; i <= 70; ++i) {
                    urls.Add($"{_url}{i}");
                }

                const int chapterPerVolume = 100;

                int volume = 1;
                int chapter = 1;
                foreach (string url in urls) {
                    Console.WriteLine($"{url}");
                    await etherReads.DownloadChapter(url, @"D:\Visual Novels\[Self-Sourced] [Ongoing] Yellow-haired villain\Raw\" + $"Volume {volume}", $"{(chapter++).ToString("D4")}.xhtml");

                    if (chapter > chapterPerVolume) {
                        ++volume;
                        chapter = 1;
                    }

                    Thread.Sleep(500); // Cloudflare rate limiting
                }

                Console.WriteLine("Done!");
            });

            Console.ReadLine();

            return 0;
        }
    }
}