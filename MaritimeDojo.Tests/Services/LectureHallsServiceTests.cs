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
    public class LectureHallsServiceTests
    {
        private GetAllLectureHallsQuery mockQueryAllLectureHalls;
        private IDatabase mockDb;

        [TestInitialize]
        public void Init()
        {
            AutoMapperConfig.Init();
            mockDb = TestDatabaseFactory.CreateDatabase();
            mockQueryAllLectureHalls = new GetAllLectureHallsQuery(mockDb);
        }

        [TestMethod]
        public void When_AllLectureHallsRunsAgainstEmptyDatabase_Then_EmptyCollectionIsReturned()
        {
            // Arrange
            var service = new LectureHallsService(new GetAllLectureHallsQuery(TestDatabaseFactory.CreateEmptyDatabase()));

            // Act
            var allLectureHalls = service.All();

            // Assert
            allLectureHalls.Should().BeEmpty();
        }

        [TestMethod]
        public void When_AllLectureHallsRunsAgainstNonEmptyDatabase_Then_AllLectureHallsAreReturned()
        {
            // Arrange
            var service = new LectureHallsService(mockQueryAllLectureHalls);

            // Act
            var allLectureHalls = service.All();

            // Assert
            allLectureHalls.Count().Should().Be(8);
        }
    }
}
