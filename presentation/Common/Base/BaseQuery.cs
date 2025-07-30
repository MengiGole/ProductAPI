using MediatR;

namespace ProductApi.Application.Common.Base
{
    public abstract class BaseQuery<TResponse> : IRequest<TResponse>
    {
    }
} 