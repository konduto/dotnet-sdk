using System;

namespace KdtSdk.Exceptions
{
    /// <summary>
    /// This exception is thrown whenever Konduto's API responds something we cannot handle.
    /// Please contact our support team if this ever happens.
    /// </summary>
    public class KondutoUnexpectedAPIResponseException : KondutoException 
    {
        public KondutoUnexpectedAPIResponseException(String responseBody)
            : base(String.Format("Unexpected API response: {0}", responseBody)) { }
    }
}