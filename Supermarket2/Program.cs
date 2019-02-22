using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Supermarket
{

    public static class MyRandom
    {

        private static Random rng = new Random();

        public static string MakeRefNo(int length)
        {
            var builder = new StringBuilder();
            for(int i = 0; i < length; i++)
            {
                builder.Append('0' + rng.Next(10));
            }
            return builder.ToString();
        }
    }

    public class Supermarket
    {
        /**
         * Items, stored by reference number.
         **/
        private Dictionary<long, Item> items;

        public Supermarket()
        {
            items = new Dictionary<long, Item>(8);
        }

        public void SetupDefaults()
        {
            AddItem(new WeighableItem(1, "Apple", "Green fruit", 0.02m, 10));
            AddItem(new WeighableItem(2, "Orange", "Orange fruit", 0.05m, 5));
            AddItem(new QuantifiableItem(3, "PS4", "Console", 350m, 20));
        }

        public IReadOnlyDictionary<long, Item> Items => items;

        public void AddItem(Item item)
        {
            items.Add(item.RefNo, item);
        }
        public void RemoveItem(Item item)
        {
            items.Remove(item.RefNo);
        }
        public long NextRefNo()
        {
            var max = items.Keys.Max();
            return max + 1;
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            var market = new Supermarket();
            market.SetupDefaults();
            while(true)
            {
                var order = market.PromptOrder();
                order.DoOrder();
                Console.WriteLine();
                Console.WriteLine("Order done");
            }
        }
    }
}
