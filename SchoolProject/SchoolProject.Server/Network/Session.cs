using SchoolProject.Shared.Network;
using SchoolProject.Shared.Network.Packets;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace SchoolProject.Server.Network
{
    public class Session : ISession
    {
        private Socket Socket;
        private byte[] buffer = new byte[4096];

        public void OnAccept(Socket socket)
        {
            Socket = socket;
            Console.WriteLine($"A new client connected: {GetRemote()}");

            Socket.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, ReceiveDataCallback, null);
        }

        private void ReceiveDataCallback(IAsyncResult ar)
        {
            try
            {
                var length = Socket.EndReceive(ar);
                if (length == 0)
                    return;

                var data = new byte[length];
                Buffer.BlockCopy(buffer, 0, data, 0, data.Length);

                Socket.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, ReceiveDataCallback, null);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void Send(Packet packet)
        {
            try
            {
                Socket.Send(packet.Data, 0, packet.Data.Length, SocketFlags.None);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public string GetRemote() => Socket.RemoteEndPoint.ToString();
    }
}
