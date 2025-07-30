using ProductApi.Application.Common.Base;
using ProductApi.Application.DTOs.User;

namespace ProductApi.Application.Queries.User
{
    public class GetUserByIdQuery : BaseQuery<UserReadDto>
    {
        public int Id { get; set; }

        public GetUserByIdQuery(int id)
        {
            Id = id;
        }
    }
} 