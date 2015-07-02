using KdtSdk.Models;

namespace KdtTests.Factories
{
    public class KondutoCustomerFactory
    {
        public static KondutoCustomer BasicCustomer()
        {
            return new KondutoCustomer
            {
                Id = "1",
                Name = "Jose da Silva",
                Email = "jose.silva@gmail.com"
            };
        }

        public static KondutoCustomer CompleteCustomer()
        {
            return new KondutoCustomer
            {
                Id = "1",
                Name = "Jose da Silva",
                Email = "jose.silva@gmail.com",
                IsVip = false,
                IsNew = false,
                Phone1 = "11987654321",
                Phone2 = "1133333333",
                TaxId = "01234567890",
                CreatedAt = "2014-12-21"
            };
        }
    }
}
