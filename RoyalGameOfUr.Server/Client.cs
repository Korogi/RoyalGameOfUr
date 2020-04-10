﻿using RoyalGameOfUr.Common;
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
        //public static int dataBufferSize = 4096;
        //public readonly int Id;
        //public TcpClient Socket;

        //private NetworkStream stream;
        //private byte[] receiveBuffer;
        //private PacketBuffer receivedPacketBuffer;
        //public Client(int id)
        //    => (Id, receivedPacketBuffer) = (id, new PacketBuffer());

        //public void Connect(TcpClient socket)
        //{
        //    Socket = socket;
        //    socket.ReceiveBufferSize = dataBufferSize;
        //    socket.SendBufferSize = dataBufferSize;

        //    stream = socket.GetStream();

        //    receiveBuffer = new byte[dataBufferSize];

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
        //        Console.WriteLine($"Error receiving data with client id {Id}: {ex}");
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
        //        Console.WriteLine($"Unexpected Error while trying to send data to client {Id}: {ex}");
        //    }
        //}

        //private void SendCallback(IAsyncResult result)
        //{
        //    // nothing to do here for now
        //    // maybe log what has been sent 
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
        public Client(int id) : base(id) { }
        public override void HandlePacket(object packet)
        {
            if (packet is TestPacket)
                Console.WriteLine(packet.ToString());
            else
                throw new UnknownPacketTypeException($"Packet couldn't be recognized as any valid packet object.");
        }
    }
}
