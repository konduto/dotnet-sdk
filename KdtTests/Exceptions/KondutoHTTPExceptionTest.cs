using KdtSdk.Exceptions;
using System;
using Xunit;

namespace KdtTests.Exceptions
{
    public class KondutoHTTPExceptionTest
    {
        private class KondutoFakeHTTPException : KondutoHTTPException 
        {
		    public KondutoFakeHTTPException(String message, String responseBody) 
                : base(message, responseBody) { }
	    }

	    [Fact]
	    public void ConstructorTest()
        {
		    String message = "fake message";
		    String json = "";
            KondutoFakeHTTPException fakeException = new KondutoFakeHTTPException(message, json);

            Assert.Equal(fakeException.Message, $"{message} Response body: {json}");
	    }
    }
}
