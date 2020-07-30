using Bills.Domain.Clients.Entities;
using Bills.Domain.Clients.Queries;
using Bills.Domain.Clients.Repositories;
using Bills.Infra.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Bills.Infra.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly DataContext _context;

        public ClientRepository(DataContext context)
        {
            _context = context;
        }

        public void Create(Client client)
        {
            _context.Client.Add(client);
            _context.SaveChanges();
        }

        public Client GetClientById(Guid id)
        {
            return _context.Client.AsNoTracking().FirstOrDefault(ClientQueries.GetClientById(id));
        }

        public void Remove(Guid id)
        {
            var entity = _context.Client.Find(ClientQueries.GetClientById(id));
            _context.SaveChanges();
        }

        public void Update(Client client)
        {
            _context.Entry(client).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
