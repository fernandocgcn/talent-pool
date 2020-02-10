using TPData;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.Common;

namespace TPDomainTests.ServicesTests
{
    [TestClass]
    public class BaseServiceTests
    {
        private readonly DbConnection _connection;
        protected readonly DbContext _dbContext;

        public BaseServiceTests()
        {
            _connection = new SqliteConnection("DataSource=:memory:");
            _connection.Open();

            var options = new DbContextOptionsBuilder<TPDbContext>()
                    .UseSqlite(_connection)
                    .Options;

            _dbContext = new TPDbContext(options);
            _dbContext.Database.EnsureCreated();
        }

        [TestCleanup]
        public void BaseTestCleanup()
        {
            _dbContext.Database.EnsureDeleted();
            _dbContext.Dispose();

            _connection.Close();
            _connection.Dispose();
        }
    }
}
