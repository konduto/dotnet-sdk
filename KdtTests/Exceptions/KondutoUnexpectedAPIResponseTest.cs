using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KdtSdk.Exceptions;

namespace KdtTests.Exceptions
{
    [TestClass]
    public class KondutoUnexpectedAPIResponseExceptionTest 
    {
	
        [TestMethod]
	    public void GetMessageTest() 
        {
		    String responseBody = "";
		    KondutoUnexpectedAPIResponseException e = new KondutoUnexpectedAPIResponseException(responseBody);
		    Assert.AreEqual("Unexpected API response: " + responseBody, e.Message);
	    }
    }   
}
