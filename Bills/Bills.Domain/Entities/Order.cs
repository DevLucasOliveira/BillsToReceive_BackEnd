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
    }
}
