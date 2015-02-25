using KdtSdk.Exceptions;
using KdtSdk.Models;
using KdtSdk.Utils;
using KdtTests.Factories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace KdtTests.Models
{
    [TestClass]
    public class KondutoCreditCardPaymentTest
    {
        [TestMethod]
        public void SerializeTest()
        {
            String expectedJSON = KondutoUtils.GetFirstJArrayElement(Properties.Resources.payments);
            String actualJSON = null;
            KondutoCreditCardPayment payment = KondutoPaymentFactory.CreateCreditCardPayment();

            try
            {
                actualJSON = payment.ToJson();
            }
            catch (KondutoInvalidEntityException e)
            {
                Assert.Fail("address should be valid");
            }

            Assert.AreEqual(expectedJSON, actualJSON, "address serialization failed");

            KondutoCreditCardPayment paymentFromJSON = KondutoModel.FromJson<KondutoCreditCardPayment>(expectedJSON);
            Assert.AreEqual(payment, paymentFromJSON, "address deserialization failed");
        }
    }
}
