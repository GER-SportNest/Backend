using Microsoft.EntityFrameworkCore;

namespace SportNest.Infrastructure.Repositories;

public interface IDbContextFactory
{
    public DbContext GetDbContext();
}

public class DbContextFactory<TDbContext>(TDbContext context) : IDbContextFactory
where TDbContext : DbContext
{
    public DbContext GetDbContext()
    {
        return context;
    }
}