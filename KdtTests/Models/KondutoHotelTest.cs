using System.Collections.Generic;
using KdtSdk.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KdtTests.Models
{
    [TestClass]
    public class KondutoHotelTest
    {
        [TestMethod]
        public void HotelSerializationAndDeserializationTest()
        {
            KondutoHotel hotel = new KondutoHotel
            {
                Name = "Grand Hotel",
                Address1 = "Av. Paulista, 1000",
                Address2 = "Apto 501",
                City = "Sao Paulo",
                State = "SP",
                Zip = "01310-100",
                Country = "BR",
                Rooms = new List<KondutoHotelRoom>
                {
                    new KondutoHotelRoom
                    {
                        Type = "deluxe",
                        Code = "DLX1",
                        CheckInDate = "2026-10-01T12:00:00Z",
                        CheckOutDate = "2026-10-05T10:00:00Z",
                        Guests = new List<KondutoHotelGuest>
                        {
                            new KondutoHotelGuest
                            {
                                Name = "Maria Silva",
                                Document = "12345678900",
                                Dob = "1990-05-15"
                            }
                        }
                    }
                }
            };

            string json = hotel.ToJson();
            Assert.IsNotNull(json);

            KondutoHotel deserialized = KondutoModel.FromJson<KondutoHotel>(json);
            Assert.AreEqual(hotel, deserialized);
        }
    }
}
