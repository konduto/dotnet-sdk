using System;
using KdtSdk.Exceptions;
using Xunit;

namespace KdtTests.Exceptions
{
    public class KondutoUnexpectedAPIResponseExceptionTest 
    {
	
        [Fact]
	    public void GetMessageTest() 
        {
		    String responseBody = "";
		    KondutoUnexpectedAPIResponseException e = new KondutoUnexpectedAPIResponseException(responseBody);
		    Assert.Equal($"Unexpected API response: {responseBody}", e.Message);
	    }
    }   
}
