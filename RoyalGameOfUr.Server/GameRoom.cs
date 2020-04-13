using System;
using System.Collections.Generic;
using System.Text;

namespace RoyalGameOfUr.Server
{
    public class GameRoom : Server
    {
        public Game Game { get; private set; }
        public int Id;

        public GameRoom(int maxPlayers, int port, int id) : base(maxPlayers, port)
        {
            Id = id;
        }
    }
}
