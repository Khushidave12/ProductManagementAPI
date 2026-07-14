using ProductManagementAPI.Application.DTOs;
using static ProductManagementAPI.Domain.Entities.Entities;

namespace ProductManagementAPI.Services
{
    public interface IProductService
    {
        Task<Product> CreateAsync(CreateProductDto dto);
    }
}
