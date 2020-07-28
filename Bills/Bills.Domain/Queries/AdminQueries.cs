using Bills.Domain.Entities;
using System;
using System.Linq.Expressions;

namespace Bills.Domain.Queries
{
    public static class AdminQueries
    {
        public static Expression<Func<Admin, bool>> GetAdminById(Guid id)
        {
            return x => x.Id == id;
        }
    }
}
