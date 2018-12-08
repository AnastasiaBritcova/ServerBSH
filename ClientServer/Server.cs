using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace ClientServer
{
    class Server
    {
        int portUdp = 17354;
        int portTcp = 13859; 
        UdpClient udp;
        TcpListener tcpServer;
        TcpClient client;

        public Server()
        {
            udp = new UdpClient();
            tcpServer = new TcpListener(IPAddress.Any, portTcp);
            tcpServer.Start();
            udp.EnableBroadcast = true;
        }

        public void Start()
        {
            Thread threadBroadcast = new Thread(new ThreadStart(StartBroadcast)); // closing thread?
            Thread threadTcp = new Thread(new ThreadStart(StartTcpAccept));
            threadBroadcast.Start();
            threadTcp.Start();
        }

        public void StartBroadcast()
        {
            while (client == null)
            {
                byte[] bytes = Encoding.ASCII.GetBytes("connectMessage"); // system 
                udp.Send(bytes, bytes.Length, new IPEndPoint(IPAddress.Broadcast, portUdp));
                Console.WriteLine("broadcast");
                Thread.Sleep(5000);
            }
        }
        private void StartTcpAccept()
        {
            client = tcpServer.AcceptTcpClient();
            Console.WriteLine("client accepted " + client.Connected);
            var stream = client.GetStream();
            while (true)
            {
                if (stream.DataAvailable) // был stream.CanRead
                {
                    byte[] bytes = new byte[128];
                    stream.Read(bytes, 0, bytes.Length);
                    string answ = Encoding.ASCII.GetString(bytes);
                    Console.WriteLine(answ);
                    if (answ == "stop")
                        return;
                }
            }
        }

        public void Send(Message message)
        {
            
        }
        public void Receive()
        {
            //Message message = 
        }

    }
}
