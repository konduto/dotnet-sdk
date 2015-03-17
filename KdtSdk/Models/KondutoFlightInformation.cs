using System;
using Newtonsoft.Json;

namespace KdtSdk.Models
{
    public class KondutoFlightInformation : KondutoModel
    {
        //"origin": "GRU",
        //"destination": "SFO",
        //"date": "2018-12-25T18:00Z",
        //"number_of_connections": 1,
        //"class": "economy",
        //"fare_basis": "Y"

        [JsonProperty("origin", Required = Required.Always)]
        public String Origin { get; set; }
        [JsonProperty("destination", Required = Required.Always)]
        public String Destination { get; set; }
        [JsonProperty("date", Required = Required.Always)]
        public String Date { get; set; }
        [JsonProperty("number_of_connections")]
        public int NumberOfConnections { get; set; }
        [JsonProperty("class")]
        public String Class { get; set; }
        [JsonProperty("fare_basis")]
        public String FareBasis { get; set; }

        public KondutoFlightInformation() { }

        public override bool Equals(object o)
        {
            if (this == o) return true;
            if (!(o is KondutoFlightInformation)) return false;

            KondutoFlightInformation that = o as KondutoFlightInformation;

            // required
            if (!object.Equals(Origin, that.Origin)) return false;
            if (!object.Equals(Destination, that.Destination)) return false;
            if (!object.Equals(Date, that.Date)) return false;
            if (!object.Equals(NumberOfConnections, that.NumberOfConnections)) return false;
            if (!object.Equals(Class, that.Class)) return false;
            if (!object.Equals(FareBasis, that.FareBasis)) return false;

            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
