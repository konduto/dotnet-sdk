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
            Assert.Equal(greenTShirtJSON, greenTShirt.ToJson());
        }

        [Fact]
        public void Deserializationtest()
        {
            Assert.True(greenTShirt.Equals(KondutoModel.FromJson<KondutoItem>(greenTShirtJSON)));
        }
    }
}
