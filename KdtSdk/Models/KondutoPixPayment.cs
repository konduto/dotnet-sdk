using System;
using Newtonsoft.Json;

namespace KdtSdk.Models
{
    public class KondutoPixPayment : KondutoPayment
    {
        public KondutoPixPayment()
            : base(KondutoPaymentType.pix) { }

        public override bool Equals(Object o)
        {
            if (this == o) return true;
            if (!(o is KondutoPixPayment)) return false;

            KondutoPixPayment that = o as KondutoPixPayment;

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
