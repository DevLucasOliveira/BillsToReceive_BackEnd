using Bills.Shared.Commands;
using Flunt.Notifications;
using Flunt.Validations;
using System;

namespace Bills.Domain.Orders.Commands
{
    public class CreateOrderItemCommand : Notifiable, ICommand
    {
        public CreateOrderItemCommand(string product, decimal price, int quantity, Guid client)
        {
            Product = product;
            Price = price;
            Quantity = quantity;
            Client = client;
        }

        public string Product { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public Guid Client { get; set; }


        public void Validate()
        {
            AddNotifications(
                new Contract()
                .Requires()
                .IsEmpty(Client, "Client", "Id do cliente não pode ser nulo")
                );
        }
    }
}
