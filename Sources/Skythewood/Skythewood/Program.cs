// Project > Properties > Change from Console Application to Windows Application when moving to production

namespace Source {
    internal class Program {
        static int Main(string[] args) {
            Task.Run(async void () => {
                Skythewood skythewood = new Skythewood();
                /*string volume = "Volume 1";
                string[] urls = new string[] {
                    "https://skythewood.blogspot.com/2021/08/H11.html",
                    "https://skythewood.blogspot.com/2021/09/H12.html",
                    "https://skythewood.blogspot.com/2021/09/H14.html",
                    "https://skythewood.blogspot.com/2021/10/H15.html",
                    "https://skythewood.blogspot.com/2021/11/too-many-losing-heroines-v1-afterword.html",
                    "https://skythewood.blogspot.com/2021/11/too-many-losing-heroines-v1-special.html",
                    "https://skythewood.blogspot.com/2022/08/too-many-losing-heroines-v1-special.html",
                    "https://skythewood.blogspot.com/2022/08/too-many-losing-heroines-v1-special_18.html",
                    "https://skythewood.blogspot.com/2022/08/too-many-losing-heroines-v1-special_52.html",
                    "https://skythewood.blogspot.com/2022/08/too-many-losing-heroines-v1-special_20.html"
                };*/

                /*string volume = "Volume 2";
                string[] urls = new string[] {
                    "https://skythewood.blogspot.com/2022/04/too-many-losing-heroines-v2-prologue.html",
                    "https://skythewood.blogspot.com/2022/05/too-many-losing-heroines-v2-chapter-2.html",
                    "https://skythewood.blogspot.com/2022/06/too-many-losing-heroines-v2-chapter-3.html",
                    "https://skythewood.blogspot.com/2022/08/too-many-losing-heroines-v2-chapter-4.html",
                    "https://skythewood.blogspot.com/2022/09/too-many-losing-heroines-v2-afterword.html",
                    "https://skythewood.blogspot.com/2022/09/too-many-losing-heroines-v2-special.html",
                    "https://skythewood.blogspot.com/2022/12/too-many-losing-heroines-v2-special.html"
                };*/

                /*string volume = "Volume 3";
                string[] urls = new string[] {
                    "https://skythewood.blogspot.com/2022/10/too-many-losing-heroines-v3-prologue.html",
                    "https://skythewood.blogspot.com/2022/11/too-many-losing-heroines-v3-chapter-2.html",
                    "https://skythewood.blogspot.com/2022/11/too-many-losing-heroines-v3-chapter-3.html",
                    "https://skythewood.blogspot.com/2022/11/too-many-losing-heroines-v3-chapter-4.html",
                    "https://skythewood.blogspot.com/2022/12/too-many-losing-heroines-v3-afterword.html",
                    "https://skythewood.blogspot.com/2023/01/too-many-losing-heroines-v3-special.html",
                    "https://skythewood.blogspot.com/2023/01/too-many-losing-heroines-v3-special_28.html",
                    "https://skythewood.blogspot.com/2023/03/too-many-losing-heroines-v3-special.html"
                };*/

                /*string volume = "Volume 4";
                string[] urls = new string[] {
                    "https://skythewood.blogspot.com/2022/12/too-many-losing-heroines-v4-prologue.html",
                    "https://skythewood.blogspot.com/2023/01/too-many-losing-heroines-v4-chapter-2.html",
                    "https://skythewood.blogspot.com/2023/01/too-many-losing-heroines-v4-chapter-3.html",
                    "https://skythewood.blogspot.com/2023/01/too-many-losing-heroines-v4-chapter-4.html",
                    "https://skythewood.blogspot.com/2023/02/too-many-losing-heroines-v4-afterword.html",
                    "https://skythewood.blogspot.com/2023/03/too-many-losing-heroines-v4-special.html",
                    "https://skythewood.blogspot.com/2023/09/too-many-losing-heroines-v4-special.html",
                    "https://skythewood.blogspot.com/2023/10/too-many-losing-heroines-v4-special.html"
                };*/

                string volume = "Volume 5";
                string[] urls = new string[] {
                    "https://skythewood.blogspot.com/2023/03/too-many-losing-heroines-v5-prologue.html",
                    "https://skythewood.blogspot.com/2023/04/too-many-losing-heroines-v5-chapter-2.html",
                    "https://skythewood.blogspot.com/2023/05/too-many-losing-heroines-v5-chapter-3.html",
                    "https://skythewood.blogspot.com/2023/07/too-many-losing-heroines-v5-chapter-4.html",
                    "https://skythewood.blogspot.com/2023/08/too-many-losing-heroines-v5-afterword.html",
                    "https://skythewood.blogspot.com/2023/12/too-many-losing-heroines-v5-special.html",
                    "https://skythewood.blogspot.com/2023/12/too-many-losing-heroines-v5-special_14.html",
                    "https://skythewood.blogspot.com/2023/12/too-many-losing-heroines-anime.html"
                };

                // ----

                for (int i = 0; i < urls.Length; ++i) {
                    await skythewood.DownloadBlog(urls[i], @"D:\Visual Novels\[Self-Sourced] Too Many Losing Herorines (skythewood)\Raw\" + volume, $"{(i + 1).ToString("D4")}.xhtml");
                }
                Console.WriteLine("Done!");
            });

            Console.ReadLine();

            return 0;
        }
    }
}