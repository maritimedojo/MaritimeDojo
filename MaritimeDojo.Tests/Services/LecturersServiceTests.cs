using System.ComponentModel;
using System.Linq;
using FluentAssertions;
using MaritimeDojo.Db;
using MaritimeDojo.Db.Queries;
using MaritimeDojo.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaritimeDojo.Tests.Services
{
    [TestClass]
    public class LecturersServiceTests
    {
        private GetAllLecturersQuery mockQueryAllLecturers;
        private IDatabase mockDb;

        [TestInitialize]
        public void Init()
        {
            AutoMapperConfig.Init();
            mockDb = TestDatabaseFactory.CreateDatabase();
            mockQueryAllLecturers = new GetAllLecturersQuery(mockDb);
        }

        [TestMethod]
        public void When_AllLecturersRunsAgainstEmptyDatabase_Then_EmptyCollectionIsReturned()
        {
            // Arrange
            var service = new LecturersService(new GetAllLecturersQuery(TestDatabaseFactory.CreateEmptyDatabase()));

            // Act
            var allLecturers = service.All();

            // Assert
            allLecturers.Should().BeEmpty();
        }

        [TestMethod]
        public void When_AllLecturersRunsAgainstNonEmptyDatabase_Then_AllLecturersAreReturned()
        {
            // Arrange
            var service = new LecturersService(mockQueryAllLecturers);
            
            // Act
            var allLecturers = service.All();

            // Assert
            allLecturers.Count().Should().Be(8);
        }
    }
}
