using Microsoft.EntityFrameworkCore;

namespace WebapiContas.Models
{
    public class ContasContext : DbContext
    {
            public ContasContext(DbContextOptions<ContasContext> options)
                : base(options)
            {
            }

            public DbSet<Client> Client { get; set; }
            public DbSet<Order> Order { get; set; }

        }

    
}
 