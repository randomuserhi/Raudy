// Project > Properties > Change from Console Application to Windows Application when moving to production

namespace Source {
    internal class Program {
        static int Main(string[] args) {
            Task.Run(async void () => {
                Aniwave aniwave = new Aniwave();

                await aniwave.Test();

                Console.WriteLine("Done!");
            });

            Console.ReadLine();

            return 0;
        }
    }
}