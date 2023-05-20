using System.Net;
using System.Net.Sockets;
using Raudy.Net;

// Project > Properties > Change from Console Application to Windows Application when moving to production

namespace Source
{
    internal class Program
    {
        static bool connected = false;

        static int Main(string[] args)
        {
            if (args.Length < 2)
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
            }

            // Attempt connecting to server
            TCPClient client = new TCPClient(1024);
            client.onReceive += OnReceive;
            client.onConnect += OnConnect;
            client.onDisconnect += OnDisconnect;

            client.Open();
            Task connectTask = Task.Run(async () => {
                try
                {
                    await client.Connect(new IPEndPoint(address, port));
                }
                catch (SocketException ex)
                {
                    Console.WriteLine($"Failed to connect: {ex.SocketErrorCode} ({ex.ErrorCode})");
                }
            });

            if (!connectTask.Wait(5000))
            {
                Console.WriteLine("Connection to server timed out.");
                return 1;
            }

            // Running logic
            // TODO(randomuserhi) => Add tick rate and stuff

            while (connected)
            {
                // Send heartbeat message
                //Task.Run(client.Send());
            }

            return 0;
        }

        static void OnConnect(IPEndPoint endPoint)
        {
            connected = true;
        }

        static void OnReceive(IPEndPoint endPoint, int received, byte[] buffer)
        {

        }

        static void OnDisconnect(IPEndPoint endPoint)
        {
            connected = false;
        }
    }
}