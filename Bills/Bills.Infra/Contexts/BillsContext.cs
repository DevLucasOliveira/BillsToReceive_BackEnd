using Bills.Domain.Account.Entities;
using Bills.Domain.Admin.Entities;
using Bills.Domain.Clients.Entities;
using Bills.Domain.Orders.Entities;
using Flunt.Notifications;
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
        public DbSet<UserAdmin> Admin { get; set; }
        public DbSet<KeyAccess> KeyAccess { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<Notification>();
        }


    }
}
