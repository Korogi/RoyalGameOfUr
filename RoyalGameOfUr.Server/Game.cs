using System;
using System.Collections.Generic;
using System.Text;

namespace RoyalGameOfUr.Server
{
    class Game
    {
        private Client _black; 
        public Client Black
        {
            get => _black;
            set => _black = value;
        }
        private Client _white; 
        public Client White
        {
            get => _white;
            set => _white = value;
        }
        private ClientContainer _subscribers;
        private bool _isFinished = false;

        public Game(Client black, Client white)
        {
            this._black = black;
            this._white = white;
            this._subscribers = new ClientContainer();
            this._subscribers.AddClient(black);
            this._subscribers.AddClient(white);
        }

        public void AddSpectator(Client client)
        {
            this._subscribers.AddClient(client);
        }

        public void DeleteSpectatorById(int id)
        {
            this._subscribers.DeleteClientById(id);
        }
           
        public void PlayGame()
        {

        }

        public void Update()
        {

        }


    }
}
