using System;
using Newtonsoft.Json;

namespace KdtSdk.Models
{
    public class KondutoSeller : KondutoModel
    {
        [JsonProperty("id")]
        public String Id { get; set; }
        [JsonProperty("name")]
        public String Name { get; set; }
        
        /// <summary>
        /// YYYY-MM-DD
        /// </summary>
        [JsonProperty("created_at")]
        public String CreatedAt { get; set; }

        /* Constructors */

        public KondutoSeller() { }

        public override bool Equals(Object o)
        {
            if (this == o) return true;
            if (!(o is KondutoSeller)) return false;

            KondutoSeller that = o as KondutoSeller;

            if (!object.Equals(Id, that.Id)) return false;
            if (!object.Equals(Name, that.Name)) return false;
            if (!object.Equals(CreatedAt, that.CreatedAt)) return false;

            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
