using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IzmirTeknoloji.Application.Dtos.Auth;
using MediatR;

namespace IzmirTeknoloji.Application.Features.Auth.Commands.LoginUser
{
    public class LoginUserCommand : IRequest<LoginUserResponse>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
