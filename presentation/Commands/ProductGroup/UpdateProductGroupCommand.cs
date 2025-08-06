using MediatR;
using ProductApi.Application.DTOs.ProductGroup;

namespace ProductApi.Application.Commands.ProductGroup
{
    public class UpdateProductGroupCommand : IRequest<ProductGroupReadDto>
    {
        public int Id { get; }
        public ProductGroupUpdateDto Dto { get; }
        public UpdateProductGroupCommand(int id, ProductGroupUpdateDto dto)
        {
            Id = id;
            Dto = dto;
        }
    }
}