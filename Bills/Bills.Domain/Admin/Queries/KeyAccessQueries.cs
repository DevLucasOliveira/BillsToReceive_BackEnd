using Bills.Domain.Admin.Entities;
using System;
using System.Linq.Expressions;

namespace Bills.Domain.Admin.Queries
{
    public static class KeyAccessQueries
    {
        public static Expression<Func<KeyAccess, bool>> GetKeyAccessById(Guid id)
        {
            return x => x.Id == id;
        }
    }
}
