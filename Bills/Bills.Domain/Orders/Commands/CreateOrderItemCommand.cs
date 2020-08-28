using Bills.Shared.Commands;
using Flunt.Notifications;
using System;

namespace Bills.Domain.Orders.Commands
{
    public class CreateOrderItemCommand : Notifiable, ICommand
    {


        public string Product { get; set; }
        public string Price { get; set; }
        public string Quantity { get; set; }
        public string Total { get; set; }
        public DateTime Date{ get; set; }


        public void Validate()
        {
            throw new System.NotImplementedException();
        }
    }
}
