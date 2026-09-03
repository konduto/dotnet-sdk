using System;
using Newtonsoft.Json;

namespace KdtSdk.Models
{
    public class KondutoAgent : KondutoModel
    {
        [JsonProperty("id", Required = Required.Always)]
        public String Id { get; set; }

        [JsonProperty("login")]
        public String Login { get; set; }

        [JsonProperty("name", Required = Required.Always)]
        public String Name { get; set; }

        [JsonProperty("tax_id")]
        public String TaxId { get; set; }

        /// <summary>
        /// YYYY-MM-DD
        /// </summary>
        [JsonProperty("dob")]
        public String Dob { get; set; }

        [JsonProperty("category")]
        public String Category { get; set; }

        /// <summary>
        /// YYYY-MM-DD
        /// </summary>
        [JsonProperty("created_at", Required = Required.Always)]
        public String CreatedAt { get; set; }

        public KondutoAgent() { }

        public override bool Equals(Object o)
        {
            if (this == o) return true;
            if (!(o is KondutoAgent)) return false;

            KondutoAgent that = o as KondutoAgent;

            if (!object.Equals(Id, that.Id)) return false;
            if (!object.Equals(Login, that.Login)) return false;
            if (!object.Equals(Name, that.Name)) return false;
            if (!object.Equals(TaxId, that.TaxId)) return false;
            if (!object.Equals(Dob, that.Dob)) return false;
            if (!object.Equals(Category, that.Category)) return false;
            if (!object.Equals(CreatedAt, that.CreatedAt)) return false;

            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
