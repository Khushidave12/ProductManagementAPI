using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductManagementAPI.Application.DTOs;
using ProductManagementAPI.Infrastructure.Data.Repositories;
using ProductManagementAPI.Services;
using static ProductManagementAPI.Domain.Entities.Entities;

namespace ProductManagementAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase 
    {
        private readonly IProductService _productService;
        private readonly ApplicationDbContext _context;

        public ProductController(IProductService productService, ApplicationDbContext context)
        {
            _productService = productService;
            _context = context;
        }

        [HttpPost("createProduct")]
        public async Task<IActionResult> Create(CreateProductDto dto)
        {
            var product = await _productService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
        }

        [HttpGet("getProduct{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
           
            var product = await _context.Products.FindAsync(id);  
            if (product == null)
            {
                return NotFound(new { message = $"Product with ID {id} was not found." });
            }
            return Ok(product);
        }

      

        [HttpPut("updateProduct{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateProductDto dto)
        {
            var updated = await _productService.UpdateAsync(id, dto);
            if (!updated)
                return NotFound(new { error = $"Product with ID {id} not found." });
            return NoContent();
        }

        [HttpDelete("deleteProduct{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _productService.DeleteAsync(id);
            if (!deleted)
                return NotFound(new { error = $"Product with ID {id} not found." });
            return NoContent();
        }
    }
}