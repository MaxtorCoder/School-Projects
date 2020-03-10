using SchoolProject.Shared.Network.Packets;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolProject.Shared.Network
{
    public interface ISession
    {
        void Send(Packet packet);
    }
}
