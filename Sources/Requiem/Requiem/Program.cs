// Project > Properties > Change from Console Application to Windows Application when moving to production

namespace Source {
    internal class Program {
        static int Main(string[] args) {
            Task.Run(async void () => {
                Requiem requiem = new Requiem();

                string[] urls = {
                    "https://requiemtls.com/extra-cs-childhood-friend-is-the-worlds-strongest-heroine-episode-0/",
                    "https://requiemtls.com/extra-cs-childhood-friend-is-the-worlds-strongest-heroine-episode-1/",
                    "https://requiemtls.com/extra-cs-childhood-friend-is-the-worlds-strongest-heroine-episode-2/",
                    "https://requiemtls.com/extra-cs-childhood-friend-is-the-worlds-strongest-heroine-episode-3/",
                    "https://requiemtls.com/extra-cs-childhood-friend-is-the-worlds-strongest-heroine-episode-4/",
                    "https://requiemtls.com/extra-cs-childhood-friend-is-the-worlds-strongest-heroine-episode-5/",
                    "https://requiemtls.com/extra-cs-childhood-friend-is-the-worlds-strongest-heroine-episode-6/",
                    "https://requiemtls.com/extra-cs-childhood-friend-is-the-worlds-strongest-heroine-episode-7/",
                    "https://requiemtls.com/extra-cs-childhood-friend-is-the-worlds-strongest-heroine-episode-8/",
                    "https://requiemtls.com/extra-cs-childhood-friend-is-the-worlds-strongest-heroine-episode-9/",
                    "https://requiemtls.com/extra-cs-childhood-friend-is-the-worlds-strongest-heroine-episode-10/",
                    "https://requiemtls.com/extra-cs-childhood-friend-is-the-worlds-strongest-heroine-episode-11/",
                    "https://requiemtls.com/extra-cs-childhood-friend-is-the-worlds-strongest-heroine-episode-12/",
                    "https://requiemtls.com/extra-cs-childhood-friend-is-the-worlds-strongest-heroine-episode-13/",
                    "https://requiemtls.com/extra-cs-childhood-friend-is-the-worlds-strongest-heroine-episode-14/",
                    "https://requiemtls.com/extra-cs-childhood-friend-is-the-worlds-strongest-heroine-episode-15/",
                    "https://requiemtls.com/extra-cs-childhood-friend-is-the-worlds-strongest-heroine-episode-16/",
                    "https://requiemtls.com/extra-cs-childhood-friend-is-the-worlds-strongest-heroine-episode-17/",
                    "https://requiemtls.com/extra-cs-childhood-friend-is-the-worlds-strongest-heroine-episode-18/",
                    "https://requiemtls.com/extra-cs-childhood-friend-is-the-worlds-strongest-heroine-episode-19/",
                    "https://requiemtls.com/extra-cs-childhood-friend-is-the-worlds-strongest-heroine-episode-20/",
                    "https://requiemtls.com/extra-cs-childhood-friend-is-the-worlds-strongest-heroine-episode-21/",
                    "https://requiemtls.com/extra-cs-childhood-friend-is-the-worlds-strongest-heroine-episode-22/",
                    "https://requiemtls.com/extra-cs-childhood-friend-is-the-worlds-strongest-heroine-episode-23/",
                    "https://requiemtls.com/extra-cs-childhood-friend-is-the-worlds-strongest-heroine-episode-24/",
                    "https://requiemtls.com/extra-cs-childhood-friend-is-the-worlds-strongest-heroine-episode-25/",
                    "https://requiemtls.com/extra-cs-childhood-friend-is-the-worlds-strongest-heroine-episode-26/",
                    "https://requiemtls.com/extra-cs-childhood-friend-is-the-worlds-strongest-heroine-episode-27/",
                    "https://requiemtls.com/extra-cs-childhood-friend-is-the-worlds-strongest-heroine-episode-28/",
                    "https://requiemtls.com/extra-cs-childhood-friend-is-the-worlds-strongest-heroine-episode-29/",
                    "https://requiemtls.com/extra-cs-childhood-friend-is-the-worlds-strongest-heroine-episode-30/",
                    "https://requiemtls.com/extra-cs-childhood-friend-is-the-worlds-strongest-heroine-episode-31/",
                    "https://requiemtls.com/extra-cs-childhood-friend-is-the-worlds-strongest-heroine-episode-32/",
                    "https://requiemtls.com/extra-cs-childhood-friend-is-the-worlds-strongest-heroine-episode-33/",
                    "https://requiemtls.com/extra-cs-childhood-friend-is-the-worlds-strongest-heroine-episode-34/",
                    "https://requiemtls.com/extra-cs-childhood-friend-is-the-worlds-strongest-heroine-episode-35/",
                    "https://requiemtls.com/extra-cs-childhood-friend-is-the-worlds-strongest-heroine-episode-36/",
                    "https://requiemtls.com/extra-cs-childhood-friend-is-the-worlds-strongest-heroine-episode-37/",
                    "https://requiemtls.com/extra-cs-childhood-friend-is-the-worlds-strongest-heroine-episode-38/",
                    "https://requiemtls.com/extra-cs-childhood-friend-is-the-worlds-strongest-heroine-episode-39/",
                    "https://requiemtls.com/extra-cs-childhood-friend-is-the-worlds-strongest-heroine-episode-40/",
                    "https://requiemtls.com/extra-cs-childhood-friend-is-the-worlds-strongest-heroine-episode-41/",
                    "https://requiemtls.com/extra-cs-childhood-friend-is-the-worlds-strongest-heroine-episode-42/",
                    "https://requiemtls.com/extra-cs-childhood-friend-is-the-worlds-strongest-heroine-episode-43/",
                    "https://requiemtls.com/extra-cs-childhood-friend-is-the-worlds-strongest-heroine-episode-44/",
                    "https://requiemtls.com/extra-cs-childhood-friend-is-the-worlds-strongest-heroine-episode-45/",
                    "https://requiemtls.com/extra-cs-childhood-friend-is-the-worlds-strongest-heroine-episode-46/",
                    "https://requiemtls.com/extra-cs-childhood-friend-is-the-worlds-strongest-heroine-episode-47/",
                    "https://requiemtls.com/extra-cs-childhood-friend-is-the-worlds-strongest-heroine-episode-48/",
                    "https://requiemtls.com/extra-cs-childhood-friend-is-the-worlds-strongest-heroine-episode-49/",
                    "https://requiemtls.com/extra-cs-childhood-friend-is-the-worlds-strongest-heroine-episode-50/",
                    "https://requiemtls.com/extra-cs-childhood-friend-is-the-worlds-strongest-heroine-episode-51/",
                    "https://requiemtls.com/extra-cs-childhood-friend-is-the-worlds-strongest-heroine-episode-52/",
                    "https://requiemtls.com/extra-cs-childhood-friend-is-the-worlds-strongest-heroine-episode-53/",
                    "https://requiemtls.com/extra-cs-childhood-friend-is-the-worlds-strongest-heroine-episode-54/",
                    "https://requiemtls.com/extra-cs-childhood-friend-is-the-worlds-strongest-heroine-episode-55/",
                    "https://requiemtls.com/extra-cs-childhood-friend-is-the-worlds-strongest-heroine-episode-56/",
                    "https://requiemtls.com/extra-cs-childhood-friend-is-the-worlds-strongest-heroine-episode-57/",
                    "https://requiemtls.com/extra-cs-childhood-friend-is-the-worlds-strongest-heroine-episode-58/",
                    "https://requiemtls.com/extra-cs-childhood-friend-is-the-worlds-strongest-heroine-episode-59/",
                    "https://requiemtls.com/extra-cs-childhood-friend-is-the-worlds-strongest-heroine-episode-60/",
                    "https://requiemtls.com/extra-cs-childhood-friend-is-the-worlds-strongest-heroine-episode-61/",
                    "https://requiemtls.com/extra-cs-childhood-friend-is-the-worlds-strongest-heroine-episode-62/",
                    "https://requiemtls.com/extra-cs-childhood-friend-is-the-worlds-strongest-heroine-episode-63/",
                    "https://requiemtls.com/extra-cs-childhood-friend-is-the-worlds-strongest-heroine-episode-64/",
                    "https://requiemtls.com/extra-cs-childhood-friend-is-the-worlds-strongest-heroine-episode-65/",
                    "https://requiemtls.com/extra-cs-childhood-friend-is-the-worlds-strongest-heroine-episode-66/",
                    "https://requiemtls.com/extra-cs-childhood-friend-is-the-worlds-strongest-heroine-episode-67/",
                    "https://requiemtls.com/extra-cs-childhood-friend-is-the-worlds-strongest-heroine-episode-68/",
                    "https://requiemtls.com/extra-cs-childhood-friend-is-the-worlds-strongest-heroine-episode-69/",
                    "https://requiemtls.com/extra-cs-childhood-friend-is-the-worlds-strongest-heroine-episode-70/",
                    "https://requiemtls.com/extra-cs-childhood-friend-is-the-worlds-strongest-heroine-episode-71/",
                    "https://requiemtls.com/extra-cs-childhood-friend-is-the-worlds-strongest-heroine-episode-72/",
                    "https://requiemtls.com/extra-cs-childhood-friend-is-the-worlds-strongest-heroine-episode-73/",
                    "https://requiemtls.com/extra-cs-childhood-friend-is-the-worlds-strongest-heroine-episode-74/",
                    "https://requiemtls.com/extra-cs-childhood-friend-is-the-worlds-strongest-heroine-episode-75/"
                };

                const int chapterPerVolume = 100;

                int volume = 1;
                int chapter = 1;
                foreach (string url in urls) {
                    Console.WriteLine($"{url}");
                    await requiem.DownloadChapter(url, @"D:\Visual Novels\[Self-Sourced] [Ongoing] Extra C Childhood Friend\Raw\" + $"Volume {volume}", $"{(chapter++).ToString("D4")}.xhtml");

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