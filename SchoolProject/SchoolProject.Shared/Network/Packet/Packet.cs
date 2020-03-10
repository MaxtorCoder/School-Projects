using SchoolProject.Shared.Network.Constants;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SchoolProject.Shared.Network.Packets
{
    public class Packet
    {
        public PacketHeader Header { get; set; }
        public byte[] Data { get; set; }

        private BinaryReader Reader;
        private BinaryWriter Writer;

        public Packet(ServerOpcodes opcode)
        {
            Writer = new BinaryWriter(new MemoryStream());

            Header = new PacketHeader()
            {
                MessageId   = (byte)opcode,
                Size        = 0
            };

            Writer.Write(Header.MessageId);
            Writer.Write(Header.Size);
        }

        public Packet(byte[] data)
        {
            Reader = new BinaryReader(new MemoryStream(data));

            Header = new PacketHeader()
            {
                MessageId   = Reader.ReadByte(),
                Size        = Reader.ReadUInt16()
            };
        }

        public void Finish()
        {
            Writer.BaseStream.Seek(1, SeekOrigin.Begin);

            // Data size min the packet header size.
            Header.Size = (ushort)(Writer.BaseStream.Length - 3);

            // Write the new size.
            Writer.Write(Header.Size);

            Data = new byte[Header.Size + 3];
            Writer.BaseStream.Seek(0, SeekOrigin.Begin);
            Writer.BaseStream.Read(Data, 0, Data.Length);
        }
    }
}
