using KdtSdk.Exceptions;
using KdtSdk.Models;
using KdtSdk.Utils;
using KdtTests.Factories;
using System;
using Xunit;
using KdtTests.Properties;

namespace KdtTests.Models
{
    public class KondutoTravelTest
    {
        [Fact]
        public void SerializeTest()
        {
            String expectedJSON = KondutoUtils.LoadJson<KondutoTravel>(Resources.Load("flight")).ToJson();
            KondutoTravel flight = KondutoFlightFactory.CreateFlight();

            var actualJSON = flight.ToJson();
            Assert.Equal(expectedJSON, actualJSON);
            KondutoTravel flightFromJSON = KondutoModel.FromJson<KondutoTravel>(expectedJSON);
            Assert.Equal(flight, flightFromJSON);
        }
    }
}
