using KdtSdk.Exceptions;
using KdtSdk.Models;
using KdtSdk.Utils;
using KdtTests.Factories;
using System;
using Xunit;
using KdtTests.Properties;

namespace KdtTests.Models
{
    public class KondutoSellerTest
    {
        [Fact]
        public void SerializationTest()
        {
            String expectedJSON = KondutoUtils.LoadJson<KondutoSeller>(Resources.Load("seller")).ToJson();
            String actualJSON = null;
            KondutoSeller seller = KondutoSellerFactory.Create();

            try
            {
                actualJSON = seller.ToJson();
            }
            catch (KondutoInvalidEntityException e)
            {
                Assert.True(false, "seller should be valid");
            }

            Assert.Equal(expectedJSON, actualJSON);
            KondutoSeller sellerFromJson = KondutoModel.FromJson<KondutoSeller>(expectedJSON);
            Assert.Equal(seller, sellerFromJson);
        }
    }
}
