using KdtSdk.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KdtTests.Models
{
    [TestClass]
    public class KondutoDeliveryAndTenantTest
    {
        [TestMethod]
        public void DeliverySerializationAndDeserializationTest()
        {
            KondutoDelivery delivery = new KondutoDelivery
            {
                DeliveryMethod = "express",
                DeliveryCompany = "Loggi",
                EstimatedShippingDate = "2026-09-02T18:30:00Z",
                EstimatedDeliveryDate = "2026-09-05T18:30:00Z"
            };

            string json = delivery.ToJson();
            Assert.IsNotNull(json);

            KondutoDelivery deserialized = KondutoModel.FromJson<KondutoDelivery>(json);
            Assert.AreEqual(delivery, deserialized);
        }

        [TestMethod]
        public void TenantSerializationAndDeserializationTest()
        {
            KondutoTenant tenant = new KondutoTenant
            {
                Id = "TENANT-99",
                Name = "Partner Platform",
                CreatedAt = "2026-09-02"
            };

            string json = tenant.ToJson();
            Assert.IsNotNull(json);

            KondutoTenant deserialized = KondutoModel.FromJson<KondutoTenant>(json);
            Assert.AreEqual(tenant, deserialized);
        }

    }
}
