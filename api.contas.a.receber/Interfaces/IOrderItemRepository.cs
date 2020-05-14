using System.Collections.Generic;
using WebapiContas.Models;

namespace WebapiContas.Interfaces
{
    public interface IOrderItemRepository
    {
        void Add(OrderItem item);
        IEnumerable<OrderItem> GetAll();
        OrderItem Find(long id);
        IEnumerable<OrderItem> GetByIdOrderItem(long idOrderItem);
        IEnumerable<OrderItem> GetByIdOrder(long idOrder);
        void Remove(long id);
        void Update(OrderItem item);

    }
}
