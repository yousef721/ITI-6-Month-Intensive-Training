using Lap02.Models;
using Microsoft.EntityFrameworkCore;

namespace Lap02.Database;

public class ITIDbContext : DbContext
{
    public ITIDbContext(DbContextOptions<ITIDbContext> options): base(options)
    {
    }

    public DbSet<Student> Students => Set<Student>();

    public DbSet<Department> Departments => Set<Department>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source=localhost;User ID=SA;Password=reallyStrong123;Initial Catalog=ITIWebAPI;TrustServerCertificate=True");
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Student>()
            .HasOne(s => s.Supervisor)
            .WithMany()
            .HasForeignKey(s => s.SupervisorId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}