using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using System.ComponentModel;
using Newtonsoft.Json.Converters;


namespace KdtSdk.Models
{
    /// <summary>
    /// * Address model.
    /// @see <a href="http://docs.konduto.com">Konduto API Spec</a>
    /// </summary>
    public class KondutoTravel : KondutoModel
    {
        #region Attributes
        [JsonProperty("type", Required = Required.Always), JsonConverter(typeof(StringEnumConverter))]
        public KondutoTravelType TravelType { get; set; }

        [JsonProperty("passengers", Required = Required.Always)]
        public List<KondutoPassenger> Passengers { get; set; }

        [JsonProperty("departure", Required = Required.Always)]
        public KondutoTravelInformation Departure { get; set; }

        [JsonProperty("return")]
        public KondutoTravelInformation Return { get; set; }

        /// <summary>
        /// YYYY-MM-DD
        /// </summary>
        [JsonProperty("expiration_date")]
        public String ExpirationDate { get; set; }

        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        public KondutoTravel() { }

        public override bool Equals(Object o)
        {
            if (this == o) return true;

            if (!(o is KondutoTravel)) return false;

            KondutoTravel that = o as KondutoTravel;

            if (!Passengers.SequenceEqual<KondutoPassenger>(that.Passengers)) return false;
            if (!object.Equals(Departure, that.Departure)) return false;
            if (!object.Equals(Return, that.Return)) return false;

            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}