using Bills.Domain.Clients.Entities;
using System;
using System.Linq.Expressions;

namespace Bills.Domain.Clients.Queries
{
    public static class ClientQueries
    {
        public static Expression<Func<Client, bool>> GetClientById(Guid id)
        {
            return x => x.Id == id;
        }
    }
}
