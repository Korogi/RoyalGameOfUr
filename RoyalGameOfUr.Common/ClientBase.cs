using System;
using System.Collections.Generic;
using System.Text;

namespace RoyalGameOfUr.Common
{
    public class ClientBase
    {
        public string Username { get; set; }

        //public override bool Equals(object obj) => obj is ClientBase client && Username == client.Username;

        //public override int GetHashCode() => Username.GetHashCode();
    }
}
