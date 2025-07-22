namespace ProductApi.Application.DTOs.ProductGroup
{
    public class ProductGroupReadDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}