using System;
using System.Collections.Generic;
using System.Text;

namespace RoyalGameOfUr.Server
{
    class MasterServer : Server
    {

        public MasterServer(int maxPlayers, int maxGames, int port) : base(maxPlayers, maxGames, port) 
        {
            Console.Title = "Server";
        }
    }
}
