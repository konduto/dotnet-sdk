using KdtSdk.Exceptions;
using KdtSdk.Models;
using KdtSdk.Utils;
using KdtTests.Factories;
using System;
using System.Diagnostics;
using Xunit;
using KdtTests.Properties;

namespace KdtTests.Models
{
    public class KondutoCustomerTest
    {
	    [Fact]
        public void SerializationTest()
        {
            var customer = KondutoCustomerFactory.CompleteCustomer();
            var customerJSON = KondutoUtils.LoadJson<KondutoCustomer>(Resources.Load("customer")).ToJson();
            Assert.Equal(customerJSON, customer.ToJson());
            var deserializedCustomer = KondutoModel.FromJson<KondutoCustomer>(customerJSON);
            Assert.Equal(customer, deserializedCustomer);
        }
    }
}