using KdtSdk.Exceptions;
using KdtSdk.Models;
using KdtSdk.Utils;
using KdtTests.Factories;
using Newtonsoft.Json.Linq;
using System;
using Xunit;
using KdtTests.Properties;

namespace KdtTests.Models
{
    public class KondutoPaymentTest
    {
        [Fact]
        public void CreditSerializeTest()
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

        [Fact]
        public void BoletoSerializeTest()
        {
            JArray a = JArray.Parse(Resources.Load("payments"));
            String expectedJSON = a.Last.ToString();
            String actualJSON = null;
            KondutoBoletoPayment payment = KondutoPaymentFactory.CreateBoletoPayment();

            try
            {
                actualJSON = payment.ToJson();
            }
            catch (KondutoInvalidEntityException e)
            {
                Assert.True(false, "payment should be valid");
            }

            Assert.Equal(expectedJSON, actualJSON);

            KondutoBoletoPayment paymentFromJSON = KondutoModel.FromJson<KondutoBoletoPayment>(expectedJSON);
            Assert.Equal(payment, paymentFromJSON);
        }

        [Fact]
        public void DebitSerializeTest()
        {
            JArray a = JArray.Parse(Resources.Load("payments"));
            String expectedJSON = a[1].ToString();
            String actualJSON = null;
            KondutoDebitPayment payment = KondutoPaymentFactory.CreateDebitPayment();

            try
            {
                actualJSON = payment.ToJson();
            }
            catch (KondutoInvalidEntityException e)
            {
                Assert.True(false, "payment should be valid");
            }

            Assert.Equal(expectedJSON, actualJSON);

            KondutoDebitPayment paymentFromJSON = KondutoModel.FromJson<KondutoDebitPayment>(expectedJSON);
            Assert.Equal(payment, paymentFromJSON);
        }

        [Fact]
        public void TransferSerializeTest()
        {
            JArray a = JArray.Parse(Resources.Load("payments"));
            String expectedJSON = a[3].ToString();
            String actualJSON = null;
            KondutoTransferPayment payment = KondutoPaymentFactory.CreateTransferPayment();

            try
            {
                actualJSON = payment.ToJson();
            }
            catch (KondutoInvalidEntityException e)
            {
                Assert.True(false, "payment should be valid");
            }

            Assert.Equal(expectedJSON, actualJSON);

            KondutoTransferPayment paymentFromJSON = KondutoModel.FromJson<KondutoTransferPayment>(expectedJSON);
            Assert.Equal(payment, paymentFromJSON);
        }

        [Fact]
        public void VoucherSerializeTest()
        {
            JArray a = JArray.Parse(Resources.Load("payments"));
            String expectedJSON = a[2].ToString();
            KondutoVoucherPayment payment = KondutoPaymentFactory.CreateVoucherPayment();

            var actualJSON = payment.ToJson();
            Assert.Equal(expectedJSON, actualJSON);
            KondutoVoucherPayment paymentFromJSON = KondutoModel.FromJson<KondutoVoucherPayment>(expectedJSON);
            Assert.Equal(payment, paymentFromJSON);
        }
    }
}