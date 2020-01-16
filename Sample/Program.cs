using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using KdtSdk;
using KdtSdk.Models;

namespace Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start Konduto SDK");
            Konduto konduto = new Konduto("T1234567890ABCDEFGHIJ");
            KondutoOrder order = new KondutoOrder
            {
                Id = "orderID",
                Visitor = "",
                TotalAmount = 123.4,
                ShippingAmount = 12.23,
                TaxAmount = 1.23,
                Currency = "BRL",
                Installments = 3,
                Ip = "192.0.0.1",
                Analyze = true,
                Customer = new KondutoCustomer
                {
                    Id = "DotnetCustomer",
                    Name = "Bill Gates",
                    Email = "bill@microsoft.com",
                    TaxId = "12345678990",
                    Phone1 = "(11)912345678",
                    Phone2 = "(12)998765432",
                    IsNew = true,
                    IsVip = true
                },
                Payments = new List<KondutoPayment> {
                    new KondutoCreditCardPayment {
                        Status = KondutoCreditCardPaymentStatus.approved,
                        Bin = "123445",
                        Last4 = "1234",
                        ExpirationDate = "022020"
                    }
                }
            };
            if (!order.IsValid())
            {
                Console.WriteLine(order.GetError());
            }
            try
            {
                konduto.Analyze(order);

                Console.WriteLine("Order Recommendation: " + order.Recommendation);
                Console.WriteLine("Order Score: " + order.Score);

                if(order.TriggeredRules != null && order.TriggeredRules.Count > 0)
                {
                    Console.WriteLine("Triggered Rules:");
                    foreach (KondutoTriggeredRules TriggeredRule in order.TriggeredRules)
                    {
                        Console.WriteLine(" " + TriggeredRule.Name);
                    }
                }
                else
                {
                    Console.WriteLine("Order has no triggered rules");
                }

                if (order.TriggeredDecisionList != null && order.TriggeredDecisionList.Count > 0)
                {
                    Console.WriteLine("Triggered DecisionList:");
                    foreach (KondutoTriggeredDecisionList TriggeredDecisionList in order.TriggeredDecisionList)
                    {
                        Console.WriteLine(" " + TriggeredDecisionList.Type + " Decision:" + TriggeredDecisionList.Decision);
                    }
                }
                else
                {
                    Console.WriteLine("Order has no triggered decision list");
                }

                if (order.BureauxQueries != null && order.BureauxQueries.Count > 0)
                {
                    Console.WriteLine("Bureaux Queries:");
                    foreach (KondutoBureauxQueries BureauxQuery in order.BureauxQueries)
                    {
                        Console.WriteLine(" " + BureauxQuery.Service + " response:" + BureauxQuery.Response);
                    }
                }
                else
                {
                    Console.WriteLine("Order has no bureaux queries");
                }

                Console.WriteLine("Order JSON: " + JsonConvert.SerializeObject(order));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            _ = Console.Read();
        }
    }
}
