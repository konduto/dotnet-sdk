using KdtSdk.Models;

namespace KdtTests.Factories
{
    public class KondutoDeviceFactory
    {
        public static KondutoDevice Create()
        {
            return new KondutoDevice
            {
                Browser = "Chrome",
                Cookie = true,
                Fingerprint = "e4f2c690951038a8f77aa583847",
                Flash = true,
                Ip = "170.149.100.10",
                Javascript = true,
                Platform = "MacIntel",
                UserId = "405961fab293600daeed93ae561",
                Language = "en_US",
                Timezone = "GMT -1"
            };
        }
    }
}
