using IzmirTeknoloji.Application.Dtos.Auth;
using IzmirTeknoloji.Application.Interfaces;
using IzmirTeknoloji.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace IzmirTeknoloji.Application.Features.Auth.Commands.RegisterUser
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, LoginUserResponse>
    {
        private readonly IApplicationDbContext _context;
        private readonly IJwtService _jwtService;
        private readonly IPasswordHasher<User> _passwordHasher;

        public RegisterUserCommandHandler(IApplicationDbContext context, IJwtService jwtService, IPasswordHasher<User> passwordHasher)
        {
            _context = context;
            _jwtService = jwtService;
            _passwordHasher = passwordHasher;
        }

        public async Task<LoginUserResponse> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var existingUser = await _context.Users
                .FirstOrDefaultAsync(u => u.Email == request.Email, cancellationToken);
            if(existingUser != null)
            {
                throw new InvalidOperationException("Bu email adresi zaten kayıtlı.");
            }

            // New user creation    
            var user = new User
            {
                Id = Guid.NewGuid(),
                Email = request.Email,
                RoleId = 2 // Proje gereksinimi için Default olarak User rolü atandı, istenirse şu an için veritabanından admin hale getirilebilir.
            };
            user.PasswordHash = _passwordHasher.HashPassword(user, request.Password);
            _context.Users.Add(user);
            await _context.SaveChangesAsync(cancellationToken);
            var token = _jwtService.GenerateToken(user);
            return new LoginUserResponse
            {
                Token = token,
                UserId = user.Id,
                Email = user.Email,
                RoleId = user.RoleId
            };
        }
    }
}
