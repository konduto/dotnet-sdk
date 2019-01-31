using Newtonsoft.Json;

namespace KdtSdk.Models
{
    public enum KondutoOrderStatus
    {
        [JsonProperty("approved")]
        approved,
        [JsonProperty("pending")]
	    pending,
        [JsonProperty("declined")]
	    declined,
        [JsonProperty("fraud")]
	    fraud,
        [JsonProperty("not_analyzed")]
	    not_analyzed,
        [JsonProperty("not_authorized")]
        not_authorized,
        [JsonProperty("canceled")]
        canceled
    }
}
