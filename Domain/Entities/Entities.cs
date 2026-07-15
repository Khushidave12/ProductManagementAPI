namespace ProductManagementAPI.Domain.Entities
{
    public class Entities
    {
        public class Product
        {
            public int Id { get; set; }
            public string ProductName { get; set; } = string.Empty;
            public string CreatedBy { get; set; } = string.Empty;
            public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
            public string? ModifiedBy { get; set; }
            public DateTime? ModifiedOn { get; set; }

         
            public ICollection<Item> Items { get; set; } = new List<Item>();
        }

  
        public class Item
        {
            public int Id { get; set; }
            public int ProductId { get; set; }
            public int Quantity { get; set; }
            public Product? Product { get; set; }
        }
        public class JwtOptions
        {
            public string SecretKey { get; set; } = string.Empty;
            public string Issuer { get; set; } = string.Empty;
            public string Audience { get; set; } = string.Empty;
            public int ExpirationMinutes { get; set; }
        }
    }
}