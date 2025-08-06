using MediatR;
using ProductApi.Application.DTOs.ProductGroup;
using System.Collections.Generic;

namespace ProductApi.Application.Queries.ProductGroup
{
    public class GetAllProductGroupsQuery : IRequest<IEnumerable<ProductGroupReadDto>>
    {
    }
}