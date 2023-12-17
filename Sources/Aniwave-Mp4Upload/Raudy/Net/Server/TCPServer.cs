using System.Collections.Concurrent;
using System.Net.Sockets;
using System.Net;
using System.Threading;

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
            private NetworkStream? stream;
            private byte[] recvBuffer;
            private byte[] sendBuffer;
            private IPEndPoint endPoint;
            //private SemaphoreSlim semaphore = new SemaphoreSlim(1, 1);

            // Handle current recieve task
            private Task? task;
            private CancellationTokenSource cancellationToken = new CancellationTokenSource();

            public Connection(TCPServer server, IPEndPoint endPoint, Socket socket, int bufferSize)
            {
                this.server = server;
                this.endPoint = endPoint;

                recvBuffer = new byte[bufferSize];
                sendBuffer = new byte[bufferSize];
                this.socket = socket;

                stream = new NetworkStream(socket);

                task = Task.Factory.StartNew(ReceiveLoop, cancellationToken.Token);
            }

            private async Task ReceiveLoop()
            {
                const int headerSize = sizeof(int);

                while (!cancellationToken.IsCancellationRequested)
                {
                    if (socket == null) throw new NullReferenceException("socket was null.");
                    if (stream == null) throw new NullReferenceException("stream was null.");

                    try
                    {
                        if (recvBuffer.Length < headerSize) recvBuffer = new byte[headerSize];

                        int read = 0;
                        while (read < headerSize)
                        {
                            int received = await stream.ReadAsync(recvBuffer, read, headerSize);
                            if (received == 0) throw new InvalidDataException("unexpected end-of-stream");
                            read += received;
                        }

                        if (BitConverter.IsLittleEndian) Array.Reverse(recvBuffer, 0, sizeof(uint));
                        int msgSize = BitConverter.ToInt32(recvBuffer, 0);
                        if (recvBuffer.Length < msgSize) recvBuffer = new byte[msgSize];

                        read = 0;
                        while (read < msgSize)
                        {
                            int received = await stream.ReadAsync(recvBuffer, read, msgSize);
                            if (received == 0) throw new InvalidDataException("unexpected end-of-stream");
                            read += received;
                        }

                        server.onReceive?.Invoke(endPoint, msgSize, recvBuffer);
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
                    if (buffer.Length > int.MaxValue) throw new Exception("size of individual message is too large.");

                    byte[] msgSize = BitConverter.GetBytes(buffer.Length);
                    if (BitConverter.IsLittleEndian) Array.Reverse(msgSize);

                    if (sendBuffer.Length < buffer.Length + msgSize.Length)
                    {
                        sendBuffer = new byte[buffer.Length + msgSize.Length];
                    }

                    Array.Copy(msgSize, 0, sendBuffer, 0, msgSize.Length);
                    Array.Copy(buffer, 0, sendBuffer, msgSize.Length, buffer.Length);

                    await socket.SendAsync(sendBuffer, SocketFlags.None);
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
                if (socket != null)
                {
                    socket.Dispose();

                    server.onDisconnect?.Invoke(endPoint);
                    server._connections.Remove(endPoint, out _);
                }

                if (task != null)
                {
                    cancellationToken.Cancel();

                    cancellationToken = new CancellationTokenSource();
                    task.Dispose();
                    task = null;
                }

                if (stream != null)
                {
                    stream.Dispose();
                    stream = null;
                }
            }
        }

        private Socket? socket;

        private ConcurrentDictionary<IPEndPoint, Connection> _connections = new ConcurrentDictionary<IPEndPoint, Connection>();
        public ICollection<IPEndPoint> connections
        {
            get { return _connections.Keys; }
        }

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
            await _connections[remoteEndPoint].Send(buffer);
        }

        public void Disconnect(IPEndPoint remoteEndPoint)
        {
            _connections[remoteEndPoint].Disconnect();
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

            foreach (Connection conn in _connections.Values)
                conn.Dispose();
            _connections.Clear();
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
                    IPEndPoint? ep = connection.RemoteEndPoint as IPEndPoint;
                    if (ep != null)
                    {
                        // NOTE(randomuserhi): on update, keep the old socket and dispose of this socket
                        _connections.AddOrUpdate(ep, new Connection(this, ep, connection, bufferSize), (key, old) => { connection.Dispose(); return old; });
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
