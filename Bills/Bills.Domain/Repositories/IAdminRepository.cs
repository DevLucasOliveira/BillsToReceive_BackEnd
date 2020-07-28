using Bills.Domain.Entities;
using System;

namespace Bills.Domain.Repositories
{
    public interface IAdminRepository
    {
        void Create(Admin admin);
        void Update(Admin admin);
        void Remove(Guid id);
        Admin GetAdmin(Guid id);
    }
}
