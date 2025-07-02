// Project > Properties > Change from Console Application to Windows Application when moving to production

using System;
using System.Threading;
using System.Threading.Tasks;

namespace Source {
    internal class Program {
        static int Main(string[] args) {
            Task.Run(async () => {
                StoneScape stoneScape = new StoneScape();

                string[] urls = {
                    "https://stonescape.xyz/series/villainess-guardian/ch-1/",
                "https://stonescape.xyz/series/villainess-guardian/ch-2/",
                "https://stonescape.xyz/series/villainess-guardian/ch-3/",
                "https://stonescape.xyz/series/villainess-guardian/ch-4/",
                "https://stonescape.xyz/series/villainess-guardian/ch-5/",
                "https://stonescape.xyz/series/villainess-guardian/ch-6/",
                "https://stonescape.xyz/series/villainess-guardian/ch-7/",
                "https://stonescape.xyz/series/villainess-guardian/ch-8/",
                "https://stonescape.xyz/series/villainess-guardian/ch-9/",
                "https://stonescape.xyz/series/villainess-guardian/ch-10/",
                "https://stonescape.xyz/series/villainess-guardian/ch-11/",
                "https://stonescape.xyz/series/villainess-guardian/ch-12/",
                "https://stonescape.xyz/series/villainess-guardian/ch-13/",
                "https://stonescape.xyz/series/villainess-guardian/ch-14/",
                "https://stonescape.xyz/series/villainess-guardian/ch-15/",
                "https://stonescape.xyz/series/villainess-guardian/ch-16/",
                "https://stonescape.xyz/series/villainess-guardian/ch-17/",
                "https://stonescape.xyz/series/villainess-guardian/ch-18/",
                "https://stonescape.xyz/series/villainess-guardian/ch-19/",
                "https://stonescape.xyz/series/villainess-guardian/ch-20/",
                "https://stonescape.xyz/series/villainess-guardian/ch-21/",
                "https://stonescape.xyz/series/villainess-guardian/ch-22/",
                "https://stonescape.xyz/series/villainess-guardian/ch-23/",
                "https://stonescape.xyz/series/villainess-guardian/ch-24/",
                "https://stonescape.xyz/series/villainess-guardian/ch-25/",
                "https://stonescape.xyz/series/villainess-guardian/ch-26/",
                "https://stonescape.xyz/series/villainess-guardian/ch-27/",
                "https://stonescape.xyz/series/villainess-guardian/ch-28/",
                "https://stonescape.xyz/series/villainess-guardian/ch-29/",
                "https://stonescape.xyz/series/villainess-guardian/ch-30/",
                "https://stonescape.xyz/series/villainess-guardian/ch-31/",
                "https://stonescape.xyz/series/villainess-guardian/ch-32/",
                "https://stonescape.xyz/series/villainess-guardian/ch-33/",
                "https://stonescape.xyz/series/villainess-guardian/ch-34/",
                "https://stonescape.xyz/series/villainess-guardian/ch-35/",
                "https://stonescape.xyz/series/villainess-guardian/ch-36/",
                "https://stonescape.xyz/series/villainess-guardian/ch-37/",
                "https://stonescape.xyz/series/villainess-guardian/ch-38/",
                "https://stonescape.xyz/series/villainess-guardian/ch-39/",
                "https://stonescape.xyz/series/villainess-guardian/ch-40/",
                "https://stonescape.xyz/series/villainess-guardian/ch-41/",
                "https://stonescape.xyz/series/villainess-guardian/ch-42/",
                "https://stonescape.xyz/series/villainess-guardian/ch-43/",
                "https://stonescape.xyz/series/villainess-guardian/ch-44/",
                "https://stonescape.xyz/series/villainess-guardian/ch-45/",
                "https://stonescape.xyz/series/villainess-guardian/ch-46/",
                "https://stonescape.xyz/series/villainess-guardian/ch-47/",
                "https://stonescape.xyz/series/villainess-guardian/ch-48/",
                "https://stonescape.xyz/series/villainess-guardian/ch-49/",
                "https://stonescape.xyz/series/villainess-guardian/ch-50/",
                "https://stonescape.xyz/series/villainess-guardian/ch-51/",
                "https://stonescape.xyz/series/villainess-guardian/ch-52/",
                "https://stonescape.xyz/series/villainess-guardian/ch-53/",
                "https://stonescape.xyz/series/villainess-guardian/ch-54/",
                "https://stonescape.xyz/series/villainess-guardian/ch-55/",
                "https://stonescape.xyz/series/villainess-guardian/ch-56/",
                "https://stonescape.xyz/series/villainess-guardian/ch-57/",
                "https://stonescape.xyz/series/villainess-guardian/ch-58/",
                "https://stonescape.xyz/series/villainess-guardian/ch-59/",
                "https://stonescape.xyz/series/villainess-guardian/ch-60/",
                "https://stonescape.xyz/series/villainess-guardian/ch-61/",
                "https://stonescape.xyz/series/villainess-guardian/ch-62/",
                "https://stonescape.xyz/series/villainess-guardian/ch-63/",
                "https://stonescape.xyz/series/villainess-guardian/ch-64/",
                "https://stonescape.xyz/series/villainess-guardian/ch-65/",
                "https://stonescape.xyz/series/villainess-guardian/ch-66/",
                "https://stonescape.xyz/series/villainess-guardian/ch-67/",
                "https://stonescape.xyz/series/villainess-guardian/ch-68/",
                "https://stonescape.xyz/series/villainess-guardian/ch-69/",
                "https://stonescape.xyz/series/villainess-guardian/ch-70/",
                "https://stonescape.xyz/series/villainess-guardian/ch-71/",
                "https://stonescape.xyz/series/villainess-guardian/ch-72/",
                "https://stonescape.xyz/series/villainess-guardian/ch-73/",
                "https://stonescape.xyz/series/villainess-guardian/ch-74/",
                "https://stonescape.xyz/series/villainess-guardian/ch-75/",
                "https://stonescape.xyz/series/villainess-guardian/ch-76/",
                "https://stonescape.xyz/series/villainess-guardian/ch-77/",
                "https://stonescape.xyz/series/villainess-guardian/ch-78/",
                "https://stonescape.xyz/series/villainess-guardian/ch-79/",
                "https://stonescape.xyz/series/villainess-guardian/ch-80/",
                "https://stonescape.xyz/series/villainess-guardian/ch-81/",
                "https://stonescape.xyz/series/villainess-guardian/ch-82/",
                "https://stonescape.xyz/series/villainess-guardian/ch-83/",
                "https://stonescape.xyz/series/villainess-guardian/ch-84/",
                "https://stonescape.xyz/series/villainess-guardian/ch-85/",
                "https://stonescape.xyz/series/villainess-guardian/ch-86/",
                "https://stonescape.xyz/series/villainess-guardian/ch-87/",
                "https://stonescape.xyz/series/villainess-guardian/ch-88/",
                "https://stonescape.xyz/series/villainess-guardian/ch-89/",
                "https://stonescape.xyz/series/villainess-guardian/ch-90/",
                "https://stonescape.xyz/series/villainess-guardian/ch-91/",
                "https://stonescape.xyz/series/villainess-guardian/ch-92/",
                "https://stonescape.xyz/series/villainess-guardian/ch-93/",
                "https://stonescape.xyz/series/villainess-guardian/ch-94/",
                "https://stonescape.xyz/series/villainess-guardian/ch-95/",
                "https://stonescape.xyz/series/villainess-guardian/ch-96/",
                "https://stonescape.xyz/series/villainess-guardian/ch-97/",
                "https://stonescape.xyz/series/villainess-guardian/ch-98/",
                "https://stonescape.xyz/series/villainess-guardian/ch-99/",
                "https://stonescape.xyz/series/villainess-guardian/ch-100/",
                "https://stonescape.xyz/series/villainess-guardian/ch-101/",
                "https://stonescape.xyz/series/villainess-guardian/ch-102/",
                "https://stonescape.xyz/series/villainess-guardian/ch-103/",
                "https://stonescape.xyz/series/villainess-guardian/ch-104/",
                "https://stonescape.xyz/series/villainess-guardian/ch-105/",
                "https://stonescape.xyz/series/villainess-guardian/ch-106/",
                "https://stonescape.xyz/series/villainess-guardian/ch-107/",
                "https://stonescape.xyz/series/villainess-guardian/ch-108/",
                "https://stonescape.xyz/series/villainess-guardian/ch-109/",
                "https://stonescape.xyz/series/villainess-guardian/ch-110/",
                "https://stonescape.xyz/series/villainess-guardian/ch-111/",
                "https://stonescape.xyz/series/villainess-guardian/ch-112/",
                "https://stonescape.xyz/series/villainess-guardian/ch-113/",
                "https://stonescape.xyz/series/villainess-guardian/ch-114/",
                "https://stonescape.xyz/series/villainess-guardian/ch-115/",
                "https://stonescape.xyz/series/villainess-guardian/ch-116/",
                "https://stonescape.xyz/series/villainess-guardian/ch-117/",
                "https://stonescape.xyz/series/villainess-guardian/ch-118/",
                "https://stonescape.xyz/series/villainess-guardian/ch-119/",
                "https://stonescape.xyz/series/villainess-guardian/ch-120/",
                "https://stonescape.xyz/series/villainess-guardian/ch-121/",
                "https://stonescape.xyz/series/villainess-guardian/ch-122/",
                "https://stonescape.xyz/series/villainess-guardian/ch-123/",
                "https://stonescape.xyz/series/villainess-guardian/ch-124/",
                "https://stonescape.xyz/series/villainess-guardian/ch-125/",
                "https://stonescape.xyz/series/villainess-guardian/ch-126/",
                "https://stonescape.xyz/series/villainess-guardian/ch-127/",
                "https://stonescape.xyz/series/villainess-guardian/ch-128/",
                "https://stonescape.xyz/series/villainess-guardian/ch-129/",
                "https://stonescape.xyz/series/villainess-guardian/ch-130/",
                "https://stonescape.xyz/series/villainess-guardian/ch-131/",
                "https://stonescape.xyz/series/villainess-guardian/ch-132/",
                "https://stonescape.xyz/series/villainess-guardian/ch-133/",
                "https://stonescape.xyz/series/villainess-guardian/ch-134/",
                "https://stonescape.xyz/series/villainess-guardian/ch-135/",
                "https://stonescape.xyz/series/villainess-guardian/ch-136/",
                "https://stonescape.xyz/series/villainess-guardian/ch-137/",
                "https://stonescape.xyz/series/villainess-guardian/ch-138/",
                "https://stonescape.xyz/series/villainess-guardian/ch-139/",
                "https://stonescape.xyz/series/villainess-guardian/ch-140/",
                "https://stonescape.xyz/series/villainess-guardian/ch-141/",
                "https://stonescape.xyz/series/villainess-guardian/ch-142/",
                "https://stonescape.xyz/series/villainess-guardian/ch-143/",
                "https://stonescape.xyz/series/villainess-guardian/ch-144/",
                "https://stonescape.xyz/series/villainess-guardian/ch-145/",
                "https://stonescape.xyz/series/villainess-guardian/ch-146/",
                "https://stonescape.xyz/series/villainess-guardian/ch-147/",
                "https://stonescape.xyz/series/villainess-guardian/ch-148/",
                "https://stonescape.xyz/series/villainess-guardian/ch-149/",
                "https://stonescape.xyz/series/villainess-guardian/ch-150/",
                "https://stonescape.xyz/series/villainess-guardian/ch-151/",
                "https://stonescape.xyz/series/villainess-guardian/ch-152/",
                "https://stonescape.xyz/series/villainess-guardian/ch-153/",
                "https://stonescape.xyz/series/villainess-guardian/ch-154/",
                "https://stonescape.xyz/series/villainess-guardian/ch-155/",
                "https://stonescape.xyz/series/villainess-guardian/ch-156/",
                "https://stonescape.xyz/series/villainess-guardian/ch-157/",
                "https://stonescape.xyz/series/villainess-guardian/ch-158/",
                "https://stonescape.xyz/series/villainess-guardian/ch-159/",
                "https://stonescape.xyz/series/villainess-guardian/ch-160/",
                "https://stonescape.xyz/series/villainess-guardian/ch-161/",
                "https://stonescape.xyz/series/villainess-guardian/ch-162/",
                "https://stonescape.xyz/series/villainess-guardian/ch-163/",
                "https://stonescape.xyz/series/villainess-guardian/ch-164/",
                "https://stonescape.xyz/series/villainess-guardian/ch-165/",
                "https://stonescape.xyz/series/villainess-guardian/ch-166/",
                "https://stonescape.xyz/series/villainess-guardian/ch-167-side-story/",
                "https://stonescape.xyz/series/villainess-guardian/ch-168-side-story/",
                "https://stonescape.xyz/series/villainess-guardian/ch-169-side-story/",
                "https://stonescape.xyz/series/villainess-guardian/ch-170-side-story/",
                };

                const int chapterPerVolume = 100;

                int skip = 51;

                int volume = 1;
                int chapter = skip + 1;
                for (int i = skip; i < urls.Length; ++i) {
                    string url = urls[i];
                    Console.WriteLine($"{url}");
                    // NOTE(randomuserhi): Use webarchive for Extra C as it got removed somewhere along the line
                    await stoneScape.DownloadChapter($"{url}", @"D:\Visual Novels\[Self-Sourced] [Ongoing] Villainess Guardian\Raw\" + $"Volume {volume}", $"{(chapter++).ToString("D4")}.xhtml");

                    if (chapter > chapterPerVolume) {
                        ++volume;
                        chapter = 1;
                    }

                    Thread.Sleep(5000); // Cloudflare rate limiting
                }

                stoneScape.Dispose();
                Console.WriteLine("Done!");
            });

            Console.ReadLine();

            return 0;
        }
    }
}