using System;
using System.Collections.Generic;
using System.Text;

namespace RoyalGameOfUr.Common.Packets
{
    [Serializable]
    public class TestPacket
    {

        public int SomeID;
        public string someUsername;
        public List<int> information;

        public TestPacket(int id, string name, List<int> info)
            => (SomeID, someUsername, information) = (id, name, info);

        public override string ToString()
        {
            return $"TestPacket: id: {SomeID}, name: {someUsername}, info: {string.Join(", ", information.ToArray())}";
        }
    }
}
