using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using System.ComponentModel;


namespace KdtSdk.Models
{
    /// <summary>
    /// * Address model.
    /// @see <a href="http://docs.konduto.com">Konduto API Spec</a>
    /// </summary>
    public class KondutoFlight : KondutoModel
    {
        #region Attributes

        [JsonProperty("passengers", Required = Required.Always)]
        public List<KondutoPassenger> Passengers { get; set; }

        [JsonProperty("departure", Required = Required.Always)]
        public KondutoFlightInformation Departure { get; set; }

        [JsonProperty("return", Required = Required.Always)]
        public KondutoFlightInformation Return { get; set; }

        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        public KondutoFlight() { }

        public override bool Equals(Object o)
        {
            if (this == o) return true;

            if (!(o is KondutoFlight)) return false;

            KondutoFlight that = o as KondutoFlight;

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