using Mfm.Jane.Data.Contracts;
using Mfm.Jane.Domain.Models;
using Mfm.Jane.Domain.Models.Exceptions;
using Mfm.Jane.Domain.Services.UnitTests.MockProviders;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace Mfm.Jane.Domain.Services.UnitTests
{
    public class TextManagerDomainServiceUnitTests
    {
        [Fact]
        public async Task ToUpper_Should_Return_Correct_Result()
        {
            var textManagerDomainService = new TextManagerDomainService();
            var result = await textManagerDomainService.ToUpper(TestModelDomainServiceMockerProvider.TextToUppper);
            Assert.Equal(result, TestModelDomainServiceMockerProvider.ExpectedTextToUppper);
        }        
    }
}