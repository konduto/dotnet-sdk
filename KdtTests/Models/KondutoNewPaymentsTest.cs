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
                Description = "Pagamento via PIX"
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
                Description = "Pagamento com Saldo"
            };

            string json = balance.ToJson();
            Assert.IsNotNull(json);

            KondutoPayment deserialized = KondutoModel.FromJson<KondutoPayment>(json);
            Assert.IsTrue(deserialized is KondutoBalancePayment);
            Assert.AreEqual(balance, deserialized);
        }
    }
}
