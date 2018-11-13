using System;
using Newtonsoft.Json;

namespace KdtSdk.Models
{
    public class KondutoItem : KondutoModel
    {
        [JsonProperty("sku")]
        public String Sku { get; set; }
        [JsonProperty("category")]
        public int Category { get; set; }
        [JsonProperty("name")]
        public String Name { get; set; }
        [JsonProperty("description")]
        public String Description { get; set; }
        [JsonProperty("product_code")]
        public String ProductCode { get; set; }
        [JsonProperty("unit_cost")]
        public Double UnitCost { get; set; }
        [JsonProperty("quantity")]
        public float Quantity { get; set; }
        [JsonProperty("discount")]
        public Double Discount { get; set; }

        /// <summary>
        /// YYYY-MM-DD
        /// </summary>
        [JsonProperty("created_at")]
        public String CreatedAt { get; set; }

        public bool ShouldSerializeDiscount()
        {
            return Discount != 0;
        }

	    /* Constructors */

	    public KondutoItem(){}

	    public override bool Equals(Object o) 
        {
		    if (this == o) return true;
		    if (!(o is KondutoItem)) return false;

            KondutoItem that = o as KondutoItem;

            if (!object.Equals(Sku, that.Sku)) return false;
            if (!object.Equals(Category, that.Category)) return false;
            if (!object.Equals(Name, that.Name)) return false;
            if (!object.Equals(Description, that.Description)) return false;
            if (!object.Equals(ProductCode, that.ProductCode)) return false;
            if (!object.Equals(UnitCost, that.UnitCost)) return false;
            if (!object.Equals(Quantity, that.Quantity)) return false;
            if (!object.Equals(Discount, that.Discount)) return false;
            if (!object.Equals(CreatedAt, that.CreatedAt)) return false;

		    return true;
	    }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
