using Bills.Domain.Admin.Entities;
using System;

namespace Bills.Domain.Admin.Repositories
{
    public interface IKeyAccessRepository
    {
        void Create(KeyAccess keyAccess);
        void Update(KeyAccess keyAccess);
        void Remove(Guid id);
    }
}
