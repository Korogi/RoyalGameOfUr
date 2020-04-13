using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace RoyalGameOfUr.Server
{
    public class MasterServer : Server
    {
        public readonly int MaxGames;
        public GameRoom[] Rooms; 
        public MasterServer(int maxPlayers, int maxGames, int port) : base(maxPlayers, port) 
        {
            MaxGames = maxGames;
            Rooms = new GameRoom[MaxGames];
            Console.Title = "Server";
        }

        private void InitializeAllGameRooms(int firstPort)
        {
             for (int i = 1; i <= MaxGames; i++)
             {
                Rooms[i] = new GameRoom(MaxPlayers, Port + i, i);
             }
        }
    }
} 
