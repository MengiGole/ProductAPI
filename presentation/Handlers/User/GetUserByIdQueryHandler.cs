using MediatR;
using ProductApi.Application.DTOs.User;
using ProductApi.Application.Queries.User;
using ProductApi.Domain.Interfaces;
using AutoMapper;

namespace ProductApi.Application.Handlers.User
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserReadDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetUserByIdQueryHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserReadDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.Id);
            if (user == null) return null;

            return _mapper.Map<UserReadDto>(user);
        }
    }
}
