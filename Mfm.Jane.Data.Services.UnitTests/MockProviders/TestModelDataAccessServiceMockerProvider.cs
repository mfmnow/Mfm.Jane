using Mfm.Jane.Data.Entities;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace Mfm.Jane.Data.Services.UnitTests.MockProviders
{
    internal class TestModelDataAccessServiceMockerProvider
    {
        public static IQueryable<TestEntity> GetMockedData()
        {
            return new List<TestEntity>
            {
                new TestEntity
                {
                    Test = "Test"
                }
            }.AsQueryable();
        }

        public static Mock<TestEntityDataAccess> GetMockedDataAccessService()
        {
            var mockedDbContext = JaneTestDbContextMockerProvider.GetMockedJaneTestDbContext<JaneTestDbContext, TestEntity>(GetMockedData());
            var mockedDataAccessSerice = new Mock<TestEntityDataAccess>(mockedDbContext.Object) { CallBase = true };
            mockedDataAccessSerice =
               JaneTestDbContextMockerProvider.SetupDataAccessServices<TestEntityDataAccess, TestEntity>
               (mockedDataAccessSerice, GetMockedData());
            return mockedDataAccessSerice;
        }
    }
}
