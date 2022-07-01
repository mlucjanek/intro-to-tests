using Example.Application.Services;
using Example.Infrastructure.Context;
using Example.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Example.Api.DependencyInjection;

public static class ApiDependencyInjection
{
    public static void RegisterInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ExampleDbContext>(options =>
            options.UseLazyLoadingProxies()
                .UseSqlServer(configuration.GetConnectionString("ExampleConnectionString"),
                    p => p.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery)));
        services.AddScoped<IDomainEntityRepository, DomainEntityRepository>();
        services.AddScoped<IDataPersistor>(x => x.GetRequiredService<ExampleDbContext>());
    }

    public static void RegisterApplication(this IServiceCollection services)
    {
        services.AddScoped<IDomainEntityService, DomainEntityService>();
        services.AddAutoMapper(Application.Configuration.AutoMapper.Configure);
    }

    public static void RegisterAspNetWebApiServices(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
    }
}
