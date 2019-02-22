using System;
using System.Collections.Generic;
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
        private Dictionary<string, Item> items;

        public Supermarket()
        {
            items = new Dictionary<string, Item>(8);
        }

        public void SetupDefaults()
        {
            AddItem(new WeighableItem("00001", "Apple", "Green fruit", 0.02m, 10));
            AddItem(new WeighableItem("00002", "Orange", "Orange fruit", 0.05m, 5));
            AddItem(new QuantifiableItem("00003", "PS4", "Console", 350m, 20));
        }

        public IReadOnlyDictionary<string, Item> Items => items;

        public void AddItem(Item item)
        {
            items.Add(item.RefNo, item);
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
