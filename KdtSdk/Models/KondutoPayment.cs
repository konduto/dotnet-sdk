using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.ComponentModel;

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

        [JsonProperty("amount"), DefaultValue(null)]
        public Double? Amount { get; set; }

        [JsonProperty("description"), DefaultValue("")]
        public String Description { get; set; }


        public KondutoPayment(KondutoPaymentType type)
        {
            this.Type = type;
        }
    }
}