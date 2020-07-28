using Bills.Domain.Entities;
using Bills.Domain.Queries;
using Bills.Domain.Repositories;
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

        public void Create(Admin admin)
        {
            _context.Admin.Add(admin);
            _context.SaveChanges();
        }

        public Admin GetAdmin(Guid id)
        {
            return _context.Admin.AsNoTracking().FirstOrDefault(AdminQueries.GetAdminById(id));
        }

        public void Remove(Guid id)
        {
            var entity = _context.Admin.Find(AdminQueries.GetAdminById(id));
            _context.Admin.Remove(entity);
            _context.SaveChanges();
        }

        public void Update(Admin admin)
        {
            _context.Entry(admin).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
