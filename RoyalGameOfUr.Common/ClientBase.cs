using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Linq;

namespace RoyalGameOfUr.Common
{
    public abstract class ClientBase
    {
        public string Username { get; set; }

        //public override bool Equals(object obj) => obj is ClientBase client && Username == client.Username;

        //public override int GetHashCode() => Username.GetHashCode();

        public static int dataBufferSize = 4096;
        public readonly int Id;
        public TcpClient Socket { get; set; }

        public NetworkStream Stream { get; set; }
        public byte[] ReceiveBuffer { get; set; }
        public PacketBuffer ReceivedPacketBuffer { get; set; }

        private Action<object>? _handlePacketHook { get; set; }

        public ClientBase(int id, Action<object>? handlePacketHook = null)
            => (Id, ReceivedPacketBuffer, _handlePacketHook) = (id, new PacketBuffer(), handlePacketHook);

        public void Connect(TcpClient socket)
        {
            Socket = socket;
            socket.ReceiveBufferSize = dataBufferSize;
            socket.SendBufferSize = dataBufferSize;

            Stream = socket.GetStream();

            ReceiveBuffer = new byte[dataBufferSize];

            Stream.BeginRead(ReceiveBuffer, 0, dataBufferSize, ReceiveCallback, null);
        }

        public void ReceiveCallback(IAsyncResult result)
        {
            try
            {
                int byteLength = Stream.EndRead(result);
                if (byteLength <= 0)
                {
                    Disconnect();
                    return;
                }

                byte[] data = new byte[byteLength];
                Array.Copy(ReceiveBuffer, data, byteLength);

                HandleReceivedData(data);
                Stream.BeginRead(ReceiveBuffer, 0, dataBufferSize, ReceiveCallback, null);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error receiving data with client id {Id}: {ex}");
                Disconnect();
            }
        }

        public void SendData(object data)
        {
            try
            {
                byte[] byteData = PacketHandler.CreateByteArrayWithPrefixLengthAndData(data);
                Stream.BeginWrite(byteData, 0, byteData.Length, SendCallback, null);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected Error while trying to send data (client id{Id}): {ex}");
            }
        }

        public void SendCallback(IAsyncResult result)
        {
            // nothing to do here for now
            // maybe log what has been sent 
        }

        public void HandleReceivedData(byte[] data)
        {
            ReceivedPacketBuffer.WriteDataInBuffer(data);

            if (ReceivedPacketBuffer.UnreadDataInBufferLength() >= sizeof(short))
            {
                if (!ReceivedPacketBuffer.IsPacketSet())
                {
                    ReceivedPacketBuffer.SetNewPacketBuffer();
                }

                ReceivedPacketBuffer.WriteAllAvailableDataInPacketBuffer();

                if (ReceivedPacketBuffer.IsCurrentPacketComplete())
                {
                    var packet = PacketHandler.Deserialize(ReceivedPacketBuffer.CurrentPacket);
                    HandlePacket(packet);
                    _handlePacketHook?.Invoke(packet);

                    ReceivedPacketBuffer.ResetBuffer();
                }
            }
            else
            {
                ReceivedPacketBuffer.WriteAllAvailableDataInPacketBuffer();
            }
        }

        public abstract void Disconnect();
        public abstract void HandlePacket(object packet);
    }
}
