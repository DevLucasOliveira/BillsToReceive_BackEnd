using Bills.Domain.Orders.Entities;
using Bills.Domain.Orders.Queries;
using Bills.Domain.Orders.Repositories;
using Bills.Infra.Contexts;
using Microsoft.EntityFrameworkCore;
using System;

namespace Bills.Infra.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DataContext _context;

        public OrderRepository(DataContext context)
        {
            _context = context;
        }

        public void Create(Order order)
        {
            _context.Order.Add(order);
            _context.SaveChanges();
        }

        public void Remove(Guid id)
        {
            var entity = _context.Order.Find(OrderQueries.GetOrderById(id));
            _context.Order.Remove(entity);
            _context.SaveChanges();
        }

        public void Update(Order order)
        {
            _context.Entry(order).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
