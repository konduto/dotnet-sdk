using System;
using Newtonsoft.Json;

namespace KdtSdk.Models
{
    public class KondutoEventVenue : KondutoModel
    {
        [JsonProperty("name")]
        public String Name { get; set; }

        [JsonProperty("address")]
        public String Address { get; set; }

        [JsonProperty("city")]
        public String City { get; set; }

        [JsonProperty("state")]
        public String State { get; set; }

        [JsonProperty("country")]
        public String Country { get; set; }

        [JsonProperty("capacity")]
        public int? Capacity { get; set; }

        public KondutoEventVenue() { }

        public override bool Equals(Object o)
        {
            if (this == o) return true;
            if (!(o is KondutoEventVenue)) return false;

            KondutoEventVenue that = o as KondutoEventVenue;

            if (!object.Equals(Name, that.Name)) return false;
            if (!object.Equals(Address, that.Address)) return false;
            if (!object.Equals(City, that.City)) return false;
            if (!object.Equals(State, that.State)) return false;
            if (!object.Equals(Country, that.Country)) return false;
            if (!object.Equals(Capacity, that.Capacity)) return false;

            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
