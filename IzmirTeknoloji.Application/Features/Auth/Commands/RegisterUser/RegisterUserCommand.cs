using IzmirTeknoloji.Application.Dtos.Auth;
using MediatR;

namespace IzmirTeknoloji.Application.Features.Auth.Commands.RegisterUser
{
    public class RegisterUserCommand : IRequest<LoginUserResponse>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
