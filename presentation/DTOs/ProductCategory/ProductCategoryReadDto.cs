namespace ProductApi.Application.DTOs.ProductCategory
{
    public class ProductCategoryReadDto
    {
        public int Id { get; set; }
        public int GroupId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}