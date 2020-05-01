using Mfm.Jane.App.Controllers;
using Mfm.Jane.Domain.Contracts;
using Mfm.Jane.Domain.Models.Exceptions;
using Mfm.Jane.App.UnitTests.MockProviders;
using Microsoft.Extensions.Logging;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace Mfm.Jane.App.UnitTests
{
    public class CreateTestModelControllerUnitTests
    {
        private readonly Mock<ITestModelDomainService> _mockedTestModelDomainService;
        private readonly Mock<ILogger<TestModelController>> _mockedLogger;
        private readonly Mock<TestModelController> _testModelController;

        public CreateTestModelControllerUnitTests()
        {
            _mockedTestModelDomainService = new Mock<ITestModelDomainService>();
            _mockedLogger = new Mock<ILogger<TestModelController>>();
            _testModelController = new Mock<TestModelController>(_mockedTestModelDomainService.Object, _mockedLogger.Object)
            { CallBase = true };
        }

        [Fact]
        public async Task CreateTestModel_Should_Follow_LogicalFlow_On_Valid_Model()
        {
            await _testModelController.Object.CreateTestModel(CreateTestModelControllerMockerProvider.MockedTestModel);

            _mockedTestModelDomainService.Verify(t => t.CreateTestModel(CreateTestModelControllerMockerProvider.MockedTestModel), Times.Once);
        }

        [Fact]
        public async Task CreateTestModel_Should_Return_Right_Model_On_Success()
        {
            var result = await _testModelController.Object.CreateTestModel(CreateTestModelControllerMockerProvider.MockedTestModel);

            Assert.True(result.Success);
            Assert.True(string.IsNullOrEmpty(result.ErrorMessage));
            _mockedTestModelDomainService.Verify(t => t.CreateTestModel(CreateTestModelControllerMockerProvider.MockedTestModel), Times.Once);
        }

        [Fact]
        public async Task CreateTestModel_Should_Return_Right_Model_On_ValidationError ()
        {
            _mockedTestModelDomainService.Setup(t => t.CreateTestModel(CreateTestModelControllerMockerProvider.MockedTestModel)).Throws(
                new InvalidTestModelException(CreateTestModelControllerMockerProvider.MockedErrorMessage)
                );
            var result = await _testModelController.Object.CreateTestModel(CreateTestModelControllerMockerProvider.MockedTestModel);

            Assert.False(result.Success);
            Assert.Equal(result.ErrorMessage, CreateTestModelControllerMockerProvider.MockedErrorMessage);
            _mockedTestModelDomainService.Verify(t => t.CreateTestModel(CreateTestModelControllerMockerProvider.MockedTestModel), Times.Once);
        }
    }
}