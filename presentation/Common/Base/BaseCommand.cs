using MediatR;

namespace ProductApi.Application.Common.Base
{
    public abstract class BaseCommand<TResponse> : IRequest<TResponse>
    {
    }
} 