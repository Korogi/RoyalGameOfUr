using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using RoyalGameOfUr.Common;
using RoyalGameOfUr.Common.Packets;



namespace RoyalGameOfUr.Client
{
    class GameClient : ClientBase
    {
        //public static int dataBufferSize = 4096;
        //public string ServerIp = "127.0.0.1";
        //public int ServerPort = 13000;

        //public int localId;
        //public TcpClient socket;
        //public NetworkStream stream;
        //public byte[] receiveBuffer;
        //private PacketBuffer receivedPacketBuffer;

        //public GameClient()
        //    => receivedPacketBuffer = new PacketBuffer();

        //public void ConnectToServer()
        //{
        //    socket = new TcpClient
        //    {
        //        ReceiveBufferSize = dataBufferSize,
        //        SendBufferSize = dataBufferSize,
        //    };

        //    receiveBuffer = new byte[dataBufferSize];
        //    socket.BeginConnect(ServerIp, ServerPort, ConnectCallback, socket);
        //}

        //private void ConnectCallback(IAsyncResult result)
        //{
        //    socket.EndConnect(result);
        //    if (!socket.Connected) return;

        //    stream = socket.GetStream();
        //    stream.BeginRead(receiveBuffer, 0, dataBufferSize, ReceiveCallback, null);
        //}

        //private void ReceiveCallback(IAsyncResult result)
        //{
        //    try
        //    {
        //        int byteLength = stream.EndRead(result);
        //        if (byteLength <= 0)
        //        {
        //            // TODO: disconncet
        //            return;
        //        }

        //        byte[] data = new byte[byteLength];
        //        Array.Copy(receiveBuffer, data, byteLength);

        //        HandleReceivedData(data);
        //        stream.BeginRead(receiveBuffer, 0, dataBufferSize, ReceiveCallback, null);
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"Error receiving data: {ex}");
        //        // TODO: disconnect 
        //    }
        //}

        //public void SendData(object data)
        //{
        //    try
        //    {
        //        byte[] byteData = PacketHandler.CreateByteArrayWithPrefixLengthAndData(data);
        //        stream.BeginWrite(byteData, 0, byteData.Length, SendCallback, null);
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"Unexpected Error while trying to send data to server: {ex}");
        //    }
        //}

        //private void SendCallback(IAsyncResult result)
        //{
        //    // nothing to do here for now
        //}

        //private void HandleReceivedData(byte[] data)
        //{
        //    receivedPacketBuffer.WriteDataInBuffer(data);

        //    if (receivedPacketBuffer.UnreadDataInBufferLength() >= sizeof(short))
        //    {
        //        if (!receivedPacketBuffer.IsPacketSet())
        //        {
        //            receivedPacketBuffer.SetNewPacketBuffer();
        //        }

        //        receivedPacketBuffer.WriteAllAvailableDataInPacketBuffer();

        //        if (receivedPacketBuffer.IsCurrentPacketComplete())
        //        {
        //            HandlePacket(PacketHandler.Deserialize(receivedPacketBuffer.CurrentPacket));
        //            receivedPacketBuffer.ResetBuffer();
        //        }
        //    }
        //    else
        //    {
        //        receivedPacketBuffer.WriteAllAvailableDataInPacketBuffer();
        //    }

        //}
        public string ServerIp = "127.0.0.1";
        public int ServerPort = 13000;

        public GameClient(int id) : base(id) { }

        public void ConnectToServer()
        {
            Socket = new TcpClient
            {
                ReceiveBufferSize = dataBufferSize,
                SendBufferSize = dataBufferSize,
            };

            ReceiveBuffer = new byte[dataBufferSize];
            Socket.BeginConnect(ServerIp, ServerPort, ConnectCallback, Socket);
        }

        private void ConnectCallback(IAsyncResult result)
        {
            Socket.EndConnect(result);
            if (!Socket.Connected) return;

            Stream = Socket.GetStream();
            Stream.BeginRead(ReceiveBuffer, 0, dataBufferSize, ReceiveCallback, null);
        }

        public override void HandlePacket(object packet)
        {
            if (packet is TestPacket)
                Console.WriteLine(packet.ToString());
            else
                Console.WriteLine("Couldn't recognize packet");
        }
    }
}
