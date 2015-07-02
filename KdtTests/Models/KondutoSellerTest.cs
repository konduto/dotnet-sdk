using KdtSdk.Exceptions;
using KdtSdk.Models;
using KdtSdk.Utils;
using KdtTests.Factories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KdtTests.Models
{
    [TestClass]
    public class KondutoSellerTest
    {
        [TestMethod]
        public void SerializationTest()
        {
            String expectedJSON = KondutoUtils.LoadJson<KondutoSeller>(Properties.Resources.seller).ToJson();
            String actualJSON = null;
            KondutoSeller seller = KondutoSellerFactory.Create();

            try
            {
                actualJSON = seller.ToJson();
            }
            catch (KondutoInvalidEntityException e)
            {
                Assert.Fail("seller should be valid");
            }

            Assert.AreEqual(expectedJSON, actualJSON, "seller serialization failed");
            KondutoSeller sellerFromJson = KondutoModel.FromJson<KondutoSeller>(expectedJSON);
            Assert.AreEqual(seller, sellerFromJson, "passenger deserialization failed");
        }
    }
}
