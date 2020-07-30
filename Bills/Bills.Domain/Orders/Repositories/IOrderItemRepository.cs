using Bills.Domain.Orders.Entities;
using System;

namespace Bills.Domain.Orders.Repositories
{
    public interface IOrderItemRepository
    {
        void Create(OrderItem orderItem);
        void Update(OrderItem orderItem);
        void Remove(Guid id);
    }
}
