using System;

namespace KdtSdk.Exceptions
{
    /// <summary>
    /// This exception is the parent of all Konduto exceptions.
    /// Use it to catch any instance of its children and handle as you wish
    /// (e.g saving an order, reporting to our support team automatically, etc.)
    /// </summary>
    public class KondutoException : Exception
    {
        public KondutoException(){}

        public KondutoException(string message)
            : base(message){}

    }
}