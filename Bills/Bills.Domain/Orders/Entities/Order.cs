using Bills.Domain.Orders.Enums;
using Bills.Shared.Entities;
using System.Collections.Generic;

namespace Bills.Domain.Orders.Entities
{
    public class Order : Entity
    {

        public Order()
        {
            Items = new List<OrderItem>();
        }

        public List<OrderItem> Items { get; private set; }
        public EOrderStatus Status { get; private set; }


        public decimal Total()
        {
            decimal total = 0;
            foreach (var item in Items)
            {
                total += item.Total;
            }

            return total;
        }

        public IList<OrderItem> AddItems(OrderItem item)
        {
            if (item.Valid)
                Items.Add(item);

            return Items;
        }
    }
}
