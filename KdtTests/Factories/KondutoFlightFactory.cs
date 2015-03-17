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
//    "fare_basis": "Y"
//  },
//  "return": {
//    "origin": "SFO",
//    "destination": "GRU",
//    "date": "2018-12-30T18:00Z",
//    "number_of_connections": 1,
//    "class": "business"
//  },
//  "passengers": [
//    {
//      "name": "Julia da Silva",
//      "document": "A1B2C3D4",
//      "document_type": "id",
//      "dob": "1970-01-01",
//      "nationality": "US",
//      "frequent_flyer": true,
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
//      "frequent_flyer": false,
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
        public static KondutoFlightInformation CreateReturn()
        {
            return new KondutoFlightInformation
            {
                Origin = "SFO",
                Destination = "GRU",
                Date = "2018-12-30T18:00Z",
                NumberOfConnections = 1,
                Class = "business"
            };
        }

        public static KondutoFlightInformation CreateDeparture()
        {
            return new KondutoFlightInformation
            {
                Origin = "GRU",
                Destination = "SFO",
                Date = "2018-12-25T18:00Z",
                NumberOfConnections = 1,
                Class = "economy",
                FareBasis = "Y"
            };
        }

        public static KondutoFlight CreateFlight()
        {
            return new KondutoFlight
            {
                Departure = CreateDeparture(),
                Return = CreateReturn(),
                Passengers = new List<KondutoPassenger>
                {
                    KondutoPassengerFactory.CompletePassenger2(),
                    KondutoPassengerFactory.CompletePassenger()
                }
            };
        }
    }
}