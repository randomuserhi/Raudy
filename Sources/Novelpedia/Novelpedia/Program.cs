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

                Novelpia.SessionInfo session = await novelpia.GetSession("", "");

                NovelData[] novels = new NovelData[] {
                    new NovelData() {
                        novelNo = "3651",
                        path = @"D:\Visual Novels\[Self-Sourced] [Novelpia] I Became the Hated Villain of the Academy\Raw\",
                        chapters = new string[] { "1:32",
"1:34",
"1:50",
"1:59",
"1:70",
"1:85",
"1:87",
"2:1",
"2:7",
"2:16",
"2:27",
"2:29",
"2:33",
"2:42",
"2:44",
"2:48",
"2:52",
"2:55",
"2:59",
"2:60",
"2:68",
"2:78" }
                    },
                    new NovelData() {
                        novelNo = "2759",
                        path = @"D:\Visual Novels\[Self-Sourced] [Novelpia] The Childhood Friend of an Unconquerable Heroine\Raw\",
                        chapters = new string[] { "2:92" }
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