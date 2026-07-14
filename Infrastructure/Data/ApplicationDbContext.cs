using Microsoft.EntityFrameworkCore;
using static ProductManagementAPI.Domain.Entities.Entities;

namespace ProductManagementAPI.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products => Set<Product>();
    }
}
