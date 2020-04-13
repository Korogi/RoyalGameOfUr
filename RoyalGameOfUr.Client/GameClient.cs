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

        public override void Disconnect()
        {
            Stream.Close();
            Socket.Close();
            //Stream = null;
            //Socket = null;
            //ReceiveBuffer = null;
            //ReceivedPacketBuffer = new PacketBuffer();
        }
    }
}
