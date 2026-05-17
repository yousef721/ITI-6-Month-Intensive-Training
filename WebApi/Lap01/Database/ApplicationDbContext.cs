using Lap01.Model;
using Microsoft.EntityFrameworkCore;

namespace Lap01.Database;

public class ApplicationDbContext : DbContext
{
    public required DbSet<Course> Courses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source=localhost;User ID=SA;Password=reallyStrong123;Initial Catalog=CourseDB;TrustServerCertificate=True");
        base.OnConfiguring(optionsBuilder);
    }
}
