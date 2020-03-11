using System;
using System.Collections.Generic;
using System.Text;

namespace RoyalGameOfUr.Server
{
    public class Client
    {
        public readonly int Id;
        public readonly int PortNumber;
        public readonly string Ip;

        public string Username { get; set; }
        public ClientStatus Status { get; set; }

        public Client(int id, string username, ClientStatus status = ClientStatus.Connected)
            => (Id, Username, Status) = (id, username, status);

        public override string ToString()
            => $"Client[id: {Id}, username: {Username}, status: {Status}, ip: {Ip}, port: {PortNumber}]";

        public override bool Equals(object obj)
            => obj is Client client ? (client.Ip, client.PortNumber) == (Ip, PortNumber) : false;

        public override int GetHashCode()
            => new { Ip, PortNumber }.GetHashCode();
    }
}
