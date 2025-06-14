using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IzmirTeknoloji.Application.Interfaces;
using IzmirTeknoloji.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace IzmirTeknoloji.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<LoginHistory> LoginHistories => Set<LoginHistory>();  

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
