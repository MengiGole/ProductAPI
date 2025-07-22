namespace ProductApi.Application.DTOs.ProductCategory
{
    public class ProductCategoryUpdateDto
    {
        public int GroupId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
    }
}