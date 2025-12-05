// Project > Properties > Change from Console Application to Windows Application when moving to production

namespace Source {
    internal class Program {
        static int Main(string[] args) {
            Task.Run(async void () => {
                PastelTales pastel = new PastelTales();

                string[] urls = {
                    "https://pasteltales.com/series/i-couldnt-stop-my-childhood-friend-from-turning-into-a-villain/chapter-0/",
                    "https://pasteltales.com/series/i-couldnt-stop-my-childhood-friend-from-turning-into-a-villain/chapter-1/",
                    "https://pasteltales.com/series/i-couldnt-stop-my-childhood-friend-from-turning-into-a-villain/chapter-2/",
                    "https://pasteltales.com/series/i-couldnt-stop-my-childhood-friend-from-turning-into-a-villain/chapter-3/",
                    "https://pasteltales.com/series/i-couldnt-stop-my-childhood-friend-from-turning-into-a-villain/chapter-4/",
                    "https://pasteltales.com/series/i-couldnt-stop-my-childhood-friend-from-turning-into-a-villain/chapter-5/",
                    "https://pasteltales.com/series/i-couldnt-stop-my-childhood-friend-from-turning-into-a-villain/chapter-6/",
                    "https://pasteltales.com/series/i-couldnt-stop-my-childhood-friend-from-turning-into-a-villain/chapter-7/",
                    "https://pasteltales.com/series/i-couldnt-stop-my-childhood-friend-from-turning-into-a-villain/chapter-8/",
                    "https://pasteltales.com/series/i-couldnt-stop-my-childhood-friend-from-turning-into-a-villain/chapter-9/",
                    "https://pasteltales.com/series/i-couldnt-stop-my-childhood-friend-from-turning-into-a-villain/chapter-10/",
                    "https://pasteltales.com/series/i-couldnt-stop-my-childhood-friend-from-turning-into-a-villain/chapter-11/",
                    "https://pasteltales.com/series/i-couldnt-stop-my-childhood-friend-from-turning-into-a-villain/chapter-12/",
                    "https://pasteltales.com/series/i-couldnt-stop-my-childhood-friend-from-turning-into-a-villain/chapter-13/",
                    "https://pasteltales.com/series/i-couldnt-stop-my-childhood-friend-from-turning-into-a-villain/chapter-14/",
                    "https://pasteltales.com/series/i-couldnt-stop-my-childhood-friend-from-turning-into-a-villain/chapter-15/",
                    "https://pasteltales.com/series/i-couldnt-stop-my-childhood-friend-from-turning-into-a-villain/chapter-16/",
                    "https://pasteltales.com/series/i-couldnt-stop-my-childhood-friend-from-turning-into-a-villain/chapter-17/",
                    "https://pasteltales.com/series/i-couldnt-stop-my-childhood-friend-from-turning-into-a-villain/chapter-18/",
                    "https://pasteltales.com/series/i-couldnt-stop-my-childhood-friend-from-turning-into-a-villain/chapter-19/",
                    "https://pasteltales.com/series/i-couldnt-stop-my-childhood-friend-from-turning-into-a-villain/chapter-20/",
                    "https://pasteltales.com/series/i-couldnt-stop-my-childhood-friend-from-turning-into-a-villain/chapter-21/",
                    "https://pasteltales.com/series/i-couldnt-stop-my-childhood-friend-from-turning-into-a-villain/chapter-22/",
                    "https://pasteltales.com/series/i-couldnt-stop-my-childhood-friend-from-turning-into-a-villain/chapter-23/",
                    "https://pasteltales.com/series/i-couldnt-stop-my-childhood-friend-from-turning-into-a-villain/chapter-24/",
                    "https://pasteltales.com/series/i-couldnt-stop-my-childhood-friend-from-turning-into-a-villain/chapter-25/",
                    "https://pasteltales.com/series/i-couldnt-stop-my-childhood-friend-from-turning-into-a-villain/chapter-26/",
                    "https://pasteltales.com/series/i-couldnt-stop-my-childhood-friend-from-turning-into-a-villain/chapter-27/",
                    "https://pasteltales.com/series/i-couldnt-stop-my-childhood-friend-from-turning-into-a-villain/chapter-28/",
                    "https://pasteltales.com/series/i-couldnt-stop-my-childhood-friend-from-turning-into-a-villain/chapter-29/",
                    "https://pasteltales.com/series/i-couldnt-stop-my-childhood-friend-from-turning-into-a-villain/chapter-30/",
                    "https://pasteltales.com/series/i-couldnt-stop-my-childhood-friend-from-turning-into-a-villain/chapter-31/",
                    "https://pasteltales.com/series/i-couldnt-stop-my-childhood-friend-from-turning-into-a-villain/chapter-32/",
                    "https://pasteltales.com/series/i-couldnt-stop-my-childhood-friend-from-turning-into-a-villain/chapter-33/",
                    "https://pasteltales.com/series/i-couldnt-stop-my-childhood-friend-from-turning-into-a-villain/chapter-34/",
                    "https://pasteltales.com/series/i-couldnt-stop-my-childhood-friend-from-turning-into-a-villain/chapter-35/",
                    "https://pasteltales.com/series/i-couldnt-stop-my-childhood-friend-from-turning-into-a-villain/chapter-36/",
                    "https://pasteltales.com/series/i-couldnt-stop-my-childhood-friend-from-turning-into-a-villain/chapter-37/",
                    "https://pasteltales.com/series/i-couldnt-stop-my-childhood-friend-from-turning-into-a-villain/chapter-38/",
                    "https://pasteltales.com/series/i-couldnt-stop-my-childhood-friend-from-turning-into-a-villain/chapter-39/",
                    "https://pasteltales.com/series/i-couldnt-stop-my-childhood-friend-from-turning-into-a-villain/chapter-40/",
                    "https://pasteltales.com/series/i-couldnt-stop-my-childhood-friend-from-turning-into-a-villain/chapter-41/",
                    "https://pasteltales.com/series/i-couldnt-stop-my-childhood-friend-from-turning-into-a-villain/chapter-42/",
                    "https://pasteltales.com/series/i-couldnt-stop-my-childhood-friend-from-turning-into-a-villain/chapter-43/",
                    "https://pasteltales.com/series/i-couldnt-stop-my-childhood-friend-from-turning-into-a-villain/chapter-44/",
                    "https://pasteltales.com/series/i-couldnt-stop-my-childhood-friend-from-turning-into-a-villain/chapter-45/",
                    "https://pasteltales.com/series/i-couldnt-stop-my-childhood-friend-from-turning-into-a-villain/chapter-46/",
                    "https://pasteltales.com/series/i-couldnt-stop-my-childhood-friend-from-turning-into-a-villain/chapter-47/",
                    "https://pasteltales.com/series/i-couldnt-stop-my-childhood-friend-from-turning-into-a-villain/chapter-48/",
                    "https://pasteltales.com/series/i-couldnt-stop-my-childhood-friend-from-turning-into-a-villain/chapter-49/",
                    "https://pasteltales.com/series/i-couldnt-stop-my-childhood-friend-from-turning-into-a-villain/chapter-50/",
                    "https://pasteltales.com/series/i-couldnt-stop-my-childhood-friend-from-turning-into-a-villain/chapter-51/",
                    "https://pasteltales.com/series/i-couldnt-stop-my-childhood-friend-from-turning-into-a-villain/chapter-52/",
                    "https://pasteltales.com/series/i-couldnt-stop-my-childhood-friend-from-turning-into-a-villain/chapter-53/",
                    "https://pasteltales.com/series/i-couldnt-stop-my-childhood-friend-from-turning-into-a-villain/chapter-54/",
                    "https://pasteltales.com/series/i-couldnt-stop-my-childhood-friend-from-turning-into-a-villain/chapter-55/",
                    "https://pasteltales.com/series/i-couldnt-stop-my-childhood-friend-from-turning-into-a-villain/chapter-56/",
                    "https://pasteltales.com/series/i-couldnt-stop-my-childhood-friend-from-turning-into-a-villain/chapter-57/",
                    "https://pasteltales.com/series/i-couldnt-stop-my-childhood-friend-from-turning-into-a-villain/chapter-58/",
                    "https://pasteltales.com/series/i-couldnt-stop-my-childhood-friend-from-turning-into-a-villain/chapter-59/",
                    "https://pasteltales.com/series/i-couldnt-stop-my-childhood-friend-from-turning-into-a-villain/chapter-60/",
                    "https://pasteltales.com/series/i-couldnt-stop-my-childhood-friend-from-turning-into-a-villain/chapter-61/",
                    "https://pasteltales.com/series/i-couldnt-stop-my-childhood-friend-from-turning-into-a-villain/chapter-62/",
                    "https://pasteltales.com/series/i-couldnt-stop-my-childhood-friend-from-turning-into-a-villain/chapter-63/",
                    "https://pasteltales.com/series/i-couldnt-stop-my-childhood-friend-from-turning-into-a-villain/chapter-64/",
                    "https://pasteltales.com/series/i-couldnt-stop-my-childhood-friend-from-turning-into-a-villain/chapter-65/",
                    "https://pasteltales.com/series/i-couldnt-stop-my-childhood-friend-from-turning-into-a-villain/chapter-66/",
                    "https://pasteltales.com/series/i-couldnt-stop-my-childhood-friend-from-turning-into-a-villain/chapter-67/",
                    "https://pasteltales.com/series/i-couldnt-stop-my-childhood-friend-from-turning-into-a-villain/chapter-68/",
                    "https://pasteltales.com/series/i-couldnt-stop-my-childhood-friend-from-turning-into-a-villain/chapter-69/",
                    "https://pasteltales.com/series/i-couldnt-stop-my-childhood-friend-from-turning-into-a-villain/chapter-70/",
                    "https://pasteltales.com/series/i-couldnt-stop-my-childhood-friend-from-turning-into-a-villain/chapter-71/",
                    "https://pasteltales.com/series/i-couldnt-stop-my-childhood-friend-from-turning-into-a-villain/chapter-72/",
                    "https://pasteltales.com/series/i-couldnt-stop-my-childhood-friend-from-turning-into-a-villain/chapter-73/",
                    "https://pasteltales.com/series/i-couldnt-stop-my-childhood-friend-from-turning-into-a-villain/chapter-74/",
                    "https://pasteltales.com/series/i-couldnt-stop-my-childhood-friend-from-turning-into-a-villain/chapter-75/",
                    "https://pasteltales.com/series/i-couldnt-stop-my-childhood-friend-from-turning-into-a-villain/chapter-76/",
                    "https://pasteltales.com/series/i-couldnt-stop-my-childhood-friend-from-turning-into-a-villain/chapter-77/",
                    "https://pasteltales.com/series/i-couldnt-stop-my-childhood-friend-from-turning-into-a-villain/chapter-78/",
                    "https://pasteltales.com/series/i-couldnt-stop-my-childhood-friend-from-turning-into-a-villain/chapter-79/",
                    "https://pasteltales.com/series/i-couldnt-stop-my-childhood-friend-from-turning-into-a-villain/chapter-80/",
                    "https://pasteltales.com/series/i-couldnt-stop-my-childhood-friend-from-turning-into-a-villain/chapter-81/",
                    "https://pasteltales.com/series/i-couldnt-stop-my-childhood-friend-from-turning-into-a-villain/chapter-82/",
                    "https://pasteltales.com/series/i-couldnt-stop-my-childhood-friend-from-turning-into-a-villain/chapter-83/",
                    "https://pasteltales.com/series/i-couldnt-stop-my-childhood-friend-from-turning-into-a-villain/chapter-84/",
                    "https://pasteltales.com/series/i-couldnt-stop-my-childhood-friend-from-turning-into-a-villain/chapter-85/",
                    "https://pasteltales.com/series/i-couldnt-stop-my-childhood-friend-from-turning-into-a-villain/chapter-86/",
                    "https://pasteltales.com/series/i-couldnt-stop-my-childhood-friend-from-turning-into-a-villain/chapter-87/",
                    "https://pasteltales.com/series/i-couldnt-stop-my-childhood-friend-from-turning-into-a-villain/chapter-88/",
                    "https://pasteltales.com/series/i-couldnt-stop-my-childhood-friend-from-turning-into-a-villain/chapter-89/",
                    "https://pasteltales.com/series/i-couldnt-stop-my-childhood-friend-from-turning-into-a-villain/chapter-90/",
                    "https://pasteltales.com/series/i-couldnt-stop-my-childhood-friend-from-turning-into-a-villain/chapter-91/",
                    "https://pasteltales.com/series/i-couldnt-stop-my-childhood-friend-from-turning-into-a-villain/chapter-92/",
                    "https://pasteltales.com/series/i-couldnt-stop-my-childhood-friend-from-turning-into-a-villain/chapter-93/",
                    "https://pasteltales.com/series/i-couldnt-stop-my-childhood-friend-from-turning-into-a-villain/chapter-94/",
                    "https://pasteltales.com/series/i-couldnt-stop-my-childhood-friend-from-turning-into-a-villain/chapter-95/",
                    "https://pasteltales.com/series/i-couldnt-stop-my-childhood-friend-from-turning-into-a-villain/chapter-96/",
                    "https://pasteltales.com/series/i-couldnt-stop-my-childhood-friend-from-turning-into-a-villain/chapter-97/",
                    "https://pasteltales.com/series/i-couldnt-stop-my-childhood-friend-from-turning-into-a-villain/chapter-98/",
                    "https://pasteltales.com/series/i-couldnt-stop-my-childhood-friend-from-turning-into-a-villain/chapter-99/",
                    "https://pasteltales.com/series/i-couldnt-stop-my-childhood-friend-from-turning-into-a-villain/chapter-100/",
                    "https://pasteltales.com/series/i-couldnt-stop-my-childhood-friend-from-turning-into-a-villain/chapter-101/",
                    "https://pasteltales.com/series/i-couldnt-stop-my-childhood-friend-from-turning-into-a-villain/chapter-102/",
                    "https://pasteltales.com/series/i-couldnt-stop-my-childhood-friend-from-turning-into-a-villain/chapter-103/",
                    "https://pasteltales.com/series/i-couldnt-stop-my-childhood-friend-from-turning-into-a-villain/chapter-104/",
                    "https://pasteltales.com/series/i-couldnt-stop-my-childhood-friend-from-turning-into-a-villain/chapter-105/",
                    "https://pasteltales.com/series/i-couldnt-stop-my-childhood-friend-from-turning-into-a-villain/chapter-106/",
                    "https://pasteltales.com/series/i-couldnt-stop-my-childhood-friend-from-turning-into-a-villain/chapter-107/",
                    "https://pasteltales.com/series/i-couldnt-stop-my-childhood-friend-from-turning-into-a-villain/chapter-108/",
                    "https://pasteltales.com/series/i-couldnt-stop-my-childhood-friend-from-turning-into-a-villain/chapter-109/",
                    "https://pasteltales.com/series/i-couldnt-stop-my-childhood-friend-from-turning-into-a-villain/chapter-110/",
                    "https://pasteltales.com/series/i-couldnt-stop-my-childhood-friend-from-turning-into-a-villain/chapter-111/",
                    "https://pasteltales.com/series/i-couldnt-stop-my-childhood-friend-from-turning-into-a-villain/chapter-112/",
                    "https://pasteltales.com/series/i-couldnt-stop-my-childhood-friend-from-turning-into-a-villain/chapter-113/",
                    "https://pasteltales.com/series/i-couldnt-stop-my-childhood-friend-from-turning-into-a-villain/chapter-114/",
                    "https://pasteltales.com/series/i-couldnt-stop-my-childhood-friend-from-turning-into-a-villain/chapter-115/",
                    "https://pasteltales.com/series/i-couldnt-stop-my-childhood-friend-from-turning-into-a-villain/chapter-116/",
                    "https://pasteltales.com/series/i-couldnt-stop-my-childhood-friend-from-turning-into-a-villain/chapter-117/",
                    "https://pasteltales.com/series/i-couldnt-stop-my-childhood-friend-from-turning-into-a-villain/chapter-118/",
                    "https://pasteltales.com/series/i-couldnt-stop-my-childhood-friend-from-turning-into-a-villain/chapter-119/",
                    "https://pasteltales.com/series/i-couldnt-stop-my-childhood-friend-from-turning-into-a-villain/chapter-120/",
                    "https://pasteltales.com/series/i-couldnt-stop-my-childhood-friend-from-turning-into-a-villain/chapter-121/",
                    "https://pasteltales.com/series/i-couldnt-stop-my-childhood-friend-from-turning-into-a-villain/chapter-122/",
                    "https://pasteltales.com/series/i-couldnt-stop-my-childhood-friend-from-turning-into-a-villain/chapter-123/",
                    "https://pasteltales.com/series/i-couldnt-stop-my-childhood-friend-from-turning-into-a-villain/chapter-124/",
                    "https://pasteltales.com/series/i-couldnt-stop-my-childhood-friend-from-turning-into-a-villain/chapter-125/",
                    "https://pasteltales.com/series/i-couldnt-stop-my-childhood-friend-from-turning-into-a-villain/chapter-126/",
                    "https://pasteltales.com/series/i-couldnt-stop-my-childhood-friend-from-turning-into-a-villain/chapter-127/",
                    "https://pasteltales.com/series/i-couldnt-stop-my-childhood-friend-from-turning-into-a-villain/chapter-128/",
                    "https://pasteltales.com/series/i-couldnt-stop-my-childhood-friend-from-turning-into-a-villain/chapter-129/",
                    "https://pasteltales.com/series/i-couldnt-stop-my-childhood-friend-from-turning-into-a-villain/chapter-130/",
                    "https://pasteltales.com/series/i-couldnt-stop-my-childhood-friend-from-turning-into-a-villain/chapter-131/",
                    "https://pasteltales.com/series/i-couldnt-stop-my-childhood-friend-from-turning-into-a-villain/chapter-132/",
                    "https://pasteltales.com/series/i-couldnt-stop-my-childhood-friend-from-turning-into-a-villain/chapter-133/",
                    "https://pasteltales.com/series/i-couldnt-stop-my-childhood-friend-from-turning-into-a-villain/chapter-134/",
                    "https://pasteltales.com/series/i-couldnt-stop-my-childhood-friend-from-turning-into-a-villain/chapter-135/",
                    "https://pasteltales.com/series/i-couldnt-stop-my-childhood-friend-from-turning-into-a-villain/chapter-136/",
                    "https://pasteltales.com/series/i-couldnt-stop-my-childhood-friend-from-turning-into-a-villain/chapter-137/",
                    "https://pasteltales.com/series/i-couldnt-stop-my-childhood-friend-from-turning-into-a-villain/chapter-138/",
                    "https://pasteltales.com/series/i-couldnt-stop-my-childhood-friend-from-turning-into-a-villain/chapter-139/",
                    "https://pasteltales.com/series/i-couldnt-stop-my-childhood-friend-from-turning-into-a-villain/chapter-140/",
                    "https://pasteltales.com/series/i-couldnt-stop-my-childhood-friend-from-turning-into-a-villain/chapter-141/",
                    "https://pasteltales.com/series/i-couldnt-stop-my-childhood-friend-from-turning-into-a-villain/chapter-142/",
                    "https://pasteltales.com/series/i-couldnt-stop-my-childhood-friend-from-turning-into-a-villain/chapter-143/",
                    "https://pasteltales.com/series/i-couldnt-stop-my-childhood-friend-from-turning-into-a-villain/chapter-144/",
                    "https://pasteltales.com/series/i-couldnt-stop-my-childhood-friend-from-turning-into-a-villain/chapter-145/",
                    "https://pasteltales.com/series/i-couldnt-stop-my-childhood-friend-from-turning-into-a-villain/chapter-146/",
                    "https://pasteltales.com/series/i-couldnt-stop-my-childhood-friend-from-turning-into-a-villain/chapter-147/",
                    "https://pasteltales.com/series/i-couldnt-stop-my-childhood-friend-from-turning-into-a-villain/chapter-148/",
                };

                const int chapterPerVolume = 100;

                int skip = 0;

                int volume = 1;
                int chapter = 1;
                for (int i = 0; i < urls.Length; ++i) {
                    var url = urls[i];

                    Console.WriteLine($"{url}");

                    if (i >= skip) {
                        await pastel.DownloadChapter(url, @"D:\Visual Novels\[Self-Sourced] I couldn't stop my childhood friend from turning into a villain\Raw\" + $"Volume {volume}", $"{chapter.ToString("D4")}.xhtml");
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