using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using System.ComponentModel;
using System.Runtime.Serialization;
using KdtSdk.Exceptions;
using KdtSdk.Utils;

namespace KdtSdk.Models
{
    public class KondutoOrder : KondutoModel
    {
        /* Attributes */
        [JsonProperty("id", Required = Required.Always)]
        public String Id { get; set; }

        [JsonProperty("visitor", Required = Required.Always)]
        public String Visitor { get; set; }

        [JsonProperty("timestamp", DefaultValueHandling = DefaultValueHandling.Ignore), DefaultValue(0)]
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

        [JsonProperty("installments", Required = Required.Always)]
        public int Installments { get; set; }

        [JsonProperty("ip", DefaultValueHandling = DefaultValueHandling.Ignore), DefaultValue("")]
        public String Ip { get; set; }

        [JsonProperty("score", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public Double? Score { get; set; }

        [JsonProperty("bureaux_queries", DefaultValueHandling = DefaultValueHandling.Ignore), DefaultValue(null)]
        public List<KondutoBureauxQueries> BureauxQueries { get; set; }

        [JsonProperty("triggered_rules", DefaultValueHandling = DefaultValueHandling.Ignore), DefaultValue(null)]
        public List<KondutoTriggeredRules> TriggeredRules { get; set; }

        [JsonProperty("triggered_decision_list", DefaultValueHandling = DefaultValueHandling.Ignore), DefaultValue(null)]
        public List<KondutoTriggeredDecisionList> TriggeredDecisionList { get; set; }

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

        [JsonProperty("travel", DefaultValueHandling = DefaultValueHandling.Ignore), DefaultValue(null)]
        public KondutoTravel Travel { get; set; }

        [JsonProperty("status", DefaultValueHandling = DefaultValueHandling.Ignore), DefaultValue(null)]
        public String Status { get; set; }

        /// <summary>
        /// YYYY-MM-DDThh:mmZ
        /// </summary>
        [JsonProperty("first_message", DefaultValueHandling = DefaultValueHandling.Ignore), DefaultValue(null)]
        public String FirstMessage { get; set; }

        [JsonProperty("messages_exchanged", DefaultValueHandling = DefaultValueHandling.Ignore), DefaultValue(null)]
        public int MessagesExchanged { get; set; }

        /// <summary>
        /// YYYY-MM-DDTHH:mm:ssZ
        /// </summary>
        [JsonProperty("purchase_at", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore), DefaultValue(null)]
        public String PurchaseAt { get; set; }

        [JsonProperty("seller", DefaultValueHandling = DefaultValueHandling.Ignore), DefaultValue(null)]
        public KondutoSeller Seller { get; set; }

        [JsonProperty("recurring", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public bool? Recurring { get; set; }

        [JsonProperty("risk_level", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore), DefaultValue(null)]
        public String RiskLevel { get; set; }

        [JsonProperty("sales_channel", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore), DefaultValue(null)]
        public String SalesChannel { get; set; }

        [JsonProperty("scheduled", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public bool? Scheduled { get; set; }

        [JsonProperty("hotel", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore), DefaultValue(null)]
        public KondutoHotel Hotel { get; set; }

        [JsonProperty("events", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore), DefaultValue(null)]
        [JsonConverter(typeof(SingleOrArrayConverter<KondutoEvent>))]
        public List<KondutoEvent> Events { get; set; }

        [JsonProperty("vehicles", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore), DefaultValue(null)]
        public KondutoVehicle Vehicles { get; set; }

        [JsonProperty("delivery", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore), DefaultValue(null)]
        public KondutoDelivery Delivery { get; set; }

        [JsonProperty("point_of_sale", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore), DefaultValue(null)]
        public KondutoPointOfSale PointOfSale { get; set; }

        [JsonProperty("agent", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore), DefaultValue(null)]
        public KondutoAgent Agent { get; set; }

        [JsonProperty("tenant", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore), DefaultValue(null)]
        public KondutoTenant Tenant { get; set; }

        [JsonProperty("event_type", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore), DefaultValue(null)]
        public String EventType { get; set; }

        [JsonProperty("event_details", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore), DefaultValue(null)]
        public String EventDetails { get; set; }

        [JsonProperty("origin_account", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore), DefaultValue(null)]
        public KondutoBankingAccount OriginAccount { get; set; }

        [JsonProperty("destination_accounts", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore), DefaultValue(null)]
        public List<KondutoBankingAccount> DestinationAccounts { get; set; }

        /* Constructors */
        public KondutoOrder() { }

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

            if (Payments != null && that.Payments != null)
            {
                if (!Payments.SequenceEqual(that.Payments)) return false;
            }
            else if (Payments != that.Payments) return false;

            if (ShoppingCart != null && that.ShoppingCart != null)
            {
                if (!ShoppingCart.SequenceEqual(that.ShoppingCart)) return false;
            }
            else if (ShoppingCart != that.ShoppingCart) return false;

            if (!object.Equals(Device, that.Device)) return false;
            if (!object.Equals(NavigationInfo, that.NavigationInfo)) return false;

            if (!object.Equals(Analyze, that.Analyze)) return false;

            if (!object.Equals(Travel, that.Travel)) return false;

            if (!object.Equals(PurchaseAt, that.PurchaseAt)) return false;
            if (!object.Equals(MessagesExchanged, that.MessagesExchanged)) return false;
            if (!object.Equals(FirstMessage, that.FirstMessage)) return false;

            if (BureauxQueries != null && that.BureauxQueries != null)
            {
                if (BureauxQueries.Count != that.BureauxQueries.Count) return false;
            }
            else if (BureauxQueries != that.BureauxQueries) return false;

            if (TriggeredRules != null && that.TriggeredRules != null)
            {
                if (TriggeredRules.Count != that.TriggeredRules.Count) return false;
            }
            else if (TriggeredRules != that.TriggeredRules) return false;

            if (TriggeredDecisionList != null && that.TriggeredDecisionList != null)
            {
                if (TriggeredDecisionList.Count != that.TriggeredDecisionList.Count) return false;
            }
            else if (TriggeredDecisionList != that.TriggeredDecisionList) return false;

            if (!object.Equals(Seller, that.Seller)) return false;

            if (!object.Equals(Recurring, that.Recurring)) return false;
            if (!object.Equals(RiskLevel, that.RiskLevel)) return false;
            if (!object.Equals(SalesChannel, that.SalesChannel)) return false;
            if (!object.Equals(Scheduled, that.Scheduled)) return false;
            if (!object.Equals(Hotel, that.Hotel)) return false;
            if (Events != null && that.Events != null)
            {
                if (!Events.SequenceEqual(that.Events)) return false;
            }
            else if (Events != that.Events) return false;
            if (!object.Equals(Vehicles, that.Vehicles)) return false;
            if (!object.Equals(Delivery, that.Delivery)) return false;
            if (!object.Equals(PointOfSale, that.PointOfSale)) return false;
            if (!object.Equals(Agent, that.Agent)) return false;
            if (!object.Equals(Tenant, that.Tenant)) return false;
            if (!object.Equals(EventType, that.EventType)) return false;
            if (!object.Equals(EventDetails, that.EventDetails)) return false;
            if (!object.Equals(OriginAccount, that.OriginAccount)) return false;

            if (DestinationAccounts != null && that.DestinationAccounts != null)
            {
                if (!DestinationAccounts.SequenceEqual(that.DestinationAccounts)) return false;
            }
            else if (DestinationAccounts != that.DestinationAccounts) return false;

            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        [OnSerializing]
        internal void OnSerializedMethod(StreamingContext context)
        {
            if (ShoppingCart != null && Travel != null)
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
            this.Score = response.Score;
            this.NavigationInfo = response.NavigationInfo;
            this.Geolocation = response.Geolocation;
            this.Timestamp = response.Timestamp;
            this.BureauxQueries = response.BureauxQueries;
            this.TriggeredRules = response.TriggeredRules;
            this.TriggeredDecisionList = response.TriggeredDecisionList;
        }
    }
}

