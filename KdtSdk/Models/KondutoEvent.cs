using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace KdtSdk.Models
{
    public class KondutoEvent : KondutoModel
    {
        [JsonProperty("name", Required = Required.Always)]
        public String Name { get; set; }

        /// <summary>
        /// YYYY-MM-DDTHH:mm:ssZ
        /// </summary>
        [JsonProperty("date", Required = Required.Always)]
        public String Date { get; set; }

        [JsonProperty("type", Required = Required.Always)]
        public String Type { get; set; }

        [JsonProperty("subtype")]
        public String Subtype { get; set; }

        [JsonProperty("venue")]
        public KondutoEventVenue Venue { get; set; }

        [JsonProperty("tickets")]
        public List<KondutoEventTicket> Tickets { get; set; }

        public KondutoEvent() { }

        public override bool Equals(Object o)
        {
            if (this == o) return true;
            if (!(o is KondutoEvent)) return false;

            KondutoEvent that = o as KondutoEvent;

            if (!object.Equals(Name, that.Name)) return false;
            if (!object.Equals(Date, that.Date)) return false;
            if (!object.Equals(Type, that.Type)) return false;
            if (!object.Equals(Subtype, that.Subtype)) return false;
            if (!object.Equals(Venue, that.Venue)) return false;

            if (Tickets != null && that.Tickets != null)
            {
                if (!Tickets.SequenceEqual(that.Tickets)) return false;
            }
            else if (Tickets != that.Tickets) return false;

            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
