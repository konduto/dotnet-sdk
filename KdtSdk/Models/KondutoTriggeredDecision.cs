using Newtonsoft.Json;

namespace KdtSdk.Models
{
    /// <summary>
    /// Decision enum.
    /// @see <a href="http://docs.konduto.com">Konduto API Spec</a>
    /// </summary>
    public enum KondutoTriggeredDecision
    {
        [JsonProperty("approve")]
        approve,
	    [JsonProperty("review")]
        review,
	    [JsonProperty("decline")]
        decline
    }
}
