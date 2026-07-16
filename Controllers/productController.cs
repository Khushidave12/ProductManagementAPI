using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductManagementAPI.Application.DTOs;
using ProductManagementAPI.Infrastructure.Data.Repositories;
using ProductManagementAPI.Services;
using System;
using System.Threading.Tasks;
using static ProductManagementAPI.Domain.Entities.Entities;

namespace ProductManagementAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost("createProduct")]
        public async Task<IActionResult> Create([FromBody] CreateProductDto dto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(new { status = 1, httpStatusCode = 400, message = "Invalid model state." });
                }

                var product = await _productService.CreateAsync(dto);
                return Ok(new { status = 0, httpStatusCode = 201, message = "Product created successfully.", data = product });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { status = 1, httpStatusCode = 500, message = ex.Message });
            }
        }

        [HttpGet("getProduct/{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var product = await _productService.GetByIdAsync(id);

                if (product == null)
                {
                    return NotFound(new { status = 1, httpStatusCode = 404, message = $"Product with ID {id} was not found." });
                }

                return Ok(new { status = 0, httpStatusCode = 200, data = product });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { status = 1, httpStatusCode = 500, message = ex.Message });
            }
        }

        [HttpPut("updateProduct/{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateProductDto dto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(new { status = 1, httpStatusCode = 400, message = "Invalid model state." });
                }

                var updated = await _productService.UpdateAsync(id, dto);
                if (!updated)
                {
                    return NotFound(new { status = 1, httpStatusCode = 404, message = $"Product with ID {id} not found." });
                }

                return Ok(new { status = 0, httpStatusCode = 200, message = $"Product with ID {id} updated successfully." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { status = 1, httpStatusCode = 500, message = ex.Message });
            }
        }

        [HttpDelete("deleteProduct/{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var deleted = await _productService.DeleteAsync(id);
                if (!deleted)
                {
                    return NotFound(new { status = 1, httpStatusCode = 404, message = $"Product with ID {id} not found." });
                }

                return Ok(new { status = 0, httpStatusCode = 200, message = $"Product with ID {id} deleted successfully." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { status = 1, httpStatusCode = 500, message = ex.Message });
            }
        }
    }
}