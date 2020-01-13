using Newtonsoft.Json;
using System.Collections.Generic;

namespace KdtSdk.Models
{
    public class KondutoBureauxQueriesResponse
    {
        [JsonExtensionData]
        public Dictionary<string, object> Values { get; set; }
    }
}
