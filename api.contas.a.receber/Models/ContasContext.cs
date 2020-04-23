using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace WebapiContas.Models
{
    public class ContasContext : DbContext
    {
        protected readonly IConfiguration Configuration;
          public ContasContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to sql server database
            options.UseSqlServer(Configuration.GetConnectionString("Contasdb"));
        }

        public DbSet<Client> Client { get; set; }
            public DbSet<Order> Order { get; set; }
            public DbSet<User> User { get; set; }
         }

    
}
 