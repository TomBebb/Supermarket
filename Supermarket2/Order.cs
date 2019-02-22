﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Supermarket
{
    public class Order
    {
        const int RefNumLen = 10;

        public string OrderRefNo;

        private List<IOrderItem> orderItems;

        public Order()
        {
            OrderRefNo = MyRandom.MakeRefNo(RefNumLen);
            orderItems = new List<IOrderItem>(16);
        }

        public IReadOnlyList<IOrderItem> OrderItems => orderItems;

        public void AddOrderItem(IOrderItem item)
        {
            IOrderItem otherItem = orderItems.Where(oItem => item.Item == item.Item).FirstOrDefault();
            
            if(otherItem == null)
                orderItems.Add(item);
            else if(otherItem is QuanitifiableOrderItem qOtherItem && item is QuanitifiableOrderItem qItem)
            {
                qOtherItem.Quantity += qItem.Quantity;
            }
        }
        public override string ToString()
        {
            var builder = new StringBuilder();


            foreach (var item in OrderItems)
                builder.Append($"{item}\n");
            return builder.ToString();
        }

        public bool DoOrder()
        {
            foreach(var orderItem in orderItems)
            {
                if (!orderItem.DoOrder())
                    return false;
            }
            return true;
        }

        public decimal Total => orderItems.Select(item => item.Price).Sum();
    }
}
