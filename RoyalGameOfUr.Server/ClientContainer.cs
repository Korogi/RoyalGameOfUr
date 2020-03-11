using RoyalGameOfUr.Server.Exceptions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RoyalGameOfUr.Server
{
    class ClientContainer : IEnumerable
    {

        private Dictionary<int, Client> _clients;

        public ClientContainer()
        {
            this._clients = new Dictionary<int, Client>();
        }

        public Client GetClientById(int ID)
        {
            if (this._clients.TryGetValue(ID, out Client client))
            {
                return client;

            }
            else
            {
                throw new ClientNotFoundException($"Client with ID {ID} that you tried to get by ID could not be found.");
            }
        }

        public void AddClient(Client client)
        {
            if (!this._clients.TryAdd(client.Id, client))
            {
                throw new ClientAlreadyExistsException($"{client.ToString()} already exists and can not be added again.");
            }
        }

        public void DeleteClientById(int id)
        {
            if (!this._clients.Remove(id))
            {
                throw new ClientNotFoundException($"Client with ID {id} could not be found thus not be deleted.");
            }
        }

        public void DeleteClient(Client client)
        {
            if (!this._clients.Remove(client.Id))
            {
                throw new ClientNotFoundException($"{client.ToString()} could not be found thus not be deleted.");
            }
        }


        public IEnumerator GetEnumerator()
        {
            return _clients.Values.ToList().GetEnumerator();
        }
    }
}
