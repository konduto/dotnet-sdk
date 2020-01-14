using KdtSdk.Models;
using System.Collections.Generic;

namespace KdtTests.Factories
{
    public class KondutoBureauxQueriesFactory
    {
        public static List<KondutoBureauxQueries> Create()
        {
            return new List<KondutoBureauxQueries> { CreateEmailAge() };
        }

        public static KondutoBureauxQueries CreateEmailAge()
        {

            Dictionary<string, object> values = new Dictionary<string, object>();
            return new KondutoBureauxQueries
            {
                Service = "emailage",
                Response = new KondutoBureauxQueriesResponse()
                {
                    Values = CreateValuesDictionaryEmailAge()
                }
            };
        }

        private static Dictionary<string, object> CreateValuesDictionaryEmailAge()
        {
            Dictionary<string, object> values = new Dictionary<string, object>();
            values.Add("advice", "Lower Fraud Risk");
            values.Add("email", "adriano.0123456abc@gmail.com");
            values.Add("email_country", "US");
            values.Add("email_domain", "gmail.com");
            values.Add("email_domain_age", "1995-08-13T04:00:00Z");
            values.Add("email_domain_category", "Webmail");
            values.Add("email_domain_company", "Google");
            values.Add("email_domain_country", "United States");
            values.Add("email_domain_exists", true);
            values.Add("email_domain_is_corporate", false);
            values.Add("email_domain_other_info", "Valid Webmail Domain from United States");
            values.Add("email_domain_risk_level", "Moderate");
            values.Add("email_domain_risky_country", false);
            values.Add("email_exists", true);
            values.Add("email_first_seen_at", "2011-07-06T01:00:35Z");
            values.Add("email_first_seen_days", "2750 ");
            values.Add("email_last_seen_at", "2016-06-09T02:12:56Z");
            values.Add("email_status", "Verified");
            values.Add("email_total_hits", 1);
            values.Add("email_unique_hits", 1);
            values.Add("fraud_risk", "050 Very Low");
            values.Add("gender", "M");
            values.Add("last_flagged_at", "2015-09-16T05:42:58Z");
            values.Add("location", "Sao Paulo");
            values.Add("name", "Adriano Oliveira");
            values.Add("reason_for_advice", "Good Level 1");
            values.Add("risk_band", "Fraud Score 11 to 300");

            return values;
        }
    }
}
