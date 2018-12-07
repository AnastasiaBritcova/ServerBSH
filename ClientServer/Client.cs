using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
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

        public Client()
        {
            udp = new UdpClient(portUdp);
            tcpClient = new TcpClient();
            
        }

        public 

    }
}
