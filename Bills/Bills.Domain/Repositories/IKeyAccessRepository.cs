using Bills.Domain.Entities;
using System;

namespace Bills.Domain.Repositories
{
    public interface IKeyAccessRepository
    {
        void Create(KeyAccess keyAccess);
        void Update(KeyAccess keyAccess);
        void Remove(Guid id);
    }
}
