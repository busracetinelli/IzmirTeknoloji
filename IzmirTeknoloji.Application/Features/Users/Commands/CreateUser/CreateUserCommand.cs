using MediatR;

namespace IzmirTeknoloji.Application.Features.Users.Commands.CreateUser
{
    public class CreateUserCommand : IRequest<Guid>
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; } 
    }
}
