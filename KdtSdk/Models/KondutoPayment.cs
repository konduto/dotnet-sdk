using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace KdtSdk.Models
{
    /// <summary>
    /// Payment model.
    /// @see <a href="http://docs.konduto.com">Konduto API Spec</a>
    /// </summary>
    public abstract class KondutoPayment : KondutoModel
    {
        [JsonProperty("type"), JsonConverter(typeof(StringEnumConverter))]
        public KondutoPaymentType Type { get; set; }

        public KondutoPayment(KondutoPaymentType type)
        {
            this.Type = type;
        }
    }
}