using MediatR;
using ProductApi.Application.DTOs.ProductGroup;

namespace ProductApi.Application.Queries.ProductGroup
{
    public class GetProductGroupByIdQuery : IRequest<ProductGroupReadDto>
    {
        public int Id { get; }
        public GetProductGroupByIdQuery(int id)
        {
            Id = id;
        }
    }
}