using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Customer.Microservice.Context
{
    public interface IApplicationContext
    {
        DbSet<Models.Customer> Customers { get; set; }

        Task<int> SaveChanges();
    }
}