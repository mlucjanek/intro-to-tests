using Example.Infrastructure.Context;
using Microsoft.Extensions.DependencyInjection;

namespace Example.IntegrationTests.Core;

internal sealed class Fixture : IDisposable
{
    public Fixture()
    {
        ExampleApplicationFactory = new ExampleApplicationFactory();
        Client = ExampleApplicationFactory.CreateClient();
    }

    public HttpClient Client { get; }

    public ExampleDbContext DbContext =>
        ExampleApplicationFactory.Services.CreateScope().ServiceProvider.GetRequiredService<ExampleDbContext>();

    private ExampleApplicationFactory ExampleApplicationFactory { get; }


    public void Dispose()
    {
        Client.Dispose();
        ExampleApplicationFactory.Dispose();
    }
}
