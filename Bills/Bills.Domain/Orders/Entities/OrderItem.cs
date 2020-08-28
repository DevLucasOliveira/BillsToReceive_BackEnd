using Bills.Shared.Entities;
using System;

namespace Bills.Domain.Orders.Entities
{
    public class OrderItem : Entity
    {
        public OrderItem()
        {

        }

        public OrderItem(string description, decimal price, int quantity)
        {
            Description = description;
            Price = price;
            Quantity = quantity;
            Date = DateTime.Now;
            Total = price*quantity;
        }

        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public int Quantity { get; private set; }
        public decimal Total { get; private set; }
        public DateTime Date { get; private set; }

    }
}
