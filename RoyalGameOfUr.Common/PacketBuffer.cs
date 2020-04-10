using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using RoyalGameOfUr.Common.Exceptions;

namespace RoyalGameOfUr.Common
{
    public class PacketBuffer
    { 
        private List<byte> buffer;
        public int CurrentPositionRead { get; set; }

        public byte[] CurrentPacket { get; private set; }
        public int CurrentPacketLength { get; private set; }
        public int CurrentPacketPosition { get; set; }

        //public PacketBuffer(int length)
        //    => (PacketLength, buffer) = (length, new List<byte>);

        //public PacketBuffer(int length, byte[] data)
        //{
        //    if (length > data.Length)
        //        throw new PacketBufferException($"PacketBuffer overflow: packet length is {length} but data length is {data.Length}");
           
            
        //}

        public PacketBuffer()
        {
            buffer = new List<byte>();

        }

        public bool IsCurrentPacketComplete()
            => CurrentPacketPosition == CurrentPacketLength;


        public int UnreadDataInBufferLength()
            => buffer.Count - CurrentPositionRead;

        public int MissingDataFromPacketLength()
            => CurrentPacketLength - CurrentPacketPosition;

        public void WriteDataInBuffer(byte[] data)
            => buffer.AddRange(data);

        public bool IsPacketSet()
            => !(CurrentPacket is null);

        public void SetNewPacketBuffer()
        {
            CurrentPacketLength = PacketHandler.ReadPrefixLength(buffer.ToArray());
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
                
                Array.Copy(buffer.ToArray(), CurrentPositionRead, CurrentPacket, CurrentPacketPosition, UnreadDataInBufferLength()); // need to adjust length 
                CurrentPacketPosition += UnreadDataInBufferLength(); 
                CurrentPositionRead += UnreadDataInBufferLength();
                
            } else
            {
                Array.Copy(buffer.ToArray(), CurrentPositionRead, CurrentPacket, CurrentPacketPosition, MissingDataFromPacketLength());
                CurrentPositionRead += CurrentPacketLength;
                CurrentPacketPosition = CurrentPacketLength;
            }
        }

        public void ResetBuffer()
        {
            buffer.RemoveRange(0, CurrentPacketLength);
            CurrentPacket = null;
            CurrentPositionRead = 0;
            CurrentPacketPosition = 0;
        }
    }
}
