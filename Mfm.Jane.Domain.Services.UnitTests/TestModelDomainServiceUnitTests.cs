using Mfm.Jane.Data.Contracts;
using Mfm.Jane.Domain.Models;
using Mfm.Jane.Domain.Models.Exceptions;
using Mfm.Jane.Domain.Services.UnitTests.MockProviders;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace Mfm.Jane.Domain.Services.UnitTests
{
    public class TestModelDomainServiceUnitTests
    {
        private readonly Mock<ITestEntityDataAccess> _testModelDataAccess;
        private readonly Mock<TestModelDomainService> _testModelDomainService;

        public TestModelDomainServiceUnitTests()
        {
            (_testModelDataAccess, _testModelDomainService) =
                TestModelDomainServiceMockerProvider.GetMocks();
        }

        [Fact]
        public async Task CreateTestModel_Should_Follow_LogicalFlow_On_Valid_Model()
        {
            _testModelDomainService.Setup(t => t.IsValidModel(It.IsAny<TestModel>())).Returns(true);
            await _testModelDomainService.Object.CreateTestModel(TestModelDomainServiceMockerProvider.MockedValidTestModel);

            _testModelDomainService.Verify(t => t.IsValidModel(TestModelDomainServiceMockerProvider.MockedValidTestModel), Times.Once);
            _testModelDataAccess.Verify(t => t.CreateTestEntity(It.IsAny<string>(), ""), Times.Once);
        }

        [Fact]
        public void CreateTestModel_Should_Follow_LogicalFlow_On_InValid_Model()
        {
            _testModelDomainService.Setup(t => t.IsValidModel(It.IsAny<TestModel>())).Returns(false);

            Assert.ThrowsAsync<InvalidTestModelException>(() => _testModelDomainService.Object.CreateTestModel(TestModelDomainServiceMockerProvider.MockedValidTestModel));

            _testModelDomainService.Verify(t => t.IsValidModel(TestModelDomainServiceMockerProvider.MockedValidTestModel), Times.Once);
            _testModelDataAccess.Verify(t => t.CreateTestEntity(It.IsAny<string>(), ""), Times.Never);
        }

        [Fact]
        public void IsValidModel_Should_Return_True_If_Model_Is_Valid()
        {
            var result = _testModelDomainService.Object.IsValidModel(TestModelDomainServiceMockerProvider.MockedValidTestModel);

            Assert.True(result);
        }

        [Fact]
        public void IsValidModel_Should_Return_False_If_Model_Is_Not_Valid()
        {
            _testModelDomainService.Reset();
            var result = _testModelDomainService.Object.IsValidModel(TestModelDomainServiceMockerProvider.MockedInvalidTestModel);

            Assert.False(result);
        }
    }
}