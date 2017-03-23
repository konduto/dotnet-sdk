using KdtSdk.Exceptions;
using KdtSdk.Models;
using KdtSdk.Utils;
using KdtTests.Factories;
using System;
using Xunit;
using KdtTests.Properties;

namespace KdtTests.Models
{
    public class KondutoNavigationInfoTest
    {
        [Fact]
        public void SerializationTest()
        {
		    KondutoNavigationInfo navigationInfo = KondutoNavigationInfoFactory.Create();

		    String navigationInfoJSON = KondutoUtils.LoadJson<KondutoNavigationInfo>(Resources.Load("navigation")).ToJson();
			Assert.Equal(navigationInfoJSON ,navigationInfo.ToJson());
		    KondutoNavigationInfo navigationInfoDeserialized = KondutoModel.FromJson<KondutoNavigationInfo>(navigationInfoJSON);
            Assert.Equal(navigationInfoDeserialized, navigationInfo);
        }
    }
}
