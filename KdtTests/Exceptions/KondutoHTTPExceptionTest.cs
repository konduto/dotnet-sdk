using KdtSdk.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace KdtTests.Exceptions
{
    [TestClass]
    public class KondutoHTTPExceptionTest
    {
        private class KondutoFakeHTTPException : KondutoHTTPException 
        {
		    public KondutoFakeHTTPException(String message, String responseBody) 
                : base(message, responseBody) { }
	    }

	    [TestMethod]
	    public void ConstructorTest()
        {
		    String message = "fake message";
		    String json = "";
            KondutoFakeHTTPException fakeException = new KondutoFakeHTTPException(message, json);

            Assert.AreEqual(fakeException.Message, String.Format("{0} Response body: {1}", message, json));
	    }
    }
}
