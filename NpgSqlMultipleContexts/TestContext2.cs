using Microsoft.EntityFrameworkCore;

namespace NpgSqlMultipleContexts;

public class TestContext2 : DbContext
{
    public TestContext2() : base(new DbContextOptionsBuilder()
        .UseNpgsql($"Host=localhost;Database=test;Username=postgres;Password=changeme", o => o.EnableRetryOnFailure(5))
        .Options)
    {
    }
    
    public DbSet<Product> Products { get; set; }
}