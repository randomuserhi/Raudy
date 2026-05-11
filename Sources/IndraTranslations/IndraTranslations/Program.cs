// Project > Properties > Change from Console Application to Windows Application when moving to production

namespace Source {
    internal class Program {
        static int Main(string[] args) {
            Task.Run(async void () => {
                IndraTranslations indra = new IndraTranslations();
                /*
                string[] urls = {
                    "https://indratranslations.com/series/a-cadet-becomes-a-prophet/chapter-0-prologue/",
"https://indratranslations.com/series/a-cadet-becomes-a-prophet/chapter-1/",
"https://indratranslations.com/series/a-cadet-becomes-a-prophet/chapter-2/",
"https://indratranslations.com/series/a-cadet-becomes-a-prophet/chapter-3/",
"https://indratranslations.com/series/a-cadet-becomes-a-prophet/chapter-4/",
"https://indratranslations.com/series/a-cadet-becomes-a-prophet/chapter-5/",
"https://indratranslations.com/series/a-cadet-becomes-a-prophet/chapter-6/",
"https://indratranslations.com/series/a-cadet-becomes-a-prophet/chapter-7/",
"https://indratranslations.com/series/a-cadet-becomes-a-prophet/chapter-8/",
"https://indratranslations.com/series/a-cadet-becomes-a-prophet/chapter-9/",
"https://indratranslations.com/series/a-cadet-becomes-a-prophet/chapter-10/",
"https://indratranslations.com/series/a-cadet-becomes-a-prophet/chapter-11/",
"https://indratranslations.com/series/a-cadet-becomes-a-prophet/chapter-12/",
"https://indratranslations.com/series/a-cadet-becomes-a-prophet/chapter-13/",
"https://indratranslations.com/series/a-cadet-becomes-a-prophet/chapter-14/",
"https://indratranslations.com/series/a-cadet-becomes-a-prophet/chapter-15/",
"https://indratranslations.com/series/a-cadet-becomes-a-prophet/chapter-16/",
"https://indratranslations.com/series/a-cadet-becomes-a-prophet/chapter-17/",
"https://indratranslations.com/series/a-cadet-becomes-a-prophet/chapter-18/",
"https://indratranslations.com/series/a-cadet-becomes-a-prophet/chapter-19/",
"https://indratranslations.com/series/a-cadet-becomes-a-prophet/chapter-20/",
"https://indratranslations.com/series/a-cadet-becomes-a-prophet/chapter-21/",
"https://indratranslations.com/series/a-cadet-becomes-a-prophet/chapter-22/",
"https://indratranslations.com/series/a-cadet-becomes-a-prophet/chapter-23/",
"https://indratranslations.com/series/a-cadet-becomes-a-prophet/chapter-24/",
"https://indratranslations.com/series/a-cadet-becomes-a-prophet/chapter-25/",
"https://indratranslations.com/series/a-cadet-becomes-a-prophet/chapter-26/",
"https://indratranslations.com/series/a-cadet-becomes-a-prophet/chapter-27/",
"https://indratranslations.com/series/a-cadet-becomes-a-prophet/chapter-28/",
"https://indratranslations.com/series/a-cadet-becomes-a-prophet/chapter-29/",
"https://indratranslations.com/series/a-cadet-becomes-a-prophet/chapter-30/",
"https://indratranslations.com/series/a-cadet-becomes-a-prophet/chapter-31/",
"https://indratranslations.com/series/a-cadet-becomes-a-prophet/chapter-32/",
"https://indratranslations.com/series/a-cadet-becomes-a-prophet/chapter-33/",
"https://indratranslations.com/series/a-cadet-becomes-a-prophet/chapter-34/",
"https://indratranslations.com/series/a-cadet-becomes-a-prophet/chapter-35/",
"https://indratranslations.com/series/a-cadet-becomes-a-prophet/chapter-36/",
"https://indratranslations.com/series/a-cadet-becomes-a-prophet/chapter-37/",
"https://indratranslations.com/series/a-cadet-becomes-a-prophet/chapter-38/",
"https://indratranslations.com/series/a-cadet-becomes-a-prophet/chapter-39/",
"https://indratranslations.com/series/a-cadet-becomes-a-prophet/chapter-40/",
"https://indratranslations.com/series/a-cadet-becomes-a-prophet/chapter-41/",
"https://indratranslations.com/series/a-cadet-becomes-a-prophet/chapter-42/",
"https://indratranslations.com/series/a-cadet-becomes-a-prophet/chapter-43/",
"https://indratranslations.com/series/a-cadet-becomes-a-prophet/chapter-44/",
"https://indratranslations.com/series/a-cadet-becomes-a-prophet/chapter-45/",
"https://indratranslations.com/series/a-cadet-becomes-a-prophet/chapter-46/",
"https://indratranslations.com/series/a-cadet-becomes-a-prophet/chapter-47/",
"https://indratranslations.com/series/a-cadet-becomes-a-prophet/chapter-48/",
"https://indratranslations.com/series/a-cadet-becomes-a-prophet/chapter-49/",
"https://indratranslations.com/series/a-cadet-becomes-a-prophet/chapter-50/",
"https://indratranslations.com/series/a-cadet-becomes-a-prophet/chapter-51/",
"https://indratranslations.com/series/a-cadet-becomes-a-prophet/chapter-52/",
"https://indratranslations.com/series/a-cadet-becomes-a-prophet/chapter-53/",
"https://indratranslations.com/series/a-cadet-becomes-a-prophet/chapter-54/",
"https://indratranslations.com/series/a-cadet-becomes-a-prophet/chapter-55/",
"https://indratranslations.com/series/a-cadet-becomes-a-prophet/chapter-56/",
"https://indratranslations.com/series/a-cadet-becomes-a-prophet/chapter-57/",
"https://indratranslations.com/series/a-cadet-becomes-a-prophet/chapter-58/",
"https://indratranslations.com/series/a-cadet-becomes-a-prophet/chapter-59/",
"https://indratranslations.com/series/a-cadet-becomes-a-prophet/chapter-60/",
"https://indratranslations.com/series/a-cadet-becomes-a-prophet/chapter-61/",
"https://indratranslations.com/series/a-cadet-becomes-a-prophet/chapter-62/",
"https://indratranslations.com/series/a-cadet-becomes-a-prophet/chapter-63/",
"https://indratranslations.com/series/a-cadet-becomes-a-prophet/chapter-64/",
"https://indratranslations.com/series/a-cadet-becomes-a-prophet/chapter-65/",
"https://indratranslations.com/series/a-cadet-becomes-a-prophet/chapter-66/",
"https://indratranslations.com/series/a-cadet-becomes-a-prophet/chapter-67/",
"https://indratranslations.com/series/a-cadet-becomes-a-prophet/chapter-68/",
"https://indratranslations.com/series/a-cadet-becomes-a-prophet/chapter-69/",
"https://indratranslations.com/series/a-cadet-becomes-a-prophet/chapter-70/",
"https://indratranslations.com/series/a-cadet-becomes-a-prophet/chapter-71/",
"https://indratranslations.com/series/a-cadet-becomes-a-prophet/chapter-72/",
"https://indratranslations.com/series/a-cadet-becomes-a-prophet/chapter-73/",
"https://indratranslations.com/series/a-cadet-becomes-a-prophet/chapter-74/",
"https://indratranslations.com/series/a-cadet-becomes-a-prophet/chapter-75/",
"https://indratranslations.com/series/a-cadet-becomes-a-prophet/chapter-76/",
"https://indratranslations.com/series/a-cadet-becomes-a-prophet/chapter-77/",
"https://indratranslations.com/series/a-cadet-becomes-a-prophet/chapter-78/",
"https://indratranslations.com/series/a-cadet-becomes-a-prophet/chapter-79/",
"https://indratranslations.com/series/a-cadet-becomes-a-prophet/chapter-80/",
"https://indratranslations.com/series/a-cadet-becomes-a-prophet/chapter-81/",
"https://indratranslations.com/series/a-cadet-becomes-a-prophet/chapter-82/",
"https://indratranslations.com/series/a-cadet-becomes-a-prophet/chapter-83/",
"https://indratranslations.com/series/a-cadet-becomes-a-prophet/chapter-84/",
"https://indratranslations.com/series/a-cadet-becomes-a-prophet/chapter-85/",
"https://indratranslations.com/series/a-cadet-becomes-a-prophet/chapter-86/",
"https://indratranslations.com/series/a-cadet-becomes-a-prophet/chapter-87/",
"https://indratranslations.com/series/a-cadet-becomes-a-prophet/chapter-88/",
"https://indratranslations.com/series/a-cadet-becomes-a-prophet/chapter-89/",
"https://indratranslations.com/series/a-cadet-becomes-a-prophet/chapter-90/",
"https://indratranslations.com/series/a-cadet-becomes-a-prophet/chapter-91/",
"https://indratranslations.com/series/a-cadet-becomes-a-prophet/chapter-92/",
"https://indratranslations.com/series/a-cadet-becomes-a-prophet/chapter-93/",
"https://indratranslations.com/series/a-cadet-becomes-a-prophet/chapter-94/",
"https://indratranslations.com/series/a-cadet-becomes-a-prophet/chapter-95/",
"https://indratranslations.com/series/a-cadet-becomes-a-prophet/chapter-96/",
"https://indratranslations.com/series/a-cadet-becomes-a-prophet/chapter-97/",
"https://indratranslations.com/series/a-cadet-becomes-a-prophet/chapter-98/",
"https://indratranslations.com/series/a-cadet-becomes-a-prophet/chapter-99/",
"https://indratranslations.com/series/a-cadet-becomes-a-prophet/chapter-100/",
"https://indratranslations.com/series/a-cadet-becomes-a-prophet/chapter-101/",
"https://indratranslations.com/series/a-cadet-becomes-a-prophet/chapter-102/",
"https://indratranslations.com/series/a-cadet-becomes-a-prophet/chapter-103/",
"https://indratranslations.com/series/a-cadet-becomes-a-prophet/chapter-104/",
"https://indratranslations.com/series/a-cadet-becomes-a-prophet/chapter-105/",
"https://indratranslations.com/series/a-cadet-becomes-a-prophet/chapter-106/",
"https://indratranslations.com/series/a-cadet-becomes-a-prophet/chapter-107/",
"https://indratranslations.com/series/a-cadet-becomes-a-prophet/chapter-108/",
"https://indratranslations.com/series/a-cadet-becomes-a-prophet/chapter-109/",
"https://indratranslations.com/series/a-cadet-becomes-a-prophet/chapter-110/",
"https://indratranslations.com/series/a-cadet-becomes-a-prophet/chapter-111/",
"https://indratranslations.com/series/a-cadet-becomes-a-prophet/chapter-112/",
"https://indratranslations.com/series/a-cadet-becomes-a-prophet/chapter-113/",
"https://indratranslations.com/series/a-cadet-becomes-a-prophet/chapter-114/",
"https://indratranslations.com/series/a-cadet-becomes-a-prophet/chapter-115/",
"https://indratranslations.com/series/a-cadet-becomes-a-prophet/chapter-116/",
"https://indratranslations.com/series/a-cadet-becomes-a-prophet/chapter-117/",
"https://indratranslations.com/series/a-cadet-becomes-a-prophet/chapter-118/",
"https://indratranslations.com/series/a-cadet-becomes-a-prophet/chapter-119/",
"https://indratranslations.com/series/a-cadet-becomes-a-prophet/chapter-120/",
"https://indratranslations.com/series/a-cadet-becomes-a-prophet/chapter-121/",
"https://indratranslations.com/series/a-cadet-becomes-a-prophet/chapter-122/",
"https://indratranslations.com/series/a-cadet-becomes-a-prophet/chapter-123/",
"https://indratranslations.com/series/a-cadet-becomes-a-prophet/chapter-124/",
"https://indratranslations.com/series/a-cadet-becomes-a-prophet/chapter-125/",
"https://indratranslations.com/series/a-cadet-becomes-a-prophet/chapter-126/",
"https://indratranslations.com/series/a-cadet-becomes-a-prophet/chapter-127/",
"https://indratranslations.com/series/a-cadet-becomes-a-prophet/chapter-128/",
"https://indratranslations.com/series/a-cadet-becomes-a-prophet/chapter-129/",
"https://indratranslations.com/series/a-cadet-becomes-a-prophet/chapter-130/",
"https://indratranslations.com/series/a-cadet-becomes-a-prophet/chapter-131/",
"https://indratranslations.com/series/a-cadet-becomes-a-prophet/chapter-132/",
"https://indratranslations.com/series/a-cadet-becomes-a-prophet/chapter-133/",
"https://indratranslations.com/series/a-cadet-becomes-a-prophet/chapter-134/",
"https://indratranslations.com/series/a-cadet-becomes-a-prophet/chapter-135/",
"https://indratranslations.com/series/a-cadet-becomes-a-prophet/chapter-136/",
"https://indratranslations.com/series/a-cadet-becomes-a-prophet/chapter-137/",
"https://indratranslations.com/series/a-cadet-becomes-a-prophet/chapter-138/",
"https://indratranslations.com/series/a-cadet-becomes-a-prophet/chapter-139/",
"https://indratranslations.com/series/a-cadet-becomes-a-prophet/chapter-140/",
"https://indratranslations.com/series/a-cadet-becomes-a-prophet/chapter-141/",
"https://indratranslations.com/series/a-cadet-becomes-a-prophet/chapter-142/",
"https://indratranslations.com/series/a-cadet-becomes-a-prophet/chapter-143/",
"https://indratranslations.com/series/a-cadet-becomes-a-prophet/chapter-144/",
"https://indratranslations.com/series/a-cadet-becomes-a-prophet/chapter-145/",
"https://indratranslations.com/series/a-cadet-becomes-a-prophet/chapter-146/",
"https://indratranslations.com/series/a-cadet-becomes-a-prophet/chapter-147/",
"https://indratranslations.com/series/a-cadet-becomes-a-prophet/chapter-148/",
"https://indratranslations.com/series/a-cadet-becomes-a-prophet/chapter-149/",
"https://indratranslations.com/series/a-cadet-becomes-a-prophet/chapter-150/",
"https://indratranslations.com/series/a-cadet-becomes-a-prophet/chapter-151/",
"https://indratranslations.com/series/a-cadet-becomes-a-prophet/chapter-152/",
"https://indratranslations.com/series/a-cadet-becomes-a-prophet/chapter-153/",
"https://indratranslations.com/series/a-cadet-becomes-a-prophet/chapter-154/",
"https://indratranslations.com/series/a-cadet-becomes-a-prophet/chapter-155/",
"https://indratranslations.com/series/a-cadet-becomes-a-prophet/chapter-156/",
"https://indratranslations.com/series/a-cadet-becomes-a-prophet/chapter-157/",
"https://indratranslations.com/series/a-cadet-becomes-a-prophet/chapter-158/",
"https://indratranslations.com/series/a-cadet-becomes-a-prophet/chapter-159/",
"https://indratranslations.com/series/a-cadet-becomes-a-prophet/chapter-160/",
"https://indratranslations.com/series/a-cadet-becomes-a-prophet/chapter-161/",
"https://indratranslations.com/series/a-cadet-becomes-a-prophet/chapter-162/",
"https://indratranslations.com/series/a-cadet-becomes-a-prophet/chapter-163/",
"https://indratranslations.com/series/a-cadet-becomes-a-prophet/chapter-164/",
"https://indratranslations.com/series/a-cadet-becomes-a-prophet/chapter-165/",
"https://indratranslations.com/series/a-cadet-becomes-a-prophet/chapter-166/",
"https://indratranslations.com/series/a-cadet-becomes-a-prophet/chapter-167/",
"https://indratranslations.com/series/a-cadet-becomes-a-prophet/chapter-168/",
"https://indratranslations.com/series/a-cadet-becomes-a-prophet/chapter-169/",
"https://indratranslations.com/series/a-cadet-becomes-a-prophet/chapter-170/",
"https://indratranslations.com/series/a-cadet-becomes-a-prophet/chapter-171/",
"https://indratranslations.com/series/a-cadet-becomes-a-prophet/chapter-172/",
"https://indratranslations.com/series/a-cadet-becomes-a-prophet/chapter-173/",
"https://indratranslations.com/series/a-cadet-becomes-a-prophet/chapter-174/",
"https://indratranslations.com/series/a-cadet-becomes-a-prophet/chapter-175/",
"https://indratranslations.com/series/a-cadet-becomes-a-prophet/chapter-176/",
"https://indratranslations.com/series/a-cadet-becomes-a-prophet/chapter-177/",
"https://indratranslations.com/series/a-cadet-becomes-a-prophet/chapter-178/",
"https://indratranslations.com/series/a-cadet-becomes-a-prophet/chapter-179/",
"https://indratranslations.com/series/a-cadet-becomes-a-prophet/chapter-180/",
"https://indratranslations.com/series/a-cadet-becomes-a-prophet/chapter-181/",
"https://indratranslations.com/series/a-cadet-becomes-a-prophet/chapter-182/",
"https://indratranslations.com/series/a-cadet-becomes-a-prophet/chapter-183/",
                };
                */

                string[] urls = {
                    "https://indratranslations.com/series/the-despicable-villain-of-the-academy/chapter-1/",
"https://indratranslations.com/series/the-despicable-villain-of-the-academy/chapter-2/",
"https://indratranslations.com/series/the-despicable-villain-of-the-academy/chapter-3/",
"https://indratranslations.com/series/the-despicable-villain-of-the-academy/chapter-4/",
"https://indratranslations.com/series/the-despicable-villain-of-the-academy/chapter-5/",
"https://indratranslations.com/series/the-despicable-villain-of-the-academy/chapter-6/",
"https://indratranslations.com/series/the-despicable-villain-of-the-academy/chapter-7/",
"https://indratranslations.com/series/the-despicable-villain-of-the-academy/chapter-8/",
                };

                const int chapterPerVolume = 100;

                int skip = 0;

                int volume = 1;
                int chapter = 1;
                for (int i = 0; i < urls.Length; ++i) {
                    var url = urls[i];

                    Console.WriteLine($"{url}");

                    if (i >= skip) {
                        await indra.DownloadChapter(url, @"D:\Visual Novels\[Self-Sourced] [Ongoing] The Despicable Villain of the Academy\Raw\" + $"Volume {volume}", $"{chapter.ToString("D4")}.xhtml");
                    }

                    if ((++chapter) > chapterPerVolume) {
                        ++volume;
                        chapter = 1;
                    }

                    if (i >= skip) {
                        Thread.Sleep(500); // Cloudflare rate limiting
                    }
                }

                Console.WriteLine("Done!");
            });

            Console.ReadLine();

            return 0;
        }
    }
}