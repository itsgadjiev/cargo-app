using Cargo.Application.Models.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace Cargo.Identity.DbContext;

public class AppIdentityDbContext : IdentityDbContext<ApplicationUser>
{
    public AppIdentityDbContext(DbContextOptions<AppIdentityDbContext> options)
       : base(options)
    {
        Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {

        builder.HasSequence<int>("CustomerNumberSequence", schema: "dbo")
        .StartsAt(10000)
        .IncrementsBy(1);

        builder.Entity<ApplicationUser>()
            .Property(c => c.CustomerNumber)
            .ValueGeneratedOnAdd()
            .HasDefaultValueSql("NEXT VALUE FOR dbo.CustomerNumberSequence");

        builder.Entity<ApplicationUser>()
        .Ignore(a => a.Branch);

        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(typeof(AppIdentityDbContext).Assembly);
    }
}
