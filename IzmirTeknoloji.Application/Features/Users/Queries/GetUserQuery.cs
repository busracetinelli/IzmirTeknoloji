using IzmirTeknoloji.Application.Dtos.Users;
using MediatR;

namespace IzmirTeknoloji.Application.Features.Users.Queries
{
    public class GetUserQuery : IRequest<UserDto>
    {
        public Guid UserId { get; set; }
    }
}
