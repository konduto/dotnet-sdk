using System;
using Newtonsoft.Json;
using KdtSdk.Exceptions;
using KdtSdk.Utils;

namespace KdtSdk.Models
{
    public class KondutoModel
    {
        private String error = null;

        public String GetError()
        {
            return error;
        }

        public String ToJson()
        {
            JsonSerializerSettings s = new JsonSerializerSettings();
            s.MissingMemberHandling = MissingMemberHandling.Ignore;
            s.NullValueHandling = NullValueHandling.Ignore;
            s.MissingMemberHandling = MissingMemberHandling.Ignore;
            s.TypeNameHandling = TypeNameHandling.Auto;
            
            try
            {
                JsonConvert.SerializeObject(this, Formatting.Indented, s);
                return JsonConvert.SerializeObject(this, Formatting.Indented);
            }
            catch (JsonSerializationException e)
            {
                throw new KondutoInvalidEntityException(this);
            }
            catch (Exception e)
            {
                throw new KondutoInvalidEntityException(this);
            }
        }

        public static T FromJson<T>(String jsonObject)
        {
            return JsonConvert.DeserializeObject<T>(jsonObject, new KondutoUtils.PaymentConverter());
        }

        /// <summary>
        /// Validation method 
        /// </summary>
        /// <returns>whether this KondutoModel instance is valid or not.</returns>
        public bool IsValid()
        {
            error = null;

            try
            {
                JsonConvert.SerializeObject(this, Formatting.Indented);
            }
            catch (Exception e)
            {
                this.error = e.Message;
                return false;
            }
            
            return true;
		}
    }
}
