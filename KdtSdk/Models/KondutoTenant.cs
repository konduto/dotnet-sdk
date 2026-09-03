using System;
using Newtonsoft.Json;

namespace KdtSdk.Models
{
    public class KondutoTenant : KondutoModel
    {
        [JsonProperty("id", Required = Required.Always)]
        public String Id { get; set; }

        [JsonProperty("name", Required = Required.Always)]
        public String Name { get; set; }

        /// <summary>
        /// YYYY-MM-DDTHH:mm:ssZ
        /// </summary>
        [JsonProperty("created_at", Required = Required.Always)]
        public String CreatedAt { get; set; }

        public KondutoTenant() { }

        public override bool Equals(Object o)
        {
            if (this == o) return true;
            if (!(o is KondutoTenant)) return false;

            KondutoTenant that = o as KondutoTenant;

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
