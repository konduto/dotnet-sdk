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
            KondutoCustomer customer = KondutoCustomerFactory.CompleteCustomer();
            String customerJSON = KondutoUtils.LoadJson<KondutoCustomer>(Resources.Load("customer")).ToJson();
            
            try 
            {
                var v = customer.ToJson();
                Assert.Equal(customerJSON, customer.ToJson());
            } 
            catch (KondutoInvalidEntityException e) {
                Debug.WriteLine(e.Message);
            }

            KondutoCustomer deserializedCustomer = KondutoModel.FromJson<KondutoCustomer>(customerJSON);
            Assert.Equal(customer, deserializedCustomer);
        }
    }
}