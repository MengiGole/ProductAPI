using ProductApi.Application.DTOs.User;
using ProductApi.Application.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductApi.Application.Services
{
    public class UserService : IUserService
    {
        public Task<UserReadDto> RegisterAsync(UserCreateDto dto)
        {
            throw new System.NotImplementedException();
        }

        public Task<UserReadDto> LoginAsync(UserLoginDto dto)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<UserReadDto>> GetAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<UserReadDto> GetByIdAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<UserReadDto> UpdateAsync(int id, UserUpdateDto dto)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
