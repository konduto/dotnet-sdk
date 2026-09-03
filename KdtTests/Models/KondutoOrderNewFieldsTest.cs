using System.Collections.Generic;
using KdtSdk.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KdtTests.Models
{
    [TestClass]
    public class KondutoOrderNewFieldsTest
    {
        [TestMethod]
        public void OrderWithAllNewFieldsSerializationAndDeserializationTest()
        {
            KondutoOrder order = new KondutoOrder
            {
                Id = "ORDER-NEW-12345",
                Visitor = "visitor-new-fields",
                TotalAmount = 500.00,
                Installments = 1,
                Customer = new KondutoCustomer
                {
                    Id = "CUST-01",
                    Name = "Empresa ABC Ltda",
                    Email = "contato@empresaabc.com",
                    TaxId = "12345678000100",
                    Phone1 = "+5585999990000",
                    Type = "PJ",
                    RiskLevel = "low",
                    RiskScore = 0.05,
                    MotherName = "Maria Silva"
                },
                Recurring = true,
                RiskLevel = "low",
                SalesChannel = "e-commerce",
                Scheduled = false,
                Hotel = new KondutoHotel
                {
                    Name = "Resort Beach",
                    City = "Fortaleza",
                    State = "CE",
                    Country = "BR",
                    Rooms = new List<KondutoHotelRoom>
                    {
                        new KondutoHotelRoom
                        {
                            Number = "501",
                            Type = "suite",
                            CheckInDate = "2026-12-01T12:00:00Z",
                            CheckOutDate = "2026-12-10T10:00:00Z",
                            Guests = new List<KondutoHotelGuest>
                            {
                                new KondutoHotelGuest
                                {
                                    Name = "Empresa ABC Hospede",
                                    Document = "12345678900"
                                }
                            }
                        }
                    }
                },
                Events = new List<KondutoEvent>
                {
                    new KondutoEvent
                    {
                        Name = "Tech Summit",
                        Date = "2026-10-10",
                        Type = "conference"
                    }
                },
                Vehicles = new KondutoVehicle
                {
                    Make = "Fiat",
                    Model = "Pulse",
                    Registration = "BRA2E19",
                    Owner = new List<KondutoVehicleOwner>
                    {
                        new KondutoVehicleOwner
                        {
                            Name = "Empresa ABC Ltda",
                            TaxId = "12345678000100"
                        }
                    }
                },
                Delivery = new KondutoDelivery
                {
                    DeliveryMethod = "pickup",
                    DeliveryCompany = "Store Direct",
                    EstimatedShippingDate = "2026-12-01T12:00:00Z",
                    EstimatedDeliveryDate = "2026-12-02T12:00:00Z"
                },
                PointOfSale = new KondutoPointOfSale
                {
                    Id = "POS-10",
                    Name = "Loja Centro"
                },
                Agent = new KondutoAgent
                {
                    Id = "AGT-55",
                    Name = "Ana Vendedora",
                    CreatedAt = "2020-01-01"
                },
                Tenant = new KondutoTenant
                {
                    Id = "TNT-01",
                    Name = "Tenant Principal",
                    CreatedAt = "2020-01-01"
                },
                EventType = "pix",
                EventDetails = "instant_transfer",
                OriginAccount = new KondutoBankingAccount
                {
                    BankCode = "001",
                    KeyType = "email",
                    KeyValue = "origin@bank.com"
                },
                DestinationAccounts = new List<KondutoBankingAccount>
                {
                    new KondutoBankingAccount
                    {
                        BankCode = "237",
                        KeyType = "phone",
                        KeyValue = "+5511988887777"
                    }
                },
                Analyze = true
            };

            string json = order.ToJson();
            Assert.IsNotNull(json);

            KondutoOrder deserialized = KondutoModel.FromJson<KondutoOrder>(json);
            Assert.AreEqual(order, deserialized);
        }
    }
}
