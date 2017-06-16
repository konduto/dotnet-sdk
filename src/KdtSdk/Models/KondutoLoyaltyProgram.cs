using System;
using Newtonsoft.Json;

namespace KdtSdk.Models
{
    public class KondutoLoyaltyProgram : KondutoModel
    {
        [JsonProperty("program")]
        public String Program { get; set; }

        [JsonProperty("category")]
        public String Category { get; set; }

        public KondutoLoyaltyProgram() { }

        public override bool Equals(object o)
        {
            if (this == o) return true;
            if (!(o is KondutoLoyaltyProgram)) return false;

            KondutoLoyaltyProgram that = o as KondutoLoyaltyProgram;

            if (!object.Equals(Program, that.Program)) return false;
            if (!object.Equals(Category, that.Category)) return false;

            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}