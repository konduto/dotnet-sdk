using KdtSdk.Exceptions;
using KdtSdk.Models;
using KdtSdk.Utils;
using KdtTests.Factories;
using System;
using Xunit;
using KdtTests.Properties;

namespace KdtTests.Models
{
    public class KondutoDeviceTest
    {
        [Fact]
	    public void SerializeTest()
        {
		    KondutoDevice device = KondutoDeviceFactory.Create();
		    String deviceJSON = KondutoUtils.LoadJson<KondutoDevice>(Resources.Load("device")).ToJson();
			Assert.Equal(deviceJSON, device.ToJson());
		    Assert.Equal(KondutoModel.FromJson<KondutoDevice>(deviceJSON), device);
	    }
    }
}
