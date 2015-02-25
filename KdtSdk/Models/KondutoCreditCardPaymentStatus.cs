using Newtonsoft.Json;

namespace KdtSdk.Models
{
    /// <summary>
    /// Credit card status enum.
    /// @see <a href="http://docs.konduto.com">Konduto API Spec</a>
    /// </summary>
    public enum KondutoCreditCardPaymentStatus 
    {
	    [JsonProperty("approved")]
	    approved,
        [JsonProperty("declined")]
	    declined,
        [JsonProperty("pending")]
	    pending
    }
}