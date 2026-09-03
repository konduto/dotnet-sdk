using System;
using Newtonsoft.Json;

namespace KdtSdk.Models
{
    public class KondutoBankingAccount : KondutoModel
    {
        [JsonProperty("id")]
        public String Id { get; set; }

        [JsonProperty("key_type")]
        public String KeyType { get; set; }

        [JsonProperty("key_value")]
        public String KeyValue { get; set; }

        [JsonProperty("holder_name")]
        public String HolderName { get; set; }

        [JsonProperty("holder_tax_id")]
        public String HolderTaxId { get; set; }

        [JsonProperty("bank_code")]
        public String BankCode { get; set; }

        [JsonProperty("bank_name")]
        public String BankName { get; set; }

        [JsonProperty("bank_branch")]
        public String BankBranch { get; set; }

        [JsonProperty("bank_account")]
        public String BankAccount { get; set; }

        [JsonProperty("balance")]
        public Double? Balance { get; set; }

        [JsonProperty("amount")]
        public Double? Amount { get; set; }

        public KondutoBankingAccount() { }

        public override bool Equals(Object o)
        {
            if (this == o) return true;
            if (!(o is KondutoBankingAccount)) return false;

            KondutoBankingAccount that = o as KondutoBankingAccount;

            if (!object.Equals(Id, that.Id)) return false;
            if (!object.Equals(KeyType, that.KeyType)) return false;
            if (!object.Equals(KeyValue, that.KeyValue)) return false;
            if (!object.Equals(HolderName, that.HolderName)) return false;
            if (!object.Equals(HolderTaxId, that.HolderTaxId)) return false;
            if (!object.Equals(BankCode, that.BankCode)) return false;
            if (!object.Equals(BankName, that.BankName)) return false;
            if (!object.Equals(BankBranch, that.BankBranch)) return false;
            if (!object.Equals(BankAccount, that.BankAccount)) return false;
            if (!object.Equals(Balance, that.Balance)) return false;
            if (!object.Equals(Amount, that.Amount)) return false;

            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
