using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KdtSdk.Models
{
    public class KondutoVoucherPayment : KondutoPayment
    {
        public KondutoVoucherPayment()
            : base(KondutoPaymentType.voucher) { }

        public override bool Equals(Object o)
        {
            if (this == o) return true;
            if (!(o is KondutoVoucherPayment)) return false;

            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}