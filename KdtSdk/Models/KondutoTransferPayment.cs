using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KdtSdk.Models
{
    public class KondutoTransferPayment : KondutoPayment
    {
        [JsonProperty("bank_code", NullValueHandling = NullValueHandling.Ignore)]
        public String BankCode { get; set; }

        [JsonProperty("bank_branch", NullValueHandling = NullValueHandling.Ignore)]
        public String BankBranch { get; set; }

        [JsonProperty("bank_account", NullValueHandling = NullValueHandling.Ignore)]
        public String BankAccount { get; set; }

        public KondutoTransferPayment()
            : base(KondutoPaymentType.transfer) { }

        public override bool Equals(Object o)
        {
            if (this == o) return true;
            if (!(o is KondutoTransferPayment)) return false;

            KondutoTransferPayment that = o as KondutoTransferPayment;

            if (!object.Equals(BankCode, that.BankCode)) return false;
            if (!object.Equals(BankBranch, that.BankBranch)) return false;
            if (!object.Equals(BankAccount, that.BankAccount)) return false;
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