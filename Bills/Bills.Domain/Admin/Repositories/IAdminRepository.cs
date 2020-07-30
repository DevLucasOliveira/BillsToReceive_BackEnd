using Bills.Domain.Admin.Entities;
using System;

namespace Bills.Domain.Admin.Repositories
{
    public interface IAdminRepository
    {
        void Create(UserAdmin admin);
        void Update(UserAdmin admin);
        void Remove(Guid id);
        UserAdmin GetAdmin(Guid id);
    }
}
