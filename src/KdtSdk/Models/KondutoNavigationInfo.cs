using System;
using Newtonsoft.Json;

namespace KdtSdk.Models
{
    public class KondutoNavigationInfo : KondutoModel
    {
        /* all times in minutes */
        [JsonProperty("session_time")]
	    public Double SessionTime { get; set; }

        [JsonProperty("referrer")]
	    public String Referrer { get; set; }

	    [JsonProperty("time_site_1d")]
        public Double TimeOnSiteToday { get; set; }

	    [JsonProperty("new_accounts_1d")]
        public int AccountsCreatedToday { get; set; }

	    [JsonProperty("password_resets_1d")]
        public int PasswordResetsToday { get; set; }

	    [JsonProperty("sales_declined_1d")]
        public int SalesDeclinedToday { get; set; }

	    [JsonProperty("sessions_1d")]
        public int SessionsToday { get; set; }

	    [JsonProperty("time_site_7d")]
        public Double TimeOnSiteSinceLastWeek { get; set; }

	    [JsonProperty("new_accounts_7d")]
        public int AccountsCreatedSinceLastWeek { get; set; }

	    [JsonProperty("time_per_page_7d")]
        public Double TimePerPageSinceLastWeek { get; set; }

	    [JsonProperty("password_resets_7d")]
        public int PasswordResetsSinceLastWeek { get; set; }

	    [JsonProperty("checkout_count_7d")]
        public int CheckoutPageViewsSinceLastWeek { get; set; }

	    [JsonProperty("sales_declined_7d")]
        public int SalesDeclinedSinceLastWeek { get; set; }

	    [JsonProperty("sessions_7d")]
        public int SessionsSinceLastWeek { get; set; }

        [JsonProperty("time_since_last_sale")]
        public Double TimeSinceLastSale { get; set; }

	    public override bool Equals(Object o) 
        {
		    if (this == o) return true;
		    if (!(o is KondutoNavigationInfo)) return false;

            KondutoNavigationInfo that = o as KondutoNavigationInfo;

            if (!object.Equals(AccountsCreatedSinceLastWeek, that.AccountsCreatedSinceLastWeek)) return false;
            if (!object.Equals(AccountsCreatedToday, that.AccountsCreatedToday)) return false;
            if (!object.Equals(CheckoutPageViewsSinceLastWeek, that.CheckoutPageViewsSinceLastWeek)) return false;
            if (!object.Equals(PasswordResetsSinceLastWeek, that.PasswordResetsSinceLastWeek)) return false;
            if (!object.Equals(PasswordResetsToday, that.PasswordResetsToday)) return false;
            if (!object.Equals(Referrer, that.Referrer)) return false;
            if (!object.Equals(SalesDeclinedSinceLastWeek, that.SalesDeclinedSinceLastWeek)) return false;
            if (!object.Equals(SalesDeclinedToday, that.SalesDeclinedToday)) return false;
            if (!object.Equals(SessionTime, that.SessionTime)) return false;
            if (!object.Equals(SessionsSinceLastWeek, that.SessionsSinceLastWeek)) return false;
            if (!object.Equals(SessionsToday, that.SessionsToday)) return false;
            if (!object.Equals(TimeOnSiteSinceLastWeek, that.TimeOnSiteSinceLastWeek)) return false;
            if (!object.Equals(TimeOnSiteToday, that.TimeOnSiteToday)) return false;
            if (!object.Equals(TimePerPageSinceLastWeek, that.TimePerPageSinceLastWeek)) return false;
            if (!object.Equals(TimeSinceLastSale, that.TimeSinceLastSale)) return false;

		    return true;
	    }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
