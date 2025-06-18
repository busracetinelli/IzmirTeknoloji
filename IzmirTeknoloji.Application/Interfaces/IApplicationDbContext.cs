using IzmirTeknoloji.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace IzmirTeknoloji.Application.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Role> Roles { get; set; }
        DbSet<User> Users { get; set; }
        DbSet<TransactionHistory> TransactionHistories { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
