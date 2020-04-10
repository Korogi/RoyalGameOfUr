using System;
using System.Collections.Generic;
using System.Text;

namespace RoyalGameOfUr.Common.Exceptions
{
    public class InvalidMessageFormatException : Exception
    {
        public InvalidMessageFormatException(string message) : base(message)
        {

        }
    }
}
