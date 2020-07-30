using Bills.Domain.Orders.Entities;
using Bills.Domain.Orders.Queries;
using Bills.Domain.Orders.Repositories;
using Bills.Infra.Contexts;
using Microsoft.EntityFrameworkCore;
using System;

namespace Bills.Infra.Repositories
{
    public class OrderItemRepository : IOrderItemRepository
    {
        private readonly DataContext _context;

        public OrderItemRepository(DataContext context)
        {
            _context = context;
        }

        public void Create(OrderItem orderItem)
        {
            _context.OrderItem.Add(orderItem);
            _context.SaveChanges();
        }

        public void Remove(Guid id)
        {
            var entity = _context.OrderItem.Find(OrderItemQueries.GetOrderItemById(id));
            _context.OrderItem.Remove(entity);
            _context.SaveChanges();
        }

        public void Update(OrderItem orderItem)
        {
            _context.Entry(orderItem).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
