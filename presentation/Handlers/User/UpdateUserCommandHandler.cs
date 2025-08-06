using MediatR;
using ProductApi.Application.Commands.User;
using ProductApi.Application.DTOs.User;
using ProductApi.Domain.Interfaces;
using AutoMapper;

namespace ProductApi.Application.Handlers.User
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, UserReadDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UpdateUserCommandHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserReadDto> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.Id);
            if (user == null) return null;

            // Map update DTO onto the existing user entity
            _mapper.Map(request.UserUpdateDto, user);

            // TODO: Add password update & hashing logic here if applicable

            var updated = await _userRepository.UpdateAsync(user);

            return _mapper.Map<UserReadDto>(updated);
        }
    }
}
