using KdtSdk.Exceptions;
using KdtSdk.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace KdtTests.Exceptions
{
    [TestClass]
    public class KondutoInvalidEntityExceptionTest
    {
        [TestMethod]
        public void InvalidEntityExceptionMessageTest()
        {
            KondutoCustomer customer = new KondutoCustomer();
            customer.IsValid(); // triggers errors
            KondutoInvalidEntityException exception = new KondutoInvalidEntityException(customer);

            Assert.AreEqual(String.Format("{0} is invalid: {1}", customer.ToString(), customer.GetError()),
                exception.Message, "incorrect expected exception message");
        }
    }
}
