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

            Task.Run(async void () => {
                _9anime.VideoEmbed? resp = await _9anime.GetEmbed("HT6WCcIh");
                if (resp is _9anime.VideoEmbed embed)
                {
                    if (embed.skip_data is Dictionary<string, int[]> skip_data)
                    {
                        Console.WriteLine(embed.url);
                        foreach (string key in skip_data.Keys)
                        {
                            Console.WriteLine($"{key}: {skip_data[key][0]}");
                        }
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