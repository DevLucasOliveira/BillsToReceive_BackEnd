using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebapiContas.Models;

namespace WebapiContas.Repository
{
    public class ContasRepository : IContasRepository
    {
        private readonly ContasContext _context;
        public ContasRepository(ContasContext ctx)
        {
            _context = ctx;
        }

        public void AddClient(Client client)
        {
            _context.Clients.Add(client);
            _context.SaveChanges();
        }

        public void AddOrder(Order item)
        {
            _context.Orders.Add(item);
            _context.SaveChanges();
        }

        public Client FindClient(long id)
        {
            return _context.Clients.FirstOrDefault(u => u.IdClient == id);
        }

        public Order FindOrder(long id)
        {
            return _context.Orders.FirstOrDefault(u => u.IdOrder == id);
        }

        public IEnumerable<Client> GetAllClient()
        {
            return _context.Clients.ToList();
        }

        public IEnumerable<Order> GetAllOrder()
        {
            return _context.Orders.ToList();
        }

        public void RemoveClient(long id)
        {
            var entity = _context.Clients.First(u => u.IdClient == id);
            _context.Clients.Remove(entity);
            _context.SaveChanges();

        }

        public void RemoveOrder(long id)
        {
            var entity = _context.Orders.First(u => u.IdOrder == id);
            _context.Orders.Remove(entity);
            _context.SaveChanges();
        }

        public void UpdateClient(Client client)
        {
            _context.Clients.Update(client);
            _context.SaveChanges();
        }

        public void UpdateOrder(Order item)
        {
            _context.Orders.Update(item);
            _context.SaveChanges();
        }
    }
}
