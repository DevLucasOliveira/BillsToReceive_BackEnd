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
            _context.Client.Add(client);
            _context.SaveChanges();
        }

        public void AddOrder(Order item)
        {
            _context.Order.Add(item);
            _context.SaveChanges();
        }

        public Client FindClient(long id)
        {
            return _context.Client.FirstOrDefault(u => u.IdClient == id);
        }

        public Order FindOrder(long id)
        {
            return _context.Order.FirstOrDefault(u => u.IdOrder == id);
        }

        public IEnumerable<Client> GetAllClient()
        {
            return _context.Client.ToList();
        }

        public IEnumerable<Order> GetAllOrder()
        {
            return _context.Order.ToList();
        }

        public void RemoveClient(long id)
        {
            var entity = _context.Client.First(u => u.IdClient == id);
            _context.Client.Remove(entity);
            _context.SaveChanges();

        }

        public void RemoveOrder(long id)
        {
            var entity = _context.Order.First(u => u.IdOrder == id);
            _context.Order.Remove(entity);
            _context.SaveChanges();
        }

        public void UpdateClient(Client client)
        {
            _context.Client.Update(client);
            _context.SaveChanges();
        }

        public void UpdateOrder(Order item)
        {
            _context.Order.Update(item);
            _context.SaveChanges();
        }
    }
}
