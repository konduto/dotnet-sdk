using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Newtonsoft.Json.Converters;

namespace KdtSdk.Models
{
    public class KondutoDebitPayment : KondutoPayment
    {
        [JsonProperty("bin", NullValueHandling = NullValueHandling.Ignore)]
        public String Bin { get; set; }
        [JsonProperty("last4", NullValueHandling = NullValueHandling.Ignore)]
        public String Last4 { get; set; }
        [JsonProperty("expiration_date", NullValueHandling = NullValueHandling.Ignore)]
        public String ExpirationDate { get; set; }
        [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore), JsonConverter(typeof(StringEnumConverter))]
        public KondutoCreditCardPaymentStatus? Status { get; set; }
        [JsonProperty("tax_id", NullValueHandling = NullValueHandling.Ignore)]
        public String TaxId { get; set; }
        [JsonProperty("cvv_result", NullValueHandling = NullValueHandling.Ignore)]
        public String CvvResult { get; set; }
        [JsonProperty("avs_result", NullValueHandling = NullValueHandling.Ignore)]
        public String AvsResult { get; set; }
        [JsonProperty("sha1", NullValueHandling = NullValueHandling.Ignore)]
        public String Sha1 { get; set; }
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public String Name { get; set; }
        [JsonProperty("holder", NullValueHandling = NullValueHandling.Ignore)]
        public String Holder { get; set; }
        [JsonProperty("mcc", NullValueHandling = NullValueHandling.Ignore)]
        public String Mcc { get; set; }
        [JsonProperty("mid", NullValueHandling = NullValueHandling.Ignore)]
        public String Mid { get; set; }
        [JsonProperty("3ds_id", NullValueHandling = NullValueHandling.Ignore)]
        public String ThreeDsId { get; set; }
        [JsonProperty("merchant_tax_id", NullValueHandling = NullValueHandling.Ignore)]
        public String MerchantTaxId { get; set; }

        public KondutoDebitPayment()
            : base(KondutoPaymentType.debit) { }

        public override bool Equals(Object o)
        {
            if (this == o) return true;
            if (!(o is KondutoDebitPayment)) return false;

            KondutoDebitPayment that = o as KondutoDebitPayment;

            if (!object.Equals(Bin, that.Bin)) return false;
            if (!object.Equals(ExpirationDate, that.ExpirationDate)) return false;
            if (!object.Equals(Last4, that.Last4)) return false;
            if (!object.Equals(Status, that.Status)) return false;
            if (!object.Equals(TaxId, that.TaxId)) return false;
            if (!object.Equals(CvvResult, that.CvvResult)) return false;
            if (!object.Equals(AvsResult, that.AvsResult)) return false;
            if (!object.Equals(Sha1, that.Sha1)) return false;
            if (!object.Equals(Name, that.Name)) return false;
            if (!object.Equals(Holder, that.Holder)) return false;
            if (!object.Equals(Mcc, that.Mcc)) return false;
            if (!object.Equals(Mid, that.Mid)) return false;
            if (!object.Equals(ThreeDsId, that.ThreeDsId)) return false;
            if (!object.Equals(MerchantTaxId, that.MerchantTaxId)) return false;
            if (!object.Equals(Amount, that.Amount)) return false;
            if (!object.Equals(Description, that.Description)) return false;
            if (!object.Equals(Currency, that.Currency)) return false;
            if (!object.Equals(Installments, that.Installments)) return false;

            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}