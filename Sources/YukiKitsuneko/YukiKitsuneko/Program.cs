// Project > Properties > Change from Console Application to Windows Application when moving to production

namespace Source {
    internal class Program {
        static int Main(string[] args) {
            Task.Run(async void () => {
                YukiKitsuneko yuki = new YukiKitsuneko();

                string[] urls = {
"https://yukikitsuneko.blogspot.com/2025/04/arrogant-queen-v1-illustrations.html",
"https://yukikitsuneko.blogspot.com/2025/04/arrogant-queen-v1-c1.html",
"https://yukikitsuneko.blogspot.com/2025/04/arrogant-queen-v1-c2.html",
"https://yukikitsuneko.blogspot.com/2025/04/arrogant-queen-v1-c3.html",
"https://yukikitsuneko.blogspot.com/2025/04/arrogant-queen-v1-c4.html",
"https://yukikitsuneko.blogspot.com/2025/04/arrogant-queen-v1-c5.html",
"https://yukikitsuneko.blogspot.com/2025/04/arrogant-queen-v1-c6.html",
"https://yukikitsuneko.blogspot.com/2025/04/arrogant-queen-v1-c7.html",
"https://yukikitsuneko.blogspot.com/2025/04/arrogant-queen-v1-c8.html",
"https://yukikitsuneko.blogspot.com/2025/04/arrogant-queen-v1-c9.html",
"https://yukikitsuneko.blogspot.com/2025/04/arrogant-queen-v1-c10.html",
"https://yukikitsuneko.blogspot.com/2025/04/arrogant-queen-v1-afterword.html",
"https://yukikitsuneko.blogspot.com/2025/05/arrogant-queen-v2-illustrations.html",
"https://yukikitsuneko.blogspot.com/2025/05/arrogant-queen-v2-c1.html",
"https://yukikitsuneko.blogspot.com/2025/05/arrogant-queen-v2-c2.html",
"https://yukikitsuneko.blogspot.com/2025/05/arrogant-queen-v2-c3.html",
"https://yukikitsuneko.blogspot.com/2025/05/arrogant-queen-v2-c4.html",
"https://yukikitsuneko.blogspot.com/2025/05/arrogant-queen-v2-c5.html",
"https://yukikitsuneko.blogspot.com/2025/05/arrogant-queen-v2-c6.html",
"https://yukikitsuneko.blogspot.com/2025/05/arrogant-queen-v2-c7.html",
"https://yukikitsuneko.blogspot.com/2025/05/arrogant-queen-v2-c8.html",
"https://yukikitsuneko.blogspot.com/2025/05/arrogant-queen-v2-c9.html",
"https://yukikitsuneko.blogspot.com/2025/05/arrogant-queen-v2-c10.html",
"https://yukikitsuneko.blogspot.com/2025/05/arrogant-queen-v2-afterword.html",
"https://yukikitsuneko.blogspot.com/2025/06/arrogant-queen-v3-illustrations.html",
"https://yukikitsuneko.blogspot.com/2025/06/arrogant-queen-v3-c1.html",
"https://yukikitsuneko.blogspot.com/2025/06/arrogant-queen-v3-c2.html",
"https://yukikitsuneko.blogspot.com/2025/06/arrogant-queen-v3-c3.html",
"https://yukikitsuneko.blogspot.com/2025/06/arrogant-queen-v3-c4.html",
"https://yukikitsuneko.blogspot.com/2025/06/arrogant-queen-v3-c5.html",
"https://yukikitsuneko.blogspot.com/2025/06/arrogant-queen-v3-c6.html",
"https://yukikitsuneko.blogspot.com/2025/06/arrogant-queen-v3-c7.html",
"https://yukikitsuneko.blogspot.com/2025/06/arrogant-queen-v3-c8.html",
"https://yukikitsuneko.blogspot.com/2025/06/arrogant-queen-v3-c9.html",
"https://yukikitsuneko.blogspot.com/2025/06/arrogant-queen-v3-c10.html",
"https://yukikitsuneko.blogspot.com/2025/06/arrogant-queen-v3-afterword.html",
"https://yukikitsuneko.blogspot.com/2025/11/arrogant-queen-v4-illustrations.html",
"https://yukikitsuneko.blogspot.com/2025/11/arrogant-queen-v4-c1.html",
"https://yukikitsuneko.blogspot.com/2025/11/arrogant-queen-v4-c2.html",
"https://yukikitsuneko.blogspot.com/2025/11/arrogant-queen-v4-c3.html",
"https://yukikitsuneko.blogspot.com/2025/11/arrogant-queen-v4-c4.html",
"https://yukikitsuneko.blogspot.com/2025/11/arrogant-queen-v4-c5.html",
                };

                const int chapterPerVolume = 100;

                int skip = 36;

                int volume = 1;
                int chapter = 1;
                for (int i = 0; i < urls.Length; ++i) {
                    var url = urls[i];

                    Console.WriteLine($"{url}");

                    if (i >= skip) {
                        await yuki.DownloadChapter(url, @"D:\Visual Novels\[Self-Sourced] [Ongoing] Arrogant Queen\Raw\" + $"Volume {volume}", $"{chapter.ToString("D4")}.xhtml");
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