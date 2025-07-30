using MediatR;
using ProductApi.Application.Commands.Product;
using ProductApi.Domain.Interfaces;

namespace ProductApi.Application.Handlers.Product
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, bool>
    {
        private readonly IProductRepository _productRepository;

        public DeleteProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            return await _productRepository.DeleteAsync(request.Id);
        }
    }
} 