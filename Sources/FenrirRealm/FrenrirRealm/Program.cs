// Project > Properties > Change from Console Application to Windows Application when moving to production

namespace Source {
    internal class Program {
        static int Main(string[] args) {
            Task.Run(async void () => {
                FrenrirRealm frenrirRealm = new FrenrirRealm();

                string[] urls = {
                    "https://fenrirealm.com/series/academy-s-villain-professor/1",
                    "https://fenrirealm.com/series/academy-s-villain-professor/2",
                    "https://fenrirealm.com/series/academy-s-villain-professor/3",
                    "https://fenrirealm.com/series/academy-s-villain-professor/4",
                    "https://fenrirealm.com/series/academy-s-villain-professor/5",
                    "https://fenrirealm.com/series/academy-s-villain-professor/6",
                    "https://fenrirealm.com/series/academy-s-villain-professor/7",
                    "https://fenrirealm.com/series/academy-s-villain-professor/8",
                    "https://fenrirealm.com/series/academy-s-villain-professor/9",
                    "https://fenrirealm.com/series/academy-s-villain-professor/10",
                    "https://fenrirealm.com/series/academy-s-villain-professor/11",
                    "https://fenrirealm.com/series/academy-s-villain-professor/12",
                    "https://fenrirealm.com/series/academy-s-villain-professor/13",
                    "https://fenrirealm.com/series/academy-s-villain-professor/14",
                    "https://fenrirealm.com/series/academy-s-villain-professor/15",
                    "https://fenrirealm.com/series/academy-s-villain-professor/16",
                    "https://fenrirealm.com/series/academy-s-villain-professor/17",
                    "https://fenrirealm.com/series/academy-s-villain-professor/18",
                    "https://fenrirealm.com/series/academy-s-villain-professor/19",
                    "https://fenrirealm.com/series/academy-s-villain-professor/20",
                    "https://fenrirealm.com/series/academy-s-villain-professor/21",
                    "https://fenrirealm.com/series/academy-s-villain-professor/22",
                    "https://fenrirealm.com/series/academy-s-villain-professor/23",
                    "https://fenrirealm.com/series/academy-s-villain-professor/24",
                    "https://fenrirealm.com/series/academy-s-villain-professor/25",
                    "https://fenrirealm.com/series/academy-s-villain-professor/26",
                    "https://fenrirealm.com/series/academy-s-villain-professor/27",
                    "https://fenrirealm.com/series/academy-s-villain-professor/28",
                    "https://fenrirealm.com/series/academy-s-villain-professor/29",
                    "https://fenrirealm.com/series/academy-s-villain-professor/30",
                    "https://fenrirealm.com/series/academy-s-villain-professor/31",
                    "https://fenrirealm.com/series/academy-s-villain-professor/32",
                    "https://fenrirealm.com/series/academy-s-villain-professor/33",
                    "https://fenrirealm.com/series/academy-s-villain-professor/34",
                    "https://fenrirealm.com/series/academy-s-villain-professor/35",
                    "https://fenrirealm.com/series/academy-s-villain-professor/36",
                    "https://fenrirealm.com/series/academy-s-villain-professor/37",
                    "https://fenrirealm.com/series/academy-s-villain-professor/38",
                    "https://fenrirealm.com/series/academy-s-villain-professor/39",
                    "https://fenrirealm.com/series/academy-s-villain-professor/40",
                    "https://fenrirealm.com/series/academy-s-villain-professor/41",
                    "https://fenrirealm.com/series/academy-s-villain-professor/42",
                    "https://fenrirealm.com/series/academy-s-villain-professor/43",
                    "https://fenrirealm.com/series/academy-s-villain-professor/44",
                    "https://fenrirealm.com/series/academy-s-villain-professor/45",
                    "https://fenrirealm.com/series/academy-s-villain-professor/46",
                    "https://fenrirealm.com/series/academy-s-villain-professor/47",
                    "https://fenrirealm.com/series/academy-s-villain-professor/48",
                    "https://fenrirealm.com/series/academy-s-villain-professor/49",
                    "https://fenrirealm.com/series/academy-s-villain-professor/50",
                    "https://fenrirealm.com/series/academy-s-villain-professor/51",
                    "https://fenrirealm.com/series/academy-s-villain-professor/52",
                    "https://fenrirealm.com/series/academy-s-villain-professor/53",
                    "https://fenrirealm.com/series/academy-s-villain-professor/54",
                    "https://fenrirealm.com/series/academy-s-villain-professor/55",
                    "https://fenrirealm.com/series/academy-s-villain-professor/56",
                    "https://fenrirealm.com/series/academy-s-villain-professor/57",
                    "https://fenrirealm.com/series/academy-s-villain-professor/58",
                    "https://fenrirealm.com/series/academy-s-villain-professor/59",
                    "https://fenrirealm.com/series/academy-s-villain-professor/60",
                    "https://fenrirealm.com/series/academy-s-villain-professor/61",
                    "https://fenrirealm.com/series/academy-s-villain-professor/62",
                    "https://fenrirealm.com/series/academy-s-villain-professor/63",
                    "https://fenrirealm.com/series/academy-s-villain-professor/64",
                    "https://fenrirealm.com/series/academy-s-villain-professor/65",
                    "https://fenrirealm.com/series/academy-s-villain-professor/66",
                    "https://fenrirealm.com/series/academy-s-villain-professor/67",
                    "https://fenrirealm.com/series/academy-s-villain-professor/68",
                    "https://fenrirealm.com/series/academy-s-villain-professor/69",
                    "https://fenrirealm.com/series/academy-s-villain-professor/70",
                    "https://fenrirealm.com/series/academy-s-villain-professor/71",
                    "https://fenrirealm.com/series/academy-s-villain-professor/72",
                    "https://fenrirealm.com/series/academy-s-villain-professor/73",
                    "https://fenrirealm.com/series/academy-s-villain-professor/74",
                    "https://fenrirealm.com/series/academy-s-villain-professor/75",
                    "https://fenrirealm.com/series/academy-s-villain-professor/76",
                    "https://fenrirealm.com/series/academy-s-villain-professor/77",
                    "https://fenrirealm.com/series/academy-s-villain-professor/78",
                    "https://fenrirealm.com/series/academy-s-villain-professor/79",
                    "https://fenrirealm.com/series/academy-s-villain-professor/80",
                    "https://fenrirealm.com/series/academy-s-villain-professor/81",
                    "https://fenrirealm.com/series/academy-s-villain-professor/82",
                    "https://fenrirealm.com/series/academy-s-villain-professor/83",
                    "https://fenrirealm.com/series/academy-s-villain-professor/84",
                    "https://fenrirealm.com/series/academy-s-villain-professor/85",
                    "https://fenrirealm.com/series/academy-s-villain-professor/86",
                    "https://fenrirealm.com/series/academy-s-villain-professor/87",
                    "https://fenrirealm.com/series/academy-s-villain-professor/88",
                    "https://fenrirealm.com/series/academy-s-villain-professor/89",
                    "https://fenrirealm.com/series/academy-s-villain-professor/90",
                    "https://fenrirealm.com/series/academy-s-villain-professor/91",
                    "https://fenrirealm.com/series/academy-s-villain-professor/92",
                    "https://fenrirealm.com/series/academy-s-villain-professor/93",
                    "https://fenrirealm.com/series/academy-s-villain-professor/94",
                    "https://fenrirealm.com/series/academy-s-villain-professor/95",
                    "https://fenrirealm.com/series/academy-s-villain-professor/96",
                    "https://fenrirealm.com/series/academy-s-villain-professor/97",
                    "https://fenrirealm.com/series/academy-s-villain-professor/98",
                    "https://fenrirealm.com/series/academy-s-villain-professor/99",
                    "https://fenrirealm.com/series/academy-s-villain-professor/100",
                    "https://fenrirealm.com/series/academy-s-villain-professor/101",
                    "https://fenrirealm.com/series/academy-s-villain-professor/102",
                    "https://fenrirealm.com/series/academy-s-villain-professor/103",
                    "https://fenrirealm.com/series/academy-s-villain-professor/104",
                    "https://fenrirealm.com/series/academy-s-villain-professor/105",
                    "https://fenrirealm.com/series/academy-s-villain-professor/106",
                    "https://fenrirealm.com/series/academy-s-villain-professor/107",
                    "https://fenrirealm.com/series/academy-s-villain-professor/108",
                    "https://fenrirealm.com/series/academy-s-villain-professor/109",
                    "https://fenrirealm.com/series/academy-s-villain-professor/110",
                    "https://fenrirealm.com/series/academy-s-villain-professor/111",
                    "https://fenrirealm.com/series/academy-s-villain-professor/112",
                    "https://fenrirealm.com/series/academy-s-villain-professor/113",
                    "https://fenrirealm.com/series/academy-s-villain-professor/114",
                    "https://fenrirealm.com/series/academy-s-villain-professor/115",
                    "https://fenrirealm.com/series/academy-s-villain-professor/116",
                    "https://fenrirealm.com/series/academy-s-villain-professor/117",
                    "https://fenrirealm.com/series/academy-s-villain-professor/118",
                    "https://fenrirealm.com/series/academy-s-villain-professor/119",
                    "https://fenrirealm.com/series/academy-s-villain-professor/120",
                    "https://fenrirealm.com/series/academy-s-villain-professor/121",
                    "https://fenrirealm.com/series/academy-s-villain-professor/122",
                    "https://fenrirealm.com/series/academy-s-villain-professor/123",
                    "https://fenrirealm.com/series/academy-s-villain-professor/124",
                    "https://fenrirealm.com/series/academy-s-villain-professor/125",
                    "https://fenrirealm.com/series/academy-s-villain-professor/126",
                    "https://fenrirealm.com/series/academy-s-villain-professor/127",
                    "https://fenrirealm.com/series/academy-s-villain-professor/128",
                    "https://fenrirealm.com/series/academy-s-villain-professor/129",
                    "https://fenrirealm.com/series/academy-s-villain-professor/130",
                    "https://fenrirealm.com/series/academy-s-villain-professor/131",
                    "https://fenrirealm.com/series/academy-s-villain-professor/132",
                    "https://fenrirealm.com/series/academy-s-villain-professor/133",
                    "https://fenrirealm.com/series/academy-s-villain-professor/134",
                    "https://fenrirealm.com/series/academy-s-villain-professor/135",
                    "https://fenrirealm.com/series/academy-s-villain-professor/136",
                    "https://fenrirealm.com/series/academy-s-villain-professor/137",
                    "https://fenrirealm.com/series/academy-s-villain-professor/138",
                    "https://fenrirealm.com/series/academy-s-villain-professor/139",
                    "https://fenrirealm.com/series/academy-s-villain-professor/140",
                    "https://fenrirealm.com/series/academy-s-villain-professor/141",
                    "https://fenrirealm.com/series/academy-s-villain-professor/142",
                    "https://fenrirealm.com/series/academy-s-villain-professor/143",
                    "https://fenrirealm.com/series/academy-s-villain-professor/144",
                    "https://fenrirealm.com/series/academy-s-villain-professor/145",
                    "https://fenrirealm.com/series/academy-s-villain-professor/146",
                    "https://fenrirealm.com/series/academy-s-villain-professor/147",
                    "https://fenrirealm.com/series/academy-s-villain-professor/148",
                    "https://fenrirealm.com/series/academy-s-villain-professor/149",
                    "https://fenrirealm.com/series/academy-s-villain-professor/150",
                    "https://fenrirealm.com/series/academy-s-villain-professor/151",
                    "https://fenrirealm.com/series/academy-s-villain-professor/152",
                    "https://fenrirealm.com/series/academy-s-villain-professor/153",
                    "https://fenrirealm.com/series/academy-s-villain-professor/154",
                    "https://fenrirealm.com/series/academy-s-villain-professor/155",
                    "https://fenrirealm.com/series/academy-s-villain-professor/156",
                    "https://fenrirealm.com/series/academy-s-villain-professor/157",
                    "https://fenrirealm.com/series/academy-s-villain-professor/158",
                    "https://fenrirealm.com/series/academy-s-villain-professor/159",
                    "https://fenrirealm.com/series/academy-s-villain-professor/160",
                    "https://fenrirealm.com/series/academy-s-villain-professor/161",
                    "https://fenrirealm.com/series/academy-s-villain-professor/162",
                    "https://fenrirealm.com/series/academy-s-villain-professor/163",
                    "https://fenrirealm.com/series/academy-s-villain-professor/164",
                    "https://fenrirealm.com/series/academy-s-villain-professor/165",
                    "https://fenrirealm.com/series/academy-s-villain-professor/166",
                    "https://fenrirealm.com/series/academy-s-villain-professor/167",
                    "https://fenrirealm.com/series/academy-s-villain-professor/168",
                    "https://fenrirealm.com/series/academy-s-villain-professor/169",
                    "https://fenrirealm.com/series/academy-s-villain-professor/170",
                    "https://fenrirealm.com/series/academy-s-villain-professor/171",
                    "https://fenrirealm.com/series/academy-s-villain-professor/172",
                    "https://fenrirealm.com/series/academy-s-villain-professor/173",
                    "https://fenrirealm.com/series/academy-s-villain-professor/174",
                    "https://fenrirealm.com/series/academy-s-villain-professor/175",
                    "https://fenrirealm.com/series/academy-s-villain-professor/176",
                    "https://fenrirealm.com/series/academy-s-villain-professor/177",
                    "https://fenrirealm.com/series/academy-s-villain-professor/178",
                    "https://fenrirealm.com/series/academy-s-villain-professor/179",
                    "https://fenrirealm.com/series/academy-s-villain-professor/180",
                    "https://fenrirealm.com/series/academy-s-villain-professor/181",
                    "https://fenrirealm.com/series/academy-s-villain-professor/182",
                };

                const int chapterPerVolume = 100;

                int skip = 169;

                int volume = 1;
                int chapter = 1;
                for (int i = 0; i < urls.Length; ++i) {
                    var url = urls[i];

                    Console.WriteLine($"{url}");

                    if (i >= skip) {
                        await frenrirRealm.DownloadChapter(url, @"D:\Visual Novels\[Self-Sourced] [Ongoing] Academy's Villain Professor\Raw\" + $"Volume {volume}", $"{chapter.ToString("D4")}.xhtml");
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