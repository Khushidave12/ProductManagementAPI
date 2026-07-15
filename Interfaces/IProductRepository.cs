using static ProductManagementAPI.Domain.Entities.Entities;

namespace ProductManagementAPI.Repositories.Interfaces
{
    public interface IProductRepository
    {
        Task<Product?> GetByIdAsync(int id);
        Task AddAsync(Product product);  
        Task<Product?> GetByIdForUpdateAsync(int id);
        Task DeleteAsync(Product product);
        Task SaveChangesAsync();
    }
}