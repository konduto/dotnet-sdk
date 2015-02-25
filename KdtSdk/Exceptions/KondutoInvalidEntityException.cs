using System;
using KdtSdk.Models;

namespace KdtSdk.Exceptions
{
    /// <summary>
    /// This exception is thrown when a {@link KondutoModel} instance is invalid.
    /// </summary>
    public class KondutoInvalidEntityException : KondutoException 
    {
	    public KondutoInvalidEntityException(KondutoModel entity)
            : base(String.Format("{0} is invalid: {1}", entity.ToString(), entity.GetError())) { }
    }
}
