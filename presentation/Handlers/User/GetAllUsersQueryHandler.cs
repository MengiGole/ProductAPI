using MediatR;
using ProductApi.Application.DTOs.User;
using ProductApi.Application.Queries.User;
using ProductApi.Domain.Interfaces;
using System.Linq;

namespace ProductApi.Application.Handlers.User
{
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, IEnumerable<UserReadDto>>
    {
        private readonly IUserRepository _userRepository;

        public GetAllUsersQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<UserReadDto>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await _userRepository.GetAllAsync();
            return users.Select(u => new UserReadDto { Id = u.Id, Username = u.Username });
        }
    }
} 