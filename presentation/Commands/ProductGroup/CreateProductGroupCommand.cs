using MediatR;
using ProductApi.Application.DTOs.ProductGroup;

namespace ProductApi.Application.Commands.ProductGroup
{
    public class CreateProductGroupCommand : IRequest<ProductGroupReadDto>
    {
        public ProductGroupCreateDto Dto { get; }
        public CreateProductGroupCommand(ProductGroupCreateDto dto)
        {
            Dto = dto;
        }
    }
}