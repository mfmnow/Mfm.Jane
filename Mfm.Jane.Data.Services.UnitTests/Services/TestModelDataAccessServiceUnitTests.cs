using Mfm.Jane.Data.Entities;
using Mfm.Jane.Data.Services.UnitTests.MockProviders;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace Mfm.Jane.Data.Services.UnitTests.Services
{
    public class TestModelDataAccessServiceUnitTests
    {
        private readonly Mock<TestEntityDataAccess> _testModelDataAccessService;

        public TestModelDataAccessServiceUnitTests()
        {
            _testModelDataAccessService = TestModelDataAccessServiceMockerProvider.GetMockedDataAccessService();
        }

        [Fact]
        public async Task CreateTestModel_Should_Follow_LogicalFlow()
        {
            await _testModelDataAccessService.Object.CreateTestEntity(It.IsAny<string>());

            _testModelDataAccessService.Verify(t => t.Create(It.IsAny<TestEntity>()), Times.Once);
        }
    }
}
