using System;
using Newtonsoft.Json;

namespace KdtSdk.Models
{
    public class KondutoTriggeredRules : KondutoModel
    {
        [JsonProperty("name")]
        public String Name { get; set; }

        [JsonProperty("decision")]
        public KondutoTriggeredDecision Decision { get; set; }
    }
}
