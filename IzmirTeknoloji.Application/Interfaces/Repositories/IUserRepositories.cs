using IzmirTeknoloji.Domain.Entities;

namespace IzmirTeknoloji.Application.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<User?> GetByEmailAndPasswordAsync(string email, string password);
        Task<User?> GetByIdAsync(Guid userId);
    }
}
