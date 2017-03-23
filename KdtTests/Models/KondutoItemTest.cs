using System;
using KdtSdk.Exceptions;
using KdtSdk.Models;
using KdtSdk.Utils;
using KdtTests.Factories;
using KdtTests.Properties;
using Xunit;

namespace KdtTests.Models
{
    public class KondutoItemTest
    {
        KondutoItem greenTShirt = KondutoItemFactory.CreateGreenTShirt();
        String greenTShirtJSON = KondutoUtils.GetFirstJArrayElement(Resources.Load("shopping_cart"));

        [Fact]
        public void SerializationTest()
        {
            try
            {
                var v = greenTShirt.ToJson();
                Assert.Equal(greenTShirtJSON, greenTShirt.ToJson());
            }
            catch (KondutoInvalidEntityException e)
            {
                Assert.True(false, "Green T-Shirt should be valid");
            }
        }

        [Fact]
        public void Deserializationtest()
        {
            Assert.True(greenTShirt.Equals(KondutoModel.FromJson<KondutoItem>(greenTShirtJSON)));
        }
    }
}
