using KdtSdk.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KdtTests.Models
{
    [TestClass]
    public class KondutoPointOfSaleAndAgentTest
    {
        [TestMethod]
        public void PointOfSaleSerializationAndDeserializationTest()
        {
            KondutoPointOfSale pos = new KondutoPointOfSale
            {
                Id = "POS-001",
                Name = "Loja Morumbi",
                Lat = -23.6231,
                Long = -46.6989,
                Address = "Av. Roque Petroni Junior, 1089",
                City = "Sao Paulo",
                State = "SP",
                Zip = "04707-900",
                Country = "BR"
            };

            string json = pos.ToJson();
            Assert.IsNotNull(json);

            KondutoPointOfSale deserialized = KondutoModel.FromJson<KondutoPointOfSale>(json);
            Assert.AreEqual(pos, deserialized);
        }

        [TestMethod]
        public void AgentSerializationAndDeserializationTest()
        {
            KondutoAgent agent = new KondutoAgent
            {
                Id = "AGT-123",
                Login = "ana.costa",
                Name = "Ana Costa",
                TaxId = "12345678909",
                Category = "seller",
                CreatedAt = "2021-01-01"
            };

            string json = agent.ToJson();
            Assert.IsNotNull(json);

            KondutoAgent deserialized = KondutoModel.FromJson<KondutoAgent>(json);
            Assert.AreEqual(agent, deserialized);
        }
    }
}
