using ProductApi.Application.Common.Base;
using ProductApi.Application.DTOs.Product;

namespace ProductApi.Application.Queries.Product
{
    public class GetProductByIdQuery : BaseQuery<ProductReadDto>
    {
        public int Id { get; set; }

        public GetProductByIdQuery(int id)
        {
            Id = id;
        }
    }
} 