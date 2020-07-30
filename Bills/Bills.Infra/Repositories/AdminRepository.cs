using Bills.Domain.Admin.Entities;
using Bills.Domain.Admin.Queries;
using Bills.Domain.Admin.Repositories;
using Bills.Infra.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Bills.Infra.Repositories
{
    public class AdminRepository : IAdminRepository
    {
        private readonly DataContext _context;

        public AdminRepository(DataContext context)
        {
            _context = context;
        }

        public void Create(UserAdmin admin)
        {
            _context.Admin.Add(admin);
            _context.SaveChanges();
        }

        public UserAdmin GetAdmin(Guid id)
        {
            return _context.Admin.AsNoTracking().FirstOrDefault(AdminQueries.GetAdminById(id));
        }

        public void Remove(Guid id)
        {
            var entity = _context.Admin.Find(AdminQueries.GetAdminById(id));
            _context.Admin.Remove(entity);
            _context.SaveChanges();
        }

        public void Update(UserAdmin admin)
        {
            _context.Entry(admin).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
