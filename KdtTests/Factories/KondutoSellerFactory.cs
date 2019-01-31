using KdtSdk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KdtTests.Factories
{
    public class KondutoSellerFactory
    {
        public static KondutoSeller Create()
        {
            return new KondutoSeller
            {
                Id = "Seller Id",
                Name = "Sellerio Name",
                CreatedAt = "2014-12-08"
            };
        }
    }
}
