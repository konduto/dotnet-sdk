using KdtSdk.Models;
using System.Collections.Generic;

namespace KdtTests.Factories
{
    public class KondutoTriggeredDecisionListFactory
    {
        public static List<KondutoTriggeredDecisionList> Create()
        {
            return new List<KondutoTriggeredDecisionList> {
                    new KondutoTriggeredDecisionList
                    {
                        Type = "zip",
                        Trigger = "shipping_zip",
                        Decision = KondutoTriggeredDecision.review
                    },
                    new KondutoTriggeredDecisionList
                    {
                        Type = "email",
                        Trigger = "email",
                        Decision = KondutoTriggeredDecision.decline
                    }
            };
        }
    }
}
