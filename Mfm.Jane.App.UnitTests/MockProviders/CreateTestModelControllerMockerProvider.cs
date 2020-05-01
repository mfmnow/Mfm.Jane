using Mfm.Jane.Domain.Models;

namespace Mfm.Jane.App.UnitTests.MockProviders
{
    internal class CreateTestModelControllerMockerProvider
    {
        public static string MockedErrorMessage = "MockedErrorMessage";
        public static TestModel MockedTestModel = new TestModel
        {
            Test = ""
        };
    }
}
