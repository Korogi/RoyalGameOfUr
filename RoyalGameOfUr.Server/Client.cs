using RoyalGameOfUr.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using RoyalGameOfUr.Common.Packets;
using System.Linq;
using RoyalGameOfUr.Common.Exceptions;

namespace RoyalGameOfUr.Server
{
    public class Client : ClientBase
    {
        public Client(int id, Action<object> handlePacketHook = null) : base(id, handlePacketHook)
        {
        }

        public override void HandlePacket(object packet)
        {

        }

        public override void Disconnect()
        {
            Console.WriteLine($"Client with ID {Id} disconnects.");
            Stream.Close();
            Socket.Close();
            Stream = null;
            ReceiveBuffer = null;
            ReceivedPacketBuffer = new PacketBuffer();
            Socket = null;
        }
    }
}
