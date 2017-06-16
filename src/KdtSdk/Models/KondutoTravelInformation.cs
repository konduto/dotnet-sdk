using System;
using Newtonsoft.Json;

namespace KdtSdk.Models
{
    public class KondutoTravelInformation : KondutoModel
    {
        [JsonProperty("origin_city")]
        public String OriginCity { get; set; }
        [JsonProperty("destination_city")]
        public String DestinationCity { get; set; }

        [JsonProperty("origin_airport")]
        public String OriginAirport { get; set; }
        [JsonProperty("destination_airport")]
        public String DestinationAirport { get; set; }

        [JsonProperty("date", Required = Required.Always)]
        public String Date { get; set; }
        [JsonProperty("number_of_connections")]
        public int NumberOfConnections { get; set; }
        [JsonProperty("class")]
        public String Class { get; set; }
        [JsonProperty("fare_basis")]
        public String FareBasis { get; set; }

        public KondutoTravelInformation() { }

        public override bool Equals(object o)
        {
            if (this == o) return true;
            if (!(o is KondutoTravelInformation)) return false;

            KondutoTravelInformation that = o as KondutoTravelInformation;

            // required
            if (!object.Equals(OriginAirport, that.OriginAirport)) return false;
            if (!object.Equals(DestinationAirport, that.DestinationAirport)) return false;
            if (!object.Equals(OriginCity, that.OriginCity)) return false;
            if (!object.Equals(DestinationCity, that.DestinationCity)) return false;
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
