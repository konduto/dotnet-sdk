using KdtSdk.Exceptions;
using KdtSdk.Models;
using KdtSdk.Utils;
using KdtTests.Factories;
using System;
using Xunit;
using KdtTests.Properties;

namespace KdtTests.Models
{
    public class KondutoBoletoPaymentTest
    {
        [Fact]
        public void SerializeTest()
        {
            String expectedJSON = KondutoUtils.GetFirstJArrayElement(Resources.Load("payments"));
            String actualJSON = null;
            KondutoCreditCardPayment payment = KondutoPaymentFactory.CreateCreditCardPayment();

            try
            {
                actualJSON = payment.ToJson();
            }
            catch (KondutoInvalidEntityException e)
            {
                Assert.True(false, "address should be valid");
            }

            Assert.Equal(expectedJSON, actualJSON);

            KondutoCreditCardPayment paymentFromJSON = KondutoModel.FromJson<KondutoCreditCardPayment>(expectedJSON);
            Assert.Equal(payment, paymentFromJSON);
        }
    }
}
