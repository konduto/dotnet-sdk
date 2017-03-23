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
		    String actualJSON = null;
		    KondutoAddress address = KondutoAddressFactory.Create();

		    try 
            {
			    actualJSON = address.ToJson();
		    } 
            catch (KondutoInvalidEntityException e) 
            {
			    Assert.True(false, "address should be valid");
		    }

		    Assert.Equal(expectedJSON, actualJSON);
		    KondutoAddress addressFromJSON = KondutoModel.FromJson<KondutoAddress>(expectedJSON);
            Assert.Equal(address, addressFromJSON);
	    }
    }
}
