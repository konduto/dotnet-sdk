using KdtSdk.Exceptions;
using KdtSdk.Models;
using KdtSdk.Utils;
using KdtTests.Factories;
using System;
using Xunit;
using KdtTests.Properties;

namespace KdtTests.Models
{
    public class KondutoAddressTest
    {
        [Fact]
        public void SerializeTest()
        {
		    String expectedJSON = KondutoUtils.LoadJson<KondutoAddress>(Resources.Load("address")).ToJson();
		    KondutoAddress address = KondutoAddressFactory.Create();

			var actualJSON = address.ToJson();
		    Assert.Equal(expectedJSON, actualJSON);
		    var addressFromJSON = KondutoModel.FromJson<KondutoAddress>(expectedJSON);
            Assert.Equal(address, addressFromJSON);
	    }
    }
}
