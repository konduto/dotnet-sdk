using KdtSdk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KdtTests.Factories
{
    public class KondutoPassengerFactory
    {
        public static KondutoPassenger BasicPassenger()
        {
            return new KondutoPassenger
            {
                Name = "Carlos Siqueira",
                Document = "AB11223344",
                DocumentType = "passport",
                FrequentTraveler = true,
            };
        }

        public static KondutoPassenger CompletePassenger()
        {
            KondutoLoyaltyProgram loyalty = new KondutoLoyaltyProgram
            {
                Program = "multiplus",
                Category = "silver"
            };

            return new KondutoPassenger
            {
                Name = "Carlos Siqueira",
                Document = "XYZ1234",
                DocumentType = "passport",
                Dob = "1970-12-01",
                Nationality = "US",
                FrequentTraveler = false,
                SpecialNeeds = true,
                Loyalty = loyalty
            };
        }

        public static KondutoPassenger CompletePassenger2()
        {
            KondutoLoyaltyProgram loyalty = new KondutoLoyaltyProgram
            {
                Program = "smiles",
                Category = "gold"
            };

            return new KondutoPassenger
            {
                Name = "Julia da Silva",
                Document = "12345678909",
                DocumentType = "id",
                Dob = "1970-01-01",
                Nationality = "BR",
                FrequentTraveler = true,
                SpecialNeeds = false,
                Loyalty = loyalty
            };
        }
    }
}
