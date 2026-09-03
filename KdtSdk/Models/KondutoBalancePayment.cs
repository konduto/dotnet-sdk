using System;
using Newtonsoft.Json;

namespace KdtSdk.Models
{
    public class KondutoBalancePayment : KondutoPayment
    {
        [JsonProperty("user_id")]
        public String UserId { get; set; }

        public KondutoBalancePayment()
            : base(KondutoPaymentType.balance) { }

        public override bool Equals(Object o)
        {
            if (this == o) return true;
            if (!(o is KondutoBalancePayment)) return false;

            KondutoBalancePayment that = o as KondutoBalancePayment;

            if (!object.Equals(UserId, that.UserId)) return false;
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
