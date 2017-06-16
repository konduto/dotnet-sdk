using KdtSdk.Models;

namespace KdtTests.Factories
{
    public class KondutoGeolocationFactory
    {
        public static KondutoGeolocation Create()
        {
            return new KondutoGeolocation
            {
                City = "Sao Paulo",
                State = "SP",
                Country = "BR"
            };
        }
    }
}
