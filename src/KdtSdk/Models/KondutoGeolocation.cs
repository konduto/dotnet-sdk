using System;

namespace KdtSdk.Models
{
    /// <summary>
    /// Geolocation model.
    /// @see <a href="http://docs.konduto.com">Konduto API Spec</a>
    /// </summary>
    public class KondutoGeolocation : KondutoModel
    {
        /* Attributes */
	    public String City {get; set;}
	    public String State {get; set;}
	    public String Country {get; set;}

	    /* Constructors */
	    public KondutoGeolocation() { }

	    public override bool Equals(Object o) 
        {
		    if (this == o) return true;

		    if (!(o is KondutoGeolocation)) return false;

            KondutoGeolocation that = o as KondutoGeolocation;

            if (!object.Equals(City, that.City)) return false;
            if (!object.Equals(Country, that.Country)) return false;
            if (!object.Equals(State, that.State)) return false;

		    return true;
	    }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}