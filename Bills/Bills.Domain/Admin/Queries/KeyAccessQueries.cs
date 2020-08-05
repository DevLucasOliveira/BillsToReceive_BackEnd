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

        public static Expression<Func<KeyAccess, bool>> ExistsKeyAccess(string keyAccess)
        {
            return x => x.Key == keyAccess && x.ValidKey == true && x.User == false;
        }

        public static Expression<Func<KeyAccess, bool>> GetKeyAccess(string keyAccess)
        {
            return x => x.Key == keyAccess;
        }

        public static Expression<Func<KeyAccess, bool>> ValidKeyAccess(string keyAccess)
        {
            return x => x.Key == keyAccess && x.ValidKey == true && x.User == true;
        }

    }
}
