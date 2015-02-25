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

        public class PaymentConverter : CustomCreationConverter<KondutoPayment>
        {
            public override KondutoPayment Create(Type objectType)
            {
                return new KondutoCreditCardPayment();
            }
        }
    }
}
