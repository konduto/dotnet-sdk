using System;
using Newtonsoft.Json;

namespace KdtSdk.Models
{
    public class KondutoDelivery : KondutoModel
    {
        [JsonProperty("delivery_company")]
        public String DeliveryCompany { get; set; }

        [JsonProperty("delivery_method")]
        public String DeliveryMethod { get; set; }

        /// <summary>
        /// YYYY-MM-DDTHH:mm:ssZ
        /// </summary>
        [JsonProperty("estimated_shipping_date", Required = Required.Always)]
        public String EstimatedShippingDate { get; set; }

        /// <summary>
        /// YYYY-MM-DDTHH:mm:ssZ
        /// </summary>
        [JsonProperty("estimated_delivery_date", Required = Required.Always)]
        public String EstimatedDeliveryDate { get; set; }

        public KondutoDelivery() { }

        public override bool Equals(Object o)
        {
            if (this == o) return true;
            if (!(o is KondutoDelivery)) return false;

            KondutoDelivery that = o as KondutoDelivery;

            if (!object.Equals(DeliveryCompany, that.DeliveryCompany)) return false;
            if (!object.Equals(DeliveryMethod, that.DeliveryMethod)) return false;
            if (!object.Equals(EstimatedShippingDate, that.EstimatedShippingDate)) return false;
            if (!object.Equals(EstimatedDeliveryDate, that.EstimatedDeliveryDate)) return false;

            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
