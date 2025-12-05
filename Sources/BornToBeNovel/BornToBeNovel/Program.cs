// Project > Properties > Change from Console Application to Windows Application when moving to production

namespace Source {
    internal class Program {
        static int Main(string[] args) {
            Task.Run(async void () => {
                BornToBeNovel bornToBeNovel = new BornToBeNovel();

                string[] urls = {
                    "https://www.borntobenovel.com/novel/i-became-the-academys-joke-character/chapters/ch-1",
                    "https://www.borntobenovel.com/novel/i-became-the-academys-joke-character/chapters/ch-2",
                    "https://www.borntobenovel.com/novel/i-became-the-academys-joke-character/chapters/ch-3",
                    "https://www.borntobenovel.com/novel/i-became-the-academys-joke-character/chapters/ch-4",
                    "https://www.borntobenovel.com/novel/i-became-the-academys-joke-character/chapters/ch-5",
                    "https://www.borntobenovel.com/novel/i-became-the-academys-joke-character/chapters/ch-6",
                    "https://www.borntobenovel.com/novel/i-became-the-academys-joke-character/chapters/ch-7",
                    "https://www.borntobenovel.com/novel/i-became-the-academys-joke-character/chapters/ch-8",
                    "https://www.borntobenovel.com/novel/i-became-the-academys-joke-character/chapters/ch-9",
                    "https://www.borntobenovel.com/novel/i-became-the-academys-joke-character/chapters/ch-10",
                    "https://www.borntobenovel.com/novel/i-became-the-academys-joke-character/chapters/ch-11",
                    "https://www.borntobenovel.com/novel/i-became-the-academys-joke-character/chapters/ch-12",
                    "https://www.borntobenovel.com/novel/i-became-the-academys-joke-character/chapters/ch-13",
                    "https://www.borntobenovel.com/novel/i-became-the-academys-joke-character/chapters/ch-14",
                    "https://www.borntobenovel.com/novel/i-became-the-academys-joke-character/chapters/ch-15",
                    "https://www.borntobenovel.com/novel/i-became-the-academys-joke-character/chapters/ch-16",
                    "https://www.borntobenovel.com/novel/i-became-the-academys-joke-character/chapters/ch-17",
                    "https://www.borntobenovel.com/novel/i-became-the-academys-joke-character/chapters/ch-18",
                    "https://www.borntobenovel.com/novel/i-became-the-academys-joke-character/chapters/ch-19",
                    "https://www.borntobenovel.com/novel/i-became-the-academys-joke-character/chapters/ch-20",
                    "https://www.borntobenovel.com/novel/i-became-the-academys-joke-character/chapters/ch-21",
                    "https://www.borntobenovel.com/novel/i-became-the-academys-joke-character/chapters/ch-22",
                    "https://www.borntobenovel.com/novel/i-became-the-academys-joke-character/chapters/ch-23",
                    "https://www.borntobenovel.com/novel/i-became-the-academys-joke-character/chapters/ch-24",
                    "https://www.borntobenovel.com/novel/i-became-the-academys-joke-character/chapters/ch-25",
                    "https://www.borntobenovel.com/novel/i-became-the-academys-joke-character/chapters/ch-26",
                    "https://www.borntobenovel.com/novel/i-became-the-academys-joke-character/chapters/ch-27",
                    "https://www.borntobenovel.com/novel/i-became-the-academys-joke-character/chapters/ch-28",
                    "https://www.borntobenovel.com/novel/i-became-the-academys-joke-character/chapters/ch-29",
                    "https://www.borntobenovel.com/novel/i-became-the-academys-joke-character/chapters/ch-30",
                    "https://www.borntobenovel.com/novel/i-became-the-academys-joke-character/chapters/ch-31",
                    "https://www.borntobenovel.com/novel/i-became-the-academys-joke-character/chapters/ch-32",
                    "https://www.borntobenovel.com/novel/i-became-the-academys-joke-character/chapters/ch-33",
                    "https://www.borntobenovel.com/novel/i-became-the-academys-joke-character/chapters/ch-34",
                    "https://www.borntobenovel.com/novel/i-became-the-academys-joke-character/chapters/ch-35",
                    "https://www.borntobenovel.com/novel/i-became-the-academys-joke-character/chapters/ch-36",
                    "https://www.borntobenovel.com/novel/i-became-the-academys-joke-character/chapters/ch-37",
                    "https://www.borntobenovel.com/novel/i-became-the-academys-joke-character/chapters/ch-38",
                    "https://www.borntobenovel.com/novel/i-became-the-academys-joke-character/chapters/ch-39",
                    "https://www.borntobenovel.com/novel/i-became-the-academys-joke-character/chapters/ch-40",
                    "https://www.borntobenovel.com/novel/i-became-the-academys-joke-character/chapters/ch-41",
                    "https://www.borntobenovel.com/novel/i-became-the-academys-joke-character/chapters/ch-42",
                    "https://www.borntobenovel.com/novel/i-became-the-academys-joke-character/chapters/ch-43",
                    "https://www.borntobenovel.com/novel/i-became-the-academys-joke-character/chapters/ch-44",
                    "https://www.borntobenovel.com/novel/i-became-the-academys-joke-character/chapters/ch-45",
                    "https://www.borntobenovel.com/novel/i-became-the-academys-joke-character/chapters/ch-46",
                    "https://www.borntobenovel.com/novel/i-became-the-academys-joke-character/chapters/ch-47",
                    "https://www.borntobenovel.com/novel/i-became-the-academys-joke-character/chapters/ch-48",
                    "https://www.borntobenovel.com/novel/i-became-the-academys-joke-character/chapters/ch-49",
                    "https://www.borntobenovel.com/novel/i-became-the-academys-joke-character/chapters/ch-50",
                    "https://www.borntobenovel.com/novel/i-became-the-academys-joke-character/chapters/ch-51",
                    "https://www.borntobenovel.com/novel/i-became-the-academys-joke-character/chapters/ch-52",
                    "https://www.borntobenovel.com/novel/i-became-the-academys-joke-character/chapters/ch-53",
                    "https://www.borntobenovel.com/novel/i-became-the-academys-joke-character/chapters/ch-54",
                    "https://www.borntobenovel.com/novel/i-became-the-academys-joke-character/chapters/ch-55",
                    "https://www.borntobenovel.com/novel/i-became-the-academys-joke-character/chapters/ch-56",
                    "https://www.borntobenovel.com/novel/i-became-the-academys-joke-character/chapters/ch-57",
                    "https://www.borntobenovel.com/novel/i-became-the-academys-joke-character/chapters/ch-58",
                    "https://www.borntobenovel.com/novel/i-became-the-academys-joke-character/chapters/ch-59",
                    "https://www.borntobenovel.com/novel/i-became-the-academys-joke-character/chapters/ch-60",
                    "https://www.borntobenovel.com/novel/i-became-the-academys-joke-character/chapters/ch-61",
                    "https://www.borntobenovel.com/novel/i-became-the-academys-joke-character/chapters/ch-62",
                    "https://www.borntobenovel.com/novel/i-became-the-academys-joke-character/chapters/ch-63",
                    "https://www.borntobenovel.com/novel/i-became-the-academys-joke-character/chapters/ch-64",
                    "https://www.borntobenovel.com/novel/i-became-the-academys-joke-character/chapters/ch-65",
                    "https://www.borntobenovel.com/novel/i-became-the-academys-joke-character/chapters/ch-66",
                    "https://www.borntobenovel.com/novel/i-became-the-academys-joke-character/chapters/ch-67",
                    "https://www.borntobenovel.com/novel/i-became-the-academys-joke-character/chapters/ch-68",
                    "https://www.borntobenovel.com/novel/i-became-the-academys-joke-character/chapters/ch-69",
                    "https://www.borntobenovel.com/novel/i-became-the-academys-joke-character/chapters/ch-70",
                    "https://www.borntobenovel.com/novel/i-became-the-academys-joke-character/chapters/ch-71",
                    "https://www.borntobenovel.com/novel/i-became-the-academys-joke-character/chapters/ch-72",
                    "https://www.borntobenovel.com/novel/i-became-the-academys-joke-character/chapters/ch-73",
                    "https://www.borntobenovel.com/novel/i-became-the-academys-joke-character/chapters/ch-74",
                    "https://www.borntobenovel.com/novel/i-became-the-academys-joke-character/chapters/ch-75",
                    "https://www.borntobenovel.com/novel/i-became-the-academys-joke-character/chapters/ch-76",
                    "https://www.borntobenovel.com/novel/i-became-the-academys-joke-character/chapters/ch-77",
                    "https://www.borntobenovel.com/novel/i-became-the-academys-joke-character/chapters/ch-78",
                    "https://www.borntobenovel.com/novel/i-became-the-academys-joke-character/chapters/ch-79",
                    "https://www.borntobenovel.com/novel/i-became-the-academys-joke-character/chapters/ch-80",
                    "https://www.borntobenovel.com/novel/i-became-the-academys-joke-character/chapters/ch-81",
                    "https://www.borntobenovel.com/novel/i-became-the-academys-joke-character/chapters/ch-82",
                    "https://www.borntobenovel.com/novel/i-became-the-academys-joke-character/chapters/ch-83",
                    "https://www.borntobenovel.com/novel/i-became-the-academys-joke-character/chapters/ch-84",
                    "https://www.borntobenovel.com/novel/i-became-the-academys-joke-character/chapters/ch-85",
                    "https://www.borntobenovel.com/novel/i-became-the-academys-joke-character/chapters/ch-86",
                    "https://www.borntobenovel.com/novel/i-became-the-academys-joke-character/chapters/ch-87",
                    "https://www.borntobenovel.com/novel/i-became-the-academys-joke-character/chapters/ch-88",
                    "https://www.borntobenovel.com/novel/i-became-the-academys-joke-character/chapters/ch-89",
                    "https://www.borntobenovel.com/novel/i-became-the-academys-joke-character/chapters/ch-90",
                    "https://www.borntobenovel.com/novel/i-became-the-academys-joke-character/chapters/ch-91",
                    "https://www.borntobenovel.com/novel/i-became-the-academys-joke-character/chapters/ch-92",
                    "https://www.borntobenovel.com/novel/i-became-the-academys-joke-character/chapters/ch-93",
                    "https://www.borntobenovel.com/novel/i-became-the-academys-joke-character/chapters/ch-94",
                    "https://www.borntobenovel.com/novel/i-became-the-academys-joke-character/chapters/ch-95",
                    "https://www.borntobenovel.com/novel/i-became-the-academys-joke-character/chapters/ch-96",
                    "https://www.borntobenovel.com/novel/i-became-the-academys-joke-character/chapters/ch-97",
                    "https://www.borntobenovel.com/novel/i-became-the-academys-joke-character/chapters/ch-98",
                    "https://www.borntobenovel.com/novel/i-became-the-academys-joke-character/chapters/ch-99",
                    "https://www.borntobenovel.com/novel/i-became-the-academys-joke-character/chapters/ch-100",
                    "https://www.borntobenovel.com/novel/i-became-the-academys-joke-character/chapters/ch-101",
                    "https://www.borntobenovel.com/novel/i-became-the-academys-joke-character/chapters/ch-102",
                    "https://www.borntobenovel.com/novel/i-became-the-academys-joke-character/chapters/ch-103",
                    "https://www.borntobenovel.com/novel/i-became-the-academys-joke-character/chapters/ch-104",
                    "https://www.borntobenovel.com/novel/i-became-the-academys-joke-character/chapters/ch-105",
                    "https://www.borntobenovel.com/novel/i-became-the-academys-joke-character/chapters/ch-106",
                    "https://www.borntobenovel.com/novel/i-became-the-academys-joke-character/chapters/ch-107",
                    "https://www.borntobenovel.com/novel/i-became-the-academys-joke-character/chapters/ch-108",
                    "https://www.borntobenovel.com/novel/i-became-the-academys-joke-character/chapters/ch-109",
                    "https://www.borntobenovel.com/novel/i-became-the-academys-joke-character/chapters/ch-110",
                    "https://www.borntobenovel.com/novel/i-became-the-academys-joke-character/chapters/ch-111",
                    "https://www.borntobenovel.com/novel/i-became-the-academys-joke-character/chapters/ch-112",
                    "https://www.borntobenovel.com/novel/i-became-the-academys-joke-character/chapters/ch-113",
                    "https://www.borntobenovel.com/novel/i-became-the-academys-joke-character/chapters/ch-114",
                    "https://www.borntobenovel.com/novel/i-became-the-academys-joke-character/chapters/ch-115",
                    "https://www.borntobenovel.com/novel/i-became-the-academys-joke-character/chapters/ch-116",
                    "https://www.borntobenovel.com/novel/i-became-the-academys-joke-character/chapters/ch-117",
                    "https://www.borntobenovel.com/novel/i-became-the-academys-joke-character/chapters/ch-118",
                    "https://www.borntobenovel.com/novel/i-became-the-academys-joke-character/chapters/ch-119",
                    "https://www.borntobenovel.com/novel/i-became-the-academys-joke-character/chapters/ch-120",
                    "https://www.borntobenovel.com/novel/i-became-the-academys-joke-character/chapters/ch-121",
                    "https://www.borntobenovel.com/novel/i-became-the-academys-joke-character/chapters/ch-122",
                    "https://www.borntobenovel.com/novel/i-became-the-academys-joke-character/chapters/ch-123",
                    "https://www.borntobenovel.com/novel/i-became-the-academys-joke-character/chapters/ch-124",
                    "https://www.borntobenovel.com/novel/i-became-the-academys-joke-character/chapters/ch-125",
                    "https://www.borntobenovel.com/novel/i-became-the-academys-joke-character/chapters/ch-126",
                    "https://www.borntobenovel.com/novel/i-became-the-academys-joke-character/chapters/ch-127",
                    "https://www.borntobenovel.com/novel/i-became-the-academys-joke-character/chapters/ch-128",
                    "https://www.borntobenovel.com/novel/i-became-the-academys-joke-character/chapters/ch-129",
                    "https://www.borntobenovel.com/novel/i-became-the-academys-joke-character/chapters/ch-130",
                    "https://www.borntobenovel.com/novel/i-became-the-academys-joke-character/chapters/ch-131",
                    "https://www.borntobenovel.com/novel/i-became-the-academys-joke-character/chapters/ch-132",
                    "https://www.borntobenovel.com/novel/i-became-the-academys-joke-character/chapters/ch-133",
                    "https://www.borntobenovel.com/novel/i-became-the-academys-joke-character/chapters/ch-134",
                    "https://www.borntobenovel.com/novel/i-became-the-academys-joke-character/chapters/ch-135",
                    "https://www.borntobenovel.com/novel/i-became-the-academys-joke-character/chapters/ch-136",
                    "https://www.borntobenovel.com/novel/i-became-the-academys-joke-character/chapters/ch-137",
                    "https://www.borntobenovel.com/novel/i-became-the-academys-joke-character/chapters/ch-138",
                    "https://www.borntobenovel.com/novel/i-became-the-academys-joke-character/chapters/ch-139",
                    "https://www.borntobenovel.com/novel/i-became-the-academys-joke-character/chapters/ch-140",
                    "https://www.borntobenovel.com/novel/i-became-the-academys-joke-character/chapters/ch-141",
                    "https://www.borntobenovel.com/novel/i-became-the-academys-joke-character/chapters/ch-142",
                    "https://www.borntobenovel.com/novel/i-became-the-academys-joke-character/chapters/ch-143",
                    "https://www.borntobenovel.com/novel/i-became-the-academys-joke-character/chapters/ch-144",
                    "https://www.borntobenovel.com/novel/i-became-the-academys-joke-character/chapters/ch-145",
                    "https://www.borntobenovel.com/novel/i-became-the-academys-joke-character/chapters/ch-146",
                    "https://www.borntobenovel.com/novel/i-became-the-academys-joke-character/chapters/ch-147",
                    "https://www.borntobenovel.com/novel/i-became-the-academys-joke-character/chapters/ch-148",
                    "https://www.borntobenovel.com/novel/i-became-the-academys-joke-character/chapters/ch-149",
                };

                const int chapterPerVolume = 100;

                int skip = 0;

                int volume = 1;
                int chapter = 1;
                for (int i = 0; i < urls.Length; ++i) {
                    var url = urls[i];

                    Console.WriteLine($"{url}");

                    if (i >= skip) {
                        await bornToBeNovel.DownloadChapter(url, @"D:\Visual Novels\[Self-Sourced] [Missing Premium] Academy Joke Character\Raw\" + $"Volume {volume}", $"{chapter.ToString("D4")}.xhtml");
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