using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Customer.Microservice.Context
{
    public class ApplicationContext : DbContext, IApplicationContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }
        public async Task<int> SaveChanges()
        {
            return await base.SaveChangesAsync();
        }
        public DbSet<Models.Customer> Customers { get; set; }
    }
}
