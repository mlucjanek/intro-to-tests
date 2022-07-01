using AutoMapper;
using Example.Application.Dto;
using Example.Infrastructure;

namespace Example.Application.Configuration;

public class AutoMapper
{
    public static void Configure(IMapperConfigurationExpression cfg)
    {
        cfg.CreateMap<DomainEntity, DomainEntityDto>(MemberList.Source);
        cfg.CreateMap<DomainEntityDto, DomainEntity>(MemberList.Destination);
        cfg.AllowNullDestinationValues = false;
    }
}
