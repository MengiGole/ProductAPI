using ProductApi.Application.Common.Base;
using ProductApi.Application.DTOs.User;

namespace ProductApi.Application.Commands.User
{
    public class CreateUserCommand : BaseCommand<UserReadDto>
    {
        public UserCreateDto UserCreateDto { get; set; }

        public CreateUserCommand(UserCreateDto userCreateDto)
        {
            UserCreateDto = userCreateDto;
        }
    }
} 