using KdtSdk.Exceptions;
using System;
using System.Collections.Generic;
using Xunit;

namespace KdtTests.Exceptions
{
    public class KondutoHTTPExceptionFactoryTest
    {
        private static Dictionary<int, Type> HTTP_STATUSES = new Dictionary<int, Type>()
        {
            {400, typeof(KdtSdk.Exceptions.KondutoHTTPExceptionFactory.KondutoHTTPBadRequestException)},
            {401, typeof(KdtSdk.Exceptions.KondutoHTTPExceptionFactory.KondutoHTTPUnauthorizedException)},
            {403, typeof(KdtSdk.Exceptions.KondutoHTTPExceptionFactory.KondutoHTTPForbiddenException)},
            {404, typeof(KdtSdk.Exceptions.KondutoHTTPExceptionFactory.KondutoHTTPNotFoundException)},
            {405, typeof(KdtSdk.Exceptions.KondutoHTTPExceptionFactory.KondutoHTTPMethodNotAllowedException)},
            {422, typeof(KdtSdk.Exceptions.KondutoHTTPExceptionFactory.KondutoHTTPUnprocessableEntityException)},
            {429, typeof(KdtSdk.Exceptions.KondutoHTTPExceptionFactory.KondutoHTTPTooManyRequestsException)},
            {500, typeof(KdtSdk.Exceptions.KondutoHTTPExceptionFactory.KondutoHTTPInternalErrorException)}
        };

	    [Fact]
	    public void BuildExceptionTest() 
        {
            foreach (var entry in HTTP_STATUSES)
            {
                int statusCode = entry.Key;
                var type = entry.Value;
                String responseBody = "{\"statusCode\": \"" + statusCode + "\"}";
                var exception = KondutoHTTPExceptionFactory.buildException(statusCode, responseBody);

                Assert.Equal(type, exception.GetType());
            }
	    }
    }
}
