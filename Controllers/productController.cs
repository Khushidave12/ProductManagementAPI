using Microsoft.AspNetCore.Mvc;
using ProductManagementAPI.Application.DTOs;
using ProductManagementAPI.Infrastructure.Data;
using ProductManagementAPI.Services;
using static ProductManagementAPI.Domain.Entities.Entities;

namespace productController.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class productController : ControllerBase
    {

        private readonly IProductService _productService;

        public productController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost("createProduct")]
        public async Task<IActionResult> Create(CreateProductDto dto)
        {
            var product = await _productService.CreateAsync(dto);

            return CreatedAtAction(
                nameof(GetById),
                new { id = product.Id },
                product);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
           
            return Ok();
        }


    }
}
