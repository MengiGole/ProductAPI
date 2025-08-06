using MediatR;
using ProductApi.Application.DTOs.User;
using ProductApi.Application.Queries.User;
using ProductApi.Domain.Interfaces;
using AutoMapper;

namespace ProductApi.Application.Handlers.User
{
    public class LoginUserQueryHandler : IRequestHandler<LoginUserQuery, UserReadDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public LoginUserQueryHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserReadDto> Handle(LoginUserQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByUsernameAsync(request.UserLoginDto.Username!);
            if (user == null) return null;

            // TODO: Implement password verification logic here

            return _mapper.Map<UserReadDto>(user);
        }
    }
}
