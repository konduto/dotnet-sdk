using KdtSdk.Models;
using System.Collections.Generic;

namespace KdtTests.Factories
{
    public class KondutoTriggeredRulesFactory
    {
        public static List<KondutoTriggeredRules> Create()
        {
            return new List<KondutoTriggeredRules> {
                new KondutoTriggeredRules
                {
                    Name = "Cartao com BIN do Canada",
                    Decision = KondutoTriggeredDecision.decline
                }
            };
        }
    }
}
