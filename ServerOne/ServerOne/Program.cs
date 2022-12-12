using System;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using System.Net;
using System.Threading;

namespace ServerOne
{
    class Program
    {
        static void Main(string[] args)
        {
            int port = 13000;
            string IpAddress = "127.0.0.1";
            Socket ServerListener = new Socket(AddressFamily.InterNetwork,
                SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint ep = new IPEndPoint(IPAddress.Parse(IpAddress), port);
            ServerListener.Bind(ep);
            ServerListener.Listen(100);
            Console.WriteLine("Server is Up...");
            Socket ClientSocket = default(Socket);
            int counter = 0;
            Program p = new Program();
            while (true)
            {
                counter++;
                ClientSocket = ServerListener.Accept();
                Console.WriteLine(counter + " Clients Connected");
                Thread UserThread = new Thread(new ThreadStart(() => p.User(ClientSocket)));
                UserThread.Start();
            }
        }
        public void User(Socket client)
        {
            while (true)
            {
                byte[] msg = new byte[1024];
                int size = client.Receive(msg);

                client.Send(msg, 0, size, SocketFlags.None);
            }
        }
    }
}
