using KdtSdk.Exceptions;
using KdtSdk.Models;
using KdtSdk.Utils;
using KdtTests.Factories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using System;

namespace KdtTests.Models
{
    [TestClass]
    public class KondutoPaymentTest
    {
        [TestMethod]
        public void CreditSerializeTest()
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

        [TestMethod]
        public void BoletoSerializeTest()
        {
            JArray a = JArray.Parse(Properties.Resources.payments);
            String expectedJSON = a.Last.ToString();
            String actualJSON = null;
            KondutoBoletoPayment payment = KondutoPaymentFactory.CreateBoletoPayment();

            try
            {
                actualJSON = payment.ToJson();
            }
            catch (KondutoInvalidEntityException e)
            {
                Assert.Fail("address should be valid");
            }

            Assert.AreEqual(expectedJSON, actualJSON, "address serialization failed");

            KondutoBoletoPayment paymentFromJSON = KondutoModel.FromJson<KondutoBoletoPayment>(expectedJSON);
            Assert.AreEqual(payment, paymentFromJSON, "address deserialization failed");
        }


    }
}
