// Project > Properties > Change from Console Application to Windows Application when moving to production

namespace Source {
    internal class Program {
        static int Main(string[] args) {
            Task.Run(async void () => {
                KDTNovels darkStarTL = new KDTNovels();

                string[] urls = {
                    "https://kdtnovels.com/novel/im-a-kept-man-for-the-three-most-beautiful-girls-in-school/vol-1-ch-0/",
                    "https://kdtnovels.com/novel/im-a-kept-man-for-the-three-most-beautiful-girls-in-school/vol-1-ch-1/",
                    "https://kdtnovels.com/novel/im-a-kept-man-for-the-three-most-beautiful-girls-in-school/vol-1-ch-2/",
                    "https://kdtnovels.com/novel/im-a-kept-man-for-the-three-most-beautiful-girls-in-school/vol-1-ch-3/",
                    "https://kdtnovels.com/novel/im-a-kept-man-for-the-three-most-beautiful-girls-in-school/vol-1-ch-4/",
                    "https://kdtnovels.com/novel/im-a-kept-man-for-the-three-most-beautiful-girls-in-school/vol-1-ch-5/",
                    "https://kdtnovels.com/novel/im-a-kept-man-for-the-three-most-beautiful-girls-in-school/vol-1-epilogue/",
                    "https://kdtnovels.com/novel/im-a-kept-man-for-the-three-most-beautiful-girls-in-school/vol-2-ch-0/",
                    "https://kdtnovels.com/novel/im-a-kept-man-for-the-three-most-beautiful-girls-in-school/vol-2-ch-1/",
                    "https://kdtnovels.com/novel/im-a-kept-man-for-the-three-most-beautiful-girls-in-school/vol-2-ch-2/",
                    "https://kdtnovels.com/novel/im-a-kept-man-for-the-three-most-beautiful-girls-in-school/vol-2-ch-3/",
                    "https://kdtnovels.com/novel/im-a-kept-man-for-the-three-most-beautiful-girls-in-school/vol-2-ch-4/",
                    "https://kdtnovels.com/novel/im-a-kept-man-for-the-three-most-beautiful-girls-in-school/vol-2-epilogue/",
                };

                const int chapterPerVolume = 100;

                int volume = 1;
                int chapter = 1;
                foreach (string url in urls) {
                    Console.WriteLine($"{url}");
                    await darkStarTL.DownloadChapter(url, @"D:\Visual Novels\[Self-Sourced] Kept man for three girls\Raw\" + $"Volume {volume}", $"{(chapter++).ToString("D4")}.xhtml");

                    if (chapter > chapterPerVolume) {
                        ++volume;
                        chapter = 1;
                    }

                    Thread.Sleep(1500); // Cloudflare rate limiting
                }

                Console.WriteLine("Done!");
            });

            Console.ReadLine();

            return 0;
        }
    }
}