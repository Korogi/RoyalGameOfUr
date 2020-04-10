using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using RoyalGameOfUr.Common.Exceptions;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace RoyalGameOfUr.Common
{
    public class PacketHandler
    {
        public static short MAX_MESSAGE_LENGTH = 32767;

        public static byte[] CreateByteArrayWithPrefixLengthAndData(object data)
            => WrapMessageWithPrefixLength(Serialize(data));

        public static byte[] WrapMessageWithPrefixLength(byte[] message)
        {
            if (message.Length > MAX_MESSAGE_LENGTH) 
                throw new InvalidMessageFormatException($"Message with length {message.Length} is too long to be wrapped. Max length: {MAX_MESSAGE_LENGTH}");
            
            return BitConverter.GetBytes((short)message.Length).Concat(message).ToArray();
        }

        public static short ReadPrefixLength(byte[] message)
        {
            if (message.Length < sizeof(short))
                throw new InvalidMessageFormatException($"Cannot read prefix length since message is too small: message length {message.Length} but need at least {sizeof(short)}");
            
            return BitConverter.ToInt16(message.Take(sizeof(short)).ToArray(), 0);
        }
        public static byte[] Serialize(object serializableObject)
        {
            using (var memoryStream = new MemoryStream())
            {
                (new BinaryFormatter()).Serialize(memoryStream, serializableObject);
                return memoryStream.ToArray();
            }
        }

        public static object Deserialize(byte[] message)
        {
            using (var memoryStream = new MemoryStream(message))
                return (new BinaryFormatter()).Deserialize(memoryStream);
        }
    }
}
