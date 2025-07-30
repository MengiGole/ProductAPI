using MediatR;
using ProductApi.Application.Commands.User;
using ProductApi.Application.DTOs.User;
using ProductApi.Domain.Interfaces;

namespace ProductApi.Application.Handlers.User
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, UserReadDto>
    {
        private readonly IUserRepository _userRepository;

        public CreateUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserReadDto> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            // Hashing logic omitted for brevity
            var user = new global::User
            {
                Username = request.UserCreateDto.Username,
                PasswordHash = new byte[0], // TODO: Hash password
                PasswordSalt = new byte[0]  // TODO: Generate salt
            };

            var created = await _userRepository.AddAsync(user);
            return new UserReadDto { Id = created.Id, Username = created.Username };
        }
    }
} 