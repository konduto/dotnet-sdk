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
                Assert.Fail("payment should be valid");
            }

            Assert.AreEqual(expectedJSON, actualJSON, "address serialization failed");

            KondutoBoletoPayment paymentFromJSON = KondutoModel.FromJson<KondutoBoletoPayment>(expectedJSON);
            Assert.AreEqual(payment, paymentFromJSON, "payment deserialization failed");
        }

        [TestMethod]
        public void DebitSerializeTest()
        {
            JArray a = JArray.Parse(Properties.Resources.payments);
            String expectedJSON = a[1].ToString();
            String actualJSON = null;
            KondutoDebitPayment payment = KondutoPaymentFactory.CreateDebitPayment();

            try
            {
                actualJSON = payment.ToJson();
            }
            catch (KondutoInvalidEntityException e)
            {
                Assert.Fail("payment should be valid");
            }

            Assert.AreEqual(expectedJSON, actualJSON, "address serialization failed");

            KondutoDebitPayment paymentFromJSON = KondutoModel.FromJson<KondutoDebitPayment>(expectedJSON);
            Assert.AreEqual(payment, paymentFromJSON, "payment deserialization failed");
        }

        [TestMethod]
        public void TransferSerializeTest()
        {
            JArray a = JArray.Parse(Properties.Resources.payments);
            String expectedJSON = a[3].ToString();
            String actualJSON = null;
            KondutoTransferPayment payment = KondutoPaymentFactory.CreateTransferPayment();

            try
            {
                actualJSON = payment.ToJson();
            }
            catch (KondutoInvalidEntityException e)
            {
                Assert.Fail("payment should be valid");
            }

            Assert.AreEqual(expectedJSON, actualJSON, "address serialization failed");

            KondutoTransferPayment paymentFromJSON = KondutoModel.FromJson<KondutoTransferPayment>(expectedJSON);
            Assert.AreEqual(payment, paymentFromJSON, "payment deserialization failed");
        }

        [TestMethod]
        public void VoucherSerializeTest()
        {
            JArray a = JArray.Parse(Properties.Resources.payments);
            String expectedJSON = a[2].ToString();
            String actualJSON = null;
            KondutoVoucherPayment payment = KondutoPaymentFactory.CreateVoucherPayment();

            try
            {
                actualJSON = payment.ToJson();
            }
            catch (KondutoInvalidEntityException e)
            {
                Assert.Fail("payment should be valid");
            }

            Assert.AreEqual(expectedJSON, actualJSON, "address serialization failed");

            KondutoVoucherPayment paymentFromJSON = KondutoModel.FromJson<KondutoVoucherPayment>(expectedJSON);
            Assert.AreEqual(payment, paymentFromJSON, "payment deserialization failed");
        }
    }
}