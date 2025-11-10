// Project > Properties > Change from Console Application to Windows Application when moving to production

namespace Source {
    internal class Program {
        static int Main(string[] args) {
            Task.Run(async void () => {
                Mosshy mosshy = new Mosshy();

                string[] urls = {
"https://mosshytranslations.id/living-with-the-arrogant-queen-from-high-school-is-surprisingly-not-uncomfortable-chapter-1/",
"https://mosshytranslations.id/living-with-the-arrogant-queen-from-high-school-is-surprisingly-not-uncomfortable-chapter-2/",
"https://mosshytranslations.id/living-with-the-arrogant-queen-from-high-school-is-surprisingly-not-uncomfortable-chapter-3/",
"https://mosshytranslations.id/living-with-the-arrogant-queen-from-high-school-is-surprisingly-not-uncomfortable-chapter-4/",
"https://mosshytranslations.id/living-with-the-arrogant-queen-from-high-school-is-surprisingly-not-uncomfortable-chapter-5/",
"https://mosshytranslations.id/living-with-the-arrogant-queen-from-high-school-is-surprisingly-not-uncomfortable-chapter-6/",
"https://mosshytranslations.id/living-with-the-arrogant-queen-from-high-school-is-surprisingly-not-uncomfortable-chapter-7/",
"https://mosshytranslations.id/living-with-the-arrogant-queen-from-high-school-is-surprisingly-not-uncomfortable-chapter-8/",
"https://mosshytranslations.id/living-with-the-arrogant-queen-from-high-school-is-surprisingly-not-uncomfortable-chapter-9/",
"https://mosshytranslations.id/living-with-the-arrogant-queen-from-high-school-is-surprisingly-not-uncomfortable-chapter-10/",
"https://mosshytranslations.id/living-with-the-arrogant-queen-from-high-school-is-surprisingly-not-uncomfortable-chapter-11/",
"https://mosshytranslations.id/living-with-the-arrogant-queen-from-high-school-is-surprisingly-not-uncomfortable-chapter-12/",
"https://mosshytranslations.id/living-with-the-arrogant-queen-from-high-school-is-surprisingly-not-uncomfortable-chapter-13/",
"https://mosshytranslations.id/living-with-the-arrogant-queen-from-high-school-is-surprisingly-not-uncomfortable-chapter-14/",
"https://mosshytranslations.id/living-with-the-arrogant-queen-from-high-school-is-surprisingly-not-uncomfortable-chapter-15/",
"https://mosshytranslations.id/living-with-the-arrogant-queen-from-high-school-is-surprisingly-not-uncomfortable-chapter-16/",
"https://mosshytranslations.id/living-with-the-arrogant-queen-from-high-school-is-surprisingly-not-uncomfortable-chapter-17/",
"https://mosshytranslations.id/living-with-the-arrogant-queen-from-high-school-is-surprisingly-not-uncomfortable-chapter-18/",
"https://mosshytranslations.id/living-with-the-arrogant-queen-from-high-school-is-surprisingly-not-uncomfortable-chapter-19/",
"https://mosshytranslations.id/living-with-the-arrogant-queen-from-high-school-is-surprisingly-not-uncomfortable-chapter-20/",
"https://mosshytranslations.id/living-with-the-arrogant-queen-from-high-school-is-surprisingly-not-uncomfortable-chapter-21/",
"https://mosshytranslations.id/living-with-the-arrogant-queen-from-high-school-is-surprisingly-not-uncomfortable-chapter-22/",
"https://mosshytranslations.id/living-with-the-arrogant-queen-from-high-school-is-surprisingly-not-uncomfortable-chapter-23/",
"https://mosshytranslations.id/living-with-the-arrogant-queen-from-high-school-is-surprisingly-not-uncomfortable-chapter-24/",
"https://mosshytranslations.id/living-with-the-arrogant-queen-from-high-school-is-surprisingly-not-uncomfortable-chapter-25/",
"https://mosshytranslations.id/living-with-the-arrogant-queen-from-high-school-is-surprisingly-not-uncomfortable-chapter-26/",
"https://mosshytranslations.id/living-with-the-arrogant-queen-from-high-school-is-surprisingly-not-uncomfortable-chapter-27/",
"https://mosshytranslations.id/living-with-the-arrogant-queen-from-high-school-is-surprisingly-not-uncomfortable-chapter-28/",
"https://mosshytranslations.id/living-with-the-arrogant-queen-from-high-school-is-surprisingly-not-uncomfortable-chapter-29/",
"https://mosshytranslations.id/living-with-the-arrogant-queen-from-high-school-is-surprisingly-not-uncomfortable-chapter-30/",
"https://mosshytranslations.id/living-with-the-arrogant-queen-from-high-school-is-surprisingly-not-uncomfortable-chapter-31/",
"https://mosshytranslations.id/living-with-the-arrogant-queen-from-high-school-is-surprisingly-not-uncomfortable-chapter-32/",
"https://mosshytranslations.id/living-with-the-arrogant-queen-from-high-school-is-surprisingly-not-uncomfortable-chapter-33/",
"https://mosshytranslations.id/living-with-the-arrogant-queen-from-high-school-is-surprisingly-not-uncomfortable-chapter-34/",
"https://mosshytranslations.id/living-with-the-arrogant-queen-from-high-school-is-surprisingly-not-uncomfortable-chapter-35/",
"https://mosshytranslations.id/living-with-the-arrogant-queen-from-high-school-is-surprisingly-not-uncomfortable-chapter-36/",
"https://mosshytranslations.id/living-with-the-arrogant-queen-from-high-school-is-surprisingly-not-uncomfortable-chapter-37/",
"https://mosshytranslations.id/living-with-the-arrogant-queen-from-high-school-is-surprisingly-not-uncomfortable-chapter-38/",
"https://mosshytranslations.id/living-with-the-arrogant-queen-from-high-school-is-surprisingly-not-uncomfortable-chapter-39/",
"https://mosshytranslations.id/living-with-the-arrogant-queen-from-high-school-is-surprisingly-not-uncomfortable-chapter-40/",
"https://mosshytranslations.id/living-with-the-arrogant-queen-from-high-school-is-surprisingly-not-uncomfortable-chapter-41/",
"https://mosshytranslations.id/living-with-the-arrogant-queen-from-high-school-is-surprisingly-not-uncomfortable-chapter-42/",
"https://mosshytranslations.id/living-with-the-arrogant-queen-from-high-school-is-surprisingly-not-uncomfortable-chapter-43/",
"https://mosshytranslations.id/living-with-the-arrogant-queen-from-high-school-is-surprisingly-not-uncomfortable-chapter-44/",
"https://mosshytranslations.id/living-with-the-arrogant-queen-from-high-school-is-surprisingly-not-uncomfortable-chapter-45/",
"https://mosshytranslations.id/living-with-the-arrogant-queen-from-high-school-is-surprisingly-not-uncomfortable-chapter-46/",
"https://mosshytranslations.id/living-with-the-arrogant-queen-from-high-school-is-surprisingly-not-uncomfortable-chapter-47/",
"https://mosshytranslations.id/living-with-the-arrogant-queen-from-high-school-is-surprisingly-not-uncomfortable-chapter-48/",
"https://mosshytranslations.id/living-with-the-arrogant-queen-from-high-school-is-surprisingly-not-uncomfortable-chapter-49/",
"https://mosshytranslations.id/living-with-the-arrogant-queen-from-high-school-is-surprisingly-not-uncomfortable-chapter-50/",
"https://mosshytranslations.id/living-with-the-arrogant-queen-from-high-school-is-surprisingly-not-uncomfortable-chapter-51/",
"https://mosshytranslations.id/living-with-the-arrogant-queen-from-high-school-is-surprisingly-not-uncomfortable-chapter-52/",
"https://mosshytranslations.id/living-with-the-arrogant-queen-from-high-school-is-surprisingly-not-uncomfortable-chapter-53/",
"https://mosshytranslations.id/living-with-the-arrogant-queen-from-high-school-is-surprisingly-not-uncomfortable-chapter-54/",
"https://mosshytranslations.id/living-with-the-arrogant-queen-from-high-school-is-surprisingly-not-uncomfortable-chapter-55/",
"https://mosshytranslations.id/living-with-the-arrogant-queen-from-high-school-is-surprisingly-not-uncomfortable-chapter-56/",
"https://mosshytranslations.id/living-with-the-arrogant-queen-from-high-school-is-surprisingly-not-uncomfortable-chapter-57/",
"https://mosshytranslations.id/living-with-the-arrogant-queen-from-high-school-is-surprisingly-not-uncomfortable-chapter-58/",
"https://mosshytranslations.id/living-with-the-arrogant-queen-from-high-school-is-surprisingly-not-uncomfortable-chapter-59/",
"https://mosshytranslations.id/living-with-the-arrogant-queen-from-high-school-is-surprisingly-not-uncomfortable-chapter-60/",
"https://mosshytranslations.id/living-with-the-arrogant-queen-from-high-school-is-surprisingly-not-uncomfortable-chapter-61/",
"https://mosshytranslations.id/living-with-the-arrogant-queen-from-high-school-is-surprisingly-not-uncomfortable-chapter-62/",
"https://mosshytranslations.id/living-with-the-arrogant-queen-from-high-school-is-surprisingly-not-uncomfortable-chapter-63/",
"https://mosshytranslations.id/living-with-the-arrogant-queen-from-high-school-is-surprisingly-not-uncomfortable-chapter-64/",
"https://mosshytranslations.id/living-with-the-arrogant-queen-from-high-school-is-surprisingly-not-uncomfortable-chapter-65/",
"https://mosshytranslations.id/living-with-the-arrogant-queen-from-high-school-is-surprisingly-not-uncomfortable-chapter-66/",
"https://mosshytranslations.id/living-with-the-arrogant-queen-from-high-school-is-surprisingly-not-uncomfortable-chapter-67/",
"https://mosshytranslations.id/living-with-the-arrogant-queen-from-high-school-is-surprisingly-not-uncomfortable-chapter-68/",
"https://mosshytranslations.id/living-with-the-arrogant-queen-from-high-school-is-surprisingly-not-uncomfortable-chapter-69/",
"https://mosshytranslations.id/living-with-the-arrogant-queen-from-high-school-is-surprisingly-not-uncomfortable-chapter-70/",
"https://mosshytranslations.id/living-with-the-arrogant-queen-from-high-school-is-surprisingly-not-uncomfortable-chapter-71/",
"https://mosshytranslations.id/living-with-the-arrogant-queen-from-high-school-is-surprisingly-not-uncomfortable-chapter-72/",
"https://mosshytranslations.id/living-with-the-arrogant-queen-from-high-school-is-surprisingly-not-uncomfortable-chapter-73/",
"https://mosshytranslations.id/living-with-the-arrogant-queen-from-high-school-is-surprisingly-not-uncomfortable-chapter-74/",
"https://mosshytranslations.id/living-with-the-arrogant-queen-from-high-school-is-surprisingly-not-uncomfortable-chapter-75/",
"https://mosshytranslations.id/living-with-the-arrogant-queen-from-high-school-is-surprisingly-not-uncomfortable-chapter-76/",
"https://mosshytranslations.id/living-with-the-arrogant-queen-from-high-school-is-surprisingly-not-uncomfortable-chapter-77/",
"https://mosshytranslations.id/living-with-the-arrogant-queen-from-high-school-is-surprisingly-not-uncomfortable-chapter-78/",
"https://mosshytranslations.id/living-with-the-arrogant-queen-from-high-school-is-surprisingly-not-uncomfortable-chapter-79/",
"https://mosshytranslations.id/living-with-the-arrogant-queen-from-high-school-is-surprisingly-not-uncomfortable-chapter-80/",
"https://mosshytranslations.id/living-with-the-arrogant-queen-from-high-school-is-surprisingly-not-uncomfortable-chapter-81/",
"https://mosshytranslations.id/living-with-the-arrogant-queen-from-high-school-is-surprisingly-not-uncomfortable-chapter-82/",
"https://mosshytranslations.id/living-with-the-arrogant-queen-from-high-school-is-surprisingly-not-uncomfortable-chapter-83/",
"https://mosshytranslations.id/living-with-the-arrogant-queen-from-high-school-is-surprisingly-not-uncomfortable-chapter-84/",
"https://mosshytranslations.id/living-with-the-arrogant-queen-from-high-school-is-surprisingly-not-uncomfortable-chapter-85/",
"https://mosshytranslations.id/living-with-the-arrogant-queen-from-high-school-is-surprisingly-not-uncomfortable-chapter-86/",
"https://mosshytranslations.id/living-with-the-arrogant-queen-from-high-school-is-surprisingly-not-uncomfortable-chapter-87/",
"https://mosshytranslations.id/living-with-the-arrogant-queen-from-high-school-is-surprisingly-not-uncomfortable-chapter-88/",
"https://mosshytranslations.id/living-with-the-arrogant-queen-from-high-school-is-surprisingly-not-uncomfortable-chapter-89/",
"https://mosshytranslations.id/living-with-the-arrogant-queen-from-high-school-is-surprisingly-not-uncomfortable-chapter-90/",
"https://mosshytranslations.id/living-with-the-arrogant-queen-from-high-school-is-surprisingly-not-uncomfortable-chapter-91/",
"https://mosshytranslations.id/living-with-the-arrogant-queen-from-high-school-is-surprisingly-not-uncomfortable-chapter-92/",
"https://mosshytranslations.id/living-with-the-arrogant-queen-from-high-school-is-surprisingly-not-uncomfortable-chapter-93/",
"https://mosshytranslations.id/living-with-the-arrogant-queen-from-high-school-is-surprisingly-not-uncomfortable-chapter-94/",
"https://mosshytranslations.id/living-with-the-arrogant-queen-from-high-school-is-surprisingly-not-uncomfortable-chapter-95/",
"https://mosshytranslations.id/living-with-the-arrogant-queen-from-high-school-is-surprisingly-not-uncomfortable-chapter-96/",
"https://mosshytranslations.id/living-with-the-arrogant-queen-from-high-school-is-surprisingly-not-uncomfortable-chapter-97/",
"https://mosshytranslations.id/living-with-the-arrogant-queen-from-high-school-is-surprisingly-not-uncomfortable-chapter-98/",
"https://mosshytranslations.id/living-with-the-arrogant-queen-from-high-school-is-surprisingly-not-uncomfortable-chapter-99/",
"https://mosshytranslations.id/living-with-the-arrogant-queen-from-high-school-is-surprisingly-not-uncomfortable-chapter-100/",
"https://mosshytranslations.id/living-with-the-arrogant-queen-from-high-school-is-surprisingly-not-uncomfortable-chapter-101/",
"https://mosshytranslations.id/living-with-the-arrogant-queen-from-high-school-is-surprisingly-not-uncomfortable-chapter-102/",
"https://mosshytranslations.id/living-with-the-arrogant-queen-from-high-school-is-surprisingly-not-uncomfortable-chapter-103/",
"https://mosshytranslations.id/living-with-the-arrogant-queen-from-high-school-is-surprisingly-not-uncomfortable-chapter-104/",
"https://mosshytranslations.id/living-with-the-arrogant-queen-from-high-school-is-surprisingly-not-uncomfortable-chapter-105/",
"https://mosshytranslations.id/living-with-the-arrogant-queen-from-high-school-is-surprisingly-not-uncomfortable-chapter-106/",
"https://mosshytranslations.id/living-with-the-arrogant-queen-from-high-school-is-surprisingly-not-uncomfortable-chapter-107/",
"https://mosshytranslations.id/living-with-the-arrogant-queen-from-high-school-is-surprisingly-not-uncomfortable-chapter-108/",
"https://mosshytranslations.id/living-with-the-arrogant-queen-from-high-school-is-surprisingly-not-uncomfortable-chapter-109/",
"https://mosshytranslations.id/living-with-the-arrogant-queen-from-high-school-is-surprisingly-not-uncomfortable-chapter-110/",
"https://mosshytranslations.id/living-with-the-arrogant-queen-from-high-school-is-surprisingly-not-uncomfortable-chapter-111/",
"https://mosshytranslations.id/living-with-the-arrogant-queen-from-high-school-is-surprisingly-not-uncomfortable-chapter-112/",
"https://mosshytranslations.id/living-with-the-arrogant-queen-from-high-school-is-surprisingly-not-uncomfortable-chapter-113/",
"https://mosshytranslations.id/living-with-the-arrogant-queen-from-high-school-is-surprisingly-not-uncomfortable-chapter-114/",
"https://mosshytranslations.id/living-with-the-arrogant-queen-from-high-school-is-surprisingly-not-uncomfortable-chapter-115/",
"https://mosshytranslations.id/living-with-the-arrogant-queen-from-high-school-is-surprisingly-not-uncomfortable-chapter-116/",
"https://mosshytranslations.id/living-with-the-arrogant-queen-from-high-school-is-surprisingly-not-uncomfortable-chapter-117/",
"https://mosshytranslations.id/living-with-the-arrogant-queen-from-high-school-is-surprisingly-not-uncomfortable-chapter-118/",
"https://mosshytranslations.id/living-with-the-arrogant-queen-from-high-school-is-surprisingly-not-uncomfortable-chapter-119/",
"https://mosshytranslations.id/living-with-the-arrogant-queen-from-high-school-is-surprisingly-not-uncomfortable-chapter-120/",
"https://mosshytranslations.id/living-with-the-arrogant-queen-from-high-school-is-surprisingly-not-uncomfortable-chapter-121/",
"https://mosshytranslations.id/living-with-the-arrogant-queen-from-high-school-is-surprisingly-not-uncomfortable-chapter-122/",
"https://mosshytranslations.id/living-with-the-arrogant-queen-from-high-school-is-surprisingly-not-uncomfortable-chapter-123/",
"https://mosshytranslations.id/living-with-the-arrogant-queen-from-high-school-is-surprisingly-not-uncomfortable-chapter-124/",
"https://mosshytranslations.id/living-with-the-arrogant-queen-from-high-school-is-surprisingly-not-uncomfortable-chapter-125/",
"https://mosshytranslations.id/living-with-the-arrogant-queen-from-high-school-is-surprisingly-not-uncomfortable-chapter-126/",
"https://mosshytranslations.id/living-with-the-arrogant-queen-from-high-school-is-surprisingly-not-uncomfortable-chapter-127/",
"https://mosshytranslations.id/living-with-the-arrogant-queen-from-high-school-is-surprisingly-not-uncomfortable-chapter-128/",
"https://mosshytranslations.id/living-with-the-arrogant-queen-from-high-school-is-surprisingly-not-uncomfortable-chapter-129/",
"https://mosshytranslations.id/living-with-the-arrogant-queen-from-high-school-is-surprisingly-not-uncomfortable-chapter-130/",
"https://mosshytranslations.id/living-with-the-arrogant-queen-from-high-school-is-surprisingly-not-uncomfortable-chapter-131/",
"https://mosshytranslations.id/living-with-the-arrogant-queen-from-high-school-is-surprisingly-not-uncomfortable-chapter-132/",
"https://mosshytranslations.id/living-with-the-arrogant-queen-from-high-school-is-surprisingly-not-uncomfortable-chapter-133/",
"https://mosshytranslations.id/living-with-the-arrogant-queen-from-high-school-is-surprisingly-not-uncomfortable-chapter-134/",
"https://mosshytranslations.id/living-with-the-arrogant-queen-from-high-school-is-surprisingly-not-uncomfortable-chapter-135/",
"https://mosshytranslations.id/living-with-the-arrogant-queen-from-high-school-is-surprisingly-not-uncomfortable-chapter-136/",
"https://mosshytranslations.id/living-with-the-arrogant-queen-from-high-school-is-surprisingly-not-uncomfortable-chapter-137/",
"https://mosshytranslations.id/living-with-the-arrogant-queen-from-high-school-is-surprisingly-not-uncomfortable-chapter-138/",
"https://mosshytranslations.id/living-with-the-arrogant-queen-from-high-school-is-surprisingly-not-uncomfortable-chapter-139/",
"https://mosshytranslations.id/living-with-the-arrogant-queen-from-high-school-is-surprisingly-not-uncomfortable-chapter-140/",
"https://mosshytranslations.id/living-with-the-arrogant-queen-from-high-school-is-surprisingly-not-uncomfortable-chapter-141/",
"https://mosshytranslations.id/living-with-the-arrogant-queen-from-high-school-is-surprisingly-not-uncomfortable-chapter-142/",
"https://mosshytranslations.id/living-with-the-arrogant-queen-from-high-school-is-surprisingly-not-uncomfortable-chapter-143/",
"https://mosshytranslations.id/living-with-the-arrogant-queen-from-high-school-is-surprisingly-not-uncomfortable-chapter-144/",
"https://mosshytranslations.id/living-with-the-arrogant-queen-from-high-school-is-surprisingly-not-uncomfortable-chapter-145/",
"https://mosshytranslations.id/living-with-the-arrogant-queen-from-high-school-is-surprisingly-not-uncomfortable-chapter-146/",
"https://mosshytranslations.id/living-with-the-arrogant-queen-from-high-school-is-surprisingly-not-uncomfortable-chapter-147/",
"https://mosshytranslations.id/living-with-the-arrogant-queen-from-high-school-is-surprisingly-not-uncomfortable-chapter-148/",
"https://mosshytranslations.id/living-with-the-arrogant-queen-from-high-school-is-surprisingly-not-uncomfortable-chapter-149/",
"https://mosshytranslations.id/living-with-the-arrogant-queen-from-high-school-is-surprisingly-not-uncomfortable-chapter-150/",
"https://mosshytranslations.id/living-with-the-arrogant-queen-from-high-school-is-surprisingly-not-uncomfortable-chapter-151/",
"https://mosshytranslations.id/living-with-the-arrogant-queen-from-high-school-is-surprisingly-not-uncomfortable-chapter-152/",
"https://mosshytranslations.id/living-with-the-arrogant-queen-from-high-school-is-surprisingly-not-uncomfortable-chapter-153/",
"https://mosshytranslations.id/living-with-the-arrogant-queen-from-high-school-is-surprisingly-not-uncomfortable-chapter-154/",
"https://mosshytranslations.id/living-with-the-arrogant-queen-from-high-school-is-surprisingly-not-uncomfortable-chapter-155/",
"https://mosshytranslations.id/living-with-the-arrogant-queen-from-high-school-is-surprisingly-not-uncomfortable-chapter-156/",
"https://mosshytranslations.id/living-with-the-arrogant-queen-from-high-school-is-surprisingly-not-uncomfortable-chapter-157/",
                };

                const int chapterPerVolume = 100;

                int skip = 0;

                int volume = 1;
                int chapter = 1;
                for (int i = 0; i < urls.Length; ++i) {
                    var url = urls[i];

                    Console.WriteLine($"{url}");

                    if (i >= skip) {
                        await mosshy.DownloadChapter(url, @"D:\Visual Novels\[Self-Sourced] [Ongoing] Arrogant Queen (WN)\Raw\" + $"Volume {volume}", $"{chapter.ToString("D4")}.xhtml");
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