using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KdtSdk.Models
{
    public class KondutoTransferPayment : KondutoPayment
    {
        public KondutoTransferPayment()
            : base(KondutoPaymentType.transfer) { }

        public override bool Equals(Object o)
        {
            if (this == o) return true;
            if (!(o is KondutoTransferPayment)) return false;

            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}