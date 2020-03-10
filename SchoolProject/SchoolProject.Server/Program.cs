using SchoolProject.Shared.Network;
using System;

namespace SchoolProject.Server
{
    class Program
    {
        static void Main(string[] args)
        {
            var server = new Network.Server();
            server.Start("127.0.0.1", 6006);

            var packetMgr = new PacketManager();
            packetMgr.Initialize();
        }
    }
}
