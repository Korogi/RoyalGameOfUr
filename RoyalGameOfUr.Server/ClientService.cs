using RoyalGameOfUr.Server.Exceptions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RoyalGameOfUr.Server
{
    public class ClientService : IEnumerable
    {
        private readonly Dictionary<int, Client> _clients;

        public ClientService()
        {
            _clients = new Dictionary<int, Client>();
        }

        public Client GetClientById(int id)
            => _clients.TryGetValue(id, out Client client) 
                    ? client 
                    : throw new ClientNotFoundException($"Client with ID {id} that you tried to get by ID could not be found.");
 

        public void AddClient(Client client)
        {
            if (!_clients.TryAdd(client.Id, client))
            {
                throw new ClientAlreadyExistsException($"{client.ToString()} already exists and can not be added again.");
            }
        }

        public void DeleteClientById(int id)
        {
            if (!_clients.Remove(id))
            {
                throw new ClientNotFoundException($"Client with ID {id} could not be found thus not be deleted.");
            }
        }

        public void DeleteClient(Client client)
        {
            if (!_clients.Remove(client.Id))
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
