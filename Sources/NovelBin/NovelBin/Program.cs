// Project > Properties > Change from Console Application to Windows Application when moving to production

namespace Source {
    internal class Program {
        static int Main(string[] args) {
            Task.Run(async void () => {
                NovelBin novelbin = new NovelBin();

                string[] urls = {
                    "https://novelbin.me/novel-book/i-became-the-fiance-of-a-dragon-in-romance-fantasy/chapter-1-became-the-dragons-fiance-in-a-romantic-fantasy",
"https://novelbin.me/novel-book/i-became-the-fiance-of-a-dragon-in-romance-fantasy/chapter-2-adilun-1",
"https://novelbin.me/novel-book/i-became-the-fiance-of-a-dragon-in-romance-fantasy/chapter-3-adilun-2",
"https://novelbin.me/novel-book/i-became-the-fiance-of-a-dragon-in-romance-fantasy/chapter-4-not-reached-1",
"https://novelbin.me/novel-book/i-became-the-fiance-of-a-dragon-in-romance-fantasy/chapter-5-not-reached-2",
"https://novelbin.me/novel-book/i-became-the-fiance-of-a-dragon-in-romance-fantasy/chapter-6-change-1",
"https://novelbin.me/novel-book/i-became-the-fiance-of-a-dragon-in-romance-fantasy/chapter-7-change-2",
"https://novelbin.me/novel-book/i-became-the-fiance-of-a-dragon-in-romance-fantasy/chapter-8-national-foundation-day-1",
"https://novelbin.me/novel-book/i-became-the-fiance-of-a-dragon-in-romance-fantasy/chapter-9-national-foundation-day-2",
"https://novelbin.me/novel-book/i-became-the-fiance-of-a-dragon-in-romance-fantasy/chapter-10-national-foundation-day-3",
"https://novelbin.me/novel-book/i-became-the-fiance-of-a-dragon-in-romance-fantasy/chapter-11-prom-1",
"https://novelbin.me/novel-book/i-became-the-fiance-of-a-dragon-in-romance-fantasy/chapter-12-prom-2",
"https://novelbin.me/novel-book/i-became-the-fiance-of-a-dragon-in-romance-fantasy/chapter-13-prom-3",
"https://novelbin.me/novel-book/i-became-the-fiance-of-a-dragon-in-romance-fantasy/chapter-14-prom-4",
"https://novelbin.me/novel-book/i-became-the-fiance-of-a-dragon-in-romance-fantasy/chapter-15-certain-accidents-1",
"https://novelbin.me/novel-book/i-became-the-fiance-of-a-dragon-in-romance-fantasy/chapter-16-certain-accidents-2",
"https://novelbin.me/novel-book/i-became-the-fiance-of-a-dragon-in-romance-fantasy/chapter-17-this-is-the-last-chance-1",
"https://novelbin.me/novel-book/i-became-the-fiance-of-a-dragon-in-romance-fantasy/chapter-18-this-is-the-last-chance-2",
"https://novelbin.me/novel-book/i-became-the-fiance-of-a-dragon-in-romance-fantasy/chapter-19-hunting-competition-1",
"https://novelbin.me/novel-book/i-became-the-fiance-of-a-dragon-in-romance-fantasy/chapter-20-hunting-competition-2",
"https://novelbin.me/novel-book/i-became-the-fiance-of-a-dragon-in-romance-fantasy/chapter-21-hunting-competition-3",
"https://novelbin.me/novel-book/i-became-the-fiance-of-a-dragon-in-romance-fantasy/chapter-22-hunting-competition-4",
"https://novelbin.me/novel-book/i-became-the-fiance-of-a-dragon-in-romance-fantasy/chapter-23-hunting-competition-5",
"https://novelbin.me/novel-book/i-became-the-fiance-of-a-dragon-in-romance-fantasy/chapter-24-ill-wait-so-please-try-a-little-harder",
"https://novelbin.me/novel-book/i-became-the-fiance-of-a-dragon-in-romance-fantasy/chapter-25-tourney-1",
"https://novelbin.me/novel-book/i-became-the-fiance-of-a-dragon-in-romance-fantasy/chapter-26-tourney-2physiss-pov",
"https://novelbin.me/novel-book/i-became-the-fiance-of-a-dragon-in-romance-fantasy/chapter-27-tourney-3",
"https://novelbin.me/novel-book/i-became-the-fiance-of-a-dragon-in-romance-fantasy/chapter-28-tourney-4",
"https://novelbin.me/novel-book/i-became-the-fiance-of-a-dragon-in-romance-fantasy/chapter-29-tourney-5",
"https://novelbin.me/novel-book/i-became-the-fiance-of-a-dragon-in-romance-fantasy/chapter-30-martial-arts-competition-1",
"https://novelbin.me/novel-book/i-became-the-fiance-of-a-dragon-in-romance-fantasy/chapter-31-martial-arts-competition-1",
"https://novelbin.me/novel-book/i-became-the-fiance-of-a-dragon-in-romance-fantasy/chapter-32-ready-1",
"https://novelbin.me/novel-book/i-became-the-fiance-of-a-dragon-in-romance-fantasy/chapter-33-uneasiness",
"https://novelbin.me/novel-book/i-became-the-fiance-of-a-dragon-in-romance-fantasy/chapter-34-ready-2",
"https://novelbin.me/novel-book/i-became-the-fiance-of-a-dragon-in-romance-fantasy/chapter-35-wants",
"https://novelbin.me/novel-book/i-became-the-fiance-of-a-dragon-in-romance-fantasy/chapter-36-great-duel-1",
"https://novelbin.me/novel-book/i-became-the-fiance-of-a-dragon-in-romance-fantasy/chapter-37-great-duel-2",
"https://novelbin.me/novel-book/i-became-the-fiance-of-a-dragon-in-romance-fantasy/chapter-38-great-duel-3",
"https://novelbin.me/novel-book/i-became-the-fiance-of-a-dragon-in-romance-fantasy/chapter-39-previous-life",
"https://novelbin.me/novel-book/i-became-the-fiance-of-a-dragon-in-romance-fantasy/chapter-40-sure-1",
"https://novelbin.me/novel-book/i-became-the-fiance-of-a-dragon-in-romance-fantasy/chapter-41-sure-2",
"https://novelbin.me/novel-book/i-became-the-fiance-of-a-dragon-in-romance-fantasy/chapter-42-cold",
"https://novelbin.me/novel-book/i-became-the-fiance-of-a-dragon-in-romance-fantasy/chapter-43-molting",
"https://novelbin.me/novel-book/i-became-the-fiance-of-a-dragon-in-romance-fantasy/chapter-44-more-than-anyone",
"https://novelbin.me/novel-book/i-became-the-fiance-of-a-dragon-in-romance-fantasy/chapter-45-getting-drunk",
"https://novelbin.me/novel-book/i-became-the-fiance-of-a-dragon-in-romance-fantasy/chapter-46-social-gathering-1",
"https://novelbin.me/novel-book/i-became-the-fiance-of-a-dragon-in-romance-fantasy/chapter-47-social-gathering-2",
"https://novelbin.me/novel-book/i-became-the-fiance-of-a-dragon-in-romance-fantasy/chapter-48-social-gathering-3",
"https://novelbin.me/novel-book/i-became-the-fiance-of-a-dragon-in-romance-fantasy/chapter-49-fishing-1",
"https://novelbin.me/novel-book/i-became-the-fiance-of-a-dragon-in-romance-fantasy/chapter-50-fishing-2",
"https://novelbin.me/novel-book/i-became-the-fiance-of-a-dragon-in-romance-fantasy/chapter-51-fishing-3",
"https://novelbin.me/novel-book/i-became-the-fiance-of-a-dragon-in-romance-fantasy/chapter-52-awareness-and-jealousy-1",
"https://novelbin.me/novel-book/i-became-the-fiance-of-a-dragon-in-romance-fantasy/chapter-53-awareness-and-jealousy-2",
"https://novelbin.me/novel-book/i-became-the-fiance-of-a-dragon-in-romance-fantasy/chapter-54-awareness-and-jealousy-3",
"https://novelbin.me/novel-book/i-became-the-fiance-of-a-dragon-in-romance-fantasy/chapter-55-ugh",
"https://novelbin.me/novel-book/i-became-the-fiance-of-a-dragon-in-romance-fantasy/chapter-56-wish",
"https://novelbin.me/novel-book/i-became-the-fiance-of-a-dragon-in-romance-fantasy/chapter-57-alcohol",
"https://novelbin.me/novel-book/i-became-the-fiance-of-a-dragon-in-romance-fantasy/chapter-58-dreams-and-confessions",
"https://novelbin.me/novel-book/i-became-the-fiance-of-a-dragon-in-romance-fantasy/chapter-59-ortaire-1",
"https://novelbin.me/novel-book/i-became-the-fiance-of-a-dragon-in-romance-fantasy/chapter-60-ortaire-2",
"https://novelbin.me/novel-book/i-became-the-fiance-of-a-dragon-in-romance-fantasy/chapter-61-ortaire-3",
"https://novelbin.me/novel-book/i-became-the-fiance-of-a-dragon-in-romance-fantasy/chapter-62-ortaire-4",
"https://novelbin.me/novel-book/i-became-the-fiance-of-a-dragon-in-romance-fantasy/chapter-63-ortaire-5",
"https://novelbin.me/novel-book/i-became-the-fiance-of-a-dragon-in-romance-fantasy/chapter-64-commitment",
"https://novelbin.me/novel-book/i-became-the-fiance-of-a-dragon-in-romance-fantasy/chapter-65-everyday",
"https://novelbin.me/novel-book/i-became-the-fiance-of-a-dragon-in-romance-fantasy/chapter-66-picnic-1",
"https://novelbin.me/novel-book/i-became-the-fiance-of-a-dragon-in-romance-fantasy/chapter-67-picnic-2-physis-pov",
"https://novelbin.me/novel-book/i-became-the-fiance-of-a-dragon-in-romance-fantasy/chapter-68picnic-3",
"https://novelbin.me/novel-book/i-became-the-fiance-of-a-dragon-in-romance-fantasy/chapter-69-picnic-4",
"https://novelbin.me/novel-book/i-became-the-fiance-of-a-dragon-in-romance-fantasy/chapter-70-please-take-good-care-of-him",
"https://novelbin.me/novel-book/i-became-the-fiance-of-a-dragon-in-romance-fantasy/chapter-71-passion-1",
"https://novelbin.me/novel-book/i-became-the-fiance-of-a-dragon-in-romance-fantasy/chapter-72-passion-2",
"https://novelbin.me/novel-book/i-became-the-fiance-of-a-dragon-in-romance-fantasy/chapter-73-return-1",
"https://novelbin.me/novel-book/i-became-the-fiance-of-a-dragon-in-romance-fantasy/chapter-74-return-2",
"https://novelbin.me/novel-book/i-became-the-fiance-of-a-dragon-in-romance-fantasy/chapter-75-tempered-1",
"https://novelbin.me/novel-book/i-became-the-fiance-of-a-dragon-in-romance-fantasy/chapter-76-tempered-2",
"https://novelbin.me/novel-book/i-became-the-fiance-of-a-dragon-in-romance-fantasy/chapter-77-tempered-3",
"https://novelbin.me/novel-book/i-became-the-fiance-of-a-dragon-in-romance-fantasy/chapter-78-tempered-4",
"https://novelbin.me/novel-book/i-became-the-fiance-of-a-dragon-in-romance-fantasy/chapter-79-subjugation-1",
"https://novelbin.me/novel-book/i-became-the-fiance-of-a-dragon-in-romance-fantasy/chapter-80-subjugation-2",
"https://novelbin.me/novel-book/i-became-the-fiance-of-a-dragon-in-romance-fantasy/chapter-81-subjugation-3",
"https://novelbin.me/novel-book/i-became-the-fiance-of-a-dragon-in-romance-fantasy/chapter-82-take-a-break",
"https://novelbin.me/novel-book/i-became-the-fiance-of-a-dragon-in-romance-fantasy/chapter-83-subjugation-4",
"https://novelbin.me/novel-book/i-became-the-fiance-of-a-dragon-in-romance-fantasy/chapter-84-demon-king-1",
"https://novelbin.me/novel-book/i-became-the-fiance-of-a-dragon-in-romance-fantasy/chapter-85-demon-king-2",
"https://novelbin.me/novel-book/i-became-the-fiance-of-a-dragon-in-romance-fantasy/chapter-86-demon-king-3",
"https://novelbin.me/novel-book/i-became-the-fiance-of-a-dragon-in-romance-fantasy/chapter-87-previous-life-2",
"https://novelbin.me/novel-book/i-became-the-fiance-of-a-dragon-in-romance-fantasy/chapter-88-previous-life-3",
"https://novelbin.me/novel-book/i-became-the-fiance-of-a-dragon-in-romance-fantasy/chapter-89-previous-life-4",
"https://novelbin.me/novel-book/i-became-the-fiance-of-a-dragon-in-romance-fantasy/chapter-90-previous-life-5",
"https://novelbin.me/novel-book/i-became-the-fiance-of-a-dragon-in-romance-fantasy/chapter-91-travel-and-crossing-the-line-1",
"https://novelbin.me/novel-book/i-became-the-fiance-of-a-dragon-in-romance-fantasy/chapter-92-travel-and-crossing-the-line-2",
"https://novelbin.me/novel-book/i-became-the-fiance-of-a-dragon-in-romance-fantasy/chapter-93",
"https://novelbin.me/novel-book/i-became-the-fiance-of-a-dragon-in-romance-fantasy/chapter-94",
"https://novelbin.me/novel-book/i-became-the-fiance-of-a-dragon-in-romance-fantasy/chapter-95-marriage-1",
"https://novelbin.me/novel-book/i-became-the-fiance-of-a-dragon-in-romance-fantasy/chapter-96-marriage-2",
"https://novelbin.me/novel-book/i-became-the-fiance-of-a-dragon-in-romance-fantasy/chapter-97-marriage-3",
"https://novelbin.me/novel-book/i-became-the-fiance-of-a-dragon-in-romance-fantasy/chapter-98-marriage-4",
"https://novelbin.me/novel-book/i-became-the-fiance-of-a-dragon-in-romance-fantasy/chapter-99-marriage-complete",
                };

                const int chapterPerVolume = 100;

                int skip = 0;

                int volume = 1;
                int chapter = 1;
                for (int i = 0; i < urls.Length; ++i) {
                    var url = urls[i];

                    Console.WriteLine($"{url}");

                    if (i >= skip) {
                        await novelbin.DownloadChapter(url, @"D:\Visual Novels\[Self-Sourced] I Became the Fiance of a Dragon in Romance Fantasy\Raw\" + $"Volume {volume}", $"{chapter.ToString("D4")}.xhtml");
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