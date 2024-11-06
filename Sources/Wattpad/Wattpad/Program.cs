// Project > Properties > Change from Console Application to Windows Application when moving to production

namespace Source {
    internal class Program {
        static int Main(string[] args) {
            Task.Run(async void () => {
                Wattpad wattpad = new Wattpad();
                string[][] Volumes = new string[][] {
                    new string[] {
                        "https://www.wattpad.com/1457527820-i-became-a-flashing-genius-at-the-magic-academy",
                        "https://www.wattpad.com/1457528046-i-became-a-flashing-genius-at-the-magic-academy",
                        "https://www.wattpad.com/1457528264-i-became-a-flashing-genius-at-the-magic-academy",
                        "https://www.wattpad.com/1457528358-i-became-a-flashing-genius-at-the-magic-academy",
                        "https://www.wattpad.com/1457529052-i-became-a-flashing-genius-at-the-magic-academy",
                        "https://www.wattpad.com/1457529175-i-became-a-flashing-genius-at-the-magic-academy",
                        "https://www.wattpad.com/1457529251-i-became-a-flashing-genius-at-the-magic-academy",
                        "https://www.wattpad.com/1457529303-i-became-a-flashing-genius-at-the-magic-academy",
                        "https://www.wattpad.com/1457916409-i-became-a-flashing-genius-at-the-magic-academy",
                        "https://www.wattpad.com/1457916575-i-became-a-flashing-genius-at-the-magic-academy",
                        "https://www.wattpad.com/1457916661-i-became-a-flashing-genius-at-the-magic-academy",
                        "https://www.wattpad.com/1457916755-i-became-a-flashing-genius-at-the-magic-academy",
                        "https://www.wattpad.com/1457916922-i-became-a-flashing-genius-at-the-magic-academy",
                        "https://www.wattpad.com/1457917021-i-became-a-flashing-genius-at-the-magic-academy",
                        "https://www.wattpad.com/1458349483-i-became-a-flashing-genius-at-the-magic-academy",
                        "https://www.wattpad.com/1458364343-i-became-a-flashing-genius-at-the-magic-academy",
                        "https://www.wattpad.com/1458371235-i-became-a-flashing-genius-at-the-magic-academy",
                        "https://www.wattpad.com/1458378773-i-became-a-flashing-genius-at-the-magic-academy",
                        "https://www.wattpad.com/1458381861-i-became-a-flashing-genius-at-the-magic-academy",
                        "https://www.wattpad.com/1459303040-i-became-a-flashing-genius-at-the-magic-academy",
                        "https://www.wattpad.com/1459307552-i-became-a-flashing-genius-at-the-magic-academy",
                        "https://www.wattpad.com/1459307921-i-became-a-flashing-genius-at-the-magic-academy",
                        "https://www.wattpad.com/1459308029-i-became-a-flashing-genius-at-the-magic-academy",
                        "https://www.wattpad.com/1459308267-i-became-a-flashing-genius-at-the-magic-academy",
                        "https://www.wattpad.com/1459308495-i-became-a-flashing-genius-at-the-magic-academy",
                        "https://www.wattpad.com/1459308571-i-became-a-flashing-genius-at-the-magic-academy",
                        "https://www.wattpad.com/1459308681-i-became-a-flashing-genius-at-the-magic-academy",
                        "https://www.wattpad.com/1459308773-i-became-a-flashing-genius-at-the-magic-academy",
                        "https://www.wattpad.com/1459308889-i-became-a-flashing-genius-at-the-magic-academy",
                        "https://www.wattpad.com/1459309002-i-became-a-flashing-genius-at-the-magic-academy",
                        "https://www.wattpad.com/1459309108-i-became-a-flashing-genius-at-the-magic-academy",
                        "https://www.wattpad.com/1460202351-i-became-a-flashing-genius-at-the-magic-academy",
                        "https://www.wattpad.com/1460202677-i-became-a-flashing-genius-at-the-magic-academy",
                        "https://www.wattpad.com/1460203061-i-became-a-flashing-genius-at-the-magic-academy",
                        "https://www.wattpad.com/1460203158-i-became-a-flashing-genius-at-the-magic-academy",
                        "https://www.wattpad.com/1460203298-i-became-a-flashing-genius-at-the-magic-academy",
                        "https://www.wattpad.com/1460203394-i-became-a-flashing-genius-at-the-magic-academy",
                        "https://www.wattpad.com/1460203512-i-became-a-flashing-genius-at-the-magic-academy",
                        "https://www.wattpad.com/1460203579-i-became-a-flashing-genius-at-the-magic-academy",
                        "https://www.wattpad.com/1460469280-i-became-a-flashing-genius-at-the-magic-academy",
                        "https://www.wattpad.com/1460469467-i-became-a-flashing-genius-at-the-magic-academy",
                        "https://www.wattpad.com/1460469693-i-became-a-flashing-genius-at-the-magic-academy",
                        "https://www.wattpad.com/1460469784-i-became-a-flashing-genius-at-the-magic-academy",
                        "https://www.wattpad.com/1460469839-i-became-a-flashing-genius-at-the-magic-academy",
                        "https://www.wattpad.com/1460469949-i-became-a-flashing-genius-at-the-magic-academy",
                        "https://www.wattpad.com/1460470020-i-became-a-flashing-genius-at-the-magic-academy",
                        "https://www.wattpad.com/1460470070-i-became-a-flashing-genius-at-the-magic-academy",
                        "https://www.wattpad.com/1460470140-i-became-a-flashing-genius-at-the-magic-academy",
                        "https://www.wattpad.com/1460470219-i-became-a-flashing-genius-at-the-magic-academy",
                        "https://www.wattpad.com/1460470283-i-became-a-flashing-genius-at-the-magic-academy",
                        "https://www.wattpad.com/1462796193-i-became-a-flashing-genius-at-the-magic-academy",
                        "https://www.wattpad.com/1462816827-i-became-a-flashing-genius-at-the-magic-academy",
                    },
                    new string[] {
                        "https://www.wattpad.com/1463013862-i-became-a-flashing-genius-at-the-magic-academy",
                        "https://www.wattpad.com/1463013996-i-became-a-flashing-genius-at-the-magic-academy",
                        "https://www.wattpad.com/1463014117-i-became-a-flashing-genius-at-the-magic-academy",
                        "https://www.wattpad.com/1463014187-i-became-a-flashing-genius-at-the-magic-academy",
                        "https://www.wattpad.com/1463014240-i-became-a-flashing-genius-at-the-magic-academy",
                        "https://www.wattpad.com/1463227881-i-became-a-flashing-genius-at-the-magic-academy",
                        "https://www.wattpad.com/1463228083-i-became-a-flashing-genius-at-the-magic-academy",
                        "https://www.wattpad.com/1463228174-i-became-a-flashing-genius-at-the-magic-academy",
                        "https://www.wattpad.com/1463783243-i-became-a-flashing-genius-at-the-magic-academy",
                        "https://www.wattpad.com/1463228250-i-became-a-flashing-genius-at-the-magic-academy",
                        "https://www.wattpad.com/1463228306-i-became-a-flashing-genius-at-the-magic-academy",
                        "https://www.wattpad.com/1463228381-i-became-a-flashing-genius-at-the-magic-academy",
                        "https://www.wattpad.com/1463228508-i-became-a-flashing-genius-at-the-magic-academy",
                        "https://www.wattpad.com/1463228574-i-became-a-flashing-genius-at-the-magic-academy",
                        "https://www.wattpad.com/1463228671-i-became-a-flashing-genius-at-the-magic-academy",
                        "https://www.wattpad.com/1463228735-i-became-a-flashing-genius-at-the-magic-academy",
                        "https://www.wattpad.com/1464448450-i-became-a-flashing-genius-at-the-magic-academy",
                        "https://www.wattpad.com/1464448629-i-became-a-flashing-genius-at-the-magic-academy",
                        "https://www.wattpad.com/1464448689-i-became-a-flashing-genius-at-the-magic-academy",
                        "https://www.wattpad.com/1464448798-i-became-a-flashing-genius-at-the-magic-academy",
                        "https://www.wattpad.com/1464448863-i-became-a-flashing-genius-at-the-magic-academy",
                        "https://www.wattpad.com/1464448926-i-became-a-flashing-genius-at-the-magic-academy",
                        "https://www.wattpad.com/1464448978-i-became-a-flashing-genius-at-the-magic-academy",
                        "https://www.wattpad.com/1464449067-i-became-a-flashing-genius-at-the-magic-academy",
                        "https://www.wattpad.com/1464449140-i-became-a-flashing-genius-at-the-magic-academy",
                        "https://www.wattpad.com/1465789881-i-became-a-flashing-genius-at-the-magic-academy",
                        "https://www.wattpad.com/1465790550-i-became-a-flashing-genius-at-the-magic-academy",
                        "https://www.wattpad.com/1465790622-i-became-a-flashing-genius-at-the-magic-academy",
                        "https://www.wattpad.com/1465790682-i-became-a-flashing-genius-at-the-magic-academy",
                        "https://www.wattpad.com/1465790790-i-became-a-flashing-genius-at-the-magic-academy",
                        "https://www.wattpad.com/1467306206-i-became-a-flashing-genius-at-the-magic-academy",
                        "https://www.wattpad.com/1467306999-i-became-a-flashing-genius-at-the-magic-academy",
                        "https://www.wattpad.com/1467307526-i-became-a-flashing-genius-at-the-magic-academy",
                        "https://www.wattpad.com/1467307617-i-became-a-flashing-genius-at-the-magic-academy",
                        "https://www.wattpad.com/1467307713-i-became-a-flashing-genius-at-the-magic-academy",
                        "https://www.wattpad.com/1467307835-i-became-a-flashing-genius-at-the-magic-academy",
                        "https://www.wattpad.com/1467307898-i-became-a-flashing-genius-at-the-magic-academy",
                        "https://www.wattpad.com/1467308536-i-became-a-flashing-genius-at-the-magic-academy",
                        "https://www.wattpad.com/1467308655-i-became-a-flashing-genius-at-the-magic-academy",
                        "https://www.wattpad.com/1467308741-i-became-a-flashing-genius-at-the-magic-academy",
                        "https://www.wattpad.com/1469201046-i-became-a-flashing-genius-at-the-magic-academy",
                        "https://www.wattpad.com/1469201374-i-became-a-flashing-genius-at-the-magic-academy",
                        "https://www.wattpad.com/1469201456-i-became-a-flashing-genius-at-the-magic-academy",
                        "https://www.wattpad.com/1469263654-i-became-a-flashing-genius-at-the-magic-academy",
                        "https://www.wattpad.com/1469264971-i-became-a-flashing-genius-at-the-magic-academy",
                        "https://www.wattpad.com/1469265187-i-became-a-flashing-genius-at-the-magic-academy",
                        "https://www.wattpad.com/1469265333-i-became-a-flashing-genius-at-the-magic-academy",
                        "https://www.wattpad.com/1469265555-i-became-a-flashing-genius-at-the-magic-academy",
                        "https://www.wattpad.com/1469265631-i-became-a-flashing-genius-at-the-magic-academy",
                        "https://www.wattpad.com/1469265716-i-became-a-flashing-genius-at-the-magic-academy",
                        "https://www.wattpad.com/1469265960-i-became-a-flashing-genius-at-the-magic-academy",
                    },
                    new string[] {
                        "https://www.wattpad.com/1469610057-i-became-a-flashing-genius-at-the-magic-academy",
                        "https://www.wattpad.com/1470376433-i-became-a-flashing-genius-at-the-magic-academy",
                        "https://www.wattpad.com/1470429627-i-became-a-flashing-genius-at-the-magic-academy",
                        "https://www.wattpad.com/1470441694-i-became-a-flashing-genius-at-the-magic-academy",
                        "https://www.wattpad.com/1470596557-i-became-a-flashing-genius-at-the-magic-academy",
                        "https://www.wattpad.com/1470648620-i-became-a-flashing-genius-at-the-magic-academy",
                        "https://www.wattpad.com/1471074765-i-became-a-flashing-genius-at-the-magic-academy",
                        "https://www.wattpad.com/1471297572-i-became-a-flashing-genius-at-the-magic-academy",
                        "https://www.wattpad.com/1471302262-i-became-a-flashing-genius-at-the-magic-academy",
                        "https://www.wattpad.com/1471302311-i-became-a-flashing-genius-at-the-magic-academy",
                        "https://www.wattpad.com/1471302341-i-became-a-flashing-genius-at-the-magic-academy",
                        "https://www.wattpad.com/1471747007-i-became-a-flashing-genius-at-the-magic-academy",
                        "https://www.wattpad.com/1471747719-i-became-a-flashing-genius-at-the-magic-academy",
                        "https://www.wattpad.com/1471749371-i-became-a-flashing-genius-at-the-magic-academy",
                        "https://www.wattpad.com/1471849723-i-became-a-flashing-genius-at-the-magic-academy",
                        "https://www.wattpad.com/1472082848-i-became-a-flashing-genius-at-the-magic-academy",
                        "https://www.wattpad.com/1472193030-i-became-a-flashing-genius-at-the-magic-academy",
                        "https://www.wattpad.com/1473446282-i-became-a-flashing-genius-at-the-magic-academy",
                        "https://www.wattpad.com/1473766382-i-became-a-flashing-genius-at-the-magic-academy",
                        "https://www.wattpad.com/1473717311-i-became-a-flashing-genius-at-the-magic-academy",
                        "https://www.wattpad.com/1473783821-i-became-a-flashing-genius-at-the-magic-academy",
                        "https://www.wattpad.com/1473784119-i-became-a-flashing-genius-at-the-magic-academy",
                        "https://www.wattpad.com/1473784226-i-became-a-flashing-genius-at-the-magic-academy",
                        "https://www.wattpad.com/1473784387-i-became-a-flashing-genius-at-the-magic-academy",
                        "https://www.wattpad.com/1473784545-i-became-a-flashing-genius-at-the-magic-academy",
                        "https://www.wattpad.com/1473784692-i-became-a-flashing-genius-at-the-magic-academy",
                        "https://www.wattpad.com/1473784823-i-became-a-flashing-genius-at-the-magic-academy",
                        "https://www.wattpad.com/1473784951-i-became-a-flashing-genius-at-the-magic-academy",
                        "https://www.wattpad.com/1473785144-i-became-a-flashing-genius-at-the-magic-academy",
                        "https://www.wattpad.com/1473785245-i-became-a-flashing-genius-at-the-magic-academy",
                        "https://www.wattpad.com/1474126585-i-became-a-flashing-genius-at-the-magic-academy",
                        "https://www.wattpad.com/1477271798-i-became-a-flashing-genius-at-the-magic-academy"
                    }
                };

                // ----

                int offset = 5;

                for (int v = 0; v < Volumes.Length; ++v) {
                    Console.WriteLine("Downloading Volume " + (v + 1 + offset));
                    string[] urls = Volumes[v];
                    for (int i = 0; i < urls.Length; ++i) {
                        await wattpad.DownloadBlog(urls[i], @"D:\Visual Novels\[Ongoing] I became a flashing genius\Raw\" + $"Volume {(v + 1 + offset)}", $"{(i + 1).ToString("D4")}.xhtml");
                        Console.WriteLine($"- Chapter {i + 1}");
                    }
                }
                Console.WriteLine("Done!");
            });

            Console.ReadLine();

            return 0;
        }
    }
}