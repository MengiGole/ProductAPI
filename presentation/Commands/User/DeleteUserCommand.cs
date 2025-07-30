using ProductApi.Application.Common.Base;

namespace ProductApi.Application.Commands.User
{
    public class DeleteUserCommand : BaseCommand<bool>
    {
        public int Id { get; set; }

        public DeleteUserCommand(int id)
        {
            Id = id;
        }
    }
} 