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
            udp = new UdpClient(portUdp);
            tcpServer = new TcpListener(IPAddress.Any, portTcp);
            udp.EnableBroadcast = true;
        }

        public void Start()
        {
            Thread threadBroadcast = new Thread(new ThreadStart(StartBroadcast)); // closing thread?
            Thread threadTcp = new Thread(new ThreadStart(StartTcpAccept));
        }

        private void StartBroadcast()
        {
            while (client == null)
            {
                byte[] bytes = Encoding.ASCII.GetBytes("connectMessage"); // system 
                udp.Send(bytes, bytes.Length, new IPEndPoint(IPAddress.Broadcast, portUdp));
                Thread.Sleep(5000);
            }
        }
        private void StartTcpAccept()
        {
            client = tcpServer.AcceptTcpClient();
            var stream = client.GetStream();
            while (true)
            {
                if (stream.CanRead)
                {
                    
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
