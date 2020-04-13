using System;

namespace RoyalGameOfUr.Server
{
    class Program
    {
        static void Main(string[] args)
        {
            Server server = new Server(16, 13000);
            server.Start();
            Console.ReadKey();
        }
    }

}
