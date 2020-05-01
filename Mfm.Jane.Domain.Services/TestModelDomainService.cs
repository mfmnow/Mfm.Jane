using Mfm.Jane.Data.Contracts;
using Mfm.Jane.Domain.Contracts;
using Mfm.Jane.Domain.Models;
using Mfm.Jane.Domain.Models.Exceptions;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mfm.Jane.Domain.Services
{
    public class TestModelDomainService : ITestModelDomainService
    {
        private readonly ITestEntityDataAccess _testModelDataAccess;

        public TestModelDomainService(ITestEntityDataAccess testModelDataAccess)
        {
            _testModelDataAccess = testModelDataAccess;
        }

        public virtual async Task CreateTestModel(TestModel testModel)
        {
            if (!IsValidModel(testModel)) {
                throw new InvalidTestModelException("Invalid Text Passed");
            }
            await _testModelDataAccess.CreateTestEntity(testModel.Test);
        }

        public async Task<List<TestModel>> GetTestModels()
        {
            var result= await _testModelDataAccess.GetTestEntitiies();
            return result.Select(t => { 
                    return new TestModel { Test = t.Test }; 
                })
                .ToList();
        }

        public virtual bool IsValidModel(TestModel testModel)
        {
            return ! string.IsNullOrEmpty(testModel.Test);
        }
    }
}
