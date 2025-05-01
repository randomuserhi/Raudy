// Project > Properties > Change from Console Application to Windows Application when moving to production

namespace Source {
    internal class Program {
        static int Main(string[] args) {
            Task.Run(async void () => {
                DarkStarTL darkStarTL = new DarkStarTL();

                string[] urls = {
                    "https://darkstartranslations.com/series/you-were-mistaken-as-a-great-war-commander/0",
"https://darkstartranslations.com/series/you-were-mistaken-as-a-great-war-commander/1",
"https://darkstartranslations.com/series/you-were-mistaken-as-a-great-war-commander/2",
"https://darkstartranslations.com/series/you-were-mistaken-as-a-great-war-commander/3",
"https://darkstartranslations.com/series/you-were-mistaken-as-a-great-war-commander/4",
"https://darkstartranslations.com/series/you-were-mistaken-as-a-great-war-commander/5",
"https://darkstartranslations.com/series/you-were-mistaken-as-a-great-war-commander/6",
"https://darkstartranslations.com/series/you-were-mistaken-as-a-great-war-commander/7",
"https://darkstartranslations.com/series/you-were-mistaken-as-a-great-war-commander/8",
"https://darkstartranslations.com/series/you-were-mistaken-as-a-great-war-commander/9",
"https://darkstartranslations.com/series/you-were-mistaken-as-a-great-war-commander/10",
"https://darkstartranslations.com/series/you-were-mistaken-as-a-great-war-commander/11",
"https://darkstartranslations.com/series/you-were-mistaken-as-a-great-war-commander/12",
"https://darkstartranslations.com/series/you-were-mistaken-as-a-great-war-commander/13",
"https://darkstartranslations.com/series/you-were-mistaken-as-a-great-war-commander/14",
"https://darkstartranslations.com/series/you-were-mistaken-as-a-great-war-commander/15",
"https://darkstartranslations.com/series/you-were-mistaken-as-a-great-war-commander/16",
"https://darkstartranslations.com/series/you-were-mistaken-as-a-great-war-commander/17",
"https://darkstartranslations.com/series/you-were-mistaken-as-a-great-war-commander/18",
"https://darkstartranslations.com/series/you-were-mistaken-as-a-great-war-commander/19",
"https://darkstartranslations.com/series/you-were-mistaken-as-a-great-war-commander/20",
"https://darkstartranslations.com/series/you-were-mistaken-as-a-great-war-commander/21",
"https://darkstartranslations.com/series/you-were-mistaken-as-a-great-war-commander/22",
"https://darkstartranslations.com/series/you-were-mistaken-as-a-great-war-commander/23",
"https://darkstartranslations.com/series/you-were-mistaken-as-a-great-war-commander/24",
"https://darkstartranslations.com/series/you-were-mistaken-as-a-great-war-commander/25",
"https://darkstartranslations.com/series/you-were-mistaken-as-a-great-war-commander/26",
"https://darkstartranslations.com/series/you-were-mistaken-as-a-great-war-commander/27",
"https://darkstartranslations.com/series/you-were-mistaken-as-a-great-war-commander/28",
"https://darkstartranslations.com/series/you-were-mistaken-as-a-great-war-commander/29",
"https://darkstartranslations.com/series/you-were-mistaken-as-a-great-war-commander/30",
"https://darkstartranslations.com/series/you-were-mistaken-as-a-great-war-commander/31",
"https://darkstartranslations.com/series/you-were-mistaken-as-a-great-war-commander/32",
"https://darkstartranslations.com/series/you-were-mistaken-as-a-great-war-commander/33",
"https://darkstartranslations.com/series/you-were-mistaken-as-a-great-war-commander/34",
"https://darkstartranslations.com/series/you-were-mistaken-as-a-great-war-commander/35",
"https://darkstartranslations.com/series/you-were-mistaken-as-a-great-war-commander/36",
"https://darkstartranslations.com/series/you-were-mistaken-as-a-great-war-commander/37",
"https://darkstartranslations.com/series/you-were-mistaken-as-a-great-war-commander/38",
"https://darkstartranslations.com/series/you-were-mistaken-as-a-great-war-commander/39",
"https://darkstartranslations.com/series/you-were-mistaken-as-a-great-war-commander/40",
"https://darkstartranslations.com/series/you-were-mistaken-as-a-great-war-commander/41",
"https://darkstartranslations.com/series/you-were-mistaken-as-a-great-war-commander/42",
"https://darkstartranslations.com/series/you-were-mistaken-as-a-great-war-commander/43",
"https://darkstartranslations.com/series/you-were-mistaken-as-a-great-war-commander/44",
"https://darkstartranslations.com/series/you-were-mistaken-as-a-great-war-commander/45",
"https://darkstartranslations.com/series/you-were-mistaken-as-a-great-war-commander/46",
"https://darkstartranslations.com/series/you-were-mistaken-as-a-great-war-commander/47",
"https://darkstartranslations.com/series/you-were-mistaken-as-a-great-war-commander/48",
"https://darkstartranslations.com/series/you-were-mistaken-as-a-great-war-commander/49",
"https://darkstartranslations.com/series/you-were-mistaken-as-a-great-war-commander/50",
"https://darkstartranslations.com/series/you-were-mistaken-as-a-great-war-commander/51",
"https://darkstartranslations.com/series/you-were-mistaken-as-a-great-war-commander/52",
"https://darkstartranslations.com/series/you-were-mistaken-as-a-great-war-commander/53",
"https://darkstartranslations.com/series/you-were-mistaken-as-a-great-war-commander/54",
"https://darkstartranslations.com/series/you-were-mistaken-as-a-great-war-commander/55",
"https://darkstartranslations.com/series/you-were-mistaken-as-a-great-war-commander/56",
"https://darkstartranslations.com/series/you-were-mistaken-as-a-great-war-commander/57",
"https://darkstartranslations.com/series/you-were-mistaken-as-a-great-war-commander/58",
"https://darkstartranslations.com/series/you-were-mistaken-as-a-great-war-commander/59",
"https://darkstartranslations.com/series/you-were-mistaken-as-a-great-war-commander/60",
"https://darkstartranslations.com/series/you-were-mistaken-as-a-great-war-commander/61",
"https://darkstartranslations.com/series/you-were-mistaken-as-a-great-war-commander/62",
"https://darkstartranslations.com/series/you-were-mistaken-as-a-great-war-commander/63",
"https://darkstartranslations.com/series/you-were-mistaken-as-a-great-war-commander/64",
"https://darkstartranslations.com/series/you-were-mistaken-as-a-great-war-commander/65",
"https://darkstartranslations.com/series/you-were-mistaken-as-a-great-war-commander/66",
"https://darkstartranslations.com/series/you-were-mistaken-as-a-great-war-commander/67",
"https://darkstartranslations.com/series/you-were-mistaken-as-a-great-war-commander/68",
"https://darkstartranslations.com/series/you-were-mistaken-as-a-great-war-commander/69",
"https://darkstartranslations.com/series/you-were-mistaken-as-a-great-war-commander/70",
"https://darkstartranslations.com/series/you-were-mistaken-as-a-great-war-commander/71",
"https://darkstartranslations.com/series/you-were-mistaken-as-a-great-war-commander/72",
"https://darkstartranslations.com/series/you-were-mistaken-as-a-great-war-commander/73",
"https://darkstartranslations.com/series/you-were-mistaken-as-a-great-war-commander/74",
"https://darkstartranslations.com/series/you-were-mistaken-as-a-great-war-commander/75",
"https://darkstartranslations.com/series/you-were-mistaken-as-a-great-war-commander/76",
"https://darkstartranslations.com/series/you-were-mistaken-as-a-great-war-commander/77",
"https://darkstartranslations.com/series/you-were-mistaken-as-a-great-war-commander/78",
"https://darkstartranslations.com/series/you-were-mistaken-as-a-great-war-commander/79",
"https://darkstartranslations.com/series/you-were-mistaken-as-a-great-war-commander/80",
"https://darkstartranslations.com/series/you-were-mistaken-as-a-great-war-commander/81",
"https://darkstartranslations.com/series/you-were-mistaken-as-a-great-war-commander/82",
"https://darkstartranslations.com/series/you-were-mistaken-as-a-great-war-commander/83",
"https://darkstartranslations.com/series/you-were-mistaken-as-a-great-war-commander/84",
"https://darkstartranslations.com/series/you-were-mistaken-as-a-great-war-commander/85",
"https://darkstartranslations.com/series/you-were-mistaken-as-a-great-war-commander/86",
"https://darkstartranslations.com/series/you-were-mistaken-as-a-great-war-commander/87",
"https://darkstartranslations.com/series/you-were-mistaken-as-a-great-war-commander/88",
"https://darkstartranslations.com/series/you-were-mistaken-as-a-great-war-commander/89",
"https://darkstartranslations.com/series/you-were-mistaken-as-a-great-war-commander/90",
"https://darkstartranslations.com/series/you-were-mistaken-as-a-great-war-commander/91",
"https://darkstartranslations.com/series/you-were-mistaken-as-a-great-war-commander/92",
"https://darkstartranslations.com/series/you-were-mistaken-as-a-great-war-commander/93",
"https://darkstartranslations.com/series/you-were-mistaken-as-a-great-war-commander/94",
"https://darkstartranslations.com/series/you-were-mistaken-as-a-great-war-commander/95",
"https://darkstartranslations.com/series/you-were-mistaken-as-a-great-war-commander/96",
"https://darkstartranslations.com/series/you-were-mistaken-as-a-great-war-commander/97",
"https://darkstartranslations.com/series/you-were-mistaken-as-a-great-war-commander/98",
"https://darkstartranslations.com/series/you-were-mistaken-as-a-great-war-commander/99",
"https://darkstartranslations.com/series/you-were-mistaken-as-a-great-war-commander/100",
"https://darkstartranslations.com/series/you-were-mistaken-as-a-great-war-commander/101",
"https://darkstartranslations.com/series/you-were-mistaken-as-a-great-war-commander/102",
"https://darkstartranslations.com/series/you-were-mistaken-as-a-great-war-commander/103",
"https://darkstartranslations.com/series/you-were-mistaken-as-a-great-war-commander/104",
"https://darkstartranslations.com/series/you-were-mistaken-as-a-great-war-commander/105",
"https://darkstartranslations.com/series/you-were-mistaken-as-a-great-war-commander/106",
"https://darkstartranslations.com/series/you-were-mistaken-as-a-great-war-commander/107",
"https://darkstartranslations.com/series/you-were-mistaken-as-a-great-war-commander/108",
"https://darkstartranslations.com/series/you-were-mistaken-as-a-great-war-commander/109",
"https://darkstartranslations.com/series/you-were-mistaken-as-a-great-war-commander/110",
"https://darkstartranslations.com/series/you-were-mistaken-as-a-great-war-commander/111",
"https://darkstartranslations.com/series/you-were-mistaken-as-a-great-war-commander/112",
                };

                const int chapterPerVolume = 100;

                int volume = 1;
                int chapter = 1;
                foreach (string url in urls) {
                    Console.WriteLine($"{url}");
                    await darkStarTL.DownloadChapter(url, @"D:\Visual Novels\[Self-Sourced] [Ongoing] I Was Mistaken as a Great War Commander\Raw\" + $"Volume {volume}", $"{(chapter++).ToString("D4")}.xhtml");

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