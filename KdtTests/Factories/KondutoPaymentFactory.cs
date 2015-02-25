using KdtSdk.Models;
using System.Collections.Generic;

namespace KdtTests.Factories
{
    public class KondutoPaymentFactory
    {
        public static KondutoCreditCardPayment CreateCreditCardPayment()
        {
            return new KondutoCreditCardPayment
            {
                Bin = "123",
                ExpirationDate = "012014",
                Last4 = "1234",
                Status = KondutoCreditCardPaymentStatus.approved,
                Type = KondutoPaymentType.credit
            };
        }

        public static List<KondutoPayment> CreatePayments()
        {
            return new List<KondutoPayment> { CreateCreditCardPayment() };
        }
    }
}
