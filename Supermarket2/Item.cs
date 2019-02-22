using System;
using System.Linq;

namespace Supermarket
{
    public abstract class Item
    {
        public static readonly string[] TypeNames = {
            WeighableItem.ItemTypeName,
            QuantifiableItem.ItemTypeName
        };
        public string Name, Description;
        public long RefNo;

        public Item(long refNo, string name, string description)
        {
            RefNo = refNo;
            Name = name;
            Description = description;
        }

        public override string ToString()
        {
            return $"{Name} ({RefNo}): {Description}";
        }
    }

    public class QuantifiableItem : Item
    {
        public const string ItemTypeName  = "Quantifiable";

        public decimal PricePerEach;

        public long NumberInStock;

        public QuantifiableItem(long refNo, string name, string description, decimal pricePerEach, long numberInStock): base(refNo, name, description)
        {
            PricePerEach = pricePerEach;
            NumberInStock = numberInStock;
        }

        public decimal CalculatePrice(int quantity)
            => PricePerEach * quantity;

        public override string ToString()
        {
            return $"{base.ToString()} ({PricePerEach:C} each, {NumberInStock} in stock)";
        }

        public long StockAfterOrder(Order order)
        {
            var totalStockInOrder = order.OrderItems.Select(item => item.Item == this &&
                 item is QuanitifiableOrderItem qOrder ? qOrder.Quantity : 0).Sum();
            return NumberInStock - totalStockInOrder;
        }
    }
    public class WeighableItem : Item
    {
        public const string ItemTypeName = "Weighable";
        public decimal PricePerKg;

        public double KgsInStock;

        public WeighableItem(long refNo, string name, string description, decimal pricePerKg, double kgsInStock = 0) : base(refNo, name, description)
        {
            PricePerKg = pricePerKg;
            KgsInStock = kgsInStock;
        }


        public decimal CalculatePrice(double kgs) =>
            (decimal) kgs * PricePerKg;


        public override string ToString()
        {
            return $"{base.ToString()} ({PricePerKg:C} per kg, {KgsInStock:0.##} kg in stock)";
        }



        public double KgsAfterOrder(Order order)
        {
            var totalKgsInOrder = order.OrderItems.Select(item => item.Item == this &&
                 item is WeighableOrderItem wOrder ? wOrder.Weight : 0).Sum();
            return KgsInStock - totalKgsInOrder;
        }
    }

}