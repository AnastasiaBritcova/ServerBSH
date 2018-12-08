using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;


namespace ClientServer
{
    class Client
    {
        int portUdp = 17354;
        int portTcp = 13859;
        UdpClient udp;
        TcpClient tcpClient;
        IPEndPoint endPoint;

        public Client() 
        {
            udp = new UdpClient(portUdp);
            tcpClient = new TcpClient();
            
        }

        public void Receive()
        {
            IPEndPoint remoteIp = null; // чтобы слушать всех

            byte[] received = udp.Receive(ref remoteIp);
            Console.WriteLine(Encoding.ASCII.GetString(received));
            Console.WriteLine("Ipaddress from remoteIp: " + remoteIp.Address);
            TcpConnect(remoteIp.Address);
        }
        private void TcpConnect(IPAddress address)
        {
            tcpClient.Connect(address, portTcp);
            Console.WriteLine("client connected");

        }

        public void Send(string message)
        {
            byte[] bytes = Encoding.ASCII.GetBytes(message);
            tcpClient.GetStream().Write(bytes, 0, bytes.Length);
            Console.WriteLine("send end");
        }

        public void Send(Message message)
        {
            BinaryFormatter formatter = new BinaryFormatter();

            NetworkStream stream = tcpClient.GetStream();
            formatter.Serialize(stream, message);
        }
    }
}
