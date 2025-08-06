using MediatR;
using ProductApi.Application.DTOs.ProductCategory;

namespace ProductApi.Application.Commands.ProductCategory
{
    public class UpdateProductCategoryCommand : IRequest<ProductCategoryReadDto>
    {
        public int Id { get; }
        public ProductCategoryUpdateDto Dto { get; }
        public UpdateProductCategoryCommand(int id, ProductCategoryUpdateDto dto)
        {
            Id = id;
            Dto = dto;
        }
    }
}