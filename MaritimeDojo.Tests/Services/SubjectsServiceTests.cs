using System.Linq;
using FluentAssertions;
using MaritimeDojo.Db;
using MaritimeDojo.Db.Queries;
using MaritimeDojo.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaritimeDojo.Tests.Services
{
    [TestClass]
    public class SubjectsServiceTests
    {
        private GetAllSubjectsQuery mockQueryAllSubjects;
        private IDatabase mockDb;

        [TestInitialize]
        public void Init()
        {
            AutoMapperConfig.Init();
            mockDb = TestDatabaseFactory.CreateDatabase();
            mockQueryAllSubjects = new GetAllSubjectsQuery(mockDb);
        }

        [TestMethod]
        public void When_AllSubjectsRunsAgainstEmptyDatabase_Then_EmptyCollectionIsReturned()
        {
            // Arrange
            var service = new SubjectsService(new GetAllSubjectsQuery(TestDatabaseFactory.CreateEmptyDatabase()));

            // Act
            var allSubjects = service.All();

            // Assert
            allSubjects.Should().BeEmpty();
        }

        [TestMethod]
        public void When_AllSubjectsRunsAgainstNonEmptyDatabase_Then_AllLecturersAreReturned()
        {
            // Arrange
            var service = new SubjectsService(mockQueryAllSubjects);

            // Act
            var allSubjects = service.All();

            // Assert
            allSubjects.Count().Should().Be(4);
        }
    }
}