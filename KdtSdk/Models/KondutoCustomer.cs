using System;
using Newtonsoft.Json;

namespace KdtSdk.Models
{
    public class KondutoCustomer : KondutoModel
    {
        /// Requireds
        [JsonProperty("id", Required = Required.Always)]
        public String Id{ get; set;}
        [JsonProperty("name", Required = Required.Always)]
	    public String Name{ get; set;}
        [JsonProperty("email", Required = Required.Always)]
	    public String Email{ get; set;}

        [JsonProperty("tax_id", Required = Required.Always)]
        public String TaxId { get; set; }
        [JsonProperty("phone1", Required = Required.Always)]
        public String Phone1 { get; set; }
        [JsonProperty("phone2")]
        public String Phone2 { get; set; }
        
	    [JsonProperty("vip")] 
        public Boolean IsVip { get; set;}
        [JsonProperty("new")]
	    public Boolean IsNew { get; set;}

        /// <summary>
        /// YYYY-MM-DD
        /// </summary>
        [JsonProperty("created_at")]
        public String CreatedAt { get; set; }

        /// <summary>
        /// YYYY-MM-DD
        /// </summary>
        [JsonProperty("dob")]
        public String DOB { get; set; }

        [JsonProperty("document_type")]
        public String DocumentType { get; set; }

        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public String Type { get; set; }

        [JsonProperty("risk_level", NullValueHandling = NullValueHandling.Ignore)]
        public String RiskLevel { get; set; }

        [JsonProperty("risk_score", NullValueHandling = NullValueHandling.Ignore)]
        public Double? RiskScore { get; set; }

        [JsonProperty("mother_name", NullValueHandling = NullValueHandling.Ignore)]
        public String MotherName { get; set; }

	    /* Constructors */

	    public KondutoCustomer() { }

	    public override bool Equals(Object o) 
        {
		    
            if (this == o) return true;
		    if (!(o is KondutoCustomer)) return false;

            KondutoCustomer that = o as KondutoCustomer;

		    // required
            if (!object.Equals(Id, that.Id)) return false;
		    if (!object.Equals(Email, that.Email)) return false;
            if (!object.Equals(Name, that.Name)) return false;

		    // optional
            if (!object.Equals(IsNew, that.IsNew)) return false;
            if (!object.Equals(IsVip, that.IsVip)) return false;
            if (!object.Equals(Phone1, that.Phone1)) return false;
            if (!object.Equals(Phone2, that.Phone2)) return false;
            if (!object.Equals(TaxId, that.TaxId)) return false;
            if (!object.Equals(CreatedAt, that.CreatedAt)) return false;
            if (!object.Equals(DOB, that.DOB)) return false;
            if (!object.Equals(DocumentType, that.DocumentType)) return false;
            if (!object.Equals(Type, that.Type)) return false;
            if (!object.Equals(RiskLevel, that.RiskLevel)) return false;
            if (!object.Equals(RiskScore, that.RiskScore)) return false;
            if (!object.Equals(MotherName, that.MotherName)) return false;

		    return true;
	    }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
