using System.Collections.Generic;
using KdtSdk.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KdtTests.Models
{
    [TestClass]
    public class KondutoBankingTest
    {
        [TestMethod]
        public void BankingAccountSerializationAndDeserializationTest()
        {
            KondutoBankingAccount origin = new KondutoBankingAccount
            {
                BankCode = "341",
                BankName = "Itau",
                BankBranch = "1234",
                BankAccount = "56789-0",
                KeyType = "cpf",
                KeyValue = "12345678900",
                HolderName = "Joao Santos",
                HolderTaxId = "12345678900"
            };

            string json = origin.ToJson();
            Assert.IsNotNull(json);

            KondutoBankingAccount deserialized = KondutoModel.FromJson<KondutoBankingAccount>(json);
            Assert.AreEqual(origin, deserialized);
        }
    }
}
