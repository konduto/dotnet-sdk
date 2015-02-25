using KdtSdk.Exceptions;
using KdtSdk.Models;
using KdtSdk.Utils;
using KdtTests.Factories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;

namespace KdtTests.Models
{
    [TestClass]
    public class KondutoCustomerTest
    {
        [TestMethod]
	    public void IsValidTest() 
        {
	        KondutoCustomer customer = new KondutoCustomer();
	        Assert.IsFalse(customer.IsValid(), "customer should be invalid without id");
	        customer.Id = "customer1";
	        Assert.IsFalse(customer.IsValid(), "customer should be invalid without name");
	        customer.Name = "Jose da Silva";
	        Assert.IsFalse(customer.IsValid(), "customer should be invalid without email");
	        customer.Email = "jose.silva@gmail.com";
	        Assert.IsTrue(customer.IsValid(), "customer should be valid");
        }

	    [TestMethod]
        public void SerializationTest()
        {
            KondutoCustomer customer = KondutoCustomerFactory.CompleteCustomer();
            String customerJSON = KondutoUtils.LoadJson<KondutoCustomer>(Properties.Resources.customer).ToJson();
            
            try 
            {
                var v = customer.ToJson();
                Assert.AreEqual(customerJSON, customer.ToJson(), "serialization failed");
            } 
            catch (KondutoInvalidEntityException e) {
                Debug.WriteLine(e.Message);
            }

            KondutoCustomer deserializedCustomer = KondutoModel.FromJson<KondutoCustomer>(customerJSON);
            Assert.AreEqual(customer, deserializedCustomer, "deserialization failed");
        }

        [TestMethod, ExpectedException(typeof(KondutoInvalidEntityException))]
        public void InvalidCustomerSerializationThrowsExceptionTest()
        {
            KondutoCustomer customer = new KondutoCustomer();
            customer.ToJson();
             // triggers invalid customer exception
        }
    }
}
