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

        public override bool Equals(object o)
        {
            if (this == o) return true;
            if (!(o is KondutoTriggeredRules)) return false;

            KondutoTriggeredRules that = o as KondutoTriggeredRules;

            if (!object.Equals(Name, that.Name)) return false;
            if (!object.Equals(Decision, that.Decision)) return false;

            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
