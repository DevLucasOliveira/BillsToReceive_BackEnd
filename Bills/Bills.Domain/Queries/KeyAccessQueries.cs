using Bills.Domain.Entities;
using System;
using System.Linq.Expressions;

namespace Bills.Domain.Queries
{
    public static class KeyAccessQueries
    {
        public static Expression<Func<KeyAccess, bool>> GetKeyAccessById(Guid id)
        {
            return x => x.Id == id;
        }
    }
}
