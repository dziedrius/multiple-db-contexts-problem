using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace NpgSqlMultipleContexts;

public class TestContext : DbContext
{
    static TestContext() => NpgsqlConnection.GlobalTypeMapper
        .MapEnum<ClientType>();
    
    public TestContext() : base(new DbContextOptionsBuilder()
        .UseNpgsql($"Host=localhost;Database=test;Username=postgres;Password=changeme", o => o.EnableRetryOnFailure(5))
        .Options)
    {
    }
    
    public DbSet<Client> Clients { get; set; }
}