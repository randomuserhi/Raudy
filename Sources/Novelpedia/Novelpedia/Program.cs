// Project > Properties > Change from Console Application to Windows Application when moving to production

namespace Source {
    internal struct NovelData {
        public string novelNo;
        public string path;
        public string[]? chapters;
    }

    internal class Program {
        static int Main(string[] args) {
            Task.Run(async void () => {
                Novelpia novelpia = new Novelpia();

                Novelpia.SessionInfo session = await novelpia.GetSession(
                    "magicalworld.nano@gmail.com",
                    "randomnovelpia1*"
                );

                NovelData[] novels = new NovelData[] {
                    new NovelData() {
                        novelNo = "1216",
                        path = @"D:\Visual Novels\[Self-Sourced] [Novelpia] I Can Hear the Saintess’s Inner Thoughts\Raw\",
                    },
                    new NovelData() {
                        novelNo = "312",
                        path = @"D:\Visual Novels\[Self-Sourced] [Novelpia] I Became the Husband of a Sword Demon\Raw\",
                    },
                    new NovelData() {
                        novelNo = "985",
                        path = @"D:\Visual Novels\[Self-Sourced] [Novelpia] The Priest's Wife Was a Demon King\Raw\",
                    },
                };

                foreach (var novel in novels) {
                    Console.WriteLine($"Starting {novel.path}");

                    string novelNo = novel.novelNo;

                    var episodes = await novelpia.GetChapterList(session, novelNo);

                    const int chapterPerVolume = 100;

                    int skip = 0;

                    int volume = 1;
                    int chapter = 1;
                    for (int i = 0; i < episodes.Length; ++i) {
                        var url = episodes[i];

                        Console.WriteLine($"{volume}:{chapter} - {url}");

                        string episodeNo = url.Split("/").Last();

                        bool scrape = (novel.chapters == null && i >= skip) || (novel.chapters != null && novel.chapters.Contains($"{volume}:{chapter}"));

                        if (scrape) {
                            await novelpia.DownloadChapter(session, novelNo, episodeNo, novel.path + $"Volume {volume}", $"{chapter.ToString("D4")}.xhtml");
                        }

                        if ((++chapter) > chapterPerVolume) {
                            ++volume;
                            chapter = 1;
                        }

                        if (scrape) {
                            Thread.Sleep(5000); // Cloudflare rate limiting
                        }
                    }

                    Console.WriteLine($"Finished {novel.path}");
                }

                Console.WriteLine("Done!");
            });

            Console.ReadLine();

            return 0;
        }
    }
}