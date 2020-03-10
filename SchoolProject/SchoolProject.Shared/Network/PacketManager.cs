using SchoolProject.Shared.Network.Constants;
using SchoolProject.Shared.Network.Packets;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace SchoolProject.Shared.Network
{
    public class PacketManager
    {
        private ConcurrentDictionary<ServerOpcodes, HandlePacket> ServerHandlers = new ConcurrentDictionary<ServerOpcodes, HandlePacket>();
        private ConcurrentDictionary<ClientOpcodes, HandlePacket> ClientHandlers = new ConcurrentDictionary<ClientOpcodes, HandlePacket>();
        delegate void HandlePacket(Packet packet, ISession session);

        public void Initialize()
        {
            foreach (var type in Assembly.GetExecutingAssembly().GetTypes()
                .Concat(Assembly.GetEntryAssembly().GetTypes()))
            {
                foreach (var methodInfo in type.GetMethods())
                {

                }
            }
        }
    }
}
