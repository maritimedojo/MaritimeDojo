using System;
using System.Linq;
using FluentAssertions;
using MaritimeDojo.Db;
using MaritimeDojo.Db.Queries;
using MaritimeDojo.Models;
using MaritimeDojo.Services;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaritimeDojo.Tests.Services
{
    [TestClass]
    public class ReservationsServiceTests
    {
        private GetAllLectureHallsQuery mockQueryAllLectureHalls;
        private GetAllLecturersQuery mockQueryAllLectures;
        private GetAllReservationsQuery mockQueryAllReservations;
        private AddReservationQuery mockQueryAddReservation;
        private DeleteReservationQuery mockQueryDeleteReservation;
        private GetReservationByIdQuery mockQueryGetReservationById;

        private IDatabase mockDb;

        [TestInitialize]
        public void Init()
        {
            AutoMapperConfig.Init();
        }

        private ReservationsService CreateReservationsService(bool empty)
        {
            mockDb = empty ? TestDatabaseFactory.CreateEmptyDatabase() : TestDatabaseFactory.CreateDatabase();

            mockQueryAllLectureHalls = new GetAllLectureHallsQuery(mockDb);
            mockQueryAllLectures = new GetAllLecturersQuery(mockDb);
            mockQueryAllReservations = new GetAllReservationsQuery(mockDb);
            mockQueryAddReservation = new AddReservationQuery(mockDb);
            mockQueryDeleteReservation = new DeleteReservationQuery(mockDb);
            mockQueryGetReservationById = new GetReservationByIdQuery(mockDb);

            return new ReservationsService(mockQueryAllReservations, mockQueryGetReservationById,
                mockQueryAddReservation, mockQueryDeleteReservation, mockQueryAllLectures, mockQueryAllLectureHalls);
        }

        private ReservationsService CreateReservationsServiceForStatisticsTests()
        {
            mockDb = TestDatabaseFactory.CreateDatabaseForStatistics();

            mockQueryAllLectureHalls = new GetAllLectureHallsQuery(mockDb);
            mockQueryAllLectures = new GetAllLecturersQuery(mockDb);
            mockQueryAllReservations = new GetAllReservationsQuery(mockDb);
            mockQueryAddReservation = new AddReservationQuery(mockDb);
            mockQueryDeleteReservation = new DeleteReservationQuery(mockDb);
            mockQueryGetReservationById = new GetReservationByIdQuery(mockDb);

            return new ReservationsService(mockQueryAllReservations, mockQueryGetReservationById,
                mockQueryAddReservation, mockQueryDeleteReservation, mockQueryAllLectures, mockQueryAllLectureHalls);
        }

        [TestMethod]
        public void When_AddReservationRunsAndItIsCorrect_Then_ItIsAdded()
        {
            // Arrange
            var service = CreateReservationsService(false);

            var newReservation = new NewReservationItem
            {
                From = new DateTime(2015, 1, 2, 14, 0, 0),
                To = new DateTime(2015, 1, 2, 16, 0, 0),
                LectureHallNumber = 202,
                LecturerId = 8
            };

            // Act
            var result = service.Add(newReservation);

            // Assert
            ((result & ValidationResult.Conflicting) == ValidationResult.Conflicting).Should().BeFalse();
            ((result & ValidationResult.Ok) == ValidationResult.Ok).Should().BeTrue();
            service.All().Count().Should().Be(4);
            service.GetById(4).LectureHallNumber.Should().Be(202);
        }

        [TestMethod]
        public void
            When_AddReservationRunsAndItIsNoCorrectBecauseOfManyReasons_Then_ItIsNotAddedAndFullInformationIsReturned()
        {
            // Arrange
            var service = CreateReservationsService(false);

            var newReservation = new NewReservationItem
            {
                From = new DateTime(2015, 1, 2, 10, 0, 0),
                To = new DateTime(2015, 1, 2, 20, 0, 0),
                LectureHallNumber = 202,
                LecturerId = 100
            };

            // Act
            var result = service.Add(newReservation);

            // Assert
            ((result & ValidationResult.TooLong) == ValidationResult.TooLong).Should().BeTrue();
            ((result & ValidationResult.OutsideWorkingHours) == ValidationResult.OutsideWorkingHours).Should().BeTrue();
            ((result & ValidationResult.Conflicting) == ValidationResult.Conflicting).Should().BeTrue();
            ((result & ValidationResult.LecturerDoesNotExist) == ValidationResult.LecturerDoesNotExist).Should()
                .BeTrue();
            ((result & ValidationResult.HallDoesNotExist) == ValidationResult.HallDoesNotExist).Should().BeFalse();
            ((result & ValidationResult.Ok) == ValidationResult.Ok).Should().BeFalse();
            service.All().Count().Should().Be(3);
        }

        [TestMethod]
        public void When_AddReservationRunsAndItIsNotInConflictOnHall_Then_ItIsAdded()
        {
            // Arrange
            var service = CreateReservationsService(false);

            var newReservation = new NewReservationItem
            {
                From = new DateTime(2015, 1, 2, 9, 0, 0),
                To = new DateTime(2015, 1, 2, 12, 0, 0),
                LectureHallNumber = 201,
                LecturerId = 1
            };

            // Act
            var result = service.Add(newReservation);

            // Assert
            ((result & ValidationResult.Ok) == ValidationResult.Ok).Should().BeTrue();
            service.All().Count().Should().Be(4);
            service.GetById(4).LectureHallNumber.Should().Be(201);
        }


        [TestMethod]
        public void When_AddReservationRunsAndItIsNotInConflictWithAnyButIsBorderline_Then_ItIsAdded()
        {
            // Arrange
            var service = CreateReservationsService(false);

            var newReservation = new NewReservationItem
            {
                From = new DateTime(2015, 1, 2, 10, 0, 0),
                To = new DateTime(2015, 1, 2, 11, 0, 0),
                LectureHallNumber = 202,
                LecturerId = 8
            };

            // Act
            var result = service.Add(newReservation);

            // Assert
            ((result & ValidationResult.Conflicting) == ValidationResult.Conflicting).Should().BeFalse();
            ((result & ValidationResult.Ok) == ValidationResult.Ok).Should().BeTrue();
            service.All().Count().Should().Be(4);
            service.GetById(4).LectureHallNumber.Should().Be(202);
        }


        [TestMethod]
        public void When_AllReservationsRunsAgainstEmptyDatabase_Then_EmptyCollectionIsReturned()
        {
            // Arrange
            var service = CreateReservationsService(true);

            // Act
            var allReservations = service.All();

            // Assert
            allReservations.Should().BeEmpty();
        }

        [TestMethod]
        public void When_AllReservationsRunsAgainstNotEmptyDatabase_Then_AllReservationsAreReturned()
        {
            // Arrange
            var service = CreateReservationsService(false);

            // Act
            var allReservations = service.All();

            // Assert
            allReservations.Count().Should().Be(3);
        }

        [TestMethod]
        public void When_DeleteReservationRunsAndThatReservationDoesNotExist_Then_NothingHappens()
        {
            // Arrange
            var service = CreateReservationsService(true);

            // Act
            service.Delete(1);

            // Assert
            service.All().Should().BeEmpty();
        }

        [TestMethod]
        public void When_DeleteReservationRunsAndThatReservationExists_Then_ItIsDeleted()
        {
            // Arrange
            var service = CreateReservationsService(false);

            // Act
            service.Delete(1);

            // Assert
            service.All().Count().Should().Be(2);
            service.GetById(1).Should().BeNull();
            service.GetById(2).Should().NotBeNull();
        }

        [TestMethod]
        public void When_GetReservationByIdRunsAndThatReservationDoesNotExist_Then_NullObjectIsReturned()
        {
            // Arrange
            var service = CreateReservationsService(true);

            // Act
            var reservationById = service.GetById(101);

            // Assert
            reservationById.Should().BeNull();
        }

        [TestMethod]
        public void When_GetReservationByIdRunsAndThatReservationExists_Then_ProperReservationIsReturned()
        {
            // Arrange
            var service = CreateReservationsService(false);

            // Act
            var reservationById = service.GetById(2);

            // Assert
            reservationById.Id.Should().Be(2);
            reservationById.LectureHallNumber.Should().Be(202);
        }
    }

}
