using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebapiContas.Interfaces;
using WebapiContas.Models;

namespace WebapiContas.Repository
{
    public class OrdersRepository : IOrdersRepository
    {
        private readonly ContasContext _context;
        public OrdersRepository(ContasContext ctx)
        {
            _context = ctx;
        }

        public void Add(Order item)
        {
            _context.Order.Add(item);
            _context.SaveChanges();
        }


        public Order Find(long id)
        {
            return _context.Order.FirstOrDefault(u => u.IdOrder == id);
        }
        

        public IEnumerable<Order> GetAll()
        {
            return _context.Order.ToList();
        }

        public IEnumerable<Order> GetByIdClient(long idClient)
        {
            return _context.Order.Where(w => w.IdClient == idClient);
        }

        public void Remove(long id)
        {
            var entity = _context.Order.First(u => u.IdOrder == id);
            _context.Order.Remove(entity);
            _context.SaveChanges();
        }


        public void Update(Order item)
        {
            _context.Order.Update(item);
            _context.SaveChanges();
        }



    }
}
