using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolProject.Shared.Network.Packets
{
    public class PacketHeader
    {
        public byte MessageId { get; set; }
        public ushort Size { get; set; }
    }
}
