using System;
using System.Collections.Generic;
using System.Text;

namespace RoyalGameOfUr.Server.Exceptions
{
    class ClientAlreadyExistsException : Exception
    {
        public ClientAlreadyExistsException(string message) : base(message)
        {

        }
    }
}
