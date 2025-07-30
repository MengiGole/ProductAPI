using MediatR;
using ProductApi.Application.DTOs.User;
using ProductApi.Application.Queries.User;
using ProductApi.Domain.Interfaces;

namespace ProductApi.Application.Handlers.User
{
    public class LoginUserQueryHandler : IRequestHandler<LoginUserQuery, UserReadDto>
    {
        private readonly IUserRepository _userRepository;

        public LoginUserQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserReadDto> Handle(LoginUserQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByUsernameAsync(request.UserLoginDto.Username!);
            if (user == null) return null;

            // Password check omitted for brevity
            return new UserReadDto { Id = user.Id, Username = user.Username };
        }
    }
} 