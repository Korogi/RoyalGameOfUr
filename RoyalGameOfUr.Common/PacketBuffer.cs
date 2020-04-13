using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using RoyalGameOfUr.Common.Exceptions;

namespace RoyalGameOfUr.Common
{
    public class PacketBuffer
    { 
        private readonly List<byte> Buffer;
        public int CurrentPositionRead { get; set; }

        public byte[] CurrentPacket { get; private set; }
        public int CurrentPacketLength { get; private set; }
        public int CurrentPacketPosition { get; set; }

        public PacketBuffer()
        {
            Buffer = new List<byte>();

        }
        public bool IsPacketSet()
            => !(CurrentPacket is null);
        public bool IsCurrentPacketComplete()
            => CurrentPacketPosition == CurrentPacketLength;

        public int UnreadDataInBufferLength()
            => Buffer.Count - CurrentPositionRead;

        public int MissingDataFromPacketLength()
            => CurrentPacketLength - CurrentPacketPosition;

        public void WriteDataInBuffer(byte[] data)
            => Buffer.AddRange(data);

        public void SetNewPacketBuffer()
        {
            CurrentPacketLength = PacketHandler.ReadPrefixLength(Buffer.ToArray());
            CurrentPositionRead += sizeof(short);
            CurrentPacketPosition = 0;
            CurrentPacket = new byte[CurrentPacketLength];
        }

        public void WriteAllAvailableDataInPacketBuffer()
        {
            if (CurrentPacket is null) 
                throw new PacketBufferException($"PacketBuffer Null Exception: current packet length wasn't set. No new current packet was initialized");

            if (UnreadDataInBufferLength() < MissingDataFromPacketLength())
            {
                
                Array.Copy(Buffer.ToArray(), CurrentPositionRead, CurrentPacket, CurrentPacketPosition, UnreadDataInBufferLength()); 
                CurrentPacketPosition += UnreadDataInBufferLength(); 
                CurrentPositionRead += UnreadDataInBufferLength();
                
            } else
            {
                Array.Copy(Buffer.ToArray(), CurrentPositionRead, CurrentPacket, CurrentPacketPosition, MissingDataFromPacketLength());
                CurrentPositionRead += CurrentPacketLength;
                CurrentPacketPosition = CurrentPacketLength;
            }
        }

        public void ResetBuffer()
        {
            Buffer.RemoveRange(0, CurrentPacketLength + sizeof(short));
            CurrentPacket = null;
            CurrentPositionRead = 0;
            CurrentPacketPosition = 0;
        }
    }
}
