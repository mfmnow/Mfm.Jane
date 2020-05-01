using Mfm.Jane.Data.Contracts;
using Mfm.Jane.Domain.Models;
using Moq;

namespace Mfm.Jane.Domain.Services.UnitTests.MockProviders
{
    internal class TestModelDomainServiceMockerProvider
    {
        private static Mock<ITestEntityDataAccess> _testModelDataAccess;
        private static  Mock<TestModelDomainService> _testModelDomainService;

        public static TestModel MockedValidTestModel = new TestModel
        {
            Test = "Test"
        };

        public static TestModel MockedInvalidTestModel = new TestModel
        {
            Test = ""
        };

        public static (Mock<ITestEntityDataAccess>, Mock<TestModelDomainService>) GetMocks() {
            _testModelDataAccess = new Mock<ITestEntityDataAccess>();
            _testModelDomainService = new Mock<TestModelDomainService>(_testModelDataAccess.Object)
            { CallBase = true };

            return (_testModelDataAccess, _testModelDomainService);
        }
    }
}
