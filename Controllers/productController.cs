using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductManagementAPI.Application.DTOs;
using ProductManagementAPI.Services;
using static ProductManagementAPI.Domain.Entities.Entities;

namespace ProductManagementAPI.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ProductController : ControllerBase 
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

      
    

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)  
        {
           
            return Ok(new Product());
        }

        [HttpPost("createProduct")]
        public async Task<IActionResult> Create(CreateProductDto dto)
        {
            var product = await _productService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateProductDto dto)
        {
            var updated = await _productService.UpdateAsync(id, dto);
            if (!updated)
                return NotFound(new { error = $"Product with ID {id} not found." });
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _productService.DeleteAsync(id);
            if (!deleted)
                return NotFound(new { error = $"Product with ID {id} not found." });
            return NoContent();
        }
    }
}