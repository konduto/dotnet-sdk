using System;
using Newtonsoft.Json;

namespace KdtSdk.Models
{
    public class KondutoEventAttendee : KondutoModel
    {
        [JsonProperty("name")]
        public String Name { get; set; }

        [JsonProperty("document", Required = Required.Always)]
        public String Document { get; set; }

        [JsonProperty("document_type")]
        public String DocumentType { get; set; }

        /// <summary>
        /// YYYY-MM-DD
        /// </summary>
        [JsonProperty("dob")]
        public String Dob { get; set; }

        public KondutoEventAttendee() { }

        public override bool Equals(Object o)
        {
            if (this == o) return true;
            if (!(o is KondutoEventAttendee)) return false;

            KondutoEventAttendee that = o as KondutoEventAttendee;

            if (!object.Equals(Name, that.Name)) return false;
            if (!object.Equals(Document, that.Document)) return false;
            if (!object.Equals(DocumentType, that.DocumentType)) return false;
            if (!object.Equals(Dob, that.Dob)) return false;

            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
