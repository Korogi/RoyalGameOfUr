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
        // public Server ConnectedServer { get; set; }
        public Client(int id) : base(id) { }
        public override void HandlePacket(object packet)
        {
            if (packet is TestPacket)
                Console.WriteLine(packet.ToString());
                
            else
                throw new UnknownPacketTypeException($"Packet couldn't be recognized as any valid packet object.");
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
