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

        public override bool Equals(object o)
        {
            if (this == o) return true;
            if (!(o is KondutoTriggeredDecisionList)) return false;

            KondutoTriggeredDecisionList that = o as KondutoTriggeredDecisionList;

            if (!object.Equals(Type, that.Type)) return false;
            if (!object.Equals(Trigger, that.Trigger)) return false;
            if (!object.Equals(Decision, that.Decision)) return false;

            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
