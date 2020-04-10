using Microsoft.EntityFrameworkCore;

namespace WebapiContas.Models
{
    public class ContasContext : DbContext
    {
            public ContasContext(DbContextOptions<ContasContext> options)
                : base(options)
            {
            }

            public DbSet<Client> Clients { get; set; }
            public DbSet<Order> Orders { get; set; }

        }

    
}
 