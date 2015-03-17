using KdtSdk.Exceptions;
using KdtSdk.Models;
using KdtSdk.Utils;
using KdtTests.Factories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Text;

namespace KdtTests.Models
{
    [TestClass]
    public class KondutoGeolocationTest
    {
        [TestMethod]
        public void SerializationTest()
        {
		    KondutoGeolocation geolocation = KondutoGeolocationFactory.Create();

            String geolocationJSON = KondutoUtils.LoadJson<KondutoGeolocation>(Properties.Resources.geolocation).ToJson();
		    
            try 
            {
			    Assert.AreEqual(geolocationJSON, geolocation.ToJson(), "serialization failed");
		    }
            catch (KondutoInvalidEntityException e) 
            {
			    Assert.Fail("geolocation should be valid");
		    }

		    KondutoGeolocation geolocationDeserialized = KondutoModel.FromJson<KondutoGeolocation>(geolocationJSON);
            Assert.AreEqual(geolocation, geolocationDeserialized, "deserialization failed");
	    }
    }
}