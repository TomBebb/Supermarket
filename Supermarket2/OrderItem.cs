using System;
using System.Collections.Generic;
using System.Text;

namespace Supermarket
{
    public interface IOrderItem
    {
        Item Item { get; }
        Decimal Price { get; }
        bool IsInStock();
        bool DoOrder();
    }

    public class QuanitifiableOrderItem : IOrderItem
    {
        public int Quantity;

        private QuantifiableItem item;

        public QuanitifiableOrderItem(int quantity, QuantifiableItem item)
        {
            this.Quantity = quantity;
            this.item = item;
        }

        public Item Item => item;

        public decimal Price => item.CalculatePrice(Quantity);

        public bool DoOrder()
        {
            var inStock = IsInStock();
            if(inStock)
                item.NumberInStock -= Quantity;
            return inStock;
        }

        public bool IsInStock()
        {
            return item.NumberInStock >= Quantity;
        }

        public override string ToString()
        {
            return $"{item} × {Quantity} = {Price:C}";
        }
    }

    public class WeighableOrderItem : IOrderItem
    {
        public double Weight;

        private WeighableItem item;

        public WeighableOrderItem(double weight, WeighableItem item)
        {
            Weight = weight;
            this.item = item;
        }

        public Item Item => item;

        public decimal Price => item.CalculatePrice(Weight);

        public bool DoOrder()
        {
            var inStock = IsInStock();
            if(inStock)
                item.KgsInStock -= Weight;
            return inStock;
        }

        public bool IsInStock()
        {
            return item.KgsInStock >= Weight;
        }

        public override string ToString()
        {
            return $"{Weight}kg of {item} = {Price:C}";
        }
    }
}
