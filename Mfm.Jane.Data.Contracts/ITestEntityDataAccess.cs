using Mfm.Jane.Data.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mfm.Jane.Data.Contracts
{
    public interface ITestEntityDataAccess
    {
        Task CreateTestEntity(string test, string createdBy="");
        Task<List<TestEntity>> GetTestEntitiies();
    }
}
