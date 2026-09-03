using System;
using Newtonsoft.Json;

namespace KdtSdk.Models
{
    public class KondutoVehicleOwner : KondutoModel
    {
        [JsonProperty("name")]
        public String Name { get; set; }

        [JsonProperty("tax_id", Required = Required.Always)]
        public String TaxId { get; set; }

        public KondutoVehicleOwner() { }

        public override bool Equals(Object o)
        {
            if (this == o) return true;
            if (!(o is KondutoVehicleOwner)) return false;

            KondutoVehicleOwner that = o as KondutoVehicleOwner;

            if (!object.Equals(Name, that.Name)) return false;
            if (!object.Equals(TaxId, that.TaxId)) return false;

            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
