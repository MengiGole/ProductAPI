using ProductApi.Application.Common.Base;
using ProductApi.Application.DTOs.User;

namespace ProductApi.Application.Queries.User
{
    public class GetAllUsersQuery : BaseQuery<IEnumerable<UserReadDto>>
    {
    }
} 