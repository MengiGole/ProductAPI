using MediatR;
using ProductApi.Application.Commands.User;
using ProductApi.Application.DTOs.User;
using ProductApi.Domain.Interfaces;

namespace ProductApi.Application.Handlers.User
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, UserReadDto>
    {
        private readonly IUserRepository _userRepository;

        public UpdateUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserReadDto> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.Id);
            if (user == null) return null;

            user.Username = request.UserUpdateDto.Username;
            // Password update logic omitted for brevity

            var updated = await _userRepository.UpdateAsync(user);
            return new UserReadDto { Id = updated.Id, Username = updated.Username };
        }
    }
} 