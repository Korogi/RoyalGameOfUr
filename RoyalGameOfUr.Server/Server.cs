using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace RoyalGameOfUr.Server
{
    public class Server
    {
        public int MaxPlayers { get; private set; }
        // public  int MaxGames { get; private set; }

        public int Port { get; private set; }

        public Dictionary<int, Client> clients = new Dictionary<int, Client>();

        private readonly TcpListener Listener;

        public Server(int maxPlayers,  int port)
            => (MaxPlayers, Port, Listener) = (maxPlayers, port, new TcpListener(IPAddress.Any, port));

        public void Start()
        {
            InitializeServerData();

            Listener.Start();
            Listener.BeginAcceptTcpClient(TCPConnectCallback, null);

            Console.WriteLine($"Server started on {Port}");
        }

        private void TCPConnectCallback(IAsyncResult result)
        {
            TcpClient client = Listener.EndAcceptTcpClient(result);
            Listener.BeginAcceptTcpClient(TCPConnectCallback, null);
            Console.WriteLine($"Incoming connection from {client.Client.RemoteEndPoint}");

            for (int i = 0; i < MaxPlayers; i++)
            {
                if (clients[i].Socket is null)
                {
                    clients[i].Connect(client);
                    Console.WriteLine($"Client {client.Client.RemoteEndPoint} got ID: {i}");
                    return;
                }
            }

            // If this line is executed the server is full
            Console.WriteLine($"{client.Client.RemoteEndPoint} failed to connect: Server full");
        }

        private void InitializeServerData()
        {
            for (int i = 0; i < MaxPlayers; i++)
            {
                clients.Add(i, new Client(i));
            }

        }

       
    }
}
