// Project > Properties > Change from Console Application to Windows Application when moving to production

namespace Source {
    internal class Program {
        static int Main(string[] args) {
            Task.Run(async void () => {
                YukiKitsuneko yuki = new YukiKitsuneko();

                string[] urls = {
                    //"https://yukikitsuneko.blogspot.com/2025/01/imadoki-gal-e1.html",
                    //"https://yukikitsuneko.blogspot.com/2025/01/imadoki-gal-e2.html",
                    "https://yukikitsuneko.blogspot.com/2025/01/imadoki-gal-e3.html",
                    "https://yukikitsuneko.blogspot.com/2025/01/imadoki-gal-e4.html",
                    "https://yukikitsuneko.blogspot.com/2025/01/imadoki-gal-e5.html",
                    "https://yukikitsuneko.blogspot.com/2025/01/imadoki-gal-e6.html",
                    "https://yukikitsuneko.blogspot.com/2025/01/imadoki-gal-e7.html",
                    "https://yukikitsuneko.blogspot.com/2025/01/imadoki-gal-e8.html",
                    "https://yukikitsuneko.blogspot.com/2025/01/imadoki-gal-e9.html",
                    "https://yukikitsuneko.blogspot.com/2025/01/imadoki-gal-e10.html",
                    "https://yukikitsuneko.blogspot.com/2025/01/imadoki-gal-e11.html",
                    "https://yukikitsuneko.blogspot.com/2025/01/imadoki-gal-e12.html",
                    "https://yukikitsuneko.blogspot.com/2025/01/imadoki-gal-e13.html",
                    "https://yukikitsuneko.blogspot.com/2025/01/imadoki-gal-e14.html",
                    "https://yukikitsuneko.blogspot.com/2025/01/imadoki-gal-e15.html",
                    "https://yukikitsuneko.blogspot.com/2025/01/imadoki-gal-e16.html",
                    "https://yukikitsuneko.blogspot.com/2025/01/imadoki-gal-e17.html",
                    "https://yukikitsuneko.blogspot.com/2025/01/imadoki-gal-e18.html",
                    "https://yukikitsuneko.blogspot.com/2025/01/imadoki-gal-e19.html",
                    "https://yukikitsuneko.blogspot.com/2025/01/imadoki-gal-e20.html",
                    "https://yukikitsuneko.blogspot.com/2025/01/imadoki-gal-e21.html",
                    "https://yukikitsuneko.blogspot.com/2025/01/imadoki-gal-i1.html",
                    "https://yukikitsuneko.blogspot.com/2025/01/imadoki-gal-e22.html",
                    "https://yukikitsuneko.blogspot.com/2025/01/imadoki-gal-e23.html",
                    "https://yukikitsuneko.blogspot.com/2025/01/imadoki-gal-e24.html",
                    "https://yukikitsuneko.blogspot.com/2025/01/imadoki-gal-e25.html",
                    "https://yukikitsuneko.blogspot.com/2025/01/imadoki-gal-e26.html",
                    "https://yukikitsuneko.blogspot.com/2025/01/imadoki-gal-e27.html",
                    "https://yukikitsuneko.blogspot.com/2025/01/imadoki-gal-e28.html",
                    "https://yukikitsuneko.blogspot.com/2025/01/imadoki-gal-e29.html",
                    "https://yukikitsuneko.blogspot.com/2025/01/imadoki-gal-e30.html",
                    "https://yukikitsuneko.blogspot.com/2025/01/imadoki-gal-e31.html",
                    "https://yukikitsuneko.blogspot.com/2025/01/imadoki-gal-e32.html",
                    "https://yukikitsuneko.blogspot.com/2025/01/imadoki-gal-e33.html",
                    "https://yukikitsuneko.blogspot.com/2025/01/imadoki-gal-e34.html",
                    "https://yukikitsuneko.blogspot.com/2025/01/imadoki-gal-e35.html",
                    "https://yukikitsuneko.blogspot.com/2025/01/imadoki-gal-e36.html",
                    "https://yukikitsuneko.blogspot.com/2025/01/imadoki-gal-e37.html",
                    "https://yukikitsuneko.blogspot.com/2025/01/imadoki-gal-e38.html",
                    "https://yukikitsuneko.blogspot.com/2025/01/imadoki-gal-e39.html",
                    "https://yukikitsuneko.blogspot.com/2025/01/imadoki-gal-e40.html",
                    "https://yukikitsuneko.blogspot.com/2025/01/imadoki-gal-e41.html",
                    "https://yukikitsuneko.blogspot.com/2025/01/imadoki-gal-e42.html",
                    "https://yukikitsuneko.blogspot.com/2025/01/imadoki-gal-i2.html",
                    "https://yukikitsuneko.blogspot.com/2025/01/imadoki-gal-e43.html",
                    "https://yukikitsuneko.blogspot.com/2025/01/imadoki-gal-e44.html",
                    "https://yukikitsuneko.blogspot.com/2025/01/imadoki-gal-e45.html",
                    "https://yukikitsuneko.blogspot.com/2025/01/imadoki-gal-e46.html",
                    "https://yukikitsuneko.blogspot.com/2025/01/imadoki-gal-e47.html",
                    "https://yukikitsuneko.blogspot.com/2025/01/imadoki-gal-e48.html",
                    "https://yukikitsuneko.blogspot.com/2025/01/imadoki-gal-e49.html",
                    "https://yukikitsuneko.blogspot.com/2025/01/imadoki-gal-e50.html",
                    "https://yukikitsuneko.blogspot.com/2025/01/imadoki-gal-e51.html",
                    "https://yukikitsuneko.blogspot.com/2025/01/imadoki-gal-e52.html",
                    "https://yukikitsuneko.blogspot.com/2025/01/imadoki-gal-e53.html",
                    "https://yukikitsuneko.blogspot.com/2025/01/imadoki-gal-e54.html",
                    "https://yukikitsuneko.blogspot.com/2025/01/imadoki-gal-e55.html",
                    "https://yukikitsuneko.blogspot.com/2025/01/imadoki-gal-e56.html",
                    "https://yukikitsuneko.blogspot.com/2025/01/imadoki-gal-e57.html",
                    "https://yukikitsuneko.blogspot.com/2025/01/imadoki-gal-e58.html",
                    "https://yukikitsuneko.blogspot.com/2025/01/imadoki-gal-e59.html",
                    "https://yukikitsuneko.blogspot.com/2025/01/imadoki-gal-e60.html",
                    "https://yukikitsuneko.blogspot.com/2025/01/imadoki-gal-e61.html",
                    "https://yukikitsuneko.blogspot.com/2025/01/imadoki-gal-e62.html",
                    "https://yukikitsuneko.blogspot.com/2025/01/imadoki-gal-e63.html",
                    "https://yukikitsuneko.blogspot.com/2025/01/imadoki-gal-e64.html",
                    "https://yukikitsuneko.blogspot.com/2025/01/imadoki-gal-e65.html",
                    "https://yukikitsuneko.blogspot.com/2025/01/imadoki-gal-e66.html",
                    "https://yukikitsuneko.blogspot.com/2025/01/imadoki-gal-e67.html",
                    "https://yukikitsuneko.blogspot.com/2025/01/imadoki-gal-e68.html",
                    "https://yukikitsuneko.blogspot.com/2025/01/imadoki-gal-e69.html",
                    "https://yukikitsuneko.blogspot.com/2025/01/imadoki-gal-e70.html",
                    "https://yukikitsuneko.blogspot.com/2025/01/imadoki-gal-e71.html",
                    "https://yukikitsuneko.blogspot.com/2025/01/imadoki-gal-e72.html",
                    "https://yukikitsuneko.blogspot.com/2025/01/imadoki-gal-e73.html",
                    "https://yukikitsuneko.blogspot.com/2025/01/imadoki-gal-e74.html",
                    "https://yukikitsuneko.blogspot.com/2025/01/imadoki-gal-e75.html",
                    "https://yukikitsuneko.blogspot.com/2025/01/imadoki-gal-e76.html",
                    "https://yukikitsuneko.blogspot.com/2025/01/imadoki-gal-e77.html",
                    "https://yukikitsuneko.blogspot.com/2025/01/imadoki-gal-e78.html",
                    "https://yukikitsuneko.blogspot.com/2025/01/imadoki-gal-e79.html",
                    "https://yukikitsuneko.blogspot.com/2025/01/imadoki-gal-e80.html",
                    "https://yukikitsuneko.blogspot.com/2025/01/imadoki-gal-e81.html",
                    "https://yukikitsuneko.blogspot.com/2025/01/imadoki-gal-e82.html",
                    "https://yukikitsuneko.blogspot.com/2025/01/imadoki-gal-e83.html",
                    "https://yukikitsuneko.blogspot.com/2025/04/imadoki-gal-e84.html",
                    "https://yukikitsuneko.blogspot.com/2025/04/imadoki-gal-e85.html",
                    "https://yukikitsuneko.blogspot.com/2025/04/imadoki-gal-e86.html",
                    "https://yukikitsuneko.blogspot.com/2025/05/imadoki-gal-e87.html",
                    "https://yukikitsuneko.blogspot.com/2025/05/imadoki-gal-e88.html",
                    "https://yukikitsuneko.blogspot.com/2025/05/imadoki-gal-e89.html",
                    "https://yukikitsuneko.blogspot.com/2025/05/imadoki-gal-e90.html",
                    "https://yukikitsuneko.blogspot.com/2025/05/imadoki-gal-e91.html",
                    "https://yukikitsuneko.blogspot.com/2025/06/imadoki-gal-e92.html",
                };

                const int chapterPerVolume = 100;

                int skip = 80;

                int volume = 1;
                int chapter = 1;
                for (int i = 0; i < urls.Length; ++i) {
                    var url = urls[i];

                    Console.WriteLine($"{url}");

                    if (i >= skip) {
                        await yuki.DownloadChapter(url, @"D:\Visual Novels\[Self-Sourced] [Incomplete] Apparently My Childhood Friend is a Yandere\Raw\" + $"Volume {volume}", $"{chapter.ToString("D4")}.xhtml");
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