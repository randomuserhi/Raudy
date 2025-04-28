// Project > Properties > Change from Console Application to Windows Application when moving to production

namespace Source {
    internal class Program {
        static int Main(string[] args) {
            Task.Run(async void () => {
                ArcaneTL arcaneTL = new ArcaneTL();

                string[] urls = {
                    "https://arcanetranslations.com/i-kidnapped-the-hero-party-chapter-0/",
                    "https://arcanetranslations.com/i-kidnapped-the-hero-party-chapter-1/",
                    "https://arcanetranslations.com/i-kidnapped-the-hero-party-chapter-2/",
                    "https://arcanetranslations.com/i-kidnapped-the-hero-party-chapter-3/",
                    "https://arcanetranslations.com/i-kidnapped-the-hero-party-chapter-4/",
                    "https://arcanetranslations.com/i-kidnapped-the-hero-party-chapter-5/",
                    "https://arcanetranslations.com/i-kidnapped-the-hero-party-chapter-6/",
                    "https://arcanetranslations.com/i-kidnapped-the-hero-party-chapter-7/",
                    "https://arcanetranslations.com/i-kidnapped-the-hero-party-chapter-8/",
                    "https://arcanetranslations.com/i-kidnapped-the-hero-party-chapter-9/",
                    "https://arcanetranslations.com/i-kidnapped-the-hero-party-chapter-10/",
                    "https://arcanetranslations.com/i-kidnapped-the-hero-party-chapter-11/",
                    "https://arcanetranslations.com/i-kidnapped-the-hero-party-chapter-12/",
                    "https://arcanetranslations.com/i-kidnapped-the-hero-party-chapter-13/",
                    "https://arcanetranslations.com/i-kidnapped-the-hero-party-chapter-14/",
                    "https://arcanetranslations.com/i-kidnapped-the-hero-party-chapter-15/",
                    "https://arcanetranslations.com/i-kidnapped-the-hero-party-chapter-16/",
                    "https://arcanetranslations.com/i-kidnapped-the-hero-party-chapter-17/",
                    "https://arcanetranslations.com/i-kidnapped-the-hero-party-chapter-18/",
                    "https://arcanetranslations.com/i-kidnapped-the-hero-party-chapter-19/",
                    "https://arcanetranslations.com/i-kidnapped-the-hero-party-chapter-20/",
                    "https://arcanetranslations.com/i-kidnapped-the-hero-party-chapter-21/",
                    "https://arcanetranslations.com/i-kidnapped-the-hero-party-chapter-22/",
                    "https://arcanetranslations.com/i-kidnapped-the-hero-party-chapter-23/",
                    "https://arcanetranslations.com/i-kidnapped-the-hero-party-chapter-24/",
                    "https://arcanetranslations.com/i-kidnapped-the-hero-party-chapter-25/",
                    "https://arcanetranslations.com/i-kidnapped-the-hero-party-chapter-26/",
                    "https://arcanetranslations.com/i-kidnapped-the-hero-party-chapter-27/",
                    "https://arcanetranslations.com/i-kidnapped-the-hero-party-chapter-28/",
                    "https://arcanetranslations.com/i-kidnapped-the-hero-party-chapter-29/",
                    "https://arcanetranslations.com/i-kidnapped-the-hero-party-chapter-30/",
                    "https://arcanetranslations.com/i-kidnapped-the-hero-party-chapter-31/",
                    "https://arcanetranslations.com/i-kidnapped-the-hero-party-chapter-32/",
                    "https://arcanetranslations.com/i-kidnapped-the-hero-party-chapter-33/",
                    "https://arcanetranslations.com/i-kidnapped-the-hero-party-chapter-34/",
                    "https://arcanetranslations.com/i-kidnapped-the-hero-party-chapter-35/",
                    "https://arcanetranslations.com/i-kidnapped-the-hero-party-chapter-36/",
                    "https://arcanetranslations.com/i-kidnapped-the-hero-party-chapter-37/",
                    "https://arcanetranslations.com/i-kidnapped-the-hero-party-chapter-38/",
                    "https://arcanetranslations.com/i-kidnapped-the-hero-party-chapter-39/",
                    "https://arcanetranslations.com/i-kidnapped-the-hero-party-chapter-40/",
                    "https://arcanetranslations.com/i-kidnapped-the-hero-party-chapter-41/",
                    "https://arcanetranslations.com/i-kidnapped-the-hero-party-chapter-42/",
                    "https://arcanetranslations.com/i-kidnapped-the-hero-party-chapter-43/",
                    "https://arcanetranslations.com/i-kidnapped-the-hero-party-chapter-44/",
                    "https://arcanetranslations.com/i-kidnapped-the-hero-party-chapter-45/",
                    "https://arcanetranslations.com/i-kidnapped-the-hero-party-chapter-46/",
                    "https://arcanetranslations.com/i-kidnapped-the-hero-party-chapter-47/",
                    "https://arcanetranslations.com/i-kidnapped-the-hero-party-chapter-48/",
                    "https://arcanetranslations.com/i-kidnapped-the-hero-party-chapter-49/",
                    "https://arcanetranslations.com/i-kidnapped-the-hero-party-chapter-50/",
                    "https://arcanetranslations.com/i-kidnapped-the-hero-party-chapter-51/",
                    "https://arcanetranslations.com/i-kidnapped-the-hero-party-chapter-52/",
                    "https://arcanetranslations.com/i-kidnapped-the-hero-party-chapter-53/",
                    "https://arcanetranslations.com/i-kidnapped-the-hero-party-chapter-54/",
                    "https://arcanetranslations.com/i-kidnapped-the-hero-party-chapter-55/",
                    "https://arcanetranslations.com/i-kidnapped-the-hero-party-chapter-56/",
                    "https://arcanetranslations.com/i-kidnapped-the-hero-party-chapter-57/",
                    "https://arcanetranslations.com/i-kidnapped-the-hero-party-chapter-58/",
                    "https://arcanetranslations.com/i-kidnapped-the-hero-party-chapter-59/",
                    "https://arcanetranslations.com/i-kidnapped-the-hero-party-chapter-60/",
                    "https://arcanetranslations.com/i-kidnapped-the-hero-party-chapter-61/",
                    "https://arcanetranslations.com/i-kidnapped-the-hero-party-chapter-62/",
                    "https://arcanetranslations.com/i-kidnapped-the-hero-party-chapter-63/",
                    "https://arcanetranslations.com/i-kidnapped-the-hero-party-chapter-64/",
                    "https://arcanetranslations.com/i-kidnapped-the-hero-party-chapter-65/",
                    "https://arcanetranslations.com/i-kidnapped-the-hero-party-chapter-66/",
                    "https://arcanetranslations.com/i-kidnapped-the-hero-party-chapter-67/",
                    "https://arcanetranslations.com/i-kidnapped-the-hero-party-chapter-68/",
                    "https://arcanetranslations.com/i-kidnapped-the-hero-party-chapter-69/",
                    "https://arcanetranslations.com/i-kidnapped-the-hero-party-chapter-70/",
                    "https://arcanetranslations.com/i-kidnapped-the-hero-party-chapter-71/",
                    "https://arcanetranslations.com/i-kidnapped-the-hero-party-chapter-72/",
                    "https://arcanetranslations.com/i-kidnapped-the-hero-party-chapter-73/",
                    "https://arcanetranslations.com/i-kidnapped-the-hero-party-chapter-74/",
                    "https://arcanetranslations.com/i-kidnapped-the-hero-party-chapter-75/",
                    "https://arcanetranslations.com/i-kidnapped-the-hero-party-chapter-76/",
                    "https://arcanetranslations.com/i-kidnapped-the-hero-party-chapter-77/",
                    "https://arcanetranslations.com/i-kidnapped-the-hero-party-chapter-78/",
                    "https://arcanetranslations.com/i-kidnapped-the-hero-party-chapter-79/",
                    "https://arcanetranslations.com/i-kidnapped-the-hero-party-chapter-80/",
                    "https://arcanetranslations.com/i-kidnapped-the-hero-party-chapter-81/",
                    "https://arcanetranslations.com/i-kidnapped-the-hero-party-chapter-82/",
                    "https://arcanetranslations.com/i-kidnapped-the-hero-party-chapter-83/",
                    "https://arcanetranslations.com/i-kidnapped-the-hero-party-chapter-84/",
                    "https://arcanetranslations.com/i-kidnapped-the-hero-party-chapter-85/",
                    "https://arcanetranslations.com/i-kidnapped-the-hero-party-chapter-86/",
                    "https://arcanetranslations.com/i-kidnapped-the-hero-party-chapter-87/",
                    "https://arcanetranslations.com/i-kidnapped-the-hero-party-chapter-88/",
                    "https://arcanetranslations.com/i-kidnapped-the-hero-party-chapter-89/",
                    "https://arcanetranslations.com/i-kidnapped-the-hero-party-chapter-90/",
                    "https://arcanetranslations.com/i-kidnapped-the-hero-party-chapter-91/",
                    "https://arcanetranslations.com/i-kidnapped-the-hero-party-chapter-92/",
                    "https://arcanetranslations.com/i-kidnapped-the-hero-party-chapter-93/",
                    "https://arcanetranslations.com/i-kidnapped-the-hero-party-chapter-94/",
                    "https://arcanetranslations.com/i-kidnapped-the-hero-party-chapter-95/",
                    "https://arcanetranslations.com/i-kidnapped-the-hero-party-chapter-96/",
                    "https://arcanetranslations.com/i-kidnapped-the-hero-party-chapter-97/",
                    "https://arcanetranslations.com/i-kidnapped-the-hero-party-chapter-98/",
                    "https://arcanetranslations.com/i-kidnapped-the-hero-party-chapter-99/",
                    "https://arcanetranslations.com/i-kidnapped-the-hero-party-chapter-100/",
                    "https://arcanetranslations.com/i-kidnapped-the-hero-party-chapter-101/",
                    "https://arcanetranslations.com/i-kidnapped-the-hero-party-chapter-102/",
                    "https://arcanetranslations.com/i-kidnapped-the-hero-party-chapter-103/",
                    "https://arcanetranslations.com/i-kidnapped-the-hero-party-chapter-104/",
                    "https://arcanetranslations.com/i-kidnapped-the-hero-party-chapter-105/",
                    "https://arcanetranslations.com/i-kidnapped-the-hero-party-chapter-106/",
                    "https://arcanetranslations.com/i-kidnapped-the-hero-party-chapter-107/",
                    "https://arcanetranslations.com/i-kidnapped-the-hero-party-chapter-108/",
                    "https://arcanetranslations.com/i-kidnapped-the-hero-party-chapter-109/",
                    "https://arcanetranslations.com/i-kidnapped-the-hero-party-chapter-110/",
                    "https://arcanetranslations.com/i-kidnapped-the-hero-party-chapter-111/",
                    "https://arcanetranslations.com/i-kidnapped-the-hero-party-chapter-112/",
                    "https://arcanetranslations.com/i-kidnapped-the-hero-party-chapter-113/",
                    "https://arcanetranslations.com/i-kidnapped-the-hero-party-chapter-114/",
                    "https://arcanetranslations.com/i-kidnapped-the-hero-party-chapter-115/",
                    "https://arcanetranslations.com/i-kidnapped-the-hero-party-chapter-116/",
                    "https://arcanetranslations.com/i-kidnapped-the-hero-party-chapter-117/",
                    "https://arcanetranslations.com/i-kidnapped-the-hero-party-chapter-118/",
                    "https://arcanetranslations.com/i-kidnapped-the-hero-party-chapter-119/",
                    "https://arcanetranslations.com/i-kidnapped-the-hero-party-chapter-120/",
                    "https://arcanetranslations.com/i-kidnapped-the-hero-party-chapter-121/",
                    "https://arcanetranslations.com/i-kidnapped-the-hero-party-chapter-122/",
                    "https://arcanetranslations.com/i-kidnapped-the-hero-party-chapter-123/",
                    "https://arcanetranslations.com/i-kidnapped-the-hero-party-chapter-124/",
                    "https://arcanetranslations.com/i-kidnapped-the-hero-party-chapter-125/",
                    "https://arcanetranslations.com/i-kidnapped-the-hero-party-chapter-126/",
                    "https://arcanetranslations.com/i-kidnapped-the-hero-party-chapter-127/",
                    "https://arcanetranslations.com/i-kidnapped-the-hero-party-chapter-128/",
                    "https://arcanetranslations.com/i-kidnapped-the-hero-party-chapter-129/",
                    "https://arcanetranslations.com/i-kidnapped-the-hero-party-chapter-130/",
                    "https://arcanetranslations.com/i-kidnapped-the-hero-party-chapter-131/",
                    "https://arcanetranslations.com/i-kidnapped-the-hero-party-chapter-132/",
                    "https://arcanetranslations.com/i-kidnapped-the-hero-party-chapter-133/",
                    "https://arcanetranslations.com/i-kidnapped-the-hero-party-chapter-134/",
                    "https://arcanetranslations.com/i-kidnapped-the-hero-party-chapter-135/",
                    "https://arcanetranslations.com/i-kidnapped-the-hero-party-chapter-136/",
                    "https://arcanetranslations.com/i-kidnapped-the-hero-party-chapter-137/",
                };

                const int chapterPerVolume = 100;

                int volume = 1;
                int chapter = 1;
                foreach (string url in urls) {
                    Console.WriteLine($"{url}");
                    await arcaneTL.DownloadChapter(url, @"D:\Visual Novels\[Self-Sourced] [Ongoing] I kidnapped the hero party\Raw\" + $"Volume {volume}", $"{(chapter++).ToString("D4")}.xhtml");

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