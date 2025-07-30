using ProductApi.Application.Common.Base;
using ProductApi.Application.DTOs.Product;

namespace ProductApi.Application.Commands.Product
{
    public class UpdateProductCommand : BaseCommand<ProductReadDto>
    {
        public int Id { get; set; }
        public ProductUpdateDto ProductUpdateDto { get; set; }

        public UpdateProductCommand(int id, ProductUpdateDto productUpdateDto)
        {
            Id = id;
            ProductUpdateDto = productUpdateDto;
        }
    }
} 