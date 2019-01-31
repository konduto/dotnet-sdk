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
    }
}