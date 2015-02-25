using KdtSdk.Exceptions;
using KdtSdk.Models;
using KdtSdk.Utils;
using KdtTests.Factories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace KdtTests.Models
{
    [TestClass]
    public class KondutoDeviceTest
    {
        [TestMethod]
	    public void SerializeTest()
        {
		    KondutoDevice device = KondutoDeviceFactory.Create();
		    String deviceJSON = KondutoUtils.LoadJson<KondutoDevice>(Properties.Resources.device).ToJson();

		    try 
            {
			    Assert.AreEqual(deviceJSON, device.ToJson(), "serialization failed");
		    } 
            catch (KondutoInvalidEntityException e) 
            {
			    Assert.Fail("device should be valid");
		    }

		    Assert.AreEqual(KondutoModel.FromJson<KondutoDevice>(deviceJSON), device, "deserialization failed");
	    }
    }
}
