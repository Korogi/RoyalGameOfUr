using System;
using System.Collections.Generic;
using System.Text;

namespace RoyalGameOfUr.Common.Exceptions
{
    public class UnknownPacketTypeException : Exception
    {
        public UnknownPacketTypeException(string message) : base(message)
        {

        }
    }
}
