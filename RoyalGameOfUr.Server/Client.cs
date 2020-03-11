using System;
using System.Collections.Generic;
using System.Text;

namespace RoyalGameOfUr.Server
{
    class Client
    {
        private readonly int _ID;
        public int Id 
        { 
            get => _ID; 
        }
        private int _portNumber;
        public int PortNumber
        {
            get => _portNumber;
        }

        private string _IP;
        public string Ip
        {
            get => _IP;
        }

        private String _username;
        public String Username 
        { 
            get => _username; 
            set => _username = value; 
        }
    
        private ClientStatus _status;
        public ClientStatus Status
        {
            get => _status;
            set => _status = value;
        }


        public Client(int ID, String username, ClientStatus status = ClientStatus.connected)
        {
            this._ID = ID;
            this._username = username;
            this._status = status;
        }

        public override string ToString()
        {
            return $"Client[id: {_ID}, username: {_username}, status: {_status}]";
        }

        public override bool Equals(object obj)
        {
            var client = obj as Client; 
            if (client == null)
            {
                return false;
            }
            return client.Ip == _IP && client.PortNumber == _portNumber;
        }

        public override int GetHashCode()
        {
            return new { _ID, _portNumber }.GetHashCode();
        }
    }
}
