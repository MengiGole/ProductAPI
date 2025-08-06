using MediatR;

namespace ProductApi.Application.Commands.ProductCategory
{
    public class DeleteProductCategoryCommand : IRequest<bool>
    {
        public int Id { get; }
        public DeleteProductCategoryCommand(int id)
        {
            Id = id;
        }
    }
}