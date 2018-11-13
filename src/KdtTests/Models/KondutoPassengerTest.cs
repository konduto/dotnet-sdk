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
            KondutoPassenger passenger = KondutoPassengerFactory.CompletePassenger();
            
            var actualJSON = passenger.ToJson();
            Assert.Equal(expectedJSON, actualJSON);
            KondutoPassenger passengerFromJson = KondutoModel.FromJson<KondutoPassenger>(expectedJSON);
            Assert.Equal(passenger, passengerFromJson);
        }
    }
}