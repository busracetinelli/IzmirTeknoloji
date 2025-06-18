using IzmirTeknoloji.Application.Interfaces;
using IzmirTeknoloji.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace IzmirTeknoloji.Application.Features.Users.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Guid>
    {
        private readonly IApplicationDbContext _context;
        private readonly IPasswordHasher<User> _passwordHasher;

        public CreateUserCommandHandler(IApplicationDbContext context, IPasswordHasher<User> paswordHasher)
        {
            _context = context;
            _passwordHasher = paswordHasher;
        }

        public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User
            {
                Id = Guid.NewGuid(),
                Email = request.Email,
                RoleId = request.RoleId
            };

            user.PasswordHash = _passwordHasher.HashPassword(user, request.Password);

            _context.Users.Add(user);
            await _context.SaveChangesAsync(cancellationToken);

            return user.Id;
        }
    }
}
