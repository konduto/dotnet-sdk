using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using KdtSdk.Utils;

namespace KdtSdk.Models
{
    public class KondutoVehicle : KondutoModel
    {
        [JsonProperty("vid")]
        public String Vid { get; set; }

        [JsonProperty("renavam")]
        public String Renavam { get; set; }

        [JsonProperty("registration")]
        public String Registration { get; set; }

        [JsonProperty("make", Required = Required.Always)]
        public String Make { get; set; }

        [JsonProperty("model", Required = Required.Always)]
        public String Model { get; set; }

        [JsonProperty("type")]
        public String Type { get; set; }

        [JsonProperty("usage")]
        public String Usage { get; set; }

        [JsonProperty("owner", Required = Required.Always)]
        [JsonConverter(typeof(SingleOrArrayConverter<KondutoVehicleOwner>))]
        public List<KondutoVehicleOwner> Owner { get; set; }

        public KondutoVehicle() { }

        public override bool Equals(Object o)
        {
            if (this == o) return true;
            if (!(o is KondutoVehicle)) return false;

            KondutoVehicle that = o as KondutoVehicle;

            if (!object.Equals(Vid, that.Vid)) return false;
            if (!object.Equals(Renavam, that.Renavam)) return false;
            if (!object.Equals(Registration, that.Registration)) return false;
            if (!object.Equals(Make, that.Make)) return false;
            if (!object.Equals(Model, that.Model)) return false;
            if (!object.Equals(Type, that.Type)) return false;
            if (!object.Equals(Usage, that.Usage)) return false;

            if (Owner != null && that.Owner != null)
            {
                if (!Owner.SequenceEqual(that.Owner)) return false;
            }
            else if (Owner != that.Owner) return false;

            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
