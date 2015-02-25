using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using System.ComponentModel;

namespace KdtSdk.Models
{
    public class KondutoOrder : KondutoModel
    {
        /* Attributes */
        [JsonProperty("id", Required = Required.Always)]
        public String Id { get; set; }

        [JsonProperty("visitor")]
        public String Visitor { get; set; }

        [JsonProperty("timestamp")]
        public long Timestamp { get; set; }

        [JsonProperty("total_amount", Required = Required.Always)]
        public Double TotalAmount { get; set; }

        [JsonProperty("shipping_amount")]
        public Double ShippingAmount { get; set; }

        [JsonProperty("tax_amount")]
        public Double TaxAmount { get; set; }

        [JsonProperty("customer", Required = Required.Always)]
        public KondutoCustomer Customer { get; set; }

        [JsonProperty("currency")]
        public String Currency { get; set; }

        [JsonProperty("installments")]
        public int Installments { get; set; }

        [JsonProperty("ip")]
        public String Ip { get; set; }

        [JsonProperty("score"), DefaultValue(null)]
        public Double Score { get; set; }

        [JsonProperty("shipping")]
        public KondutoAddress ShippingAddress { get; set; }

        [JsonProperty("billing")]
        public KondutoAddress BillingAddress { get; set; }

        [JsonProperty("recommendation"), DefaultValue(KondutoRecommendation.none)]
        public KondutoRecommendation Recommendation { get; set; }

        [JsonProperty("status"), DefaultValue(KondutoOrderStatus.not_analyzed)]
        public KondutoOrderStatus Status { get; set; }

        [JsonProperty("geolocation")]
        public KondutoGeolocation Geolocation { get; set; }

        [JsonProperty("analyze"), DefaultValue(true)]
        public bool Analyze { get; set; }

        [JsonProperty("payment")]
        public List<KondutoPayment> Payments { get; set; }

        [JsonProperty("shopping_cart")]
        public List<KondutoItem> ShoppingCart { get; set; }
        
        [JsonProperty("device")]
        public KondutoDevice Device { get; set; }

        [JsonProperty("navigation")]
        public KondutoNavigationInfo NavigationInfo { get; set; }

	    /* Constructors */
	    public KondutoOrder() {}

        /// <summary>
        /// Equals
        /// </summary>
        /// <param name="o">object to compare</param>
        /// <returns></returns>
        public override bool Equals(Object o)
        {
            if (this == o) return true;
		    if (!(o is KondutoOrder)) return false;

            KondutoOrder that = o as KondutoOrder;

            if (!object.Equals(BillingAddress, that.BillingAddress)) return false;
            if (!object.Equals(Currency, that.Currency)) return false;
            if (!object.Equals(Customer, that.Customer)) return false;
            if (!object.Equals(Geolocation, that.Geolocation)) return false;
            if (!object.Equals(Id, that.Id)) return false;
            if (!object.Equals(Installments, that.Installments)) return false;
            if (!object.Equals(Ip, that.Ip)) return false;
            if (!object.Equals(Recommendation, that.Recommendation)) return false;
            if (!object.Equals(Score, that.Score)) return false;

            if (!object.Equals(ShippingAddress, that.ShippingAddress)) return false;
            if (!object.Equals(ShippingAmount, that.ShippingAmount)) return false;
            if (!object.Equals(Status, that.Status)) return false;
            if (!object.Equals(TaxAmount, that.TaxAmount)) return false;
            if (!object.Equals(Timestamp, that.Timestamp)) return false;

            if (!object.Equals(TotalAmount, that.TotalAmount)) return false;
            if (!object.Equals(Visitor, that.Visitor)) return false;

            if (!Payments.SequenceEqual<KondutoPayment>(that.Payments)) return false;
            if (!ShoppingCart.SequenceEqual<KondutoItem>(that.ShoppingCart)) return false;

            if (!object.Equals(Device, that.Device)) return false;
            if (!object.Equals(NavigationInfo, that.NavigationInfo)) return false;

            if (!object.Equals(Analyze, that.Analyze)) return false;

            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
