using Bills.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Bills.Infra.Contexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) {  }

        public DbSet<User> User { get; set; }
        public DbSet<Client> Client { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderItem> OrderItem { get; set; }
        public DbSet<Admin> Admin { get; set; }
        public DbSet<KeyAccess> KeyAccess { get; set; }

    }
}
