// Project > Properties > Change from Console Application to Windows Application when moving to production

namespace Source {
    internal struct NovelData {
        public string novelNo;
        public string path;
    }

    internal class Program {
        static int Main(string[] args) {
            Task.Run(async void () => {
                Novelpia novelpia = new Novelpia();

                Novelpia.SessionInfo session = await novelpia.GetSession("", "");

                NovelData[] novels = new NovelData[] {
                    new NovelData() {
                        novelNo = "1837",
                        path = @"D:\Visual Novels\[Self-Sourced] [Novelpia] The Romance Fantasy Novel MC is Only Into Me\Raw\"
                    },
                    new NovelData() {
                        novelNo = "1312",
                        path = @"D:\Visual Novels\[Self-Sourced] [Novelpia] I Saved the Heroine Just Before Her Death\Raw\"
                    },
                    new NovelData() {
                        novelNo = "1145",
                        path = @"D:\Visual Novels\[Self-Sourced] [Novelpia] The Hero and the Beast\Raw\"
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

                        if (i >= skip) {
                            await novelpia.DownloadChapter(session, novelNo, episodeNo, novel.path + $"Volume {volume}", $"{chapter.ToString("D4")}.xhtml");
                        }

                        if ((++chapter) > chapterPerVolume) {
                            ++volume;
                            chapter = 1;
                        }

                        if (i >= skip) {
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