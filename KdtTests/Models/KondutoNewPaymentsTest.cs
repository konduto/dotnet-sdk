using KdtSdk.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KdtTests.Models
{
    [TestClass]
    public class KondutoNewPaymentsTest
    {
        [TestMethod]
        public void PixPaymentSerializationAndDeserializationTest()
        {
            KondutoPixPayment pix = new KondutoPixPayment
            {
                Amount = 150.00,
                Description = "Pagamento via PIX",
                KeyType = "email",
                KeyValue = "cliente@example.com",
                EndToEndId = "E12345678202609021200abc",
                QrCode = "00020126580014br.gov.bcb.pix...",
                ExpirationDate = "2026-09-02",
                Status = "pending"
            };

            string json = pix.ToJson();
            Assert.IsNotNull(json);

            KondutoPayment deserialized = KondutoModel.FromJson<KondutoPayment>(json);
            Assert.IsTrue(deserialized is KondutoPixPayment);
            Assert.AreEqual(pix, deserialized);
        }

        [TestMethod]
        public void BalancePaymentSerializationAndDeserializationTest()
        {
            KondutoBalancePayment balance = new KondutoBalancePayment
            {
                Amount = 50.00,
                Description = "Pagamento com Saldo",
                UserId = "USR-777"
            };

            string json = balance.ToJson();
            Assert.IsNotNull(json);

            KondutoPayment deserialized = KondutoModel.FromJson<KondutoPayment>(json);
            Assert.IsTrue(deserialized is KondutoBalancePayment);
            Assert.AreEqual(balance, deserialized);
        }
    }
}
