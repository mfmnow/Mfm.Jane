using Mfm.Jane.Data.Contracts;
using Mfm.Jane.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mfm.Jane.Data.Services
{
    public class TestEntityDataAccess : GenericRepository<TestEntity>, ITestEntityDataAccess
    {
        private readonly IJaneTestDbContext _context;

        public TestEntityDataAccess(JaneTestDbContext janeTestDbContext) : base(janeTestDbContext)
        {
            _context = janeTestDbContext;
        }

        public async Task CreateTestEntity(string test, string createdBy = "")
        {
            var entity = new TestEntity
            {
                Test = test,
                CreatedBy = createdBy
            };
            await Create(entity);
        }

        public async Task<List<TestEntity>> GetTestEntitiies()
        {
            return await GetAll();
        }
    }
}
