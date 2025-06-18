using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using IzmirTeknoloji.Application.Interfaces;
using IzmirTeknoloji.Domain.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace IzmirTeknoloji.Infrastructure.Services
{
    public class JwtService : IJwtService
    {
        private readonly IConfiguration _configuration;
        private readonly JwtSettings _jwtSettings;

        public JwtService(IConfiguration configuration)
        {
            _configuration = configuration;

            // Get the 1JWT" section from configuration
            _jwtSettings = _configuration.GetSection("Jwt").Get<JwtSettings>();

            // Check key length (256 bits = 32 bytes)
            if (Encoding.UTF8.GetBytes(_jwtSettings.Key).Length < 32)
            {
                throw new ArgumentOutOfRangeException("JWT key must be at least 32 bytes (256 bits) long.");
            }
        }

        public string GenerateToken(User user)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(ClaimTypes.Role, user.RoleId.ToString()),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddHours(2),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }

    public class JwtSettings
    {
        public string Key { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
    }
}
