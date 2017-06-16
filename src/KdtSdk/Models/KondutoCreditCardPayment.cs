using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace KdtSdk.Models
{
    public class KondutoCreditCardPayment : KondutoPayment
    {
        [JsonProperty("bin")]
        public String Bin { get; set; }
        [JsonProperty("last4")]
        public String Last4 { get; set; }
        [JsonProperty("expiration_date")]
        public String ExpirationDate { get; set; }
        [JsonProperty("status"), JsonConverter(typeof(StringEnumConverter))]
        public KondutoCreditCardPaymentStatus Status { get; set; }

        public KondutoCreditCardPayment()
            : base(KondutoPaymentType.credit) { }


        public override bool Equals(Object o) 
        {
		    if (this == o) return true;
		    if (!(o is KondutoCreditCardPayment)) return false;

            KondutoCreditCardPayment that = o as KondutoCreditCardPayment;

            if (!object.Equals(Bin, that.Bin)) return false;
            if (!object.Equals(ExpirationDate, that.ExpirationDate)) return false;
            if (!object.Equals(Last4, that.Last4)) return false;
            if (!object.Equals(Status, that.Status)) return false;

		    return true;
	    }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}