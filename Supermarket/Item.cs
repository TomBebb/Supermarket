namespace Supermarket
{
    public abstract class Item
    {
        public string RefNo, Name, Description;

        public Item(string refNo, string name, string description)
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
        public decimal PricePerEach;

        public long NumberInStock;

        public QuantifiableItem(string refNo, string name, string description, decimal pricePerEach, long numberInStock): base(refNo, name, description)
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
    }
    public class WeighableItem : Item
    {
        public decimal PricePerKg;

        public double KgsInStock;

        public WeighableItem(string refNo, string name, string description, decimal pricePerKg, double kgsInStock = 0) : base(refNo, name, description)
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
    }
}