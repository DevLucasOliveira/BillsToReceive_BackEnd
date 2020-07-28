using Bills.Domain.Enums;
using Bills.Shared.Entities;
using System.Collections.Generic;

namespace Bills.Domain.Entities
{
    public class Order : Entity
    {
        public Order()
        {

        }

        public Order(List<OrderItem> items)
        {
            Items = items;
        }

        public List<OrderItem> Items { get; private set; }
        public EOrderStatus Status { get; private set; }


        public decimal Total()
        {
            decimal total = 0;
            foreach (var item in Items)
            {
                total += item.Total();
            }

            return total;
        }
    }
}
