using System.Threading.Tasks;
using AutoMapper;
using Example.Application.Dto;
using Example.Application.Services;
using Example.Infrastructure;
using Example.Infrastructure.Context;
using Example.Infrastructure.Repositories;
using Moq;
using Xunit;

namespace Example.UnitTests.Application
{
    public class TaskTemplateServiceTests
    {
        private readonly IDomainEntityService _systemUnderTest;
        private readonly Mock<IMapper> _mapperMock;
        private readonly Mock<IDomainEntityRepository> _repositoryMock;
        private readonly Mock<IDataPersistor> _dataPersistor;

        public TaskTemplateServiceTests()
        {
            _mapperMock = new Mock<IMapper>();
            _dataPersistor = new Mock<IDataPersistor>();
            _repositoryMock = new Mock<IDomainEntityRepository>();
            _systemUnderTest = new DomainEntityService(_repositoryMock.Object, _dataPersistor.Object, _mapperMock.Object);
        }


        [Fact]
        public async Task AddNewTriggersCorrectMethods()
        {
            var dto = new DomainEntityDto(0, "anything");
            var template = new DomainEntity() { Id = 2 };
            _mapperMock.Setup(x => x.Map<DomainEntity>(dto)).Returns(template);

            await _systemUnderTest.AddNew(dto);

            _mapperMock.Verify(x => x.Map<DomainEntity>(It.IsAny<DomainEntityDto>()), Times.Once);
            _dataPersistor.Verify(x => x.Persist(), Times.Once);
            _repositoryMock.Verify(x => x.AddNew(template), Times.Once);
            _mapperMock.Verify(x => x.Map<DomainEntityDto>(It.IsAny<DomainEntity>()), Times.Once);
            _repositoryMock.Verify(x => x.GetAll(), Times.Never);
        }
    }
}
