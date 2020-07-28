using Bills.Shared.Entities;
using System;

namespace Bills.Domain.Entities
{
    public class OrderItem : Entity
    {
        public OrderItem()
        {

        }

        public OrderItem(string description, decimal price, int quantity, DateTime date, decimal total)
        {
            Description = description;
            Price = price;
            Quantity = quantity;
            Date = date;
        }

        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public int Quantity { get; private set; }
        public DateTime Date { get; private set; }

        public decimal Total()
        {
            return Price * Quantity;
        }
    }
}
