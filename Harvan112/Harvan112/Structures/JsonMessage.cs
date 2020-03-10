using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using Newtonsoft.Json;

namespace Harvan112.Structures
{
    public class AED : ICloneable
    {
        public uint Id;
        public string Location;
        public uint Enabled;

        [JsonProperty(PropertyName = "batterypercentage")]
        public float Battery;

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
