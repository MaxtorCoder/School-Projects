using SchoolProject.Shared.Network.Constants;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolProject.Shared.Attributes
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class NetMessageAttribute : Attribute
    {
        public ClientOpcodes ClientMessage { get; set; }
        public ServerOpcodes ServerMessage { get; set; }

        public NetMessageAttribute(ClientOpcodes message) => ClientMessage = message;
        public NetMessageAttribute(ServerOpcodes message) => ServerMessage = message;
    }
}
