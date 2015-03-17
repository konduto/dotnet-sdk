using KdtSdk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KdtTests.Factories
{
    public class KondutoPassengerFactory
    {
        //{  
        //  "name":"Júlia da Silva",
        //  "document": "A1B2C3D4",
        //  "document_type": "id",
        //  "dob": "1970-01-01",
        //  "nationality": "US",
        //  "frequent_flyer": true,
        //  "special_needs": false,
        //  "loyalty": {  
        //    "program": "aadvantage",
        //    "category": "gold"
        //  }
        //}
        //{  
        //  "name": "Carlos Siqueira",
        //  "document": "AB11223344",
        //  "document_type": "passport",
        //  "dob": "1970-12-01",
        //  "nationality": "US",
        //  "frequent_flyer": false,
        //  "special_needs": true,
        //  "loyalty": {  
        //    "program": "skymiles",
        //    "category": "silver"
        //  }

        public static KondutoPassenger BasicPassenger()
        {
            return new KondutoPassenger
            {
                Name = "Carlos Siqueira",
                Document = "AB11223344",
                DocumentType = "passport",
                FrequentFlyer = true,
            };
        }

        public static KondutoPassenger CompletePassenger()
        {
            KondutoLoyaltyProgram loyalty = new KondutoLoyaltyProgram
            {
                Program = "skymiles",
                Category = "silver"
            };

            return new KondutoPassenger
            {
                Name = "Carlos Siqueira",
                Document = "AB11223344",
                DocumentType = "passport",
                Dob = "1970-12-01",
                Nationality = "US",
                FrequentFlyer = false,
                SpecialNeeds = true,
                Loyalty = loyalty
            };
        }

        public static KondutoPassenger CompletePassenger2()
        {
            KondutoLoyaltyProgram loyalty = new KondutoLoyaltyProgram
            {
                Program = "aadvantage",
                Category = "gold"
            };

            return new KondutoPassenger
            {
                Name = "Julia da Silva",
                Document = "A1B2C3D4",
                DocumentType = "id",
                Dob = "1970-01-01",
                Nationality = "US",
                FrequentFlyer = true,
                SpecialNeeds = false,
                Loyalty = loyalty
            };
        }
    }
}
