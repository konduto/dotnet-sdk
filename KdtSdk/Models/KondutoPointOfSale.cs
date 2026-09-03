using System;
using Newtonsoft.Json;

namespace KdtSdk.Models
{
    public class KondutoPointOfSale : KondutoModel
    {
        [JsonProperty("id", Required = Required.Always)]
        public String Id { get; set; }

        [JsonProperty("name", Required = Required.Always)]
        public String Name { get; set; }

        [JsonProperty("lat")]
        public Double? Lat { get; set; }

        [JsonProperty("long")]
        public Double? Long { get; set; }

        [JsonProperty("address")]
        public String Address { get; set; }

        [JsonProperty("city")]
        public String City { get; set; }

        [JsonProperty("state")]
        public String State { get; set; }

        [JsonProperty("zip")]
        public String Zip { get; set; }

        [JsonProperty("country")]
        public String Country { get; set; }

        public KondutoPointOfSale() { }

        public override bool Equals(Object o)
        {
            if (this == o) return true;
            if (!(o is KondutoPointOfSale)) return false;

            KondutoPointOfSale that = o as KondutoPointOfSale;

            if (!object.Equals(Id, that.Id)) return false;
            if (!object.Equals(Name, that.Name)) return false;
            if (!object.Equals(Lat, that.Lat)) return false;
            if (!object.Equals(Long, that.Long)) return false;
            if (!object.Equals(Address, that.Address)) return false;
            if (!object.Equals(City, that.City)) return false;
            if (!object.Equals(State, that.State)) return false;
            if (!object.Equals(Zip, that.Zip)) return false;
            if (!object.Equals(Country, that.Country)) return false;

            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
