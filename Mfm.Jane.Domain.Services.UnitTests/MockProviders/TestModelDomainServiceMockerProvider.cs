using Mfm.Jane.Data.Contracts;
using Mfm.Jane.Domain.Contracts;
using Mfm.Jane.Domain.Models;
using Moq;

namespace Mfm.Jane.Domain.Services.UnitTests.MockProviders
{
    internal class TestModelDomainServiceMockerProvider
    {
        private static Mock<ITestEntityDataAccess> _testModelDataAccess;
        private static  Mock<TestModelDomainService> _testModelDomainService;
        private static Mock<ITextManagerDomainService> _textManagerDomainService;

        public static TestModel MockedValidTestModel = new TestModel
        {
            Test = "Test"
        };

        public static TestModel MockedInvalidTestModel = new TestModel
        {
            Test = ""
        };

        public static string TextToUppper = "Hi";
        public static string ExpectedTextToUppper = "HI";

        public static (Mock<ITestEntityDataAccess>, Mock<TestModelDomainService>, Mock<ITextManagerDomainService>) GetMocks() {
            
            _testModelDataAccess = new Mock<ITestEntityDataAccess>();
            _textManagerDomainService = new Mock<ITextManagerDomainService>();
            _testModelDomainService = new Mock<TestModelDomainService>(_testModelDataAccess.Object, _textManagerDomainService.Object)
            { CallBase = true };

            return (_testModelDataAccess, _testModelDomainService, _textManagerDomainService);
        }
    }
}
