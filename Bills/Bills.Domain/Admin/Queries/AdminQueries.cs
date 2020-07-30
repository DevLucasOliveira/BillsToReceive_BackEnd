using Bills.Domain.Admin.Entities;
using System;
using System.Linq.Expressions;

namespace Bills.Domain.Admin.Queries
{
    public static class AdminQueries
    {
        public static Expression<Func<UserAdmin, bool>> GetAdminById(Guid id)
        {
            return x => x.Id == id;
        }
    }
}
