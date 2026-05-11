// Project > Properties > Change from Console Application to Windows Application when moving to production

namespace Source {
    internal class Program {
        static int Main(string[] args) {
            Task.Run(async void () => {
                GenesisStudio genesisStudio = new GenesisStudio();

                GenesisStudio.SessionInfo session = await genesisStudio.GetSession("", "");

                string[] episodes = {
                "https://genesistudio.com/viewer/8810",
"https://genesistudio.com/viewer/8811",
"https://genesistudio.com/viewer/8812",
"https://genesistudio.com/viewer/8813",
"https://genesistudio.com/viewer/8814",
"https://genesistudio.com/viewer/8815",
"https://genesistudio.com/viewer/8816",
"https://genesistudio.com/viewer/8817",
"https://genesistudio.com/viewer/8818",
"https://genesistudio.com/viewer/8819",
"https://genesistudio.com/viewer/8820",
"https://genesistudio.com/viewer/8821",
"https://genesistudio.com/viewer/8822",
"https://genesistudio.com/viewer/8823",
"https://genesistudio.com/viewer/8824",
"https://genesistudio.com/viewer/8825",
"https://genesistudio.com/viewer/8826",
"https://genesistudio.com/viewer/8827",
"https://genesistudio.com/viewer/8828",
"https://genesistudio.com/viewer/8829",
"https://genesistudio.com/viewer/60036",
"https://genesistudio.com/viewer/60312",
"https://genesistudio.com/viewer/60313",
"https://genesistudio.com/viewer/60314",
"https://genesistudio.com/viewer/60315",
"https://genesistudio.com/viewer/60316",
"https://genesistudio.com/viewer/60317",
"https://genesistudio.com/viewer/60318",
"https://genesistudio.com/viewer/60319",
"https://genesistudio.com/viewer/60320",
"https://genesistudio.com/viewer/60321",
"https://genesistudio.com/viewer/60322",
"https://genesistudio.com/viewer/60323",
"https://genesistudio.com/viewer/60324",
"https://genesistudio.com/viewer/60325",
"https://genesistudio.com/viewer/60326",
"https://genesistudio.com/viewer/60327",
"https://genesistudio.com/viewer/60328",
"https://genesistudio.com/viewer/60329",
"https://genesistudio.com/viewer/60330",
"https://genesistudio.com/viewer/60331",
"https://genesistudio.com/viewer/60332",
"https://genesistudio.com/viewer/60333",
"https://genesistudio.com/viewer/60334",
"https://genesistudio.com/viewer/60335",
"https://genesistudio.com/viewer/60336",
"https://genesistudio.com/viewer/60337",
"https://genesistudio.com/viewer/60338",
"https://genesistudio.com/viewer/60339",
"https://genesistudio.com/viewer/60340",
"https://genesistudio.com/viewer/60341",
"https://genesistudio.com/viewer/60342",
"https://genesistudio.com/viewer/60343",
"https://genesistudio.com/viewer/60344",
"https://genesistudio.com/viewer/60345",
"https://genesistudio.com/viewer/60346",
"https://genesistudio.com/viewer/60347",
"https://genesistudio.com/viewer/60348",
"https://genesistudio.com/viewer/60349",
"https://genesistudio.com/viewer/60350",
"https://genesistudio.com/viewer/60351",
"https://genesistudio.com/viewer/60352",
"https://genesistudio.com/viewer/60353",
"https://genesistudio.com/viewer/60354",
"https://genesistudio.com/viewer/60355",
"https://genesistudio.com/viewer/60356",
"https://genesistudio.com/viewer/60357",
"https://genesistudio.com/viewer/60358",
"https://genesistudio.com/viewer/60359",
"https://genesistudio.com/viewer/60360",
"https://genesistudio.com/viewer/60361",
"https://genesistudio.com/viewer/60363",
"https://genesistudio.com/viewer/60398",
"https://genesistudio.com/viewer/60399",
"https://genesistudio.com/viewer/60400",
"https://genesistudio.com/viewer/60401",
"https://genesistudio.com/viewer/60460",
"https://genesistudio.com/viewer/60461",
"https://genesistudio.com/viewer/60462",
"https://genesistudio.com/viewer/60463",
"https://genesistudio.com/viewer/60464",
"https://genesistudio.com/viewer/60465",
"https://genesistudio.com/viewer/60466",
"https://genesistudio.com/viewer/60548",
"https://genesistudio.com/viewer/60549",
"https://genesistudio.com/viewer/60550",
"https://genesistudio.com/viewer/60551",
"https://genesistudio.com/viewer/60791",
"https://genesistudio.com/viewer/60792",
"https://genesistudio.com/viewer/60793",
"https://genesistudio.com/viewer/60794",
"https://genesistudio.com/viewer/60807",
"https://genesistudio.com/viewer/60809",
"https://genesistudio.com/viewer/60808",
"https://genesistudio.com/viewer/60811",
"https://genesistudio.com/viewer/60828",
"https://genesistudio.com/viewer/60829",
"https://genesistudio.com/viewer/60830",
"https://genesistudio.com/viewer/60831",
"https://genesistudio.com/viewer/60883",
"https://genesistudio.com/viewer/60884",
"https://genesistudio.com/viewer/60885",
"https://genesistudio.com/viewer/60886",
"https://genesistudio.com/viewer/60908",
"https://genesistudio.com/viewer/60909",
"https://genesistudio.com/viewer/60910",
"https://genesistudio.com/viewer/60911",
"https://genesistudio.com/viewer/60913",
"https://genesistudio.com/viewer/60914",
"https://genesistudio.com/viewer/60915",
"https://genesistudio.com/viewer/60916",
"https://genesistudio.com/viewer/60917",
"https://genesistudio.com/viewer/60918",
"https://genesistudio.com/viewer/60919",
"https://genesistudio.com/viewer/60920",
"https://genesistudio.com/viewer/60921",
"https://genesistudio.com/viewer/60922",
"https://genesistudio.com/viewer/60923",
"https://genesistudio.com/viewer/60924",
"https://genesistudio.com/viewer/60925",
"https://genesistudio.com/viewer/60926",
"https://genesistudio.com/viewer/60991",
"https://genesistudio.com/viewer/60992",
"https://genesistudio.com/viewer/60993",
"https://genesistudio.com/viewer/60994",
"https://genesistudio.com/viewer/60995",
"https://genesistudio.com/viewer/60996",
"https://genesistudio.com/viewer/61001",
"https://genesistudio.com/viewer/61002",
"https://genesistudio.com/viewer/61003",
                };

                const int chapterPerVolume = 100;

                int skip = 0;

                int volume = 1;
                int chapter = 1;
                for (int i = 0; i < episodes.Length; ++i) {
                    var url = episodes[i];

                    Console.WriteLine($"{volume}:{chapter} - {url}");

                    string episodeNo = url.Split("/").Last();

                    if (i >= skip) {
                        await genesisStudio.DownloadChapter(session, episodeNo, @"D:\Visual Novels\[Self-Sourced] [Missing Premium] A Third Son's Unlucky Rise to Prominence\Raw\" + $"Volume {volume}", $"{chapter.ToString("D4")}.xhtml");
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