using ProductManagementAPI.Application.DTOs;
using ProductManagementAPI.Infrastructure.Data;
using static ProductManagementAPI.Domain.Entities.Entities;

namespace ProductManagementAPI.Services
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext _context;

        public ProductService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Product> CreateAsync(CreateProductDto dto)
        {
            var product = new Product
            {
                ProductName = dto.ProductName,
                CreatedBy = "Admin",
                CreatedOn = DateTime.UtcNow
            };

            _context.Products.Add(product);

            await _context.SaveChangesAsync();

            return product;
        }
    }
}
