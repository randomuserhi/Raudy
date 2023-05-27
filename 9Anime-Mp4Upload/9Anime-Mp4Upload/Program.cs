using System.Net;
using System.Text.Json;

// Project > Properties > Change from Console Application to Windows Application when moving to production

namespace Source
{
    internal class Program
    {
        static bool connected = false;

        static int Main(string[] args)
        {
            /*if (args.Length < 2)
            {
                Console.WriteLine("No IP or Port was given.");
                return 1;
            }

            // Get ip and port from arguments
            IPAddress? address;
            if (!IPAddress.TryParse(args[0], out address)) 
            {
                Console.WriteLine($"Failed to parse IP from '{args[0]}'");
                return 1;
            }

            int port;
            if (!int.TryParse(args[1], out port))
            {
                Console.WriteLine($"Failed to parse Port from '{args[1]}'");
                return 1;
            }*/

            // Boot Server
            /*TCPServer server = new TCPServer(1024);
            server.onReceive += OnReceive;
            server.onAccept += OnAccept;
            server.onDisconnect += OnDisconnect;

            // TODO(randomuserhi): Maybe timeout if server doesn't connect and close server
            //                     Have a timeout flag => if its 0, then dont auto-close
            //                     otherwise close after timeout.

            server.Open();
            //server.Bind(new IPEndPoint(address, port));
            server.Bind(new IPEndPoint(IPAddress.Any, 65034));

            // Running logic
            Console.ReadKey();

            server.Dispose();*/

            _9anime source = new _9anime();

            Task.Run(async void () => {
                _9anime.Query? query = await source.Search("one piece");
                Console.WriteLine(query?.results[0].link);

                _9anime.AnimeInfo info = new _9anime.AnimeInfo();
                info.link = query?.results[0].link!;
                _9anime.Anime? anime = await source.GetFullAnimeDetails(info);

                _9anime.EpisodeList? episodes = await source.GetEpisodes(anime.Value, _9anime.Category.Sub);

                if (episodes != null)
                {
                    _9anime.EpisodeList list = episodes.Value;
                    foreach (_9anime.Episode ep in list.episodes)
                    {
                        Console.WriteLine($"{ep.id}: {ep.epNum} - {ep.enTitle}: {ep.category}");
                    }

                    _9anime.SourceList? sourceList = await source.GetSources(list.episodes[0]);

                    if (sourceList != null)
                    {
                        _9anime.SourceList slist = sourceList.Value;

                        foreach (_9anime.Source src in slist.sources)
                        {
                            Console.WriteLine($"{src.name}: {src.id}");
                        }

                        _9anime.VideoEmbed? embed = await source.GetEmbed(slist.sources[0]);
                        Console.WriteLine(embed?.video?.url);
                    }
                }
            });

            Console.ReadLine();

            return 0;
        }

        // Manage connection
        static void OnAccept(IPEndPoint endPoint)
        {
            Console.WriteLine("Accepted");
        }

        static void OnReceive(IPEndPoint endPoint, int received, byte[] buffer)
        {
            Console.WriteLine("Received something");
        }

        static void OnDisconnect(IPEndPoint endPoint)
        {
            
        }
    }
}