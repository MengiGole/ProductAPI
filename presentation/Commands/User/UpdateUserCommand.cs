using ProductApi.Application.Common.Base;
using ProductApi.Application.DTOs.User;

namespace ProductApi.Application.Commands.User
{
    public class UpdateUserCommand : BaseCommand<UserReadDto>
    {
        public int Id { get; set; }
        public UserUpdateDto UserUpdateDto { get; set; }

        public UpdateUserCommand(int id, UserUpdateDto userUpdateDto)
        {
            Id = id;
            UserUpdateDto = userUpdateDto;
        }
    }
} 