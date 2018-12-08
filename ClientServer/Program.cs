using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ClientServer
{
    class Program
    {
        static void Main(string[] args)
        {
            int start;
            start = Int32.Parse(Console.ReadLine());
            Server server;
            Client client;

            if (start == 0)
            {
                server = new Server();
                server.Start();
            }
            else
            {
                client = new Client();
                client.Receive();

                client.Send("message from client");
                Thread.Sleep(5000);
                client.Send("stop");
                Thread.Sleep(5000);
                //client.Receive();
            }
        }
    }
}
