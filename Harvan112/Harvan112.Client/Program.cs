using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Harvan112.Client
{
    class Program
    {
        private static Socket Client;
        private static byte[] buffer = new byte[4096];

        static void Main(string[] args)
        {
            Client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            Client.Connect(IPAddress.Parse("127.0.0.1"), 6666);

            new Thread(ReceiveData).Start();

            while (true)
            {
                var command = Console.ReadLine().Split(' ');

                switch (command[0])
                {
                    case "send":
                        if (command.Length > 1 && command[1] != "")
                            SendData(command[1]);

                        break;
                    default:
                        Console.WriteLine(">> Unknown command, try again...");
                        break;
                }
            }
        }

        static void ReceiveData()
        {
            var dataLength = Client.Receive(buffer);
            if (dataLength > 0)
            {
                var data = Encoding.UTF8.GetString(buffer, 0, dataLength);
                Console.WriteLine(data);
            }
        }

        static void SendData(string data) => Client.Send(Encoding.Default.GetBytes(data));
    }
}
