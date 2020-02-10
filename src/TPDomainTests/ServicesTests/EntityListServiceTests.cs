using EntityFramework.Data;
using TPDomain.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TPDomainTests.ServicesTests
{
    [TestClass]
    public class EntityListServiceTests : BaseServiceTests
    {
        private readonly IEntityListService _entityListService;

        public EntityListServiceTests()
        {
            _entityListService = new EntityListService(
                new Repository(_dbContext)
            );
        }

        [TestMethod]
        public void GetAvailabilities()
        {
            const int migrationSeedCount = 5;
            var entities = _entityListService.GetAvailabilities();

            Assert.AreEqual(entities.Count, migrationSeedCount);
        }

        [TestMethod]
        public void GetKnowledges()
        {
            const int migrationSeedCount = 32;
            var entities = _entityListService.GetKnowledges();

            Assert.AreEqual(entities.Count, migrationSeedCount);
        }

        [TestMethod]
        public void GetWorkingTimes()
        {
            const int migrationSeedCount = 5;
            var entities = _entityListService.GetWorkingTimes();

            Assert.AreEqual(entities.Count, migrationSeedCount);
        }
    }
}
