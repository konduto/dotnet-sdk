using KdtSdk.Models;
using System.Collections.Generic;

namespace KdtTests.Factories
{
    public class KondutoItemFactory
    {
        public static List<KondutoItem> CreateShoppingCart()
        {
            return new List<KondutoItem> { CreateGreenTShirt(), CreateYellowSocks() };
        }

        public static KondutoItem CreateGreenTShirt()
        {
            return new KondutoItem
            {
                Sku = "9919023",
                ProductCode = "123456789999",
                Category = 201,
                Name = "Green T-Shirt",
                Description = "Male Green T-Shirt V Neck",
                UnitCost = 1999.99,
                Quantity = 1
            };
        }

        public static KondutoItem CreateYellowSocks()
        {
            return new KondutoItem
            {
                Sku = "0017273",
                Category = 202,
                Name = "Yellow Socks",
                Description = "Pair of Yellow Socks",
                UnitCost = 29.9,
                Quantity = 2,
                Discount = 5.0
            };
        }
    }
}
