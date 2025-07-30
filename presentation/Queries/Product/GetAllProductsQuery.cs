using ProductApi.Application.Common.Base;
using ProductApi.Application.DTOs.Product;

namespace ProductApi.Application.Queries.Product
{
    public class GetAllProductsQuery : BaseQuery<IEnumerable<ProductReadDto>>
    {
    }
} 