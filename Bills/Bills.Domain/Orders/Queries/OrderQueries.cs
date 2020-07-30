using Bills.Domain.Orders.Entities;
using System;
using System.Linq.Expressions;

namespace Bills.Domain.Orders.Queries
{
    public static class OrderQueries
    {
        public static Expression<Func<Order, bool>> GetOrderById(Guid id)
        {
            return x => x.Id == id;
        }
    }
}
