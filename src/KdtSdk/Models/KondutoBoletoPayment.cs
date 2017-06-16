using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KdtSdk.Models
{
    public class KondutoBoletoPayment : KondutoPayment
    {
        //Expiration date. YYYY-MM-DD
        [JsonProperty("expiration_date")]
        public String ExpirationDate { get; set; }

        public KondutoBoletoPayment()
        : base(KondutoPaymentType.boleto){ }

        public override bool Equals(Object o){
            if (this == o) return true;
		    if (!(o is KondutoBoletoPayment)) return false;

            KondutoBoletoPayment that = o as KondutoBoletoPayment;

            if (!object.Equals(ExpirationDate, that.ExpirationDate)) return false;

		    return true;
        }

        public override int GetHashCode()
        {
 	         return base.GetHashCode();
        }
    }
}