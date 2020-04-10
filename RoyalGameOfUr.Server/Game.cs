using RoyalGameOfUr.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace RoyalGameOfUr.Server
{
    public class Game
    {
        public Client BlackPlayer { get; set; }
        public Client WhitePlayer { get; set; }
        public ClientContainer Subscribers { get; private set; }
        private bool IsFinished { get; set; }
        public Client CurrentPlayer { get; set; }
        public Board Board { get; private set; }

        public Game(Client blackPlayer, Client whitePlayer)
        {
            this.BlackPlayer = blackPlayer;
            this.WhitePlayer = whitePlayer;

            this.Subscribers = new ClientContainer();

            this.Subscribers.AddClient(blackPlayer);
            this.Subscribers.AddClient(whitePlayer);

            Board = new Board();
        }

        public void AddSpectator(Client client)
        {
            this.Subscribers.AddClient(client);
        }

        public void DeleteSpectatorById(int id)
        {
            this.Subscribers.DeleteClientById(id);
        }

        public void Run()
        {
            // new GameHandler(this);
        }
    }
}
