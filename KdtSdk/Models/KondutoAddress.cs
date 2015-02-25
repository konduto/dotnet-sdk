using System;

namespace KdtSdk.Models
{
    /// <summary>
    /// * Address model.
    /// @see <a href="http://docs.konduto.com">Konduto API Spec</a>
    /// </summary>
    public class KondutoAddress : KondutoModel
    {
        #region Attributes

        public String Name { get; set; }
        public String Address1 { get; set; }
        public String Address2 { get; set; }
        public String Zip { get; set; }
        public String City { get; set; }
        public String State { get; set; }
        public String Country { get; set; }

        #endregion

	    /// <summary>
	    /// Constructor
	    /// </summary>
	    public KondutoAddress() 
        {
            this.Name = null;
            this.Address1 = null;
            this.Address2 = null;
            this.Zip = null;
            this.City = null;
            this.State = null;
            this.Country = null;
        }

        public KondutoAddress withName(string name)
        {
            this.Name = name;
            return this;
        }

	    public override bool Equals(Object o) {
		    if (this == o) return true;

		    if (!(o is KondutoAddress)) return false;

		    KondutoAddress that = o as KondutoAddress;

            if (!object.Equals(Address1, that.Address1)) return false;
            if (!object.Equals(Address2, that.Address2)) return false;
            if (!object.Equals(City, that.City)) return false;

            if (!object.Equals(Country, that.Country)) return false;
            if (!object.Equals(Name, that.Name)) return false;
            if (!object.Equals(State, that.State)) return false;
            if (!object.Equals(Zip, that.Zip)) return false;

		    return true;
	    }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
