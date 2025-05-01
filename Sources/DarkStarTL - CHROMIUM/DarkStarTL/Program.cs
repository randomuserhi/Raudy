// Project > Properties > Change from Console Application to Windows Application when moving to production

using System;
using System.Threading;
using System.Threading.Tasks;

namespace Source {
    internal class Program {
        static int Main(string[] args) {
            Task.Run(async () => {
                DarkStarTL darkStarTL = new DarkStarTL();

                string[] urls = {
                    "https://darkstartranslations.com/series/avoid-the-yandere-goddess/0"
                };

                const int chapterPerVolume = 100;

                int volume = 1;
                int chapter = 1;
                foreach (string url in urls) {
                    Console.WriteLine($"{url}");
                    // NOTE(randomuserhi): Use webarchive for Extra C as it got removed somewhere along the line
                    await darkStarTL.DownloadChapter($"{url}", @"D:\Visual Novels\[Self-Sourced] [Ongoing] Avoid The Yandere Goddess\Raw\" + $"Volume {volume}", $"{(chapter++).ToString("D4")}.xhtml");

                    if (chapter > chapterPerVolume) {
                        ++volume;
                        chapter = 1;
                    }

                    Thread.Sleep(100); // Cloudflare rate limiting
                }

                darkStarTL.Dispose();
                Console.WriteLine("Done!");
            });

            Console.ReadLine();

            return 0;
        }
    }
}