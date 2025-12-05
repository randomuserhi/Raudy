// Project > Properties > Change from Console Application to Windows Application when moving to production

namespace Source {
    internal class Program {
        static int Main(string[] args) {
            Task.Run(async void () => {
                Novelpia novelpia = new Novelpia();

                Novelpia.SessionInfo session = await novelpia.GetSession("", "");

                string[] episodes = {"222485",
"222492",
"222514",
"222528",
"222542",
"222557",
"222572",
"222588",
"222604",
"222620",
"222633",
"222656",
"222673",
"222690",
"222704",
"222718",
"222734",
"222751",
"222764",
"222784",
"222795",
"222809",
"222824",
"222839",
"222855",
"222870",
"222885",
"222898",
"222911",
"222925",
"222942",
"222954",
"222972",
"222985",
"223005",
"223019",
"223035",
"223050",
"223067",
"223086",
"223104",
"223117",
"223132",
"223148",
"223161",
"223174",
"223189",
"223203",
"223222",
"223235",
"223252",
"223271",
"223286",
"223317",
"223334",
"223349",
"223366",
"223382",
"223397",
"223408",
"223425",
"223444",
"223460",
"223477",
"223494",
"223510",
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

                const string novelNo = "1068";

                const int chapterPerVolume = 100;

                int skip = 0;

                int volume = 1;
                int chapter = 1;
                for (int i = 0; i < episodes.Length; ++i) {
                    var url = episodes[i];

                    Console.WriteLine($"{volume}:{chapter} - {url}");

                    string episodeNo = url.Split("/").Last();

                    if (i >= skip) {
                        await novelpia.DownloadChapter(session, novelNo, episodeNo, @"D:\Visual Novels\[Self-Sourced] [Novelpia] [Missing Premium] The rescued villains are obssessed with me\Raw\" + $"Volume {volume}", $"{chapter.ToString("D4")}.xhtml");
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