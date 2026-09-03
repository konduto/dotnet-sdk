using System;
using Newtonsoft.Json;

namespace KdtSdk.Models
{
    public class KondutoBureauxQueries : KondutoModel
    {
        [JsonProperty("service")]
        public String Service { get; set; }

        [JsonProperty("response")]
        public KondutoBureauxQueriesResponse Response { get; set; }

        public override bool Equals(object o)
        {
            if (this == o) return true;
            if (!(o is KondutoBureauxQueries)) return false;

            KondutoBureauxQueries that = o as KondutoBureauxQueries;

            if (!object.Equals(Service, that.Service)) return false;
            if (!object.Equals(Response, that.Response)) return false;

            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}