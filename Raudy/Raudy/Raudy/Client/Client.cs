using System;
using System.Net;
using System.Net.Sockets;

namespace Raudy.Net
{
    public class TCPClient
    {
        public delegate void ReceiveDelegate(IPEndPoint endPoint, int received, byte[] buffer);
        public delegate void ConnectDelegate(IPEndPoint endPoint);
        public delegate void DisconnectDelegate(IPEndPoint endPoint);

        private Socket? socket;
        private byte[] buffer;

        public ReceiveDelegate? onReceive;
        public ConnectDelegate? onConnect;
        public DisconnectDelegate? onDisconnect;

        // Handle current recieve task
        private Task? task;
        private CancellationTokenSource cancellationToken = new CancellationTokenSource();

        public TCPClient(int bufferSize)
        {
            buffer = new byte[bufferSize];
        }

        public IPEndPoint LocalEndPoint
        {
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

        public async Task Connect(IPEndPoint endPoint)
        {
            if (socket == null) throw new NullReferenceException("socket was null.");
            if (task != null) throw new Exception("Dispose of socket first.");

            await socket.ConnectAsync(endPoint);
            onConnect?.Invoke(endPoint);

            task = Task.Factory.StartNew(ReceiveLoop, cancellationToken.Token);
        }

        private async Task ReceiveLoop()
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                if (socket == null) throw new NullReferenceException("socket was null.");

                IPEndPoint? ep = socket.LocalEndPoint as IPEndPoint;
                if (ep == null)
                {
                    Dispose();
                    return;
                }

                try
                {
                    int received = await socket.ReceiveAsync(buffer, SocketFlags.None);
                    onReceive?.Invoke(ep, received, buffer);
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
            if (socket == null) throw new NullReferenceException("socket was null.");

            Dispose();
        }

        public void Dispose()
        {
            if (socket == null) return;

            IPEndPoint? ep = socket.RemoteEndPoint as IPEndPoint;

            socket.Dispose();
            if (task != null)
            {
                cancellationToken.Cancel();
                task.Wait();

                cancellationToken = new CancellationTokenSource();
                task = null;
            }
            socket = null;

            if (ep != null) onDisconnect?.Invoke(ep);
        }
    }
}
