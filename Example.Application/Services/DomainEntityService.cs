using AutoMapper;
using Example.Application.Dto;
using Example.Infrastructure;
using Example.Infrastructure.Context;
using Example.Infrastructure.Repositories;

namespace Example.Application.Services;

public class DomainEntityService : IDomainEntityService
{
    private readonly IDataPersistor _dataPersistor;
    private readonly IMapper _mapper;
    private readonly IDomainEntityRepository _templateRepository;

    public DomainEntityService(IDomainEntityRepository templateRepository, IDataPersistor dataPersistor, IMapper mapper)
    {
        _templateRepository = templateRepository;
        _dataPersistor = dataPersistor;
        _mapper = mapper;
    }

    public async Task<IEnumerable<DomainEntityDto>> GetAllTemplates()
    {
        return _mapper.Map<IEnumerable<DomainEntityDto>>(await _templateRepository.GetAll());
    }

    public async Task<DomainEntityDto> AddNew(DomainEntityDto template)
    {
        var addedTask = await _templateRepository.AddNew(_mapper.Map<DomainEntity>(template));

        await _dataPersistor.Persist();
        return _mapper.Map<DomainEntityDto>(addedTask);
    }
}
