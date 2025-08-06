using MediatR;

namespace ProductApi.Application.Commands.ProductGroup
{
    public class DeleteProductGroupCommand : IRequest<bool>
    {
        public int Id { get; }
        public DeleteProductGroupCommand(int id)
        {
            Id = id;
        }
    }
}