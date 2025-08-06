using AutoMapper;
using MediatR;
using ProductApi.Application.Commands.User;
using ProductApi.Application.DTOs.User;
using ProductApi.Domain.Interfaces;
using domain.Entities;  // Keep this as is if your entity namespace is lowercase

namespace ProductApi.Application.Handlers.User
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, UserReadDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public CreateUserCommandHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserReadDto> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            // Fully qualify User here to avoid 'User is namespace' error
            var user = _mapper.Map<domain.Entities.User>(request.UserCreateDto);

            var createdUser = await _userRepository.AddAsync(user);

            return _mapper.Map<UserReadDto>(createdUser);
        }
    }
}
