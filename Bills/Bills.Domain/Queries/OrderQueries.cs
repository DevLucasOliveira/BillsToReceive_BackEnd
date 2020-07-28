using Bills.Domain.Entities;
using System;
using System.Linq.Expressions;

namespace Bills.Domain.Queries
{
    public static class OrderQueries
    {
        public static Expression<Func<Order, bool>> GetOrderById(Guid id)
        {
            return x => x.Id == id;
        }
    }
}
