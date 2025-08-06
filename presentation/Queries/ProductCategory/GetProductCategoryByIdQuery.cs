using MediatR;
using ProductApi.Application.DTOs.ProductCategory;

namespace ProductApi.Application.Queries.ProductCategory
{
    public class GetProductCategoryByIdQuery : IRequest<ProductCategoryReadDto>
    {
        public int Id { get; }
        public GetProductCategoryByIdQuery(int id)
        {
            Id = id;
        }
    }
}