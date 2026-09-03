using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace KdtSdk.Models
{
    public class KondutoEventTicket : KondutoModel
    {
        [JsonProperty("id")]
        public String Id { get; set; }

        [JsonProperty("category", Required = Required.Always)]
        public String Category { get; set; }

        [JsonProperty("section")]
        public String Section { get; set; }

        [JsonProperty("premium", Required = Required.Always)]
        public bool? Premium { get; set; }

        [JsonProperty("attendee", Required = Required.Always)]
        public List<KondutoEventAttendee> Attendee { get; set; }

        public KondutoEventTicket() { }

        public override bool Equals(Object o)
        {
            if (this == o) return true;
            if (!(o is KondutoEventTicket)) return false;

            KondutoEventTicket that = o as KondutoEventTicket;

            if (!object.Equals(Id, that.Id)) return false;
            if (!object.Equals(Category, that.Category)) return false;
            if (!object.Equals(Section, that.Section)) return false;
            if (!object.Equals(Premium, that.Premium)) return false;

            if (Attendee != null && that.Attendee != null)
            {
                if (!Attendee.SequenceEqual(that.Attendee)) return false;
            }
            else if (Attendee != that.Attendee) return false;

            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
