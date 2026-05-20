using Lap03.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Lap03.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
    public DbSet<Employee> Employees { get;}
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseSqlServer("Data Source=localhost;User ID=SA;Password=reallyStrong123;Initial Catalog=IdentityWebAPI;TrustServerCertificate=True");
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<IdentityRole>().HasData(
            new IdentityRole() { Id = "1", Name = "employee", NormalizedName = "EMPLOYEE", ConcurrencyStamp = "1" }
        );
    }
}
