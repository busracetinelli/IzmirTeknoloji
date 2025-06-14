using IzmirTeknoloji.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace IzmirTeknoloji.Application.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<User> Users { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
