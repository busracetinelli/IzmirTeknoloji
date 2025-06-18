using IzmirTeknoloji.Application.Interfaces.Repositories;
using IzmirTeknoloji.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using IzmirTeknoloji.Application.Interfaces;
using IzmirTeknoloji.Infrastructure.Persistence;

namespace IzmirTeknoloji.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<User?> GetByEmailAndPasswordAsync(string email, string password)
        {
            return await _context.Users
                .FirstOrDefaultAsync(u => u.Email == email && u.PasswordHash == password);
        }

        public async Task<User?> GetByIdAsync(Guid userId)
        {
            return await _context.Users
                .FirstOrDefaultAsync(u => u.Id == userId);
        }
    }
}
