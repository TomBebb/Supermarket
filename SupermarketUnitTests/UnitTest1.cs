using Microsoft.VisualStudio.TestTools.UnitTesting;
using Supermarket;

namespace SupermarketUnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [DataRow("100.0", 1)]
        [DataRow("10000", 1)]
        [DataRow("1", 0)]
        [DataRow("3", 2)]
        [TestMethod]
        public void QuantifiableOrderItem_HasCorrectPrice(string pricePerEachText, int quantity)
        {
            decimal pricePerEach = decimal.Parse(pricePerEachText);
            var item = new QuantifiableItem("refNo", "name", "dec", pricePerEach, 0);
            var orderItem = new QuanitifiableOrderItem(quantity, item);

            Assert.AreEqual(orderItem.Price, pricePerEach * quantity);
        }

        [DataRow(4, 5)]
        [DataRow(4, 10)]
        [DataRow(4, 4)]
        [DataRow(4, -10)]
        [DataRow(-4, -10)]
        [TestMethod]
        public void QuantifiableOrderItem_QuantityAlwaysPositive(int quantityInStock, int orderQuantity, bool shouldProcess)
        {
            var item = new QuantifiableItem("refNo", "name", "dec", 3.0m, quantityInStock);
            var orderItem = new QuanitifiableOrderItem(orderQuantity, item);

            Assert.IsTrue(orderItem.DoOrder() == shouldProcess);

            Assert.IsTrue(item.NumberInStock >= 0);
        }
    }
}
