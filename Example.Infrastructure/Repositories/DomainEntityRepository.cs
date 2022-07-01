using System.Data;
using Example.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Example.Infrastructure.Repositories;

public class DomainEntityRepository : IDomainEntityRepository
{
    private readonly ExampleDbContext _dbContext;

    public DomainEntityRepository(ExampleDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<DomainEntity>> GetAll()
    {
        return await _dbContext.DomainEntities.ToListAsync();
    }

    public async Task<DomainEntity> AddNew(DomainEntity template)
    {
        if (template == null)
        {
            throw new ArgumentNullException(nameof(template));
        }

        var existing = await _dbContext.DomainEntities.FindAsync(template.Id);
        if (existing != null)
        {
            throw new DataException($"Task template with id {existing.Id} already exist");
        }

        var added = await _dbContext.DomainEntities.AddAsync(template);

        return added.Entity;
    }
}
