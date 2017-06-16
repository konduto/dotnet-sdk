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
            KondutoCreditCardPayment payment = KondutoPaymentFactory.CreateCreditCardPayment();
            
            var actualJSON = payment.ToJson();
            Assert.Equal(expectedJSON, actualJSON);
            KondutoCreditCardPayment paymentFromJSON = KondutoModel.FromJson<KondutoCreditCardPayment>(expectedJSON);
            Assert.Equal(payment, paymentFromJSON);
        }

        [Fact]
        public void BoletoSerializeTest()
        {
            JArray a = JArray.Parse(Resources.Load("payments"));
            String expectedJSON = a.Last.ToString();
            KondutoBoletoPayment payment = KondutoPaymentFactory.CreateBoletoPayment();

            var actualJSON = payment.ToJson();
            Assert.Equal(expectedJSON, actualJSON);
            KondutoBoletoPayment paymentFromJSON = KondutoModel.FromJson<KondutoBoletoPayment>(expectedJSON);
            Assert.Equal(payment, paymentFromJSON);
        }

        [Fact]
        public void DebitSerializeTest()
        {
            JArray a = JArray.Parse(Resources.Load("payments"));
            String expectedJSON = a[1].ToString();
            KondutoDebitPayment payment = KondutoPaymentFactory.CreateDebitPayment();

            var actualJSON = payment.ToJson();
            Assert.Equal(expectedJSON, actualJSON);
            KondutoDebitPayment paymentFromJSON = KondutoModel.FromJson<KondutoDebitPayment>(expectedJSON);
            Assert.Equal(payment, paymentFromJSON);
        }

        [Fact]
        public void TransferSerializeTest()
        {
            JArray a = JArray.Parse(Resources.Load("payments"));
            String expectedJSON = a[3].ToString();
            KondutoTransferPayment payment = KondutoPaymentFactory.CreateTransferPayment();

            var actualJSON = payment.ToJson();
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