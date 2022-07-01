namespace Example.Infrastructure.Repositories;

public interface IDomainEntityRepository
{
    Task<List<DomainEntity>> GetAll();
    Task<DomainEntity> AddNew(DomainEntity template);
}
