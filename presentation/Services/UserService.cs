using ProductApi.Application.DTOs.User;
using ProductApi.Application.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using ProductApi.Domain.Interfaces;
using System.Linq;

namespace ProductApi.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserReadDto> RegisterAsync(UserCreateDto dto)
        {
            // Hashing logic omitted for brevity
            var user = new User
            {
                Username = dto.Username,
                PasswordHash = new byte[0], // TODO: Hash password
                PasswordSalt = new byte[0]  // TODO: Generate salt
            };
            var created = await _userRepository.AddAsync(user);
            return new UserReadDto { Id = created.Id, Username = created.Username };
        }

        public async Task<UserReadDto> LoginAsync(UserLoginDto dto)
        {
            var user = await _userRepository.GetByUsernameAsync(dto.Username!);
            if (user == null) return null;
            // Password check omitted for brevity
            return new UserReadDto { Id = user.Id, Username = user.Username };
        }

        public async Task<IEnumerable<UserReadDto>> GetAllAsync()
        {
            var users = await _userRepository.GetAllAsync();
            return users.Select(u => new UserReadDto { Id = u.Id, Username = u.Username });
        }

        public async Task<UserReadDto> GetByIdAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null) return null;
            return new UserReadDto { Id = user.Id, Username = user.Username };
        }

        public async Task<UserReadDto> UpdateAsync(int id, UserUpdateDto dto)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null) return null;
            user.Username = dto.Username;
            // Password update logic omitted for brevity
            var updated = await _userRepository.UpdateAsync(user);
            return new UserReadDto { Id = updated.Id, Username = updated.Username };
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _userRepository.DeleteAsync(id);
        }
    }
}
