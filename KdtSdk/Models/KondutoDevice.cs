using System;
using Newtonsoft.Json;

namespace KdtSdk.Models
{
    public class KondutoDevice : KondutoModel
    {
        [JsonProperty("user_id")]
        public String UserId { get; set; }
        [JsonProperty("fingerprint")]
        public String Fingerprint { get; set; }
        [JsonProperty("platform")]
        public String Platform { get; set; }
        [JsonProperty("browser")]
        public String Browser { get; set; }
        [JsonProperty("language")]
        public String Language { get; set; }
        [JsonProperty("timezone")]
        public String Timezone { get; set; }
        [JsonProperty("cookie")]
        public bool Cookie { get; set; }
        [JsonProperty("javascript")]
        public bool Javascript { get; set; }
        [JsonProperty("flash")]
        public bool Flash { get; set; }
        [JsonProperty("ip")]
        public String Ip { get; set; }

	    public KondutoDevice(){}

	    public override bool Equals(Object o) 
        {
		    if (this == o) return true;
		    if (!(o is KondutoDevice)) return false;

            KondutoDevice that = o as KondutoDevice;

            if (!object.Equals(Cookie, that.Cookie)) return false;
            if (!object.Equals(Flash, that.Flash)) return false;
            if (!object.Equals(Javascript, that.Javascript)) return false;
            if (!object.Equals(Browser, that.Browser)) return false;
            if (!object.Equals(Fingerprint, that.Fingerprint)) return false;
            if (!object.Equals(Ip, that.Ip)) return false;
            if (!object.Equals(Language, that.Language)) return false;
            if (!object.Equals(Platform, that.Platform)) return false;
            if (!object.Equals(Timezone, that.Timezone)) return false;
            if (!object.Equals(UserId, that.UserId)) return false;

		    return true;
	    }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}