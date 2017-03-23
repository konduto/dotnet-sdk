using KdtSdk.Exceptions;
using KdtSdk.Models;
using KdtSdk.Utils;
using KdtTests.Factories;
using System;
using System.Diagnostics;
using Xunit;
using KdtTests.Properties;

namespace KdtTests.Models
{
    public class KondutoPassengerTest
    {
        [Fact]
        public void SerializationTest()
        {
            String expectedJSON = KondutoUtils.LoadJson<KondutoPassenger>(Resources.Load("passenger")).ToJson();
            String actualJSON = null;
            KondutoPassenger passenger = KondutoPassengerFactory.CompletePassenger();

            try
            {
                actualJSON = passenger.ToJson();
            }
            catch (KondutoInvalidEntityException e)
            {
                Assert.True(false, "passenger should be valid");
            }

            Assert.Equal(expectedJSON, actualJSON);
            KondutoPassenger passengerFromJson = KondutoModel.FromJson<KondutoPassenger>(expectedJSON);
            Assert.Equal(passenger, passengerFromJson);
        }
    }
}