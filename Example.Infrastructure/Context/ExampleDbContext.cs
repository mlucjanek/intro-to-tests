using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace Example.Infrastructure.Context;

public class ExampleDbContext : DbContext, IDataPersistor
{
    public ExampleDbContext(DbContextOptions<ExampleDbContext> options) : base(options)
    {
    }

    public DbSet<DomainEntity> DomainEntities { get; set; }

    public async Task Persist()
    {
        await SaveChangesAsync();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
