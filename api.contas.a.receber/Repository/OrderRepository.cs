using System.Collections.Generic;
using System.Linq;
using WebapiContas.Interfaces;
using WebapiContas.Models;
using WebapiContas.Models.Entities;

namespace WebapiContas.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ContasContext _context;
        private readonly IOrderItemRepository _orderItemRepository;
        public OrderRepository(ContasContext ctx, IOrderItemRepository orderItemRepository)
        {
            _context = ctx;
            _orderItemRepository = orderItemRepository;
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
            var orders = _context.Order.Where(w => w.IdClient == idClient);
            foreach(var order in orders)
            {
                order.Items = _orderItemRepository.GetByIdOrder(order.IdOrder).ToList();
            }
            return orders;
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
