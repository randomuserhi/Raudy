// Project > Properties > Change from Console Application to Windows Application when moving to production

namespace Source {
    internal class Program {
        static int Main(string[] args) {
            Task.Run(async void () => {
                AsianLitLoom asianLitLoom = new AsianLitLoom();

                string[] urls = {
                    "http://www.asianlitloom.com/2024/02/i-became-a-childhood-friend-with-the-villainous-saintess-chapter-0.html",
"http://www.asianlitloom.com/2024/02/i-became-a-childhood-friend-with-the-villainous-saintess-chapter-1.html",
"http://www.asianlitloom.com/2024/02/i-became-a-childhood-friend-with-the-villainous-saintess-chapter-2.html",
"http://www.asianlitloom.com/2024/02/i-became-a-childhood-friend-with-the-villainous-saintess-chapter-3.html",
"http://www.asianlitloom.com/2024/02/i-became-a-childhood-friend-with-the-villainous-saintess-chapter-4.html",
"http://www.asianlitloom.com/2024/02/i-became-a-childhood-friend-with-the-villainous-saintess-chapter-5.html",
"http://www.asianlitloom.com/2024/02/i-became-a-childhood-friend-with-the-villainous-saintess-chapter-6.html",
"http://www.asianlitloom.com/2024/03/i-became-a-childhood-friend-with-the-villainous-saintess-chapter-7.html",
"http://www.asianlitloom.com/2024/03/i-became-a-childhood-friend-with-the-villainous-saintess-chapter-8.html",
"http://www.asianlitloom.com/2024/03/i-became-a-childhood-friend-with-the-villainous-saintess-chapter-9.html",
"http://www.asianlitloom.com/2024/03/i-became-a-childhood-friend-with-the-villainous-saintess-chapter-10.html",
"http://www.asianlitloom.com/2024/03/i-became-a-childhood-friend-with-the-villainous-saintess-chapter-11.html",
"http://www.asianlitloom.com/2024/03/i-became-a-childhood-friend-with-the-villainous-saintess-chapter-12.html",
"http://www.asianlitloom.com/2024/05/i-became-a-childhood-friend-with-the-villainous-saintess-chapter-13.html",
"http://www.asianlitloom.com/2024/05/i-became-a-childhood-friend-with-the-villainous-saintess-chapter-14.html",
"http://www.asianlitloom.com/2024/05/i-became-a-childhood-friend-with-the-villainous-saintess-chapter-15.html",
"http://www.asianlitloom.com/2024/05/i-became-a-childhood-friend-with-the-villainous-saintess-chapter-16.html",
"http://www.asianlitloom.com/2024/05/i-became-a-childhood-friend-with-the-villainous-saintess-chapter-17.html",
"http://www.asianlitloom.com/2024/05/i-became-a-childhood-friend-with-the-villainous-saintess-chapter-18.html",
"http://www.asianlitloom.com/2024/05/i-became-a-childhood-friend-with-the-villainous-saintess-chapter-19.html",
"http://www.asianlitloom.com/2024/05/i-became-a-childhood-friend-with-the-villainous-saintess-chapter-20.html",
"http://www.asianlitloom.com/2024/05/i-became-a-childhood-friend-with-the-villainous-saintess-chapter-21.html",
"http://www.asianlitloom.com/2024/05/i-became-a-childhood-friend-with-the-villainous-saintess-chapter-22.html",
"http://www.asianlitloom.com/2024/05/i-became-a-childhood-friend-with-the-villainous-saintess-chapter-23.html",
"http://www.asianlitloom.com/2024/06/i-became-a-childhood-friend-with-the-villainous-saintess-chapter-24.html",
"http://www.asianlitloom.com/2024/06/i-became-a-childhood-friend-with-the-villainous-saintess-chapter-25.html",
"http://www.asianlitloom.com/2024/06/i-became-a-childhood-friend-with-the-villainous-saintess-chapter-26.html",
"http://www.asianlitloom.com/2024/06/i-became-a-childhood-friend-with-the-villainous-saintess-chapter-27.html",
"http://www.asianlitloom.com/2024/06/i-became-a-childhood-friend-with-the-villainous-saintess-chapter-28.html",
"http://www.asianlitloom.com/2024/06/i-became-a-childhood-friend-with-the-villainous-saintess-chapter-29.html",
"http://www.asianlitloom.com/2024/06/i-became-a-childhood-friend-with-the-villainous-saintess-chapter-30.html",
"http://www.asianlitloom.com/2024/07/i-became-a-childhood-friend-with-the-villainous-saintess-chapter-31.html",
"http://www.asianlitloom.com/2024/07/i-became-a-childhood-friend-with-the-villainous-saintess-chapter-32.html",
"http://www.asianlitloom.com/2024/07/i-became-a-childhood-friend-with-the-villainous-saintess-chapter-33.html",
"http://www.asianlitloom.com/2024/07/i-became-a-childhood-friend-with-the-villainous-saintess-chapter-34.html",
"http://www.asianlitloom.com/2024/07/i-became-a-childhood-friend-with-the-villainous-saintess-chapter-35.html",
"http://www.asianlitloom.com/2024/07/i-became-a-childhood-friend-with-the-villainous-saintess-chapter-36.html",
"http://www.asianlitloom.com/2024/07/i-became-a-childhood-friend-with-the-villainous-saintess-chapter-37.html",
"http://www.asianlitloom.com/2024/08/i-became-a-childhood-friend-with-the-villainous-saintess-chapter-38.html",
"http://www.asianlitloom.com/2024/08/i-became-a-childhood-friend-with-the-villainous-saintess-chapter-39.html",
"http://www.asianlitloom.com/2024/08/i-became-a-childhood-friend-with-the-villainous-saintess-chapter-40.html",
"http://www.asianlitloom.com/2024/08/i-became-a-childhood-friend-with-the-villainous-saintess-chapter-41.html",
"http://www.asianlitloom.com/2024/08/i-became-a-childhood-friend-with-the-villainous-saintess-chapter-42.html",
"http://www.asianlitloom.com/2024/08/i-became-a-childhood-friend-with-the-villainous-saintess-chapter-43.html",
"http://www.asianlitloom.com/2024/08/i-became-a-childhood-friend-with-the-villainous-saintess-chapter-44.html",
"http://www.asianlitloom.com/2024/08/i-became-a-childhood-friend-with-the-villainous-saintess-chapter-45.html",
"http://www.asianlitloom.com/2024/08/i-became-a-childhood-friend-with-the-villainous-saintess-chapter-46.html",
"http://www.asianlitloom.com/2024/08/i-became-a-childhood-friend-with-the-villainous-saintess-chapter-47.html",
"http://www.asianlitloom.com/2024/09/i-became-a-childhood-friend-with-the-villainous-saintess-chapter-48.html",
"http://www.asianlitloom.com/2024/09/i-became-a-childhood-friend-with-the-villainous-saintess-chapter-49.html",
"http://www.asianlitloom.com/2024/09/i-became-a-childhood-friend-with-the-villainous-saintess-chapter-50.html",
"http://www.asianlitloom.com/2024/09/i-became-a-childhood-friend-with-the-villainous-saintess-chapter-51.html",
"http://www.asianlitloom.com/2024/09/i-became-a-childhood-friend-with-the-villainous-saintess-chapter-52.html",
"http://www.asianlitloom.com/2024/09/i-became-a-childhood-friend-with-the-villainous-saintess-chapter-53.html",
"http://www.asianlitloom.com/2024/09/i-became-a-childhood-friend-with-the-villainous-saintess-chapter-54.html",
"http://www.asianlitloom.com/2024/10/i-became-a-childhood-friend-with-the-villainous-saintess-chapter-58.html",
"http://www.asianlitloom.com/2024/09/i-became-a-childhood-friend-with-the-villainous-saintess-chapter-55.html",
"http://www.asianlitloom.com/2024/10/i-became-a-childhood-friend-with-the-villainous-saintess-chapter-56.html",
"http://www.asianlitloom.com/2024/10/i-became-a-childhood-friend-with-the-villainous-saintess-chapter-57.html",
"http://www.asianlitloom.com/2024/10/i-became-a-childhood-friend-with-the-villainous-saintess-chapter-59.html",
"http://www.asianlitloom.com/2024/11/i-became-a-childhood-friend-with-the-villainous-saintess-chapter-60.html",
"http://www.asianlitloom.com/2024/11/i-became-a-childhood-friend-with-the-villainous-saintess-chapter-61.html",
"http://www.asianlitloom.com/2024/11/i-became-a-childhood-friend-with-the-villainous-saintess-chapter-62.html",
"http://www.asianlitloom.com/2024/11/i-became-a-childhood-friend-with-the-villainous-saintess-chapter-63.html",
"http://www.asianlitloom.com/2024/11/i-became-a-childhood-friend-with-the-villainous-saintess-chapter-64.html",
"http://www.asianlitloom.com/2024/11/i-became-a-childhood-friend-with-the-villainous-saintess-chapter-65.html",
"http://www.asianlitloom.com/2024/11/i-became-a-childhood-friend-with-the-villainous-saintess-chapter-66.html",
"http://www.asianlitloom.com/2024/12/i-became-a-childhood-friend-with-the-villainous-saintess-chapter-67.html",
"http://www.asianlitloom.com/2024/12/i-became-a-childhood-friend-with-the-villainous-saintess-chapter-68.html",
"http://www.asianlitloom.com/2024/12/i-became-a-childhood-friend-with-the-villainous-saintess-chapter-69.html",
"http://www.asianlitloom.com/2024/12/i-became-a-childhood-friend-with-the-villainous-saintess-chapter-70.html",
"http://www.asianlitloom.com/2024/12/i-became-a-childhood-friend-with-the-villainous-saintess-chapter-71.html",
"http://www.asianlitloom.com/2025/01/i-became-a-childhood-friend-with-the-villainous-saintess-chapter-76.html",
"http://www.asianlitloom.com/2024/12/i-became-a-childhood-friend-with-the-villainous-saintess-chapter-72.html",
"http://www.asianlitloom.com/2024/12/i-became-a-childhood-friend-with-the-villainous-saintess-chapter-73.html",
"http://www.asianlitloom.com/2024/12/i-became-a-childhood-friend-with-the-villainous-saintess-chapter-74.html",
"http://www.asianlitloom.com/2025/01/i-became-a-childhood-friend-with-the-villainous-saintess-chapter-75.html",
"http://www.asianlitloom.com/2025/01/i-became-a-childhood-friend-with-the-villainous-saintess-chapter-77.html",
"http://www.asianlitloom.com/2025/01/i-became-a-childhood-friend-with-the-villainous-saintess-chapter-78.html",
"http://www.asianlitloom.com/2025/01/i-became-a-childhood-friend-with-the-villainous-saintess-chapter-79.html",
"http://www.asianlitloom.com/2025/01/i-became-a-childhood-friend-with-the-villainous-saintess-chapter-80.html",
"http://www.asianlitloom.com/2025/01/i-became-a-childhood-friend-with-the-villainous-saintess-chapter-81.html",
"http://www.asianlitloom.com/2025/02/i-became-a-childhood-friend-with-the-villainous-saintess-chapter-82.html",
"http://www.asianlitloom.com/2025/02/i-became-a-childhood-friend-with-the-villainous-saintess-chapter-83.html",
"http://www.asianlitloom.com/2025/03/i-became-a-childhood-friend-with-the-villainous-saintess-chapter-84.html",
"http://www.asianlitloom.com/2025/03/i-became-a-childhood-friend-with-the-villainous-saintess-chapter-85.html",
"http://www.asianlitloom.com/2025/03/i-became-a-childhood-friend-with-the-villainous-saintess-chapter-86.html",
"http://www.asianlitloom.com/2025/03/i-became-a-childhood-friend-with-the-villainous-saintess-chapter-87.html",
"http://www.asianlitloom.com/2025/03/i-became-a-childhood-friend-with-the-villainous-saintess-chapter-88.html",
"http://www.asianlitloom.com/2025/04/i-became-a-childhood-friend-with-the-villainous-saintess-chapter-89.html",
                };

                const int chapterPerVolume = 100;

                int volume = 1;
                int chapter = 1;
                foreach (string url in urls) {
                    Console.WriteLine($"{url}");
                    await asianLitLoom.DownloadChapter(url, @"D:\Visual Novels\[Self-Sourced] [Ongoing] Childhood friend villainess saintess\Raw\" + $"Volume {volume}", $"{(chapter++).ToString("D4")}.xhtml");

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