// Project > Properties > Change from Console Application to Windows Application when moving to production

namespace Source {
    internal class Program {
        static int Main(string[] args) {
            Task.Run(async void () => {
                GenesisStudio genesisStudio = new GenesisStudio();

                string[] urls = new string[] {
                    "https://dasuitl.com/wn/apparently-my-childhood-friends-older-sister-who-is-called-a-gal-nowadays-is-a-yandere-who-pathologically-loves-me/episode-1-you-should-ask-my-brother-that/"
                };

                urls = urls.Reverse().ToArray();

                const int chapterPerVolume = 100;

                int skip = 309;

                int volume = 1;
                int chapter = 1;
                for (int i = 0; i < urls.Length; ++i) {

                    var url = urls[i];
                    Console.WriteLine($"vol. {volume} ch. {chapter} - {url}");

                    if (i >= skip) {
                        await genesisStudio.DownloadChapter(url, @"D:\Visual Novels\[Self-Sourced] [Ongoing] The academy weakest became demon hunter\Raw\" + $"Volume {volume}", $"{chapter.ToString("D4")}.xhtml");
                    }

                    if ((++chapter) > chapterPerVolume) {
                        ++volume;
                        chapter = 1;
                    }

                    if (i >= skip) {
                        Thread.Sleep(3500); // Cloudflare rate limiting
                    }
                }

                Console.WriteLine("Done!");
            });

            Console.ReadLine();

            return 0;
        }
    }
}