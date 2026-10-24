// Project > Properties > Change from Console Application to Windows Application when moving to production

namespace Source {
    internal class Program {
        static int Main(string[] args) {
            Task.Run(async void () => {
                Localizermeerkat scraper = new Localizermeerkat();

                string[] urls = {
                    "https://localizermeerkat.github.io/the-c-rank-magic-student-light-novel-illustrations/",
                    "https://localizermeerkat.github.io/the-c-rank-magic-student-volume-1-prologue/",
                    "https://localizermeerkat.github.io/the-c-rank-magic-student-volume-1-chapter-1-part-1/",
                    "https://localizermeerkat.github.io/the-c-rank-magic-student-volume-1-chapter-1-part-2/",
                    "https://localizermeerkat.github.io/c-level-magic-student-volume-1-chapter-2-part-1/",
                    "https://localizermeerkat.github.io/c-level-magic-student-volume-1-chapter-2-2/",
                    "https://localizermeerkat.github.io/c-level-magic-student-volume-1-chapter-3/",
                    "https://localizermeerkat.github.io/c-level-magic-student-volume-1-chapter-4-part-1/",
                    "https://localizermeerkat.github.io/c-level-magic-student-volume-1-chapter-4-part-2/",
                    "https://localizermeerkat.github.io/c-level-magic-student-volume-1-chapter-4-part-3/",
                    "https://localizermeerkat.github.io/c-level-magic-student-volume-1-chapter-4-part-4/",
                    "https://localizermeerkat.github.io/c-level-magic-student-volume-1-chapter-4-part-5/",
                    "https://localizermeerkat.github.io/c-level-magic-student-volume-1-chapter-5/",
                    "https://localizermeerkat.github.io/c-level-magic-student-volume-1-chapter-6-part-1/",
                    "https://localizermeerkat.github.io/c-level-magic-student-volume-1-chapter-6-part-2/",
                    "https://localizermeerkat.github.io/c-level-magic-student-volume-1-chapter-7-part-1/",
                    "https://localizermeerkat.github.io/c-level-magic-student-volume-1-chapter-7-part-2/",
                    "https://localizermeerkat.github.io/c-level-magic-student-volume-1-chapter-7-part-3/",
                    "https://localizermeerkat.github.io/c-level-magic-student-volume-1-chapter-7-part-4/",
                    "https://localizermeerkat.github.io/c-level-magic-student-volume-1-chapter-7-part-5/",
                    "https://localizermeerkat.github.io/c-level-magic-student-volume-1-chapter-8-part-1/",
                    "https://localizermeerkat.github.io/c-level-magic-student-volume-1-chapter-8-part-2/",
                    "https://localizermeerkat.github.io/c-level-magic-student-volume-1-chapter-9-part-1/",
                    "https://localizermeerkat.github.io/c-level-magic-student-volume-1-chapter-9-part-2/",
                    "https://localizermeerkat.github.io/c-level-magic-student-volume-1-chapter-9-part-3/",
                    "https://localizermeerkat.github.io/c-level-magic-student-volume-1-chapter-10-part-1/",
                    "https://localizermeerkat.github.io/c-level-magic-student-volume-1-chapter-10-part-2/",
                    "https://localizermeerkat.github.io/c-level-magic-student-volume-1-chapter-10-part-3/",
                    "https://localizermeerkat.github.io/c-level-magic-student-volume-1-chapter-10-part-4/",
                    "https://localizermeerkat.github.io/c-level-magic-student-volume-1-chapter-11-part-1/",
                    "https://localizermeerkat.github.io/c-level-magic-student-volume-1-chapter-11-part-2/",
                    "https://localizermeerkat.github.io/c-level-magic-student-volume-1-chapter-11-part-3/",
                    "https://localizermeerkat.github.io/c-level-magic-student-volume-1-chapter-11-part-4/",
                    "https://localizermeerkat.github.io/c-level-magic-student-volume-1-chapter-11-5/",
                    "https://localizermeerkat.github.io/c-level-magic-student-volume-1-chapter-12-part-1/",
                    "https://localizermeerkat.github.io/c-level-magic-student-volume-1-chapter-12-part-2/",
                    "https://localizermeerkat.github.io/c-level-magic-student-volume-1-chapter-12-part-3/",
                    "https://localizermeerkat.github.io/c-level-magic-student-volume-1-chapter-12-part-4/",
                    "https://localizermeerkat.github.io/c-level-magic-student-volume-1-chapter-12-part-5/",
                    "https://localizermeerkat.github.io/c-level-magic-student-volume-1-chapter-13-part-1/",
                    "https://localizermeerkat.github.io/c-level-magic-student-volume-1-chapter-13-part-2/",
                    "https://localizermeerkat.github.io/c-level-magic-student-volume-1-chapter-13-part-3/",
                    "https://localizermeerkat.github.io/c-level-magic-student-volume-1-chapter-epilogue/",
                    "https://localizermeerkat.github.io/c-level-magic-student-volume-1-extra-afterword/",

                    "https://localizermeerkat.github.io/the-c-rank-magic-student-light-novel-illustrations/2",
                    "https://localizermeerkat.github.io/c-level-magic-student-volume-2-prologue/",
                    "https://localizermeerkat.github.io/c-level-magic-student-volume-2-chapter-1-part-1/",
                    "https://localizermeerkat.github.io/c-level-magic-student-volume-2-chapter-1-part-2/",
                    "https://localizermeerkat.github.io/c-level-magic-student-volume-2-chapter-1-part-3/",
                    "https://localizermeerkat.github.io/c-level-magic-student-volume-2-chapter-1-part-4/",
                    "https://localizermeerkat.github.io/c-level-magic-student-volume-2-chapter-2-part-1/",
                    "https://localizermeerkat.github.io/c-level-magic-student-volume-2-chapter-2-part-2/",
                    "https://localizermeerkat.github.io/c-level-magic-student-volume-2-chapter-2-part-3/",
                    "https://localizermeerkat.github.io/c-level-magic-student-volume-2-chapter-2-part-4/",
                    "https://localizermeerkat.github.io/c-level-magic-student-volume-2-chapter-2-part-5/",
                    "https://localizermeerkat.github.io/c-level-magic-student-volume-2-chapter-2-part-6/",
                    "https://localizermeerkat.github.io/c-level-magic-student-volume-2-chapter-2-part-7/",
                    "https://localizermeerkat.github.io/c-level-magic-student-volume-2-chapter-3-part-1/",
                    "https://localizermeerkat.github.io/c-level-magic-student-volume-2-chapter-3-part-2/",
                    "https://localizermeerkat.github.io/c-level-magic-student-volume-2-chapter-4-part-1/",
                    "https://localizermeerkat.github.io/c-level-magic-student-volume-2-chapter-4-part-2/",
                    "https://localizermeerkat.github.io/c-level-magic-student-volume-2-chapter-4-part-3/",
                    "https://localizermeerkat.github.io/c-level-magic-student-volume-2-chapter-5-part-1/",
                    "https://localizermeerkat.github.io/c-level-magic-student-volume-2-chapter-5-part-2/",
                    "https://localizermeerkat.github.io/c-level-magic-student-volume-2-chapter-6-part-1/",
                    "https://localizermeerkat.github.io/c-level-magic-student-volume-2-chapter-6-part-2/",
                    "https://localizermeerkat.github.io/c-level-magic-student-volume-2-chapter-7-part-1/",
                    "https://localizermeerkat.github.io/c-level-magic-student-volume-2-chapter-7-part-2/",
                    "https://localizermeerkat.github.io/c-level-magic-student-volume-2-chapter-8-part-1/",
                    "https://localizermeerkat.github.io/c-level-magic-student-volume-2-chapter-8-part-2/",
                    "https://localizermeerkat.github.io/c-level-magic-student-volume-2-chapter-9-part-1/",
                    "https://localizermeerkat.github.io/c-level-magic-student-volume-2-chapter-9-part-2/",
                    "https://localizermeerkat.github.io/c-level-magic-student-volume-2-chapter-10-part-1/",
                    "https://localizermeerkat.github.io/c-level-magic-student-volume-2-chapter-10-part-2/",
                    "https://localizermeerkat.github.io/c-level-magic-student-volume-2-chapter-11-part-1/",
                    //"https://ko-fi.com/post/C-level-magic-student-Volume-2-Chapter-11-W7W41TABGV?fromEditor=true",
                    //"https://ko-fi.com/post/C-level-magic-student-Volume-2-Chapter-11-W7W41TABGV?fromEditor=true",
                    //"https://ko-fi.com/Post/C-level-magic-student-Volume-2-Chapter-12-Z8Z01VDRE9/",
                    //"https://ko-fi.com/Post/C-level-magic-student-Volume-2-Chapter-12-Z8Z01VDRE9/",
                    //"https://ko-fi.com/Post/C-level-magic-student-Volume-2-Chapter-12-Z8Z01VDRE9/",
                    //"https://ko-fi.com/Post/C-level-magic-student-Volume-2-Chapter-13-U7U61VDRLM/",
                    //"https://ko-fi.com/Post/C-level-magic-student-Volume-2-Chapter-14--Epilog-B0B41XGSJV/",
                    //"https://ko-fi.com/Post/C-level-magic-student-Volume-2-Chapter-14--Epilog-B0B41XGSJV/",
                    //"https://ko-fi.com/Post/C-level-magic-student-Volume-2-Chapter-14--Epilog-B0B41XGSJV/",
                };

                const int chapterPerVolume = 100;

                int skip = 0;

                int volume = 1;
                int chapter = 1;
                for (int i = 0; i < urls.Length; ++i) {
                    var url = urls[i];

                    Console.WriteLine($"{url}");

                    if (i >= skip) {
                        await scraper.DownloadChapter(url, @"D:\Visual Novels\[Self-Sourced] [Ongoing] C-level magic student who thinks he is SSS class\Raw\" + $"Volume {volume}", $"{chapter.ToString("D4")}.xhtml");
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