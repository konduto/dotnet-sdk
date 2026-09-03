using System.Collections.Generic;
using KdtSdk.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KdtTests.Models
{
    [TestClass]
    public class KondutoVehicleTest
    {
        [TestMethod]
        public void VehicleSerializationAndDeserializationTest()
        {
            KondutoVehicle vehicle = new KondutoVehicle
            {
                Make = "Toyota",
                Model = "Corolla",
                Vid = "9BRBL42EXF8000000",
                Renavam = "12345678901",
                Registration = "ABC1D23",
                Type = "sedan",
                Usage = "personal",
                Owner = new List<KondutoVehicleOwner>
                {
                    new KondutoVehicleOwner
                    {
                        Name = "Pedro Alvares",
                        TaxId = "11122233344"
                    }
                }
            };

            string json = vehicle.ToJson();
            Assert.IsNotNull(json);

            KondutoVehicle deserialized = KondutoModel.FromJson<KondutoVehicle>(json);
            Assert.AreEqual(vehicle, deserialized);
        }
    }
}
