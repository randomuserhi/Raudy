// Project > Properties > Change from Console Application to Windows Application when moving to production

// TODO(randomuserhi): Move to use chromium, the Post request is super dodgy and fails constantly :(
//                     Only seems stable if I have a chrome tab with the website open

namespace Source {
    internal class Program {
        static int Main(string[] args) {
            Task.Run(async void () => {
                FontMapping fontMapping = new FontMapping();

                try {
                    fontMapping.Add("\n", "\n");

                    // Use a viewer like https://fontdrop.info/ and locate all characters and use a pattern:
                    {
                        for (int codePoint = 0x2010, i = 0; codePoint < 0x2F42; ++codePoint, ++i) {
                            string c = char.ConvertFromUtf32(codePoint).ToString();
                            fontMapping.Add(c, c);
                        }

                        for (int codePoint = 0x300E, i = 0; codePoint <= 0x300F; ++codePoint, ++i) {
                            string c = char.ConvertFromUtf32(codePoint).ToString();
                            fontMapping.Add(c, c);
                        }
                    }
                    {
                        string characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
                        for (int codePoint = 0x2F42, i = 0; codePoint <= 0x2F75; ++codePoint, ++i) {
                            fontMapping.Add(char.ConvertFromUtf32(codePoint).ToString(), characters[i].ToString());
                        }
                    }
                } catch (Exception ex) {
                    Console.WriteLine(ex);
                    return;
                }

                StorySeed storySeed = new StorySeed();

                string[] urls = {
                    "https://storyseedling.com/series/99893/v1/1",
                    "https://storyseedling.com/series/99893/v1/2",
                    "https://storyseedling.com/series/99893/v1/3",
                    "https://storyseedling.com/series/99893/v1/4",
                    "https://storyseedling.com/series/99893/v1/5",
                    "https://storyseedling.com/series/99893/v1/6",
                    "https://storyseedling.com/series/99893/v1/7",
                    "https://storyseedling.com/series/99893/v1/8",
                    "https://storyseedling.com/series/99893/v1/9",
                    "https://storyseedling.com/series/99893/v1/10",
                    //"https://storyseedling.com/series/99893/v1/194",
                    "https://storyseedling.com/series/99893/v2/11",
                    "https://storyseedling.com/series/99893/v2/12",
                    "https://storyseedling.com/series/99893/v2/13",
                    "https://storyseedling.com/series/99893/v2/14",
                    "https://storyseedling.com/series/99893/v2/15",
                    "https://storyseedling.com/series/99893/v2/16",
                    "https://storyseedling.com/series/99893/v2/17",
                    "https://storyseedling.com/series/99893/v2/18",
                    "https://storyseedling.com/series/99893/v2/19",
                    "https://storyseedling.com/series/99893/v2/20",
                    "https://storyseedling.com/series/99893/v2/21",
                    "https://storyseedling.com/series/99893/v2/22",
                    "https://storyseedling.com/series/99893/v2/23",
                    "https://storyseedling.com/series/99893/v2/24",
                    "https://storyseedling.com/series/99893/v2/25",
                    "https://storyseedling.com/series/99893/v2/26",
                    "https://storyseedling.com/series/99893/v2/27",
                    "https://storyseedling.com/series/99893/v2/28",
                    "https://storyseedling.com/series/99893/v2/29",
                    "https://storyseedling.com/series/99893/v3/30",
                    "https://storyseedling.com/series/99893/v3/31",
                    "https://storyseedling.com/series/99893/v3/32",
                    "https://storyseedling.com/series/99893/v3/33",
                    "https://storyseedling.com/series/99893/v3/34",
                    "https://storyseedling.com/series/99893/v3/35",
                    "https://storyseedling.com/series/99893/v3/36",
                    "https://storyseedling.com/series/99893/v3/37",
                    "https://storyseedling.com/series/99893/v3/38",
                    "https://storyseedling.com/series/99893/v3/39",
                    "https://storyseedling.com/series/99893/v3/40",
                    "https://storyseedling.com/series/99893/v3/41",
                    "https://storyseedling.com/series/99893/v3/42",
                    "https://storyseedling.com/series/99893/v3/43",
                    "https://storyseedling.com/series/99893/v3/44",
                    "https://storyseedling.com/series/99893/v3/45",
                    "https://storyseedling.com/series/99893/v3/46",
                    "https://storyseedling.com/series/99893/v3/47",
                    "https://storyseedling.com/series/99893/v3/48",
                    "https://storyseedling.com/series/99893/v3/49",
                    "https://storyseedling.com/series/99893/v3/50",
                    "https://storyseedling.com/series/99893/v3/51",
                    "https://storyseedling.com/series/99893/v3/52",
                    "https://storyseedling.com/series/99893/v3/53",
                    "https://storyseedling.com/series/99893/v4/54",
                    "https://storyseedling.com/series/99893/v4/55",
                    "https://storyseedling.com/series/99893/v4/56",
                    "https://storyseedling.com/series/99893/v4/57",
                    "https://storyseedling.com/series/99893/v4/58",
                    "https://storyseedling.com/series/99893/v4/59",
                    "https://storyseedling.com/series/99893/v4/60",
                    "https://storyseedling.com/series/99893/v4/61",
                    "https://storyseedling.com/series/99893/v4/62",
                    "https://storyseedling.com/series/99893/v4/63",
                    "https://storyseedling.com/series/99893/v4/64",
                    "https://storyseedling.com/series/99893/v4/65",
                    "https://storyseedling.com/series/99893/v4/66",
                    "https://storyseedling.com/series/99893/v4/67",
                    "https://storyseedling.com/series/99893/v4/68",
                    "https://storyseedling.com/series/99893/v4/69",
                    "https://storyseedling.com/series/99893/v4/70",
                    "https://storyseedling.com/series/99893/v4/71",
                    "https://storyseedling.com/series/99893/v4/72",
                    "https://storyseedling.com/series/99893/v4/73",
                    "https://storyseedling.com/series/99893/v4/74",
                    "https://storyseedling.com/series/99893/v4/75",
                    "https://storyseedling.com/series/99893/v4/76",
                    "https://storyseedling.com/series/99893/v5/77",
                    "https://storyseedling.com/series/99893/v5/78",
                    "https://storyseedling.com/series/99893/v5/79",
                    "https://storyseedling.com/series/99893/v5/80",
                    "https://storyseedling.com/series/99893/v5/81",
                    "https://storyseedling.com/series/99893/v5/82",
                    "https://storyseedling.com/series/99893/v5/83",
                    "https://storyseedling.com/series/99893/v5/84",
                    "https://storyseedling.com/series/99893/v5/85",
                    "https://storyseedling.com/series/99893/v5/86",
                    "https://storyseedling.com/series/99893/v5/87",
                    "https://storyseedling.com/series/99893/v5/88",
                    "https://storyseedling.com/series/99893/v5/89",
                    "https://storyseedling.com/series/99893/v5/90",
                    "https://storyseedling.com/series/99893/v5/91",
                    "https://storyseedling.com/series/99893/v5/92",
                    "https://storyseedling.com/series/99893/v5/93",
                    "https://storyseedling.com/series/99893/v5/94",
                    "https://storyseedling.com/series/99893/v5/95",
                    "https://storyseedling.com/series/99893/v5/96",
                    "https://storyseedling.com/series/99893/v5/97",
                    "https://storyseedling.com/series/99893/v5/98",
                    "https://storyseedling.com/series/99893/v5/99",
                    "https://storyseedling.com/series/99893/v5/100",
                    "https://storyseedling.com/series/99893/v5/101",
                    "https://storyseedling.com/series/99893/v5/102",
                    "https://storyseedling.com/series/99893/v5/103",
                    "https://storyseedling.com/series/99893/v6/104",
                    "https://storyseedling.com/series/99893/v6/105",
                    "https://storyseedling.com/series/99893/v6/106",
                    "https://storyseedling.com/series/99893/v6/107",
                    "https://storyseedling.com/series/99893/v6/108",
                    "https://storyseedling.com/series/99893/v6/109",
                    "https://storyseedling.com/series/99893/v6/110",
                    "https://storyseedling.com/series/99893/v6/111",
                    "https://storyseedling.com/series/99893/v6/112",
                    "https://storyseedling.com/series/99893/v6/113",
                    "https://storyseedling.com/series/99893/v6/114",
                    "https://storyseedling.com/series/99893/v6/115",
                    "https://storyseedling.com/series/99893/v6/116",
                    "https://storyseedling.com/series/99893/v6/117",
                    "https://storyseedling.com/series/99893/v6/118",
                    "https://storyseedling.com/series/99893/v6/119",
                    "https://storyseedling.com/series/99893/v6/120",
                    "https://storyseedling.com/series/99893/v6/121",
                    "https://storyseedling.com/series/99893/v6/122",
                    "https://storyseedling.com/series/99893/v6/123",
                    "https://storyseedling.com/series/99893/v6/124",
                    "https://storyseedling.com/series/99893/v6/125",
                    "https://storyseedling.com/series/99893/v6/126",
                    "https://storyseedling.com/series/99893/v6/127",
                    "https://storyseedling.com/series/99893/v6/128",
                    "https://storyseedling.com/series/99893/v6/129",
                    "https://storyseedling.com/series/99893/v6/130",
                    "https://storyseedling.com/series/99893/v6/131",
                    "https://storyseedling.com/series/99893/v6/132",

                    /*"https://storyseedling.com/series/99893/v6/133",
                    "https://storyseedling.com/series/99893/v6/134",
                    "https://storyseedling.com/series/99893/v6/135",
                    "https://storyseedling.com/series/99893/v6/136",
                    "https://storyseedling.com/series/99893/v6/137",
                    "https://storyseedling.com/series/99893/v6/138",
                    "https://storyseedling.com/series/99893/v6/139",
                    "https://storyseedling.com/series/99893/v6/140",
                    "https://storyseedling.com/series/99893/v6/141",
                    "https://storyseedling.com/series/99893/v6/142",
                    "https://storyseedling.com/series/99893/v6/143",
                    "https://storyseedling.com/series/99893/v6/144",
                    "https://storyseedling.com/series/99893/v6/145",
                    "https://storyseedling.com/series/99893/v6/146",
                    "https://storyseedling.com/series/99893/v6/147",
                    "https://storyseedling.com/series/99893/v6/148",
                    "https://storyseedling.com/series/99893/v6/149",
                    "https://storyseedling.com/series/99893/v6/150",
                    "https://storyseedling.com/series/99893/v6/151",
                    "https://storyseedling.com/series/99893/v6/152",
                    "https://storyseedling.com/series/99893/v6/153",
                    "https://storyseedling.com/series/99893/v6/154",
                    "https://storyseedling.com/series/99893/v6/155",
                    "https://storyseedling.com/series/99893/v6/156",
                    "https://storyseedling.com/series/99893/v6/157",
                    "https://storyseedling.com/series/99893/v6/158",
                    "https://storyseedling.com/series/99893/v6/159",
                    "https://storyseedling.com/series/99893/v6/160",
                    "https://storyseedling.com/series/99893/v6/161",
                    "https://storyseedling.com/series/99893/v6/162",
                    "https://storyseedling.com/series/99893/v6/163",
                    "https://storyseedling.com/series/99893/v6/164",
                    "https://storyseedling.com/series/99893/v6/165",
                    "https://storyseedling.com/series/99893/v6/166",
                    "https://storyseedling.com/series/99893/v6/167",
                    "https://storyseedling.com/series/99893/v6/168",
                    "https://storyseedling.com/series/99893/v6/169",
                    "https://storyseedling.com/series/99893/v6/170",
                    "https://storyseedling.com/series/99893/v6/171",
                    "https://storyseedling.com/series/99893/v6/172",
                    "https://storyseedling.com/series/99893/v6/173",
                    "https://storyseedling.com/series/99893/v6/174",
                    "https://storyseedling.com/series/99893/v6/175",
                    "https://storyseedling.com/series/99893/v6/176",
                    "https://storyseedling.com/series/99893/v6/177",
                    "https://storyseedling.com/series/99893/v6/178",
                    "https://storyseedling.com/series/99893/v6/179",
                    "https://storyseedling.com/series/99893/v6/180",
                    "https://storyseedling.com/series/99893/v6/181",
                    "https://storyseedling.com/series/99893/v6/182",
                    "https://storyseedling.com/series/99893/v6/183",
                    "https://storyseedling.com/series/99893/v6/184",
                    "https://storyseedling.com/series/99893/v6/185",
                    "https://storyseedling.com/series/99893/v6/186",
                    "https://storyseedling.com/series/99893/v6/187",
                    "https://storyseedling.com/series/99893/v6/188",
                    "https://storyseedling.com/series/99893/v6/189",
                    "https://storyseedling.com/series/99893/v6/190",
                    "https://storyseedling.com/series/99893/v6/191",
                    "https://storyseedling.com/series/99893/v6/192",
                    "https://storyseedling.com/series/99893/v6/193",
                    "https://storyseedling.com/series/99893/v6/194",
                    "https://storyseedling.com/series/99893/v6/195",
                    "https://storyseedling.com/series/99893/v6/196",*/
                };

                Random r = new Random();

                const int chapterPerVolume = 100;

                int skip = 50;

                int volume = 1;
                int chapter = skip + 1;
                for (int i = skip; i < urls.Length; ++i) {
                    string url = urls[i];
                    Console.WriteLine($"{url}");
                    if (!await storySeed.DownloadChapter(url, @"D:\Visual Novels\[Self-Sourced] [Ongoing] Lazy Villainous and The Villainess Daughter\Raw\" + $"Volume {volume}", $"{(chapter++).ToString("D4")}.xhtml", fontMapping)) {
                        throw new Exception("Dead");
                    }

                    if (chapter > chapterPerVolume) {
                        ++volume;
                        chapter = 1;
                    }

                    Thread.Sleep(5000); // Cloudflare rate limiting
                }

                Console.WriteLine("Done!");
            });

            Console.ReadLine();

            return 0;
        }
    }
}