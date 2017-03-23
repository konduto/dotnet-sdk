using KdtSdk.Exceptions;
using KdtSdk.Models;
using KdtSdk.Utils;
using KdtTests.Factories;
using System;
using Xunit;
using KdtTests.Properties;

namespace KdtTests.Models
{
    public class KondutoOrderTest
    {
        [Fact]
	    public void IsValidTest()
        {
		    KondutoOrder order = new KondutoOrder();
            Assert.False(order.IsValid(), "order should be invalid without id");

		    order.Id = "order1";
		    Assert.False(order.IsValid(), "order should be invalid without total amount");

		    order.TotalAmount = 120.1;
		    Assert.False(order.IsValid(), "order should be invalid without customer");

		    order.Customer = KondutoCustomerFactory.BasicCustomer();
		    Assert.True(order.IsValid(), "order should be valid");
		    Assert.True(order.GetError() == null, "order errors should be empty");
	    }

	    [Fact]
	    public void SerializationTest() 
        {
		    KondutoOrder order = KondutoOrderFactory.completeOrder();
		    String orderJSON = KondutoUtils.LoadJson<KondutoOrder>(Resources.Load("order")).ToJson();

		    try
            {
                Assert.Equal(orderJSON, order.ToJson());
		    }
            catch (KondutoInvalidEntityException e)
            {
			    Assert.True(false, "order should be valid");
		    }

		    KondutoOrder deserializedOrder = KondutoModel.FromJson<KondutoOrder>(orderJSON);
            Assert.True(order.Equals(deserializedOrder), "deserialization failed");
	    }

        [Fact]
        public void SerializationTestWithShoppingAndFlight()
        {
            KondutoOrder order = KondutoOrderFactory.completeOrder();
            order.Travel = KondutoFlightFactory.CreateFlight();

            try
            {
                order.ToJson();
                Assert.True(false, "order should be invalid");
            }
            catch (KondutoInvalidEntityException e)
            {
                //ok
            }

            order = KondutoOrderFactory.completeOrder();
            order.Travel = KondutoFlightFactory.CreateFlight();
            order.ShoppingCart = null;
            //ok
        }

	    [Fact/*, ExpectedException(typeof(KondutoInvalidEntityException))*/]
	    public void invalidOrderSerializationThrowsExceptionTest() 
        {
            Assert.True(false, "not implemented");
		    KondutoOrder order = new KondutoOrder();
		    order.ToJson(); // triggers invalid customer exception
	    }
    }
}
