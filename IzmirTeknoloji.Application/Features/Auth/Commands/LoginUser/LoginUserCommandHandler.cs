using System.Security.Authentication;
using IzmirTeknoloji.Application.Dtos.Auth;
using IzmirTeknoloji.Application.Features.Auth.Commands.LoginUser;
using IzmirTeknoloji.Application.Interfaces;
using IzmirTeknoloji.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace IzmirTeknoloji.Application.Features.Users.Handlers
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, LoginUserResponse>
    {
        private readonly IApplicationDbContext _context;
        private readonly IJwtService _jwtService;
        private readonly IPasswordHasher<User> _passwordHasher;

        public LoginUserCommandHandler(IApplicationDbContext context, IJwtService jwtService, IPasswordHasher<User> passwordHasher)
        {
            _context = context;
            _jwtService = jwtService;
            _passwordHasher = passwordHasher;
        }

        public async Task<LoginUserResponse> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            // Find user by email
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == request.Email, cancellationToken);

            if (user == null)
            {
                throw new AuthenticationException("Kullanıcı bulunamadı.");
            }

            // Verify password
            var verificationResult = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, request.Password);
            if (verificationResult != PasswordVerificationResult.Success)
            {
                throw new AuthenticationException("Şifre yanlış.");
            }

            // Create JWT token
            var token = _jwtService.GenerateToken(user);

            return new LoginUserResponse
            {
                Token = token,
                RoleId = user.RoleId,
                Email = user.Email,
                UserId = user.Id
            };
        }
    }
}
