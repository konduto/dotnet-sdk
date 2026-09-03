using System.Collections.Generic;
using KdtSdk.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KdtTests.Models
{
    [TestClass]
    public class KondutoEventTest
    {
        [TestMethod]
        public void EventSerializationAndDeserializationTest()
        {
            KondutoEvent ev = new KondutoEvent
            {
                Name = "Rock Festival 2026",
                Date = "2026-11-20T20:00:00Z",
                Type = "concert",
                Subtype = "music",
                Venue = new KondutoEventVenue
                {
                    Name = "Stadium Arena",
                    Address = "Av. das Nacoes, 500",
                    City = "Sao Paulo",
                    State = "SP",
                    Country = "BR",
                    Capacity = 50000
                },
                Tickets = new List<KondutoEventTicket>
                {
                    new KondutoEventTicket
                    {
                        Id = "TICKET-01",
                        Category = "VIP",
                        Section = "VIP",
                        Premium = true,
                        Attendee = new List<KondutoEventAttendee>
                        {
                            new KondutoEventAttendee
                            {
                                Name = "Carlos Souza",
                                Document = "98765432100"
                            }
                        }
                    }
                }
            };

            string json = ev.ToJson();
            Assert.IsNotNull(json);

            KondutoEvent deserialized = KondutoModel.FromJson<KondutoEvent>(json);
            Assert.AreEqual(ev, deserialized);
        }
    }
}
