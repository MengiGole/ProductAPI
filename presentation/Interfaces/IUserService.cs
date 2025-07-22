using ProductApi.Application.DTOs.User;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ProductApi.Application.Interfaces
{
    public interface IUserService
    {
        Task<UserReadDto> RegisterAsync(UserCreateDto dto);
        Task<UserReadDto> LoginAsync(UserLoginDto dto);
        Task<IEnumerable<UserReadDto>> GetAllAsync();
        Task<UserReadDto> GetByIdAsync(int id);
        Task<UserReadDto> UpdateAsync(int id, UserUpdateDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
