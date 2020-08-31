using Bills.Domain.Account.Entities;
using Bills.Domain.Orders.Entities;
using Bills.Shared.Entities;
using System;

namespace Bills.Domain.Clients.Entities
{
    public class Client : Entity
    {
        public Client()
        {

        }

        public Client(string name, string cellPhone)
        {
            Name = name;
            CellPhone = cellPhone;
            CreatedAt = DateTime.Now;
            Order = new Order();
        }

        public string Name { get; private set; }
        public string CellPhone { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public Order Order { get; private set; }
        public User User { get; private set; }

    }
}
