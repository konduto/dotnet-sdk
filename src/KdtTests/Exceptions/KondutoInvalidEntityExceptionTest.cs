using KdtSdk.Exceptions;
using KdtSdk.Models;
using Xunit;

namespace KdtTests.Exceptions
{
    public class KondutoInvalidEntityExceptionTest
    {
        [Fact]
        public void InvalidEntityExceptionMessageTest()
        {
            KondutoCustomer customer = new KondutoCustomer();
            customer.IsValid(); // triggers errors
            KondutoInvalidEntityException exception = new KondutoInvalidEntityException(customer);

            Assert.Equal($"{customer} is invalid: {customer.GetError()}", exception.Message);
        }
    }
}
