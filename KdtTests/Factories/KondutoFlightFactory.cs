using KdtSdk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//{
//  "departure": {
//    "origin": "GRU",
//    "destination": "SFO",
//    "date": "2018-12-25T18:00Z",
//    "number_of_connections": 1,
//    "class": "economy",
//    "fare_basis": "Y",
//    "company": "LATAM"
//  },
//  "return": {
//    "origin": "SFO",
//    "destination": "GRU",
//    "date": "2018-12-30T18:00Z",
//    "number_of_connections": 1,
//    "class": "business",
//    "company": "LATAM"
//  },
//  "passengers": [
//    {
//      "name": "Julia da Silva",
//      "document": "A1B2C3D4",
//      "document_type": "id",
//      "dob": "1970-01-01",
//      "nationality": "US",
//      "frequent_traveler": true,
//      "special_needs": false,
//      "loyalty": {
//        "program": "aadvantage",
//        "category": "gold"
//      }
//    },
//    {
//      "name": "Carlos Siqueira",
//      "document": "AB11223344",
//      "document_type": "passport",
//      "dob": "1970-12-01",
//      "nationality": "US",
//      "frequent_traveler": false,
//      "special_needs": true,
//      "loyalty": {
//        "program": "skymiles",
//        "category": "silver"
//      }
//    }
//  ]
//}

namespace KdtTests.Factories
{
    public class KondutoFlightFactory
    {
        public static KondutoTravelInformation CreateReturn()
        {
            return new KondutoTravelInformation
            {
                OriginAirport = "SFO",
                DestinationAirport = "GRU",
                Date = "2018-12-30T18:00Z",
                NumberOfConnections = 1,
                Class = "business",
                Company = "LATAM"
            };
        }

        public static KondutoTravelInformation CreateDeparture()
        {
            return new KondutoTravelInformation
            {
                OriginAirport = "GRU",
                DestinationAirport = "SFO",
                Date = "2018-12-25T18:00Z",
                NumberOfConnections = 1,
                Class = "economy",
                FareBasis = "Y",
                Company = "LATAM"
            };
        }

        public static KondutoTravel CreateFlight()
        {
            return new KondutoTravel
            {
                Departure = CreateDeparture(),
                Return = CreateReturn(),
                ExpirationDate = "2019-12-25T18:00Z",
                Passengers = new List<KondutoPassenger>
                {
                    KondutoPassengerFactory.CompletePassenger2(),
                    KondutoPassengerFactory.CompletePassenger()
                }
            };
        }
    }
}