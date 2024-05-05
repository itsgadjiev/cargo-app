using Cargo.Domain;
using Cargo.Domain.Base;
using Microsoft.EntityFrameworkCore;

namespace Cargo.Persistence.Context
{
    public class AppDbContext : DbContext
    {
        public List<Branch> Filials { get; init; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in base.ChangeTracker.Entries<BaseEntity>()
                .Where(q => q.State == EntityState.Added || q.State == EntityState.Modified))
            {
                entry.Entity.UpdatedAt = DateTime.Now;
                //entry.Entity.UpdatedBy = _userService.UserId;

                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreatedAt = DateTime.Now;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
