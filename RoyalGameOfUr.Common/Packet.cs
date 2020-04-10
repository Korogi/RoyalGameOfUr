using System;
using System.Collections.Generic;
using System.Text;

namespace RoyalGameOfUr.Common
{
    public class Packet
    {
        public readonly int PacketLength;
        public readonly byte[] Data;

        public Packet(int packetLength, byte[] data)
            => (PacketLength, Data) = (packetLength, data);
    }
}
