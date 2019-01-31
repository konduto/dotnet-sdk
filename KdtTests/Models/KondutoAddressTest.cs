using KdtSdk.Exceptions;
using KdtSdk.Models;
using KdtSdk.Utils;
using KdtTests.Factories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace KdtTests.Models
{
    [TestClass]
    public class KondutoAddressTest
    {
        [TestMethod]
        public void SerializeTest()
        {
		    String expectedJSON = KondutoUtils.LoadJson<KondutoAddress>(Properties.Resources.address).ToJson();
		    String actualJSON = null;
		    KondutoAddress address = KondutoAddressFactory.Create();

		    try 
            {
			    actualJSON = address.ToJson();
		    } 
            catch (KondutoInvalidEntityException e) 
            {
			    Assert.Fail("address should be valid");
		    }

		    Assert.AreEqual(expectedJSON, actualJSON, "address serialization failed");
		    KondutoAddress addressFromJSON = KondutoModel.FromJson<KondutoAddress>(expectedJSON);
            Assert.AreEqual(address, addressFromJSON, "address deserialization failed");
	    }
    }
}
