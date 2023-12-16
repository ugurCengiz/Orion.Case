using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Orion.Case.Core.Entities;
using Orion.Case.Entities.Concrete;

namespace Orion.Case.DataAccess.Contexts;

public class AppDbContext: IdentityDbContext<IdentityUser,IdentityRole,string>
{
    public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
    {
        
    }

    public DbSet<TelephoneDirectory> TelephoneDirectories { get; set; }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var entries = ChangeTracker.Entries<BaseEntity>();

        foreach (var entry in entries)
        {
            if (entry.State == EntityState.Added)
            {
                entry.Property(p => p.CreatedDate)
                    .CurrentValue = DateTime.Now;
            }

            if (entry.State == EntityState.Modified)
            {
                entry.Property(p => p.UpdatedDate)
                    .CurrentValue = DateTime.Now;
            }
        }
        return base.SaveChangesAsync(cancellationToken);
    }
}
