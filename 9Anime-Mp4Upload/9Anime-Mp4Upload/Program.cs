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

            // Boot Server
            TCPServer server = new TCPServer(1024);
            server.onReceive += OnReceive;
            server.onAccept += OnAccept;
            server.onDisconnect += OnDisconnect;

            // TODO(randomuserhi): Maybe timeout if server doesn't connect and close server
            //                     Have a timeout flag => if its 0, then dont auto-close
            //                     otherwise close after timeout.

            // Running logic


            return 0;
        }

        // Manage connection
        static void OnAccept(IPEndPoint endPoint)
        {
            
        }

        static void OnReceive(IPEndPoint endPoint, int received, byte[] buffer)
        {

        }

        static void OnDisconnect(IPEndPoint endPoint)
        {
            
        }
    }
}