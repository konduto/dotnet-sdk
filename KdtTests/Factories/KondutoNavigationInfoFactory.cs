using KdtSdk.Models;

namespace KdtTests.Factories
{
    public class KondutoNavigationInfoFactory
    {
        public static KondutoNavigationInfo Create() 
        {
            return new KondutoNavigationInfo
            {
                SessionTime = 12d,
                Referrer = "http://www.google.com?q=buy+shirt",
                TimeSinceLastSale = 4d,

                TimeOnSiteToday = 26d,
                AccountsCreatedToday = 2,
                PasswordResetsToday = 0,
                SalesDeclinedToday = 1,
                SessionsToday = 4,

                TimeOnSiteSinceLastWeek = 58d,
                TimePerPageSinceLastWeek = 7d,
                
                AccountsCreatedSinceLastWeek = 9,
                PasswordResetsSinceLastWeek = 3,
                CheckoutPageViewsSinceLastWeek = 4,
                SessionsSinceLastWeek = 12,
                SalesDeclinedSinceLastWeek = 5
            };
        }
    }
}
