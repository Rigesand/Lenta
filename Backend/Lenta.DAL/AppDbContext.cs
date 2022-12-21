using Lenta.DAL.Enities;
using Microsoft.EntityFrameworkCore;

namespace Lenta.DAL;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    }


    public DbSet<User> Users => Set<User>();
    public DbSet<Student> Students => Set<Student>();
}