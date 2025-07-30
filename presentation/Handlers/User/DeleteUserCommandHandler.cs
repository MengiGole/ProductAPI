using MediatR;
using ProductApi.Application.Commands.User;
using ProductApi.Domain.Interfaces;

namespace ProductApi.Application.Handlers.User
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, bool>
    {
        private readonly IUserRepository _userRepository;

        public DeleteUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            return await _userRepository.DeleteAsync(request.Id);
        }
    }
} 