using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using System.ComponentModel;
using System.Runtime.Serialization;
using KdtSdk.Exceptions;

namespace KdtSdk.Models
{
    public class KondutoOrder : KondutoModel
    {
        /* Attributes */
        [JsonProperty("id", Required = Required.Always)]
        public String Id { get; set; }

        [JsonProperty("visitor"), DefaultValue(null)]
        public String Visitor { get; set; }

        [JsonProperty("timestamp", DefaultValueHandling=DefaultValueHandling.Ignore), DefaultValue(0)]
        public long Timestamp { get; set; }

        [JsonProperty("total_amount", Required = Required.Always)]
        public Double TotalAmount { get; set; }

        [JsonProperty("shipping_amount", DefaultValueHandling = DefaultValueHandling.Ignore), DefaultValue(-1)]
        public Double ShippingAmount { get; set; }

        [JsonProperty("tax_amount", DefaultValueHandling = DefaultValueHandling.Ignore), DefaultValue(0)]
        public Double TaxAmount { get; set; }

        [JsonProperty("customer", Required = Required.Always)]
        public KondutoCustomer Customer { get; set; }

        [JsonProperty("currency", DefaultValueHandling = DefaultValueHandling.Ignore), DefaultValue("")]
        public String Currency { get; set; }

        [JsonProperty("installments", DefaultValueHandling = DefaultValueHandling.Ignore), DefaultValue(0)]
        public int Installments { get; set; }

        [JsonProperty("ip", DefaultValueHandling = DefaultValueHandling.Ignore), DefaultValue("")]
        public String Ip { get; set; }

        [JsonProperty("score", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public Double? Score { get; set; }

        [JsonProperty("shipping", DefaultValueHandling = DefaultValueHandling.Ignore), DefaultValue(null)]
        public KondutoAddress ShippingAddress { get; set; }

        [JsonProperty("billing", DefaultValueHandling = DefaultValueHandling.Ignore), DefaultValue(null)]
        public KondutoAddress BillingAddress { get; set; }

        [JsonProperty("recommendation", DefaultValueHandling = DefaultValueHandling.Ignore), DefaultValue(KondutoRecommendation.none)]
        public KondutoRecommendation Recommendation { get; set; }

        [JsonProperty("geolocation", DefaultValueHandling = DefaultValueHandling.Ignore), DefaultValue(null)]
        public KondutoGeolocation Geolocation { get; set; }

        [JsonProperty("analyze"), DefaultValue(true)]
        public bool Analyze { get; set; }

        [JsonProperty("payment", DefaultValueHandling = DefaultValueHandling.Ignore), DefaultValue(null)]
        public List<KondutoPayment> Payments { get; set; }

        [JsonProperty("shopping_cart", DefaultValueHandling = DefaultValueHandling.Ignore), DefaultValue(null)]
        public List<KondutoItem> ShoppingCart { get; set; }

        [JsonProperty("device", DefaultValueHandling = DefaultValueHandling.Ignore), DefaultValue(null)]
        public KondutoDevice Device { get; set; }

        [JsonProperty("navigation", DefaultValueHandling = DefaultValueHandling.Ignore), DefaultValue(null)]
        public KondutoNavigationInfo NavigationInfo { get; set; }

        [JsonProperty("flight", DefaultValueHandling = DefaultValueHandling.Ignore), DefaultValue(null)]
        public KondutoTravel Flight { get; set; }

        /// <summary>
        /// YYYY-MM-DDThh:mmZ
        /// </summary>
        [JsonProperty("first_message", DefaultValueHandling = DefaultValueHandling.Ignore), DefaultValue(null)]
        public String FirstMessage { get; set; }

        [JsonProperty("messages_exchanged", DefaultValueHandling = DefaultValueHandling.Ignore), DefaultValue(null)]
        public int MessagesExchanged { get; set; }

        /// <summary>
        /// YYYY-MM-DDThh:mmZ
        /// </summary>
        [JsonProperty("purchased_at", DefaultValueHandling = DefaultValueHandling.Ignore), DefaultValue(null)]
        public String PurchasedAt { get; set; }

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
            if (!object.Equals(TaxAmount, that.TaxAmount)) return false;
            if (!object.Equals(Timestamp, that.Timestamp)) return false;

            if (!object.Equals(TotalAmount, that.TotalAmount)) return false;
            if (!object.Equals(Visitor, that.Visitor)) return false;

            if (!Payments.SequenceEqual<KondutoPayment>(that.Payments)) return false;
            if (!ShoppingCart.SequenceEqual<KondutoItem>(that.ShoppingCart)) return false;

            if (!object.Equals(Device, that.Device)) return false;
            if (!object.Equals(NavigationInfo, that.NavigationInfo)) return false;

            if (!object.Equals(Analyze, that.Analyze)) return false;

            if (!object.Equals(Flight, that.Flight)) return false;

            if (!object.Equals(PurchasedAt, that.PurchasedAt)) return false;
            if (!object.Equals(MessagesExchanged, that.MessagesExchanged)) return false;
            if (!object.Equals(FirstMessage, that.FirstMessage)) return false;

            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        [OnSerializing]
        internal void OnSerializedMethod(StreamingContext context)
        {
            if (ShoppingCart != null && Flight != null)
            {
                throw new JsonSerializationException("Shopping cart and flight object cannnot exist in same order.");
            }
        }

        /// <summary>
        /// Merges a konduto response of order to current KondutoOrder
        /// </summary>
        /// <param name="response">KondutoOrder response from API</param>
        public void MergeKondutoOrderResponse(KondutoOrderResponse response)
        {
            this.Device = response.Device;
            this.Recommendation = response.Recommendation;
            this.Score= response.Score;
            this.NavigationInfo = response.NavigationInfo;
            this.Geolocation = response.Geolocation;
            this.Timestamp = response.Timestamp;
        }
    }
}
