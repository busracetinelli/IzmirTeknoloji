using IzmirTeknoloji.Domain.Entities;

namespace IzmirTeknoloji.Application.Interfaces
{
    public interface IJwtService
    {
        string GenerateToken(User user);
    }
}
