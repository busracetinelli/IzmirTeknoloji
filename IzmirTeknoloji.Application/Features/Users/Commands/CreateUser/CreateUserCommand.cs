using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace IzmirTeknoloji.Application.Features.Users.Commands.CreateUser
{
    public class CreateUserCommand : IRequest<Guid>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Role { get; set; } = "User"; // Default role is User
    }
}
