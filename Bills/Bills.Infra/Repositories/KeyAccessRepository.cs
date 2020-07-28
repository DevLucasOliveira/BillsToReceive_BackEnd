using Bills.Domain.Entities;
using Bills.Domain.Queries;
using Bills.Domain.Repositories;
using Bills.Infra.Contexts;
using Microsoft.EntityFrameworkCore;
using System;

namespace Bills.Infra.Repositories
{
    public class KeyAccessRepository : IKeyAccessRepository
    {
        private readonly DataContext _context;

        public KeyAccessRepository(DataContext context)
        {
            _context = context;
        }

        public void Create(KeyAccess keyAccess)
        {
            _context.KeyAccess.Add(keyAccess);
            _context.SaveChanges();
        }

        public void Remove(Guid id)
        {
            _context.KeyAccess.Find(KeyAccessQueries.GetKeyAccessById(id));
            _context.SaveChanges();
        }

        public void Update(KeyAccess keyAccess)
        {
            _context.Entry(keyAccess).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
