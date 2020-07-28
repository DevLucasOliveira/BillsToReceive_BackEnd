using Bills.Domain.Entities;
using System;

namespace Bills.Domain.Repositories
{
    public interface IOrderItemRepository
    {
        void Create(OrderItem orderItem);
        void Update(OrderItem orderItem);
        void Remove(Guid id);
    }
}
