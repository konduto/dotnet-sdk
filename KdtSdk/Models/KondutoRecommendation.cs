using Newtonsoft.Json;

namespace KdtSdk.Models
{
    /// <summary>
    /// Recommendation enum.
    /// @see <a href="http://docs.konduto.com">Konduto API Spec</a>
    /// </summary>
    public enum KondutoRecommendation
    {
        [JsonProperty("none")]
	    none,
        [JsonProperty("approve")]
	    approve,
	    [JsonProperty("review")]
	    review,
	    [JsonProperty("decline")]
	    decline
    }
}
