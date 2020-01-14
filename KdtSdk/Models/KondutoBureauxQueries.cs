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
    }
}