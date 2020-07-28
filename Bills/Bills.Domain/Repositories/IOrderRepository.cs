using Bills.Domain.Entities;
using System;

namespace Bills.Domain.Repositories
{
    public interface IOrderRepository
    {
        void Create(Order order);
        void Update(Order order);
        void Remove(Guid id);
    }
}
