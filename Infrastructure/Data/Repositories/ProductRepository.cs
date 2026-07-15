using Microsoft.EntityFrameworkCore;
using ProductManagementAPI.Repositories.Interfaces;
using static ProductManagementAPI.Domain.Entities.Entities;

namespace ProductManagementAPI.Infrastructure.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

 
        public async Task<Product?> GetByIdAsync(int id)
        {
            return await _context.Products
                .AsNoTracking()
                .Include(p => p.Items)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

       
        public async Task<Product?> GetByIdForUpdateAsync(int id)
        {
            return await _context.Products
                .Include(p => p.Items)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task AddAsync(Product product)
        {
            await _context.Products.AddAsync(product);
        }

      
        public Task DeleteAsync(Product product)
        {
            _context.Products.Remove(product);
            return Task.CompletedTask;
        }

       
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
