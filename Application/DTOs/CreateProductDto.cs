namespace ProductManagementAPI.Application.DTOs
{
    public class CreateProductDto
    {
        public string ProductName { get; set; } = string.Empty;
    }
    public record UpdateProductDto(string ProductName, string ModifiedBy);
}

