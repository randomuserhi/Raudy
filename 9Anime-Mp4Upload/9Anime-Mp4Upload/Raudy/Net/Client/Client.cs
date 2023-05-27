using CefSharp.DevTools.IO;
using System;
using System.IO;
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
        private NetworkStream? stream;
        private byte[] recvBuffer;
        private byte[] sendBuffer;

        public ReceiveDelegate? onReceive;
        public ConnectDelegate? onConnect;
        public DisconnectDelegate? onDisconnect;

        // Handle current recieve task
        private Task? task;
        private CancellationTokenSource cancellationToken = new CancellationTokenSource();

        public TCPClient(int bufferSize)
        {
            recvBuffer = new byte[bufferSize];
            sendBuffer = new byte[bufferSize];
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

            stream = new NetworkStream(socket);
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
            const int headerSize = sizeof(int);

            while (!cancellationToken.IsCancellationRequested)
            {
                if (socket == null) throw new NullReferenceException("socket was null.");
                if (stream == null) throw new NullReferenceException("network stream was null.");

                IPEndPoint? ep = socket.LocalEndPoint as IPEndPoint;
                if (ep == null)
                {
                    Dispose();
                    return;
                }

                try
                {
                    if (recvBuffer.Length < headerSize) recvBuffer = new byte[headerSize];

                    int read = 0;
                    while (read < headerSize)
                    {
                        int received = await stream.ReadAsync(recvBuffer, 0, headerSize);
                        if (received == 0) throw new InvalidDataException("unexpected end-of-stream");
                        read += received;
                    }

                    if (BitConverter.IsLittleEndian) Array.Reverse(recvBuffer, 0, sizeof(int));
                    int msgSize = BitConverter.ToInt32(recvBuffer, 0);
                    if (recvBuffer.Length < msgSize) recvBuffer = new byte[msgSize];

                    read = 0;
                    while (read < msgSize)
                    {
                        int received = await stream.ReadAsync(recvBuffer, 0, headerSize);
                        if (received == 0) throw new InvalidDataException("unexpected end-of-stream");
                        read += received;
                    }

                    onReceive?.Invoke(ep, msgSize, recvBuffer);
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
            if (socket == null) throw new NullReferenceException("socket was null.");

            Dispose();
        }

        public void Dispose()
        {
            if (socket != null)
            {
                IPEndPoint? ep = socket.RemoteEndPoint as IPEndPoint;

                socket.Dispose();
                socket = null;

                if (ep != null) onDisconnect?.Invoke(ep);
            }

            if (task != null)
            {
                cancellationToken.Cancel();
                task.Wait();

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
}
