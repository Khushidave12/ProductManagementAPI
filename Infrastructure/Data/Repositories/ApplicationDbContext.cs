using Microsoft.EntityFrameworkCore;
using static ProductManagementAPI.Domain.Entities.Entities;

namespace ProductManagementAPI.Infrastructure.Data.Repositories
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products => Set<Product>();
        public DbSet<Item> Items => Set<Item>(); 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            
            modelBuilder.Entity<Product>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<Product>()
                .Property(p => p.ProductName)
                .IsRequired()
                .HasMaxLength(255);

           
            modelBuilder.Entity<Item>()
                .HasKey(i => i.Id);

            modelBuilder.Entity<Item>()
                .HasOne(i => i.Product)
                .WithMany(p => p.Items)
                .HasForeignKey(i => i.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            
            modelBuilder.Entity<Product>()
                .HasIndex(p => p.ProductName);

            modelBuilder.Entity<Item>()
                .HasIndex(i => i.ProductId);
        }
    }
}