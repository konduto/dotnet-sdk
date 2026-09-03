using Newtonsoft.Json;
using System.Collections.Generic;

namespace KdtSdk.Models
{
    public class KondutoBureauxQueriesResponse
    {
        [JsonExtensionData]
        public Dictionary<string, object> Values { get; set; }

        public override bool Equals(object o)
        {
            if (this == o) return true;
            if (!(o is KondutoBureauxQueriesResponse)) return false;

            KondutoBureauxQueriesResponse that = o as KondutoBureauxQueriesResponse;

            if (Values != null && that.Values != null)
            {
                if (Values.Count != that.Values.Count) return false;
                foreach (var kvp in Values)
                {
                    if (!that.Values.TryGetValue(kvp.Key, out var thatVal))
                        return false;
                    string s1 = kvp.Value is Newtonsoft.Json.Linq.JValue jv1 ? jv1.Value?.ToString() : kvp.Value?.ToString();
                    string s2 = thatVal is Newtonsoft.Json.Linq.JValue jv2 ? jv2.Value?.ToString() : thatVal?.ToString();

                    if (System.DateTime.TryParse(s1, out var dt1) && System.DateTime.TryParse(s2, out var dt2))
                    {
                        if (dt1.ToUniversalTime() != dt2.ToUniversalTime())
                            return false;
                    }
                    else if (!string.Equals(s1, s2, System.StringComparison.OrdinalIgnoreCase))
                    {
                        return false;
                    }
                }
                return true;
            }
            return Values == that.Values;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
