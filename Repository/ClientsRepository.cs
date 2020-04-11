using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebapiContas.Interfaces;
using WebapiContas.Models;

namespace WebapiContas.Repository
{
    public class ClientsRepository : IClientsRepository
    {
        private readonly ContasContext _context;
        public ClientsRepository(ContasContext ctx)
        {
            _context = ctx;
        }

        public void Add(Client client)
        {
            _context.Client.Add(client);
            _context.SaveChanges();
        }

        public Client Find(long id)
        {
            return _context.Client.FirstOrDefault(u => u.IdClient == id);
        }

        public IEnumerable<Client> GetAll()
        {
            return _context.Client.ToList();
        }

        public void Remove(long id)
        {
            var entity = _context.Client.First(u => u.IdClient == id);
            _context.Client.Remove(entity);
            _context.SaveChanges();

        }

        public void Update(Client client)
        {
            _context.Client.Update(client);
            _context.SaveChanges();
        }

    }
}
