using ProductApi.Application.Common.Base;
using ProductApi.Application.DTOs.Product;

namespace ProductApi.Application.Commands.Product
{
    public class CreateProductCommand : BaseCommand<ProductReadDto>
    {
        public ProductCreateDto ProductCreateDto { get; set; }

        public CreateProductCommand(ProductCreateDto productCreateDto)
        {
            ProductCreateDto = productCreateDto;
        }
    }
} 