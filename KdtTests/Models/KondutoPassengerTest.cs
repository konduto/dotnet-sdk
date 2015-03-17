using KdtSdk.Exceptions;
using KdtSdk.Models;
using KdtSdk.Utils;
using KdtTests.Factories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;

namespace KdtTests.Models
{
    [TestClass]
    public class KondutoPassengerTest
    {
        [TestMethod]
        public void SerializationTest()
        {
            String expectedJSON = KondutoUtils.LoadJson<KondutoPassenger>(Properties.Resources.passenger).ToJson();
            String actualJSON = null;
            KondutoPassenger passenger = KondutoPassengerFactory.CompletePassenger();

            try
            {
                actualJSON = passenger.ToJson();
            }
            catch (KondutoInvalidEntityException e)
            {
                Assert.Fail("passenger should be valid");
            }

            Assert.AreEqual(expectedJSON, actualJSON, "passenger serialization failed");
            KondutoPassenger passengerFromJson = KondutoModel.FromJson<KondutoPassenger>(expectedJSON);
            Assert.AreEqual(passenger, passengerFromJson, "passenger deserialization failed");
        }
    }
}