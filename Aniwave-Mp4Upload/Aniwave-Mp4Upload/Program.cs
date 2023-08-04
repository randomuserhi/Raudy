using System.Net;
using Raudy.Net;
using System.Text;
using Microsoft.VisualBasic;

// Project > Properties > Change from Console Application to Windows Application when moving to production

namespace Source
{
    internal class Program
    {
        static bool running = true;

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

            Task execution = Task.Run(async void () =>
            {
                const int tickRate = 1000 / 20;

                while (running)
                {
                    foreach (IPEndPoint ep in server.connections)
                    {
                        Message<string> heartBeat = Net.NewMessage<string>("HeartBeat");
                        heartBeat.status = Status.SUCCESS;
                        heartBeat.result = "";
                        await server.SendTo(ep, Net.SerializeMessage(heartBeat));
                    }

                    Thread.Sleep(tickRate);
                }
            });
            execution.Wait();

            server.Dispose();*/


            Aniwave source = new Aniwave();

            Task.Run(async void () => {
                Aniwave.Query? query = await source.Search("oshi no ko");
                Console.WriteLine(query?.results[0].link);

                Aniwave.AnimeInfo info = new Aniwave.AnimeInfo();
                info.link = query?.results[0].link!;
                Aniwave.Anime? anime = await source.GetFullAnimeDetails(info);

                Console.WriteLine(info.thumbnail);

                Aniwave.EpisodeList? episodes = await source.GetEpisodes(anime.Value, Aniwave.Category.Sub);

                if (episodes != null)
                {
                    Aniwave.EpisodeList list = episodes.Value;
                    foreach (Aniwave.Episode ep in list.episodes)
                    {
                        Console.WriteLine($"{ep.id}: {ep.epNum} - {ep.enTitle}: {ep.category}");
                    }

                    Aniwave.SourceList? sourceList = await source.GetSources(list.episodes[0]);

                    if (sourceList != null)
                    {
                        Aniwave.SourceList slist = sourceList.Value;

                        foreach (Aniwave.Source src in slist.sources)
                        {
                            Console.WriteLine($"{src.name}: {src.id}");
                        }

                        Aniwave.VideoEmbed? embed = await source.GetEmbed(slist.sources[0]);
                        Console.WriteLine(embed?.url);
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
            Console.WriteLine($"Connected: {endPoint}");
        }

        static void OnReceive(IPEndPoint endPoint, int received, byte[] buffer)
        {
            try
            {
                string msg = Encoding.UTF8.GetString(buffer, 0, received);
                string type = Net.MessageType(msg);
                switch (type)
                {
                    case "HeartBeat":
                        Console.WriteLine($"Heartbeat received");
                        break;
                    default:
                        Console.WriteLine($"Received unknown message type: {type}");
                        break;
                }
            }
            catch(Exception ex) 
            {
                Console.WriteLine(ex);
            }
        }

        static void OnDisconnect(IPEndPoint endPoint)
        {
            Console.WriteLine($"Disconnected: {endPoint}");
        }
    }
}