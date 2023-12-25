using Raudy.Net;
using System.Net;
using System.Text;

// Project > Properties > Change from Console Application to Windows Application when moving to production

namespace Source {
    internal class Program {
        static bool running = true;

        static int Main(string[] args) {
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
            TCPServer server = new TCPServer(1024);
            server.onReceive += OnReceive;
            server.onAccept += OnAccept;
            server.onDisconnect += OnDisconnect;

            // TODO(randomuserhi): Maybe timeout if server doesn't connect and close server
            //                     Have a timeout flag => if its 0, then dont auto-close
            //                     otherwise close after timeout.

            //server.Bind(new IPEndPoint(address, port));
            IPEndPoint bind = (IPEndPoint)server.Bind(new IPEndPoint(IPAddress.Any, 56759));
            Console.WriteLine(bind.Port);

            Task execution = Task.Run(async void () => {
                const int tickRate = 1000 / 20;

                while (running) {
                    foreach (EndPoint ep in server.Connections) {
                        //Console.WriteLine($"Heartbeat sent");
                        Message<string> heartBeat = Net.NewMessage<string>("HeartBeat");
                        heartBeat.status = Status.SUCCESS;
                        heartBeat.content = "";
                        await server.SendTo(Net.SerializeMessage(heartBeat), ep);
                    }

                    Thread.Sleep(tickRate);
                }
            });
            execution.Wait();

            server.Dispose();


            /*Aniwave source = new Aniwave();

            Task.Run(async void () => {
                Aniwave.Anime[] test = await source.Search("test");
                foreach (Aniwave.Anime a in test) {
                    Console.WriteLine("------------------------------");
                    Console.WriteLine($"link: {a.link}");
                    Console.WriteLine($"thumbnail: {a.thumbnail}");
                    Console.WriteLine($"title: {a.titles[0].value}");
                    Console.WriteLine($"description: {a.description}");
                }
                Console.WriteLine("--- END ---");


                Aniwave.Query? query = await source.ShortSearch("blue lock");
                Console.WriteLine(query?.results[0].link);

                Aniwave.AnimeInfo info = query!.Value.results[0];
                Aniwave.Anime? anime = await source.GetFullAnimeDetails(info);

                Console.WriteLine($"link: {anime!.Value.link}");
                Console.WriteLine($"thumbnail: {info.thumbnail}");
                Console.WriteLine($"title: {anime!.Value.titles[0].value}");
                Console.WriteLine($"description: {anime!.Value.description}");

                Aniwave.EpisodeList? episodes = await source.GetEpisodes(anime.Value, Aniwave.Category.Dub);

                if (episodes != null) {
                    Aniwave.EpisodeList list = episodes.Value;
                    foreach (Aniwave.Episode ep in list.episodes) {
                        Console.WriteLine($"{ep.id}: {ep.epNum} - {ep.titles[0]}: {ep.category}");

                        Aniwave.SourceList? sourceList = await source.GetSources(ep);

                        if (sourceList != null) {
                            Aniwave.SourceList slist = sourceList.Value;

                            foreach (Aniwave.Source src in slist.sources) {
                                Console.WriteLine($"{src.name}: {src.id}");
                            }

                            Aniwave.VideoEmbed? embed = await source.GetEmbed(slist.sources[0]);
                            Console.WriteLine(embed?.url);
                            Console.WriteLine(embed?.video?.url);
                            await source.embedScrapers["mp4upload"].DownloadVideo(embed!.Value.video!.Value.url, $"{ep.epNum} - {ep.titles[0]}");
                        }
                    }
                }
            });*/

            Console.ReadLine();

            return 0;
        }

        // Manage connection
        static void OnAccept(EndPoint endPoint) {
            Console.WriteLine($"Connected: {endPoint}");
        }

        static void OnReceive
            (ArraySegment<byte> buffer, EndPoint endPoint) {
            try {
                string msg = Encoding.UTF8.GetString(buffer.Array!, buffer.Offset, buffer.Count);
                string type = Net.MessageType(msg);
                switch (type) {
                case "HeartBeat":
                    Console.WriteLine($"Heartbeat received");
                    break;
                default:
                    Console.WriteLine($"Received unknown message type: {type}");
                    break;
                }
            } catch (Exception ex) {
                Console.WriteLine(ex);
            }
        }

        static void OnDisconnect(EndPoint endPoint) {
            Console.WriteLine($"Disconnected: {endPoint}");
        }
    }
}