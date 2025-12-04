// Project > Properties > Change from Console Application to Windows Application when moving to production

namespace Source {
    internal class Program {
        static int Main(string[] args) {
            Task.Run(async void () => {
                Novelpia novelpia = new Novelpia();

                Novelpia.SessionInfo session = await novelpia.GetSession("", "");

                string[] episodes = { };

                // The Overpowered Archmage Reveals Himself
                // novel_no 2642

                // The civil servant in a romance fantasy novel
                // novel_no = 86

                // The Side Character Is Retiring
                // novel_no = 958

                // The Imperial Princesses Are Obsessed With Their Knight
                // novel_no = 34

                const string novelNo = "2642";
                const string firstPaidEpisodeNo = "455951";

                const int chapterPerVolume = 100;

                int skip = 139;

                int volume = 1;
                int chapter = 1;
                for (int i = 0; i < episodes.Length; ++i) {
                    var url = episodes[i];

                    Console.WriteLine($"{url}");

                    string episodeNo = url.Split("/").Last();
                    if (episodeNo == firstPaidEpisodeNo) break; // Stop when we encounter paid episodes

                    if (i >= skip) {
                        await novelpia.DownloadChapter(session, novelNo, episodeNo, @"D:\Visual Novels\[Self-Sourced] [Novelpedia] The Overpowered Archmage Reveals Himself\Raw\" + $"Volume {volume}", $"{chapter.ToString("D4")}.xhtml");
                    }

                    if ((++chapter) > chapterPerVolume) {
                        ++volume;
                        chapter = 1;
                    }

                    if (i >= skip) {
                        Thread.Sleep(2000); // Cloudflare rate limiting
                    }
                }

                Console.WriteLine("Done!");
            });

            Console.ReadLine();

            return 0;
        }
    }
}