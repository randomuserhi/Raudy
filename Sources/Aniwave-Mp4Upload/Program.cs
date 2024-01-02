// Project > Properties > Change from Console Application to Windows Application when moving to production

using Raudy.Net;
using System.Net;
using System.Text;

namespace Source {
    internal class Program {
        static bool running = true;

        struct Range {
            public int start;
            public int end;

            public Range(int startEnd) {
                start = startEnd;
                end = startEnd;
            }

            public Range(int start, int end) {
                this.start = start;
                this.end = end;
            }
        }

        struct Job {
            public string link;
            public string path;
            public Range[] episodes;

            public Job(string link, string path, ArraySegment<string> ranges) {
                this.link = link;
                this.path = path;
                List<Range> eps = new List<Range>();
                foreach (string range in ranges) {
                    string[] r = range.Split("-");
                    if (r.Length == 1) {
                        int startEnd = int.Parse(r[0].Trim());
                        eps.Add(new Range(startEnd));
                    } else if (r.Length == 2) {
                        int start = int.Parse(r[0].Trim());
                        int end = int.Parse(r[1].Trim());
                        eps.Add(new Range(start, end));
                    }
                }
                episodes = eps.ToArray();
            }
        }

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

            /*
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

            server.Dispose();*/

            if (args.Length < 3) {
                Console.WriteLine("raudy <destination path: '.' for current directory> <'sub','dub'> <aniwave link> <[optional]: ranges of episodes to download, eg. '1-3,6,8-12'>");
                return 1;
            }

            Aniwave source = new Aniwave();

            Task.Run(async Task? () => {
                /*Aniwave.Anime[] test = await source.Search("test");
                foreach (Aniwave.Anime a in test) {
                    Console.WriteLine("------------------------------");
                    Console.WriteLine($"link: {a.link}");
                    Console.WriteLine($"thumbnail: {a.thumbnail}");
                    Console.WriteLine($"title: {a.titles[0].value}");
                    Console.WriteLine($"description: {a.description}");
                }
                Console.WriteLine("--- END ---");*/


                //Aniwave.Query? query = await source.ShortSearch("Kono suba");
                //Console.WriteLine(query?.results[0].link);

                //Aniwave.AnimeInfo info = query!.Value.results[0];
                //Aniwave.Anime? anime = await source.GetFullAnimeDetails(info);

                Job[] jobs = new Job[1];
                try {
                    jobs[0] = new Job(args[2], args[0], args.Length > 3 ? args[3].Split(",") : new string[0]);
                } catch (Exception) {
                    Console.WriteLine("Failed to pass job.");
                    return;
                }

                Aniwave.Category category = Aniwave.Category.None;
                if (args[1].ToLower().Trim() == "sub") {
                    category |= Aniwave.Category.Sub;
                } else if (args[1].ToLower().Trim() == "dub") {
                    category |= Aniwave.Category.Dub;
                } else {
                    Console.WriteLine("Please choose 'sub' or 'dub'.");
                }

                foreach (Job job in jobs) {
                    string link = job.link;
                    string path = job.path;
                    Aniwave.Anime? anime = await source.GetFullAnimeDetails(link);

                    Aniwave.EpisodeList? episodes = await source.GetEpisodes(anime.Value, category);

                    if (episodes != null) {
                        Aniwave.EpisodeList list = episodes.Value;
                        foreach (Aniwave.Episode ep in list.episodes) {
                            if (job.episodes.Length != 0 && !job.episodes.Any(range => range.start <= ep.epNum && range.end >= ep.epNum)) {
                                continue;
                            }

                            Console.WriteLine($"{ep.id}: {ep.epNum} - {ep.titles[0]}: {ep.category}");

                            Aniwave.SourceList? sourceList = await source.GetSources(ep);

                            if (sourceList != null) {
                                Aniwave.SourceList slist = sourceList.Value;

                                foreach (Aniwave.Source src in slist.sources) {
                                    Console.WriteLine($"{src.name}: {src.id}");
                                }

                                Aniwave.VideoEmbed? embed = await source.GetEmbed(slist.sources[0]);
                                string filename = $"{ep.epNum} - {ep.titles[0]}.mp4";
                                await source.embedScrapers["mp4upload"].DownloadVideo(embed!.Value.video!.Value.url, Path.Join(path, filename));
                                Console.WriteLine("");
                            }
                        }
                    } else {
                        Console.WriteLine("No episodes found.");
                    }
                }
            }).Wait();

            return 0;
        }

        // Manage connection
        static void OnAccept(EndPoint endPoint) {
            Console.WriteLine($"Connected: {endPoint}");
        }

        static void OnReceive(ArraySegment<byte> buffer, EndPoint endPoint) {
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