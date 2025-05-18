// Project > Properties > Change from Console Application to Windows Application when moving to production

namespace Source {
    internal class Program {
        static int Main(string[] args) {
            Task.Run(async void () => {
                ArcaneTL arcaneTL = new ArcaneTL();

                string[] urls = {
                    "https://arcanetranslations.com/how-to-ruin-a-love-comedy-chapter-1/",
"https://arcanetranslations.com/how-to-ruin-a-love-comedy-chapter-2/",
"https://arcanetranslations.com/how-to-ruin-a-love-comedy-chapter-3/",
"https://arcanetranslations.com/how-to-ruin-a-love-comedy-chapter-4/",
"https://arcanetranslations.com/how-to-ruin-a-love-comedy-chapter-5/",
"https://arcanetranslations.com/how-to-ruin-a-love-comedy-chapter-6/",
"https://arcanetranslations.com/how-to-ruin-a-love-comedy-chapter-7/",
"https://arcanetranslations.com/how-to-ruin-a-love-comedy-chapter-8/",
"https://arcanetranslations.com/how-to-ruin-a-love-comedy-chapter-9/",
"https://arcanetranslations.com/how-to-ruin-a-love-comedy-chapter-10/",
"https://arcanetranslations.com/how-to-ruin-a-love-comedy-chapter-11/",
"https://arcanetranslations.com/how-to-ruin-a-love-comedy-chapter-12/",
"https://arcanetranslations.com/how-to-ruin-a-love-comedy-chapter-13/",
"https://arcanetranslations.com/how-to-ruin-a-love-comedy-chapter-14/",
"https://arcanetranslations.com/how-to-ruin-a-love-comedy-chapter-15/",
"https://arcanetranslations.com/how-to-ruin-a-love-comedy-chapter-16/",
"https://arcanetranslations.com/how-to-ruin-a-love-comedy-chapter-17/",
"https://arcanetranslations.com/how-to-ruin-a-love-comedy-chapter-18/",
"https://arcanetranslations.com/how-to-ruin-a-love-comedy-chapter-19/",
"https://arcanetranslations.com/how-to-ruin-a-love-comedy-chapter-20/",
"https://arcanetranslations.com/how-to-ruin-a-love-comedy-chapter-21/",
"https://arcanetranslations.com/how-to-ruin-a-love-comedy-chapter-22/",
"https://arcanetranslations.com/how-to-ruin-a-love-comedy-chapter-23/",
"https://arcanetranslations.com/how-to-ruin-a-love-comedy-chapter-24/",
"https://arcanetranslations.com/how-to-ruin-a-love-comedy-chapter-25/",
"https://arcanetranslations.com/how-to-ruin-a-love-comedy-chapter-26/",
"https://arcanetranslations.com/how-to-ruin-a-love-comedy-chapter-27/",
"https://arcanetranslations.com/how-to-ruin-a-love-comedy-chapter-28/",
"https://arcanetranslations.com/how-to-ruin-a-love-comedy-chapter-29/",
"https://arcanetranslations.com/how-to-ruin-a-love-comedy-chapter-30/",
"https://arcanetranslations.com/how-to-ruin-a-love-comedy-chapter-31/",
"https://arcanetranslations.com/how-to-ruin-a-love-comedy-chapter-32/",
"https://arcanetranslations.com/how-to-ruin-a-love-comedy-chapter-33/",
"https://arcanetranslations.com/how-to-ruin-a-love-comedy-chapter-34/",
"https://arcanetranslations.com/how-to-ruin-a-love-comedy-chapter-35/",
"https://arcanetranslations.com/how-to-ruin-a-love-comedy-chapter-36/",
"https://arcanetranslations.com/how-to-ruin-a-love-comedy-chapter-37/",
"https://arcanetranslations.com/how-to-ruin-a-love-comedy-chapter-38/",
"https://arcanetranslations.com/how-to-ruin-a-love-comedy-chapter-39/",
"https://arcanetranslations.com/how-to-ruin-a-love-comedy-chapter-40/",
"https://arcanetranslations.com/how-to-ruin-a-love-comedy-chapter-41/",
"https://arcanetranslations.com/how-to-ruin-a-love-comedy-chapter-42/",
"https://arcanetranslations.com/how-to-ruin-a-love-comedy-chapter-43/",
"https://arcanetranslations.com/how-to-ruin-a-love-comedy-chapter-44/",
"https://arcanetranslations.com/how-to-ruin-a-love-comedy-chapter-45/",
"https://arcanetranslations.com/how-to-ruin-a-love-comedy-chapter-46/",
"https://arcanetranslations.com/how-to-ruin-a-love-comedy-chapter-47/",
"https://arcanetranslations.com/how-to-ruin-a-love-comedy-chapter-48/",
"https://arcanetranslations.com/how-to-ruin-a-love-comedy-chapter-49/",
"https://arcanetranslations.com/how-to-ruin-a-love-comedy-chapter-50/",
"https://arcanetranslations.com/how-to-ruin-a-love-comedy-chapter-51/",
"https://arcanetranslations.com/how-to-ruin-a-love-comedy-chapter-52/",
"https://arcanetranslations.com/how-to-ruin-a-love-comedy-chapter-53/",
"https://arcanetranslations.com/how-to-ruin-a-love-comedy-chapter-54/",
"https://arcanetranslations.com/how-to-ruin-a-love-comedy-chapter-55/",
"https://arcanetranslations.com/how-to-ruin-a-love-comedy-chapter-56/",
"https://arcanetranslations.com/how-to-ruin-a-love-comedy-chapter-57/",
"https://arcanetranslations.com/how-to-ruin-a-love-comedy-chapter-58/",
"https://arcanetranslations.com/how-to-ruin-a-love-comedy-chapter-59/",
"https://arcanetranslations.com/how-to-ruin-a-love-comedy-chapter-60/",
"https://arcanetranslations.com/how-to-ruin-a-love-comedy-chapter-61/",
"https://arcanetranslations.com/how-to-ruin-a-love-comedy-chapter-62/",
"https://arcanetranslations.com/how-to-ruin-a-love-comedy-chapter-63/",
"https://arcanetranslations.com/how-to-ruin-a-love-comedy-chapter-64/",
"https://arcanetranslations.com/how-to-ruin-a-love-comedy-chapter-65/",
"https://arcanetranslations.com/how-to-ruin-a-love-comedy-chapter-66/",
"https://arcanetranslations.com/how-to-ruin-a-love-comedy-chapter-67/",
"https://arcanetranslations.com/how-to-ruin-a-love-comedy-chapter-68/",
"https://arcanetranslations.com/how-to-ruin-a-love-comedy-chapter-69/",
"https://arcanetranslations.com/how-to-ruin-a-love-comedy-chapter-70/",
"https://arcanetranslations.com/how-to-ruin-a-love-comedy-chapter-71/",
"https://arcanetranslations.com/how-to-ruin-a-love-comedy-chapter-72/",
"https://arcanetranslations.com/how-to-ruin-a-love-comedy-chapter-73/",
"https://arcanetranslations.com/how-to-ruin-a-love-comedy-chapter-74/",
"https://arcanetranslations.com/how-to-ruin-a-love-comedy-chapter-75/",
"https://arcanetranslations.com/how-to-ruin-a-love-comedy-chapter-76/",
"https://arcanetranslations.com/how-to-ruin-a-love-comedy-chapter-77/",
"https://arcanetranslations.com/how-to-ruin-a-love-comedy-chapter-78/",
"https://arcanetranslations.com/how-to-ruin-a-love-comedy-chapter-79/",
"https://arcanetranslations.com/how-to-ruin-a-love-comedy-chapter-80/",
"https://arcanetranslations.com/how-to-ruin-a-love-comedy-chapter-81/",
"https://arcanetranslations.com/how-to-ruin-a-love-comedy-chapter-82/",
"https://arcanetranslations.com/how-to-ruin-a-love-comedy-chapter-83/",
"https://arcanetranslations.com/how-to-ruin-a-love-comedy-chapter-84/",
"https://arcanetranslations.com/how-to-ruin-a-love-comedy-chapter-85/",
"https://arcanetranslations.com/how-to-ruin-a-love-comedy-chapter-86/",
"https://arcanetranslations.com/how-to-ruin-a-love-comedy-chapter-87/",
"https://arcanetranslations.com/how-to-ruin-a-love-comedy-chapter-88/",
"https://arcanetranslations.com/how-to-ruin-a-love-comedy-chapter-89/",
"https://arcanetranslations.com/how-to-ruin-a-love-comedy-chapter-90/",
"https://arcanetranslations.com/how-to-ruin-a-love-comedy-chapter-91/",
"https://arcanetranslations.com/how-to-ruin-a-love-comedy-chapter-92/",
"https://arcanetranslations.com/how-to-ruin-a-love-comedy-chapter-93/",
"https://arcanetranslations.com/how-to-ruin-a-love-comedy-chapter-94/",
"https://arcanetranslations.com/how-to-ruin-a-love-comedy-chapter-95/",
"https://arcanetranslations.com/how-to-ruin-a-love-comedy-chapter-96/",
"https://arcanetranslations.com/how-to-ruin-a-love-comedy-chapter-97/",
"https://arcanetranslations.com/how-to-ruin-a-love-comedy-chapter-98/",
"https://arcanetranslations.com/how-to-ruin-a-love-comedy-chapter-99/",
"https://arcanetranslations.com/how-to-ruin-a-love-comedy-chapter-100/",
"https://arcanetranslations.com/how-to-ruin-a-love-comedy-chapter-101/",
"https://arcanetranslations.com/how-to-ruin-a-love-comedy-chapter-102/",
"https://arcanetranslations.com/how-to-ruin-a-love-comedy-chapter-103/",
"https://arcanetranslations.com/how-to-ruin-a-love-comedy-chapter-104/",
"https://arcanetranslations.com/how-to-ruin-a-love-comedy-chapter-105/",
"https://arcanetranslations.com/how-to-ruin-a-love-comedy-chapter-106/",
"https://arcanetranslations.com/how-to-ruin-a-love-comedy-chapter-107/",
"https://arcanetranslations.com/how-to-ruin-a-love-comedy-chapter-108/",
"https://arcanetranslations.com/how-to-ruin-a-love-comedy-chapter-109/",
"https://arcanetranslations.com/how-to-ruin-a-love-comedy-chapter-110/",
"https://arcanetranslations.com/how-to-ruin-a-love-comedy-chapter-111/",
"https://arcanetranslations.com/how-to-ruin-a-love-comedy-chapter-112/",
"https://arcanetranslations.com/how-to-ruin-a-love-comedy-chapter-113/",
"https://arcanetranslations.com/how-to-ruin-a-love-comedy-chapter-114/",
"https://arcanetranslations.com/how-to-ruin-a-love-comedy-chapter-115/",
"https://arcanetranslations.com/how-to-ruin-a-love-comedy-chapter-116/",
"https://arcanetranslations.com/how-to-ruin-a-love-comedy-chapter-117/",
"https://arcanetranslations.com/how-to-ruin-a-love-comedy-chapter-118/",
"https://arcanetranslations.com/how-to-ruin-a-love-comedy-chapter-119/",
"https://arcanetranslations.com/how-to-ruin-a-love-comedy-chapter-120/",
"https://arcanetranslations.com/how-to-ruin-a-love-comedy-chapter-121/",
"https://arcanetranslations.com/how-to-ruin-a-love-comedy-chapter-122/",
"https://arcanetranslations.com/how-to-ruin-a-love-comedy-chapter-123/",
"https://arcanetranslations.com/how-to-ruin-a-love-comedy-chapter-124/",
"https://arcanetranslations.com/how-to-ruin-a-love-comedy-chapter-125/",
"https://arcanetranslations.com/how-to-ruin-a-love-comedy-chapter-126/",
"https://arcanetranslations.com/how-to-ruin-a-love-comedy-chapter-127/",
"https://arcanetranslations.com/how-to-ruin-a-love-comedy-chapter-128/",
"https://arcanetranslations.com/how-to-ruin-a-love-comedy-chapter-129/",
"https://arcanetranslations.com/how-to-ruin-a-love-comedy-chapter-130/",
"https://arcanetranslations.com/how-to-ruin-a-love-comedy-chapter-131/",
"https://arcanetranslations.com/how-to-ruin-a-love-comedy-chapter-132/",
"https://arcanetranslations.com/how-to-ruin-a-love-comedy-chapter-133/",
"https://arcanetranslations.com/how-to-ruin-a-love-comedy-chapter-134/",
"https://arcanetranslations.com/how-to-ruin-a-love-comedy-chapter-135/",
"https://arcanetranslations.com/how-to-ruin-a-love-comedy-chapter-136/",
"https://arcanetranslations.com/how-to-ruin-a-love-comedy-chapter-137/",
"https://arcanetranslations.com/how-to-ruin-a-love-comedy-chapter-138/",
"https://arcanetranslations.com/how-to-ruin-a-love-comedy-chapter-139/",
"https://arcanetranslations.com/how-to-ruin-a-love-comedy-chapter-140/",
"https://arcanetranslations.com/how-to-ruin-a-love-comedy-chapter-141/",
"https://arcanetranslations.com/how-to-ruin-a-love-comedy-chapter-142/",
"https://arcanetranslations.com/how-to-ruin-a-love-comedy-chapter-143/",
                };

                const int chapterPerVolume = 100;

                int volume = 1;
                int chapter = 1;
                foreach (string url in urls) {
                    Console.WriteLine($"{url}");
                    await arcaneTL.DownloadChapter(url, @"D:\Visual Novels\[Self-Sourced] [Ongoing] How to ruin a romantic comedy\Raw\" + $"Volume {volume}", $"{(chapter++).ToString("D4")}.xhtml");

                    if (chapter > chapterPerVolume) {
                        ++volume;
                        chapter = 1;
                    }

                    Thread.Sleep(100); // Cloudflare rate limiting
                }

                Console.WriteLine("Done!");
            });

            Console.ReadLine();

            return 0;
        }
    }
}