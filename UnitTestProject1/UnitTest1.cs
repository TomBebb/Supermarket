using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Supermarket;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestOrder_AddsOrderItems()
        {
            var order = new Order();
            order.AddOrderItem();
        }
    }
}
