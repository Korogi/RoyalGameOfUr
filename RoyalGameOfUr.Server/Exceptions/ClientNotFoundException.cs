using System;
using System.Collections.Generic;
using System.Text;

namespace RoyalGameOfUr.Server.Exceptions
{
    class ClientNotFoundException : Exception
    {
        public ClientNotFoundException(string message) : base(message)
        {

        }
    }
}
