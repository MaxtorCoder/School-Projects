using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace SchoolProject.Server.Network
{
    public class Server
    {
        private TcpListener Listener;
        private Session Session;

        public void Start(string ip, int port)
        {
            Listener = new TcpListener(IPAddress.Parse(ip), port);
            Listener.Start();

            Console.WriteLine("Started server... Waiting for connection from client...");

            new Thread(AwaitConnection).Start();
        }

        private void AwaitConnection()
        {
            while (true)
            {
                while (Listener.Pending())
                {
                    Session = new Session();
                    Session.OnAccept(Listener.AcceptSocket());
                }
            }
        }
    }
}
