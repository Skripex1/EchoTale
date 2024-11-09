using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Infrastructure.Data;

public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
       var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
       var connectionString = "Server=localhost;Port=5432;Database=echotaledatabase;Username=postgres;Password=postgres;";
       optionsBuilder.UseNpgsql(connectionString, b=> b.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName));
       return new AppDbContext(optionsBuilder.Options);
    }
}