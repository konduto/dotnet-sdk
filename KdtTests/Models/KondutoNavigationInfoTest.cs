using KdtSdk.Exceptions;
using KdtSdk.Models;
using KdtSdk.Utils;
using KdtTests.Factories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace KdtTests.Models
{
    [TestClass]
    public class KondutoNavigationInfoTest
    {
        [TestMethod]
        public void SerializationTest()
        {
		    KondutoNavigationInfo navigationInfo = KondutoNavigationInfoFactory.Create();

		    String navigationInfoJSON = KondutoUtils.LoadJson<KondutoNavigationInfo>(Properties.Resources.navigation).ToJson();

		    try 
            {
                var c = navigationInfo.ToJson();
			    Assert.AreEqual(navigationInfoJSON ,navigationInfo.ToJson(), "serialization failed");
		    } 
            catch (KondutoInvalidEntityException e) 
            {
			    Assert.Fail("navigation info should be valid");
		    }

		    KondutoNavigationInfo navigationInfoDeserialized = KondutoModel.FromJson<KondutoNavigationInfo>(navigationInfoJSON);
            Assert.AreEqual(navigationInfoDeserialized, navigationInfo, "deserialization failed");
        }
    }
}
