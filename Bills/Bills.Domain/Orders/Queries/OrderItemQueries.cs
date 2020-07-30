using Bills.Domain.Orders.Entities;
using System;
using System.Linq.Expressions;

namespace Bills.Domain.Orders.Queries
{
    public static class OrderItemQueries
    {
        public static Expression<Func<OrderItem, bool>> GetOrderItemById(Guid id)
        {
            return x => x.Id == id;
        }
    }
}
