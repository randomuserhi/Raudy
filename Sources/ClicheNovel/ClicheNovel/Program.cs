// Project > Properties > Change from Console Application to Windows Application when moving to production

namespace Source {
    internal class Program {
        static int Main(string[] args) {
            Task.Run(async void () => {
                ClicheNovel cliche = new ClicheNovel();

                var urls = await cliche.GetChapters("patron", 26);

                const int chapterPerVolume = 100;

                int skip = 190;

                int volume = 1;
                int chapter = 1;
                for (int i = 0; i < urls.Count; ++i) {
                    var url = urls[i];

                    Console.WriteLine($"{url.url}");

                    if (i >= skip) {
                        await cliche.DownloadChapter(url.url, @"D:\Visual Novels\[Self-Sourced] [Ongoing] Patron of Villains\Raw\" + $"Volume {volume}", $"{chapter.ToString("D4")}.xhtml", url.title);
                    }

                    if ((++chapter) > chapterPerVolume) {
                        ++volume;
                        chapter = 1;
                    }

                    if (i >= skip) {
                        Thread.Sleep(1000); // Cloudflare rate limiting
                    }
                }

                Console.WriteLine("Done!");
            });

            Console.ReadLine();

            return 0;
        }
    }
}