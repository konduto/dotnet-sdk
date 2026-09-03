using System;
using Newtonsoft.Json;

namespace KdtSdk.Models
{
    public class KondutoHotelGuest : KondutoModel
    {
        [JsonProperty("name", Required = Required.Always)]
        public String Name { get; set; }

        [JsonProperty("document")]
        public String Document { get; set; }

        [JsonProperty("document_type")]
        public String DocumentType { get; set; }

        /// <summary>
        /// YYYY-MM-DD
        /// </summary>
        [JsonProperty("dob")]
        public String Dob { get; set; }

        [JsonProperty("nationality")]
        public String Nationality { get; set; }

        public KondutoHotelGuest() { }

        public override bool Equals(Object o)
        {
            if (this == o) return true;
            if (!(o is KondutoHotelGuest)) return false;

            KondutoHotelGuest that = o as KondutoHotelGuest;

            if (!object.Equals(Name, that.Name)) return false;
            if (!object.Equals(Document, that.Document)) return false;
            if (!object.Equals(DocumentType, that.DocumentType)) return false;
            if (!object.Equals(Dob, that.Dob)) return false;
            if (!object.Equals(Nationality, that.Nationality)) return false;

            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
