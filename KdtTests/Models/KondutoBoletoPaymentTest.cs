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
            KondutoCreditCardPayment payment = KondutoPaymentFactory.CreateCreditCardPayment();

            var actualJSON = payment.ToJson();
            Assert.Equal(expectedJSON, actualJSON);
            KondutoCreditCardPayment paymentFromJSON = KondutoModel.FromJson<KondutoCreditCardPayment>(expectedJSON);
            Assert.Equal(payment, paymentFromJSON);
        }
    }
}
