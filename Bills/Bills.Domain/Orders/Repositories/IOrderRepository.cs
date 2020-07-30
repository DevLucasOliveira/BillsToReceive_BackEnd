using Bills.Domain.Orders.Entities;
using System;

namespace Bills.Domain.Orders.Repositories
{
    public interface IOrderRepository
    {
        void Create(Order order);
        void Update(Order order);
        void Remove(Guid id);
    }
}
