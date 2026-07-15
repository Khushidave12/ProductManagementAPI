using ProductManagementAPI.Application.DTOs;
using static ProductManagementAPI.Domain.Entities.Entities;

namespace ProductManagementAPI.Services
{
    public interface IProductService
    {
        Task<Product?> GetByIdAsync(int id);  
    
        Task<Product> CreateAsync(CreateProductDto dto);
        Task<bool> UpdateAsync(int id, UpdateProductDto dto);
        Task<bool> DeleteAsync(int id);
    }
}