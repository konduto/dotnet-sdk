using System;
using Newtonsoft.Json;

namespace KdtSdk.Models
{
    public class KondutoPixPayment : KondutoPayment
    {
        [JsonProperty("key_type")]
        public String KeyType { get; set; }

        [JsonProperty("key_value")]
        public String KeyValue { get; set; }

        [JsonProperty("end_to_end_id")]
        public String EndToEndId { get; set; }

        [JsonProperty("qr_code")]
        public String QrCode { get; set; }

        /// <summary>
        /// YYYY-MM-DDTHH:mm:ssZ or YYYY-MM-DD
        /// </summary>
        [JsonProperty("expiration_date")]
        public String ExpirationDate { get; set; }

        [JsonProperty("status")]
        public String Status { get; set; }

        public KondutoPixPayment()
            : base(KondutoPaymentType.pix) { }

        public override bool Equals(Object o)
        {
            if (this == o) return true;
            if (!(o is KondutoPixPayment)) return false;

            KondutoPixPayment that = o as KondutoPixPayment;

            if (!object.Equals(KeyType, that.KeyType)) return false;
            if (!object.Equals(KeyValue, that.KeyValue)) return false;
            if (!object.Equals(EndToEndId, that.EndToEndId)) return false;
            if (!object.Equals(QrCode, that.QrCode)) return false;
            if (!object.Equals(ExpirationDate, that.ExpirationDate)) return false;
            if (!object.Equals(Status, that.Status)) return false;
            if (!object.Equals(Amount, that.Amount)) return false;
            if (!object.Equals(Description, that.Description)) return false;

            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
