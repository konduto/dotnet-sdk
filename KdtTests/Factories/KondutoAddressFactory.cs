using KdtSdk.Models;

namespace KdtTests.Factories
{
    public class KondutoAddressFactory
    {
        public static KondutoAddress Create()
        {
            return new KondutoAddress
            {
                Name = "Konduto",
                Address1 = "R. Teodoro Sampaio, 2393",
                Address2 = "CJ. 111",
                Zip = "05406-200",
                City = "Sao Paulo",
                State = "SP",
                Country = "BR"
            };
        }
    }
}
