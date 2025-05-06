// Project > Properties > Change from Console Application to Windows Application when moving to production

namespace Source {
    internal class Program {
        static int Main(string[] args) {
            Task.Run(async void () => {
                Greenztl greenztl = new Greenztl();

                string[] urls = {
                    "https://greenztl2.com/series/became-the-final-boss-in-a-magical-girl-game/zero/",
"https://greenztl2.com/series/became-the-final-boss-in-a-magical-girl-game/1/",
"https://greenztl2.com/series/became-the-final-boss-in-a-magical-girl-game/2/",
"https://greenztl2.com/series/became-the-final-boss-in-a-magical-girl-game/3/",
"https://greenztl2.com/series/became-the-final-boss-in-a-magical-girl-game/4/",
"https://greenztl2.com/series/became-the-final-boss-in-a-magical-girl-game/5/",
"https://greenztl2.com/series/became-the-final-boss-in-a-magical-girl-game/6/",
"https://greenztl2.com/series/became-the-final-boss-in-a-magical-girl-game/7/",
"https://greenztl2.com/series/became-the-final-boss-in-a-magical-girl-game/8/",
"https://greenztl2.com/series/became-the-final-boss-in-a-magical-girl-game/9/",
"https://greenztl2.com/series/became-the-final-boss-in-a-magical-girl-game/10/",
"https://greenztl2.com/series/became-the-final-boss-in-a-magical-girl-game/11/",
"https://greenztl2.com/series/became-the-final-boss-in-a-magical-girl-game/12/",
"https://greenztl2.com/series/became-the-final-boss-in-a-magical-girl-game/13/",
"https://greenztl2.com/series/became-the-final-boss-in-a-magical-girl-game/14/",
"https://greenztl2.com/series/became-the-final-boss-in-a-magical-girl-game/15/",
"https://greenztl2.com/series/became-the-final-boss-in-a-magical-girl-game/16/",
"https://greenztl2.com/series/became-the-final-boss-in-a-magical-girl-game/17/",
"https://greenztl2.com/series/became-the-final-boss-in-a-magical-girl-game/18/",
"https://greenztl2.com/series/became-the-final-boss-in-a-magical-girl-game/19/",
"https://greenztl2.com/series/became-the-final-boss-in-a-magical-girl-game/20/",
"https://greenztl2.com/series/became-the-final-boss-in-a-magical-girl-game/21/",
"https://greenztl2.com/series/became-the-final-boss-in-a-magical-girl-game/22/",
"https://greenztl2.com/series/became-the-final-boss-in-a-magical-girl-game/23/",
"https://greenztl2.com/series/became-the-final-boss-in-a-magical-girl-game/24/",
"https://greenztl2.com/series/became-the-final-boss-in-a-magical-girl-game/25/",
"https://greenztl2.com/series/became-the-final-boss-in-a-magical-girl-game/26/",
"https://greenztl2.com/series/became-the-final-boss-in-a-magical-girl-game/27/",
"https://greenztl2.com/series/became-the-final-boss-in-a-magical-girl-game/28/",
"https://greenztl2.com/series/became-the-final-boss-in-a-magical-girl-game/29/",
"https://greenztl2.com/series/became-the-final-boss-in-a-magical-girl-game/30/",
"https://greenztl2.com/series/became-the-final-boss-in-a-magical-girl-game/31/",
"https://greenztl2.com/series/became-the-final-boss-in-a-magical-girl-game/32/",
"https://greenztl2.com/series/became-the-final-boss-in-a-magical-girl-game/33/",
"https://greenztl2.com/series/became-the-final-boss-in-a-magical-girl-game/34/",
"https://greenztl2.com/series/became-the-final-boss-in-a-magical-girl-game/35/",
"https://greenztl2.com/series/became-the-final-boss-in-a-magical-girl-game/36/",
"https://greenztl2.com/series/became-the-final-boss-in-a-magical-girl-game/37/",
"https://greenztl2.com/series/became-the-final-boss-in-a-magical-girl-game/38/",
"https://greenztl2.com/series/became-the-final-boss-in-a-magical-girl-game/39/",
"https://greenztl2.com/series/became-the-final-boss-in-a-magical-girl-game/40/",
"https://greenztl2.com/series/became-the-final-boss-in-a-magical-girl-game/41/",
"https://greenztl2.com/series/became-the-final-boss-in-a-magical-girl-game/42/",
"https://greenztl2.com/series/became-the-final-boss-in-a-magical-girl-game/43/",
"https://greenztl2.com/series/became-the-final-boss-in-a-magical-girl-game/44/",
"https://greenztl2.com/series/became-the-final-boss-in-a-magical-girl-game/45/",
"https://greenztl2.com/series/became-the-final-boss-in-a-magical-girl-game/46/",
"https://greenztl2.com/series/became-the-final-boss-in-a-magical-girl-game/47/",
"https://greenztl2.com/series/became-the-final-boss-in-a-magical-girl-game/48/",
"https://greenztl2.com/series/became-the-final-boss-in-a-magical-girl-game/49/",
"https://greenztl2.com/series/became-the-final-boss-in-a-magical-girl-game/50/",
"https://greenztl2.com/series/became-the-final-boss-in-a-magical-girl-game/51/",
"https://greenztl2.com/series/became-the-final-boss-in-a-magical-girl-game/52/",
"https://greenztl2.com/series/became-the-final-boss-in-a-magical-girl-game/53/",
"https://greenztl2.com/series/became-the-final-boss-in-a-magical-girl-game/54/",
"https://greenztl2.com/series/became-the-final-boss-in-a-magical-girl-game/55/",
"https://greenztl2.com/series/became-the-final-boss-in-a-magical-girl-game/56/",
"https://greenztl2.com/series/became-the-final-boss-in-a-magical-girl-game/57/",
"https://greenztl2.com/series/became-the-final-boss-in-a-magical-girl-game/58/",
"https://greenztl2.com/series/became-the-final-boss-in-a-magical-girl-game/59/",
"https://greenztl2.com/series/became-the-final-boss-in-a-magical-girl-game/60/",
"https://greenztl2.com/series/became-the-final-boss-in-a-magical-girl-game/61/",
"https://greenztl2.com/series/became-the-final-boss-in-a-magical-girl-game/62/",
"https://greenztl2.com/series/became-the-final-boss-in-a-magical-girl-game/63/",
"https://greenztl2.com/series/became-the-final-boss-in-a-magical-girl-game/64/",
"https://greenztl2.com/series/became-the-final-boss-in-a-magical-girl-game/65/",
"https://greenztl2.com/series/became-the-final-boss-in-a-magical-girl-game/66/",
"https://greenztl2.com/series/became-the-final-boss-in-a-magical-girl-game/67/",
"https://greenztl2.com/series/became-the-final-boss-in-a-magical-girl-game/68/",
"https://greenztl2.com/series/became-the-final-boss-in-a-magical-girl-game/69/",
"https://greenztl2.com/series/became-the-final-boss-in-a-magical-girl-game/70/",
"https://greenztl2.com/series/became-the-final-boss-in-a-magical-girl-game/71/",
"https://greenztl2.com/series/became-the-final-boss-in-a-magical-girl-game/72/",
"https://greenztl2.com/series/became-the-final-boss-in-a-magical-girl-game/73/",
"https://greenztl2.com/series/became-the-final-boss-in-a-magical-girl-game/74/",
"https://greenztl2.com/series/became-the-final-boss-in-a-magical-girl-game/75/",
"https://greenztl2.com/series/became-the-final-boss-in-a-magical-girl-game/76/",
"https://greenztl2.com/series/became-the-final-boss-in-a-magical-girl-game/77/",
"https://greenztl2.com/series/became-the-final-boss-in-a-magical-girl-game/78/",
"https://greenztl2.com/series/became-the-final-boss-in-a-magical-girl-game/79/",
"https://greenztl2.com/series/became-the-final-boss-in-a-magical-girl-game/80/",
"https://greenztl2.com/series/became-the-final-boss-in-a-magical-girl-game/81/",
"https://greenztl2.com/series/became-the-final-boss-in-a-magical-girl-game/82/",
"https://greenztl2.com/series/became-the-final-boss-in-a-magical-girl-game/83/",
"https://greenztl2.com/series/became-the-final-boss-in-a-magical-girl-game/84/",
"https://greenztl2.com/series/became-the-final-boss-in-a-magical-girl-game/85/",
"https://greenztl2.com/series/became-the-final-boss-in-a-magical-girl-game/86/",
"https://greenztl2.com/series/became-the-final-boss-in-a-magical-girl-game/87/",
"https://greenztl2.com/series/became-the-final-boss-in-a-magical-girl-game/88/",
"https://greenztl2.com/series/became-the-final-boss-in-a-magical-girl-game/89/",
"https://greenztl2.com/series/became-the-final-boss-in-a-magical-girl-game/90/",
"https://greenztl2.com/series/became-the-final-boss-in-a-magical-girl-game/91/",
"https://greenztl2.com/series/became-the-final-boss-in-a-magical-girl-game/92/",
"https://greenztl2.com/series/became-the-final-boss-in-a-magical-girl-game/93/",
"https://greenztl2.com/series/became-the-final-boss-in-a-magical-girl-game/94/",
"https://greenztl2.com/series/became-the-final-boss-in-a-magical-girl-game/95/",
"https://greenztl2.com/series/became-the-final-boss-in-a-magical-girl-game/96/",
"https://greenztl2.com/series/became-the-final-boss-in-a-magical-girl-game/97/",
"https://greenztl2.com/series/became-the-final-boss-in-a-magical-girl-game/98/",
"https://greenztl2.com/series/became-the-final-boss-in-a-magical-girl-game/99/",
"https://greenztl2.com/series/became-the-final-boss-in-a-magical-girl-game/100/",
"https://greenztl2.com/series/became-the-final-boss-in-a-magical-girl-game/101/",
"https://greenztl2.com/series/became-the-final-boss-in-a-magical-girl-game/102/",
"https://greenztl2.com/series/became-the-final-boss-in-a-magical-girl-game/103/",
"https://greenztl2.com/series/became-the-final-boss-in-a-magical-girl-game/104/",
"https://greenztl2.com/series/became-the-final-boss-in-a-magical-girl-game/105/",
"https://greenztl2.com/series/became-the-final-boss-in-a-magical-girl-game/106/",
"https://greenztl2.com/series/became-the-final-boss-in-a-magical-girl-game/107/",
"https://greenztl2.com/series/became-the-final-boss-in-a-magical-girl-game/108/",
"https://greenztl2.com/series/became-the-final-boss-in-a-magical-girl-game/109/",
"https://greenztl2.com/series/became-the-final-boss-in-a-magical-girl-game/110/",
"https://greenztl2.com/series/became-the-final-boss-in-a-magical-girl-game/111/",
                };

                const int chapterPerVolume = 100;

                int volume = 1;
                int chapter = 1;
                foreach (string url in urls) {
                    Console.WriteLine($"{url}");
                    await greenztl.DownloadChapter(url, @"D:\Visual Novels\[Self-Sourced] [Ongoing] Became The Final Boss In a Magical Girl World\Raw\" + $"Volume {volume}", $"{(chapter++).ToString("D4")}.xhtml");

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