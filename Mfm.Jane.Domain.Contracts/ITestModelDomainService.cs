using Mfm.Jane.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mfm.Jane.Domain.Contracts
{
    public interface ITestModelDomainService
    {
        Task CreateTestModel(TestModel testModelModel);
        Task<List<TestModel>> GetTestModels();
        bool IsValidModel(TestModel testModelModel);        
    }
}
