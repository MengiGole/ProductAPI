using ProductApi.Application.Common.Base;
using ProductApi.Application.DTOs.User;

namespace ProductApi.Application.Queries.User
{
    public class LoginUserQuery : BaseQuery<UserReadDto>
    {
        public UserLoginDto UserLoginDto { get; set; }

        public LoginUserQuery(UserLoginDto userLoginDto)
        {
            UserLoginDto = userLoginDto;
        }
    }
} 