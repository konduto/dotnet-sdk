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
                Bin = "1234",
                ExpirationDate = "010214",
                Last4 = "1234",
                Status = KondutoCreditCardPaymentStatus.approved,
                Type = KondutoPaymentType.credit
            };
        }

        public static KondutoBoletoPayment CreateBoletoPayment() 
        {
            return new KondutoBoletoPayment
            {
                Type = KondutoPaymentType.boleto,
                ExpirationDate = "010214"
            };
        }

        public static List<KondutoPayment> CreatePayments()
        {
            return new List<KondutoPayment> { CreateCreditCardPayment() };
        }
    }
}
