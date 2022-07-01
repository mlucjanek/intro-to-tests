using Example.Application.Dto;

namespace Example.Application.Services;

public interface IDomainEntityService
{
    Task<IEnumerable<DomainEntityDto>> GetAllTemplates();
    Task<DomainEntityDto> AddNew(DomainEntityDto template);
}
