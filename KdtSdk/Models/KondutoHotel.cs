using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace KdtSdk.Models
{
    public class KondutoHotel : KondutoModel
    {
        [JsonProperty("name", Required = Required.Always)]
        public String Name { get; set; }

        [JsonProperty("address1")]
        public String Address1 { get; set; }

        [JsonProperty("address2")]
        public String Address2 { get; set; }

        [JsonProperty("city")]
        public String City { get; set; }

        [JsonProperty("state")]
        public String State { get; set; }

        [JsonProperty("zip")]
        public String Zip { get; set; }

        [JsonProperty("country")]
        public String Country { get; set; }

        [JsonProperty("category")]
        public String Category { get; set; }

        [JsonProperty("rooms", Required = Required.Always)]
        public List<KondutoHotelRoom> Rooms { get; set; }

        public KondutoHotel() { }

        public override bool Equals(Object o)
        {
            if (this == o) return true;
            if (!(o is KondutoHotel)) return false;

            KondutoHotel that = o as KondutoHotel;

            if (!object.Equals(Name, that.Name)) return false;
            if (!object.Equals(Address1, that.Address1)) return false;
            if (!object.Equals(Address2, that.Address2)) return false;
            if (!object.Equals(City, that.City)) return false;
            if (!object.Equals(State, that.State)) return false;
            if (!object.Equals(Zip, that.Zip)) return false;
            if (!object.Equals(Country, that.Country)) return false;
            if (!object.Equals(Category, that.Category)) return false;

            if (Rooms != null && that.Rooms != null)
            {
                if (!Rooms.SequenceEqual(that.Rooms)) return false;
            }
            else if (Rooms != that.Rooms) return false;

            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
