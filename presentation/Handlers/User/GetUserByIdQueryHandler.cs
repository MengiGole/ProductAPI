using MediatR;
using ProductApi.Application.DTOs.User;
using ProductApi.Application.Queries.User;
using ProductApi.Domain.Interfaces;

namespace ProductApi.Application.Handlers.User
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserReadDto>
    {
        private readonly IUserRepository _userRepository;

        public GetUserByIdQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserReadDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.Id);
            if (user == null) return null;

            return new UserReadDto { Id = user.Id, Username = user.Username };
        }
    }
} 