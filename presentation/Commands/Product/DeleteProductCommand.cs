using ProductApi.Application.Common.Base;

namespace ProductApi.Application.Commands.Product
{
    public class DeleteProductCommand : BaseCommand<bool>
    {
        public int Id { get; set; }

        public DeleteProductCommand(int id)
        {
            Id = id;
        }
    }
} 