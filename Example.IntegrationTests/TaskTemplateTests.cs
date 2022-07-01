using System.Net;
using System.Net.Http.Json;
using System.Text.Json;
using Example.Application.Dto;
using Example.Infrastructure;
using Example.Infrastructure.Context;
using Example.IntegrationTests.Core;
using FluentAssertions;
using Xunit;

namespace Example.IntegrationTests;

public class TaskTemplateTests : IDisposable
{
    private static JsonSerializerOptions serializerOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

    private readonly Fixture _fixture = new();

    public void Dispose()
    {
        _fixture.Dispose();
    }

    [Fact]
    public async Task GivenThereIsNoEntriesInDatabase_WhenIPostData_ThenDataIsCorrectlyInserted()
    {
        var expected = new DomainEntity { Id = 1, Name = "wow" };
        var inserted = new DomainEntityDto { Id = 0, Name = "wow" };

        var postResult = await _fixture.Client.PostAsync("/DomainEntity", JsonContent.Create(inserted));


        ExampleDbContext dbContext = _fixture.DbContext;
        var addedValue = dbContext.DomainEntities.First();

        Assert.NotNull(postResult);
        Assert.Equal(HttpStatusCode.OK, postResult.StatusCode);

        addedValue.Should().BeEquivalentTo(expected, options => options.ComparingByMembers(typeof(DomainEntity)));
    }

    [Fact]
    public async Task GivenThereIsOneEntryInDatabase_WhenIPostData_ThenDataIsCorrectlyInserted()
    {
        var expected = new DomainEntityDto { Id = 1, Name = "Some Name" };
        var inserted = new DomainEntity() { Name = "Some Name" };  
        ExampleDbContext dbContext = _fixture.DbContext;
        dbContext.DomainEntities.Add(inserted);
        await dbContext.SaveChangesAsync();

        var getResult = await _fixture.Client.GetAsync("/DomainEntity");

        Assert.NotNull(getResult);
        Assert.Equal(HttpStatusCode.OK, getResult.StatusCode);
        var content = await getResult.Content.ReadAsStringAsync();
        var resultTemplates = JsonSerializer.Deserialize<List<DomainEntityDto>>(content, serializerOptions);
        var actual = resultTemplates!.First();

        actual.Should().BeEquivalentTo(expected, options => options.ComparingByMembers(typeof(DomainEntityDto)));
    }
}
