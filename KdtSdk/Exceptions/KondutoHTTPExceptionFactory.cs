using System;
using System.Net;

namespace KdtSdk.Exceptions
{
    /// <summary>
    /// This factory is able to, given a status code,
    /// build a {@link com.konduto.sdk.exceptions.KondutoHTTPException} child exception.
    /// </summary>
    public class KondutoHTTPExceptionFactory
    {
        
	    private static String responseBody;

	    /// <summary>
	    /// </summary>
	    /// <param name="statusCode">the HTTP status code answered by Konduto's API.</param>
	    /// <param name="responseBody">the response body.</param>
	    /// <returns>an exception corresponding to the HTTP status code.</returns>
	    public static KondutoHTTPException buildException(int statusCode, String responseBody) 
        {
            KondutoHTTPExceptionFactory.responseBody = responseBody;
		    
            switch(statusCode) 
            {
                case (int)HttpStatusCode.BadRequest:
				    return new KondutoHTTPBadRequestException();
                case (int)HttpStatusCode.Unauthorized:
				    return new KondutoHTTPUnauthorizedException();
                case (int)HttpStatusCode.Forbidden:
				    return new KondutoHTTPForbiddenException();
                case (int)HttpStatusCode.NotFound:
				    return new KondutoHTTPNotFoundException();
                case (int)HttpStatusCode.MethodNotAllowed:
				    return new KondutoHTTPMethodNotAllowedException();
                case 422: // not available via HttpStatusCode enum
                    return new KondutoHTTPUnprocessableEntityException();
                case 429: // not available via HttpStatusCode enum
                    return new KondutoHTTPTooManyRequestsException();
                case (int)HttpStatusCode.InternalServerError:
				    return new KondutoHTTPInternalErrorException();
		    }

		    return null;
	    }

        /// <summary>
        /// HTTP 400 is answered when the client sent a bad request to Konduto's API.
        /// </summary>
	    public class KondutoHTTPBadRequestException : KondutoHTTPException {
		    public KondutoHTTPBadRequestException()
			    : base("Your request is incorrect. Please review the parameters sent.", responseBody) {}
	    }

        /// <summary>
        /// HTTP 401 is answered when Konduto's API fails to authenticate the merchant.
        /// </summary>
        public class KondutoHTTPUnauthorizedException : KondutoHTTPException
        {
		    public KondutoHTTPUnauthorizedException() : base("Invalid API Key", responseBody) {}
	    }

        /// <summary>
        /// HTTP 403 is answered when the merchant is not authorized to use Konduto's API.
        /// </summary>
        public class KondutoHTTPForbiddenException : KondutoHTTPException
        {
		    public KondutoHTTPForbiddenException() : base("There are problems with your account. Please contact our support team.", responseBody) {}
	    }

	    /// <summary>
	    /// HTTP 404 is answered when the resource is not found by Konduto's API.
	    /// </summary>
        public class KondutoHTTPNotFoundException : KondutoHTTPException
        {
		    public KondutoHTTPNotFoundException() : base("The requested resource could not be found.", responseBody) {}
	    }

        /// <summary>
        /// HTTP 405 is answered when the HTTP method is not allowed by Konduto's API.
        /// </summary>
        public class KondutoHTTPMethodNotAllowedException : KondutoHTTPException
        {
		    public KondutoHTTPMethodNotAllowedException() : base("Sorry, we don't accept this HTTP method.", responseBody) {}
	    }

        /// <summary>
        /// HTTP 422 is RFU
        /// </summary>
        public class KondutoHTTPUnprocessableEntityException : KondutoHTTPException
        {
		    public KondutoHTTPUnprocessableEntityException() : base("Unprocessable entity", responseBody) {}
	    }

        /// <summary>
        /// HTTP 429 is answered when a merchant who signed up for a free plan reaches the transaction limit.
        /// </summary>
        public class KondutoHTTPTooManyRequestsException : KondutoHTTPException
        {
		    public KondutoHTTPTooManyRequestsException() : base("Your free plan reached the transactions limit.", responseBody) {}
	    }

        /// <summary>
        /// HTTP 500 is answered when an internal error happens at Konduto's API.
        /// </summary>
        public class KondutoHTTPInternalErrorException : KondutoHTTPException
        {
		    public KondutoHTTPInternalErrorException() : base("Oh no...something wrong happened at our servers. Please contact our support team.", responseBody){}
	    }
    }
}
