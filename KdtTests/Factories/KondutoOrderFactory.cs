using KdtSdk.Models;

namespace KdtTests.Factories
{
    public class KondutoOrderFactory
    {
        public static KondutoOrder completeOrder()
        {
            return new KondutoOrder
            {
                Id = "1",
                TotalAmount = 120.5,
                Customer = KondutoCustomerFactory.CompleteCustomer(),

                Visitor = "a9031kdlas",
                Currency = "USD",
                Installments = 1,
                Ip = "192.168.0.1",
                ShippingAmount = 5.0,
                TaxAmount = 3.0,
                Timestamp = 123123123123L,

                ShippingAddress = KondutoAddressFactory.Create(),
                BillingAddress = KondutoAddressFactory.Create(),
                Geolocation = KondutoGeolocationFactory.Create(),

                Recommendation = KondutoRecommendation.approve,
                Payments = KondutoPaymentFactory.CreatePayments(),
                ShoppingCart = KondutoItemFactory.CreateShoppingCart(),

                Analyze = true
            };
        }

        public static KondutoOrder basicOrder()
        {
            return new KondutoOrder
            {
                Id = "1",
                TotalAmount = 120.5,
                Customer = KondutoCustomerFactory.BasicCustomer(),
                Recommendation = KondutoRecommendation.none,
                Analyze = true
            };
        }
    }
}
