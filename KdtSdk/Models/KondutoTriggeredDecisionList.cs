using Newtonsoft.Json;
using System;

namespace KdtSdk.Models
{
    public class KondutoTriggeredDecisionList : KondutoModel
    {
        [JsonProperty("type")]
        public String Type { get; set; }

        [JsonProperty("trigger")]
        public String Trigger { get; set; }

        [JsonProperty("decision")]
        public KondutoTriggeredDecision Decision { get; set; }
    }
}
