namespace ProductApi.Application.DTOs.Product
{
    public class ProductUpdateDto
    {
        public int CategoryId { get; set; }
        public string? Name { get; set; }
        public string? SKU { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string? Description { get; set; }
    }
}