
using System;
using System.Collections.Generic;
using System.Text;

namespace Supermarket
{
    public static class Prompter
    {
        public static Order PromptOrder(this Supermarket market)
        {
            var order = new Order();
            bool orderReady = false;
            while(!orderReady)
            {
                Console.WriteLine($"Order total so far: {order.Total:C}");
                var action = Prompt<string>(@"Enter action:
'add' to add item to order
'buy' to buy items in order
'show' to show order so far");
                switch(action.ToLower())
                {
                    case "add":
                        var orderItem = PromptOrderItem(market);
                        if (orderItem == null)
                            continue;
                        order.AddOrderItem(orderItem);
                        break;
                    case "buy":
                        orderReady = true;
                        break;
                    case "show":
                        Console.WriteLine(order);
                        break;
                    default:
                        Console.Error.WriteLine("Unknown action");
                        break;
                }
            }
            return order;
        }
        public static IOrderItem PromptOrderItem(this Supermarket market)
        {
            foreach(var mItem in market.Items.Values)
            {
                Console.WriteLine(mItem);
            }
            var refNo = Prompt<string>("Item Ref No.");
            if (!market.Items.ContainsKey(refNo))
            {
                Console.WriteLine($"No item with reference no.: {refNo}");
                return null;
            }

            var item = market.Items[refNo];
            Console.WriteLine($"{item} selected");
            IOrderItem orderItem = null;
            switch(item)
            {
                case QuantifiableItem quantifiableItem:

                    var quantity = Prompt<int>("Item quantity");

                    if (quantity < 0)
                    {
                        Console.Error.WriteLine("Item quantity must be positive integer");
                        return null;
                    }

                    orderItem = new QuanitifiableOrderItem(quantity, quantifiableItem);
                    if (!orderItem.IsInStock())
                    {
                        Console.Error.WriteLine($"Not enough in stock! There is {quantifiableItem.NumberInStock} of this item in stock");
                        orderItem = null;
                    }
                    break;
                case WeighableItem weighableItem:
                    var weight = Prompt<double>("Item weight (kg)");


                    orderItem = new WeighableOrderItem(weight, weighableItem);
                    if (!orderItem.IsInStock())
                    {
                        Console.Error.WriteLine($"Not enough in stock! There is {weighableItem.KgsInStock} kg of this item in stock");
                        orderItem = null;
                    }
                    break;
                default:
                    break;
            }
            return orderItem;
        }

        public static bool PromptBool(string prompt)
        {
            Console.Write($"{prompt} (yes / no): ");
            var line = Console.ReadLine();
            return line.Equals("yes", StringComparison.CurrentCultureIgnoreCase);
        }
        public static T Prompt<T>(string prompt)
        {
            Console.Write($"{prompt}: ");
            var line = Console.ReadLine();

            return (T) Convert.ChangeType(line, typeof(T));
        }
    }
}
