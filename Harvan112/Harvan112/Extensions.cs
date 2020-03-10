using System;
using System.Collections.Generic;
using System.Text;

namespace Harvan112
{

    public static class Extensions
    {
        public static string DeserializePacket(this byte[] data)
        {
            string deserializedPacket = string.Empty;

            for (int i = 0; i < data.Length; i++)
                deserializedPacket += data[i].ToString("X") + " ";

            return deserializedPacket;
        }
    }
}
