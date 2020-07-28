using Bills.Domain.Entities;
using System;
using System.Linq.Expressions;

namespace Bills.Domain.Queries
{
    public static class ClientQueries
    {
        public static Expression<Func<Client, bool>> GetClientById(Guid id)
        {
            return x => x.Id == id;
        }
    }
}
