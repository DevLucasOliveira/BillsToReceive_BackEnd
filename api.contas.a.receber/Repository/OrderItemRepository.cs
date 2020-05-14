using System.Collections.Generic;
using System.Linq;
using WebapiContas.Interfaces;
using WebapiContas.Models;

namespace WebapiContas.Repository
{
    public class OrderItemRepository : IOrderItemRepository
    {
        private readonly ContasContext _context;
        public OrderItemRepository(ContasContext ctx)
        {
            _context = ctx;
        }

        public void Add(OrderItem item)
        {
            _context.OrderItem.Add(item);
            _context.SaveChanges();
        }


        public OrderItem Find(long id)
        {
            return _context.OrderItem.FirstOrDefault(u => u.IdOrderItem == id);
        }
        

        public IEnumerable<OrderItem> GetAll()
        {
            return _context.OrderItem.ToList();
        }

        public IEnumerable<OrderItem> GetByIdOrder(long idOrder)
        {
            return _context.OrderItem.Where(w => w.IdOrder == idOrder);
        }

        public IEnumerable<OrderItem> GetByIdOrderItem(long idOrderItem)
        {
            return _context.OrderItem.Where(w => w.IdOrderItem == idOrderItem);
        }

        public void Remove(long id)
        {
            var entity = _context.OrderItem.First(u => u.IdOrderItem == id);
            _context.OrderItem.Remove(entity);
            _context.SaveChanges();
        }


        public void Update(OrderItem item)
        {
            _context.OrderItem.Update(item);
            _context.SaveChanges();
        }



    }
}
