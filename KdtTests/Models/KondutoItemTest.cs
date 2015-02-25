using System;
using KdtSdk.Exceptions;
using KdtSdk.Models;
using KdtSdk.Utils;
using KdtTests.Factories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KdtTests.Models
{
    [TestClass]
    public class KondutoItemTest
    {
        KondutoItem greenTShirt = KondutoItemFactory.CreateGreenTShirt();
        String greenTShirtJSON = KondutoUtils.GetFirstJArrayElement(Properties.Resources.shopping_cart);

        [TestMethod]
        public void SerializationTest()
        {
            try
            {
                var v = greenTShirt.ToJson();
                Assert.AreEqual(greenTShirtJSON, greenTShirt.ToJson(), "serialization failed");
            }
            catch (KondutoInvalidEntityException e)
            {
                Assert.Fail("Green T-Shirt should be valid");
            }
        }

        [TestMethod]
        public void Deserializationtest()
        {
            Assert.IsTrue(greenTShirt.Equals(KondutoModel.FromJson<KondutoItem>(greenTShirtJSON)), "deserialization failed");
        }
    }
}
