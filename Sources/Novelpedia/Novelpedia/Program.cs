// Project > Properties > Change from Console Application to Windows Application when moving to production

namespace Source {
    internal class Program {
        static int Main(string[] args) {
            Task.Run(async void () => {
                Novelpedia novelpedia = new Novelpedia();

                string cookie = await novelpedia.GetCookie("https://global.novelpia.com/viewer/350834");

                string[] urls = {
                    "https://global.novelpia.com/novel/328347",
                    "https://global.novelpia.com/novel/328362",
                    "https://global.novelpia.com/novel/328375",
                    "https://global.novelpia.com/novel/328390",
                    "https://global.novelpia.com/novel/328403",
                    "https://global.novelpia.com/novel/328419",
                    "https://global.novelpia.com/novel/328436",
                    "https://global.novelpia.com/novel/328444",
                    "https://global.novelpia.com/novel/328457",
                    "https://global.novelpia.com/novel/328474",
                    "https://global.novelpia.com/novel/328490",
                    "https://global.novelpia.com/novel/328502",
                    "https://global.novelpia.com/novel/328515",
                    "https://global.novelpia.com/novel/328530",
                    "https://global.novelpia.com/novel/328543",
                    "https://global.novelpia.com/novel/328559",
                    "https://global.novelpia.com/novel/328577",
                    "https://global.novelpia.com/novel/328592",
                    "https://global.novelpia.com/novel/328606",
                    "https://global.novelpia.com/novel/328618",
                    "https://global.novelpia.com/novel/328636",
                    "https://global.novelpia.com/novel/328649",
                    "https://global.novelpia.com/novel/328666",
                    "https://global.novelpia.com/novel/328678",
                    "https://global.novelpia.com/novel/328692",
                    "https://global.novelpia.com/novel/328704",
                    "https://global.novelpia.com/novel/328719",
                    "https://global.novelpia.com/novel/328738",
                    "https://global.novelpia.com/novel/328755",
                    "https://global.novelpia.com/novel/328768",
                    "https://global.novelpia.com/novel/328784",
                    "https://global.novelpia.com/novel/328802",
                    "https://global.novelpia.com/novel/328819",
                    "https://global.novelpia.com/novel/328837",
                    "https://global.novelpia.com/novel/328852",
                    "https://global.novelpia.com/novel/328867",
                    "https://global.novelpia.com/novel/328882",
                    "https://global.novelpia.com/novel/328896",
                    "https://global.novelpia.com/novel/328910",
                    "https://global.novelpia.com/novel/328927",
                    "https://global.novelpia.com/novel/328944",
                    "https://global.novelpia.com/novel/328959",
                    "https://global.novelpia.com/novel/328976",
                    "https://global.novelpia.com/novel/328992",
                    "https://global.novelpia.com/novel/329007",

                    "https://global.novelpia.com/novel/329020",
                    "https://global.novelpia.com/novel/329036",
                    "https://global.novelpia.com/novel/329049",
                    "https://global.novelpia.com/novel/329065",
                    "https://global.novelpia.com/novel/329082",
                    "https://global.novelpia.com/novel/329096",
                    "https://global.novelpia.com/novel/329111",
                    "https://global.novelpia.com/novel/329125",
                    "https://global.novelpia.com/novel/329138",
                    "https://global.novelpia.com/novel/329152",
                    "https://global.novelpia.com/novel/329170",
                    "https://global.novelpia.com/novel/329188",
                    "https://global.novelpia.com/novel/329203",
                    "https://global.novelpia.com/novel/329220",
                    "https://global.novelpia.com/novel/329240",
                    "https://global.novelpia.com/novel/329254",
                    "https://global.novelpia.com/novel/329265",
                    "https://global.novelpia.com/novel/329279",
                    "https://global.novelpia.com/novel/329294",
                    "https://global.novelpia.com/novel/329309",
                };

                const string novelNo = "1623";
                bool requireAds = false;

                const int chapterPerVolume = 100;

                int skip = 0;

                int volume = 1;
                int chapter = 1;
                for (int i = 0; i < urls.Length; ++i) {
                    var url = urls[i];

                    Console.WriteLine($"{url}");

                    string episodeNo = url.Split("/").Last();
                    if (episodeNo == "329020") requireAds = true;

                    if (i >= skip) {
                        if (requireAds) await novelpedia.WatchAd(novelNo, episodeNo, cookie);
                        await novelpedia.DownloadChapter(url, @"D:\Visual Novels\[Self-Sourced] [Ongoing] The Villainess Was Raised Too Well\Raw\" + $"Volume {volume}", $"{chapter.ToString("D4")}.xhtml", cookie);
                    }

                    if ((++chapter) > chapterPerVolume) {
                        ++volume;
                        chapter = 1;
                    }

                    if (i >= skip) {
                        Thread.Sleep(10000); // Cloudflare rate limiting
                    }
                }

                Console.WriteLine("Done!");
            });

            Console.ReadLine();

            return 0;
        }
    }
}