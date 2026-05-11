// Project > Properties > Change from Console Application to Windows Application when moving to production

namespace Source {
    internal class Program {
        static int Main(string[] args) {
            Task.Run(async void () => {
                Novelpia novelpia = new Novelpia();

                Novelpia.SessionInfo session = await novelpia.GetSession("", "");

                string[] episodes = {
                    "586920",
"586921",
"586922",
"586923",
"586924",
"586925",
"586926",
"586927",
"586928",
"586929",
"586930",
"586932",
"586933",
"586934",
"586935",
"586936",
"586938",
"586940",
"586941",
"586942",
"586943",
"586947",
"586948",
"586949",
"586951",
"586953",
"586957",
"586958",
"586959",
"586960",
"586963",
"586964",
"586965",
"586966",
"586968",
"586969",
"586970",
"586971",
"586972",
"586974",
"586975",
"586976",
"586977",
"586982",
"586984",
"586985",
"586987",
"586989",
"586993",
"586995",
"586996",
"586997",
"587000",
"587001",
"587002",
"587003",
"587004",
"587009",
"587010",
"587012",
"587014",
"587015",
"587022",
"587024",
"587026",
"587028",
"587029",
"587033",
"587072",
"587408",
"587845",
"588412",
"588760",
"589212",
"589861",
"591251",
"591789",
"592412",
"592902",
"593571",
"594126",
"594681",
"595222",
"595827",
"596559",
"597122",
"597394",
"597964",
"598512",
"599286",
"599782",
"600258",
"601145",
"601242",
"602103",
"603329",
"608628",
"609174",
"610040",
"610388",
                };

                // I Became a Servant Obsessed Over by Dragons
                // novel_no 2504

                // The Overpowered Archmage Reveals Himself
                // novel_no 2642

                // The civil servant in a romance fantasy novel
                // novel_no = 86

                // The Side Character Is Retiring
                // novel_no = 958

                // The Imperial Princesses Are Obsessed With Their Knight
                // novel_no = 34

                const string novelNo = "3651";

                const int chapterPerVolume = 100;

                int skip = 0;

                int volume = 1;
                int chapter = 1;
                for (int i = 0; i < episodes.Length; ++i) {
                    var url = episodes[i];

                    Console.WriteLine($"{volume}:{chapter} - {url}");

                    string episodeNo = url.Split("/").Last();

                    if (i >= skip) {
                        await novelpia.DownloadChapter(session, novelNo, episodeNo, @"D:\Visual Novels\[Self-Sourced] [Novelpia] [Missing Premium] I Became the Hated Villain of the Academy\Raw\" + $"Volume {volume}", $"{chapter.ToString("D4")}.xhtml");
                    }

                    if ((++chapter) > chapterPerVolume) {
                        ++volume;
                        chapter = 1;
                    }

                    if (i >= skip) {
                        Thread.Sleep(5000); // Cloudflare rate limiting
                    }
                }

                Console.WriteLine("Done!");
            });

            Console.ReadLine();

            return 0;
        }
    }
}