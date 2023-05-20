using System.Collections.Concurrent;
using System.Net.Sockets;
using System.Net;

namespace Raudy.Net
{
    public class TCPServer
    {
        public delegate void ReceiveDelegate(IPEndPoint endPoint, int received, byte[] buffer);
        public delegate void DisconnectDelegate(IPEndPoint endPoint);
        public delegate void AcceptDelegate(IPEndPoint endPoint);
        private class Connection
        {
            private TCPServer server;
            private Socket? socket;
            private byte[] buffer;
            private IPEndPoint endPoint;

            // Handle current recieve task
            private Task? task;
            private CancellationTokenSource cancellationToken = new CancellationTokenSource();

            public Connection(TCPServer server, IPEndPoint endPoint, Socket socket, int bufferSize)
            {
                this.server = server;
                this.endPoint = endPoint;

                buffer = new byte[bufferSize];
                this.socket = socket;

                task = Task.Factory.StartNew(ReceiveLoop, cancellationToken.Token);
            }

            private async Task ReceiveLoop()
            {
                while (!cancellationToken.IsCancellationRequested)
                {
                    if (socket == null) throw new NullReferenceException("socket was null.");

                    try
                    {
                        int received = await socket.ReceiveAsync(buffer, SocketFlags.None);
                        server.onReceive?.Invoke(endPoint, received, buffer);
                    }
                    catch (ObjectDisposedException)
                    {
                        //socket was closed during ReceiveAsync...
                    }
                }
            }

            public async Task Send(byte[] buffer)
            {
                if (socket == null) throw new NullReferenceException("socket was null.");

                try
                {
                    await socket.SendAsync(buffer, SocketFlags.None);
                }
                catch (SocketException) // TODO(randomuserhi): Check if this is the right socket exception to test for
                {
                    Dispose();
                }
            }

            public void Disconnect()
            {
                Dispose();
            }

            public void Dispose()
            {
                if (socket == null) return;

                socket.Dispose();
                if (task != null)
                {
                    cancellationToken.Cancel();
                    task.Wait();

                    cancellationToken = new CancellationTokenSource();
                    task = null;
                }

                server.onDisconnect?.Invoke(endPoint);
                server.connections.Remove(endPoint, out _);
            }
        }

        private Socket? socket;

        private ConcurrentDictionary<IPEndPoint, Connection> connections = new ConcurrentDictionary<IPEndPoint, Connection>();

        // Handle current socket task (Accept loop / Connect loop)
        private Task? task;
        private CancellationTokenSource cancellationToken = new CancellationTokenSource();

        private int bufferSize = 1024;

        public AcceptDelegate? onAccept;
        public DisconnectDelegate? onDisconnect;
        public ReceiveDelegate? onReceive;

        public TCPServer(int bufferSize)
        {
            this.bufferSize = bufferSize;
        }

        public async Task SendTo(IPEndPoint remoteEndPoint, byte[] buffer)
        {
            await connections[remoteEndPoint].Send(buffer);
        }

        public void Disconnect(IPEndPoint remoteEndPoint)
        {
            connections[remoteEndPoint].Disconnect();
        }

        public IPEndPoint LocalEndPoint { 
            get
            {
                if (socket == null) throw new NullReferenceException("socket was null.");
                IPEndPoint? ep = socket.LocalEndPoint as IPEndPoint;
                if (ep == null) throw new NullReferenceException("local endpoint was null.");

                return ep;
            }
        }

        public IPEndPoint RemoteEndPoint
        {
            get
            {
                if (socket == null) throw new NullReferenceException("socket was null.");
                IPEndPoint? ep = socket.RemoteEndPoint as IPEndPoint;
                if (ep == null) throw new NullReferenceException("remote endpoint was null.");

                return ep;
            }
        }

        public void Open()
        {
            if (socket != null) Dispose();
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.ReuseAddress, true);
        }

        public void Dispose()
        {
            if (socket == null) return;

            socket.Dispose();
            if (task != null)
            {
                cancellationToken.Cancel();
                task.Wait();

                cancellationToken = new CancellationTokenSource();
                task = null;
            }
            socket = null;

            foreach (Connection conn in connections.Values)
                conn.Dispose();
            connections.Clear();
        }

        public void Bind(IPEndPoint endPoint)
        {
            if (socket == null) throw new NullReferenceException("socket was null.");
            if (task != null) throw new Exception("Dispose of socket first.");

            socket.Bind(endPoint);
            socket.Listen();

            task = Task.Factory.StartNew(AcceptLoop, cancellationToken.Token);
        }

        private async Task AcceptLoop()
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                if (socket == null) throw new NullReferenceException("socket was null.");

                try
                {
                    Socket connection = await socket.AcceptAsync();
                    IPEndPoint? ep = connection.LocalEndPoint as IPEndPoint;
                    if (ep != null)
                    {
                        // NOTE(randomuserhi): on update, keep the old socket and dispose of this socket
                        connections.AddOrUpdate(ep, new Connection(this, ep, connection, bufferSize), (key, old) => { connection.Dispose(); return old; });
                        onAccept?.Invoke(ep);
                    }
                    else connection.Dispose();
                }
                catch (ObjectDisposedException)
                {
                    //socket was closed during AcceptAsync...
                }
            }
        }
    }
}
