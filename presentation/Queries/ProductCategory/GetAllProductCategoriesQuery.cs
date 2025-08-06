using MediatR;
using ProductApi.Application.DTOs.ProductCategory;
using System.Collections.Generic;

namespace ProductApi.Application.Queries.ProductCategory
{
    public class GetAllProductCategoriesQuery : IRequest<IEnumerable<ProductCategoryReadDto>>
    {
    }
}