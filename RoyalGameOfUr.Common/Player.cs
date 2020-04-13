using System;
using System.Collections.Generic;
using System.Text;

namespace RoyalGameOfUr.Common
{
    public class Player
    {
        public ClientBase Client;
        public int Score;
        public PlayerType Type; 

        public Player(ClientBase client) {
            Client = client;
        }
    }
}
