using KdtSdk.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;


using Newtonsoft.Json.Converters;

namespace KdtSdk.Utils
{
    public class KondutoUtils
    {
        public static T LoadJson<T>(String json) where T : KondutoModel
        {
            return JsonConvert.DeserializeObject<T>(json, new PaymentConverter());
        }

        public static String GetFirstJArrayElement(String json)
        {
            JArray a = JArray.Parse(json);
            return a.First.ToString();
        }

        public class PaymentConverter : JsonCreationConverter<KondutoPayment>
        {
            protected override KondutoPayment Create(Type objectType, JObject jObject)
            {
                if (GetPaymentType("type", jObject) == KondutoPaymentType.boleto)
                    return new KondutoBoletoPayment();

                if (GetPaymentType("type", jObject) == KondutoPaymentType.credit)
                    return new KondutoCreditCardPayment();

                if (GetPaymentType("type", jObject) == KondutoPaymentType.debit)
                    return new KondutoDebitPayment();

                if (GetPaymentType("type", jObject) == KondutoPaymentType.transfer)
                    return new KondutoTransferPayment();

                if (GetPaymentType("type", jObject) == KondutoPaymentType.voucher)
                    return new KondutoVoucherPayment();

                return null;
            }

            private KondutoPaymentType GetPaymentType(string fieldName, JObject jObject)
            {
                if (jObject[fieldName] != null)
                {
                    if (jObject[fieldName].ToString() == "boleto")
                        return KondutoPaymentType.boleto;

                    if (jObject[fieldName].ToString() == "credit")
                        return KondutoPaymentType.credit;

                    if (jObject[fieldName].ToString() == "debit")
                        return KondutoPaymentType.debit;

                    if (jObject[fieldName].ToString() == "transfer")
                        return KondutoPaymentType.transfer;

                    if (jObject[fieldName].ToString() == "voucher")
                        return KondutoPaymentType.voucher;
                }

                return KondutoPaymentType.credit;
            }
        }
    }

    public abstract class JsonCreationConverter<T> : JsonConverter
    {
        /// <summary>
        /// Create an instance of objectType, based properties in the JSON object
        /// </summary>
        /// <param name="objectType">type of object expected</param>
        /// <param name="jObject">
        /// contents of JSON object that will be deserialized
        /// </param>
        /// <returns></returns>
        protected abstract T Create(Type objectType, JObject jObject);

        public override bool CanConvert(Type objectType)
        {
            return typeof(T).IsAssignableFrom(objectType);
        }

        public override object ReadJson(JsonReader reader,
                                        Type objectType,
                                         object existingValue,
                                         JsonSerializer serializer)
        {
            // Load JObject from stream
            JObject jObject = JObject.Load(reader);

            // Create target object based on JObject
            T target = Create(objectType, jObject);

            // Populate the object properties
            serializer.Populate(jObject.CreateReader(), target);

            return target;
        }

        public override void WriteJson(JsonWriter writer,
                                       object value,
                                       JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }

}
