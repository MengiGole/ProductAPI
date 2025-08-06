using MediatR;
using ProductApi.Application.DTOs.ProductCategory;

namespace ProductApi.Application.Commands.ProductCategory
{
    public class CreateProductCategoryCommand : IRequest<ProductCategoryReadDto>
    {
        public ProductCategoryCreateDto Dto { get; }
        public CreateProductCategoryCommand(ProductCategoryCreateDto dto)
        {
            Dto = dto;
        }
    }
}