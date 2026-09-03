using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KdtSdk.Models
{
    public class KondutoVoucherPayment : KondutoPayment
    {
        [JsonProperty("voucher_type", NullValueHandling = NullValueHandling.Ignore)]
        public String VoucherType { get; set; }

        public KondutoVoucherPayment()
            : base(KondutoPaymentType.voucher) { }

        public override bool Equals(Object o)
        {
            if (this == o) return true;
            if (!(o is KondutoVoucherPayment)) return false;

            KondutoVoucherPayment that = o as KondutoVoucherPayment;

            if (!object.Equals(VoucherType, that.VoucherType)) return false;
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