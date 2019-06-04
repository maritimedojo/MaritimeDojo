using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using MaritimeDojo.Db;
using MaritimeDojo.Db.Entities;

namespace MaritimeDojo.Tests
{
    /// <summary>
    /// Responsible for db creation and filling it with initial sample data 
    /// </summary>
    public static class TestDatabaseFactory
    {
        private static IDictionary<int, Reservation> _reservations;
        private static IDictionary<int, Lecturer> _lecturers;
        private static IDictionary<int, LectureHall> _lectureHalls;
        private static IDictionary<int, Subject> _subjects;

        public static IDatabase CreateEmptyDatabase()
        {
            return new InMemoryDatabase(new ConcurrentDictionary<int, Reservation>(),
                new ConcurrentDictionary<int, Lecturer>(), new ConcurrentDictionary<int, LectureHall>(),
                new ConcurrentDictionary<int, Subject>());
        }

        public static IDatabase CreateDatabase()
        {
            SetInitialData();
            return new InMemoryDatabase(_reservations, _lecturers, _lectureHalls, _subjects);
        }

        public static IDatabase CreateDatabaseForStatistics()
        {
            SetInitialDataForStatistics();
            return new InMemoryDatabase(_reservations, _lecturers, _lectureHalls, _subjects);
        }

        private static void SetInitialData()
        {
            _reservations = new ConcurrentDictionary<int, Reservation>();
            _lecturers = new ConcurrentDictionary<int, Lecturer>();
            _lectureHalls = new ConcurrentDictionary<int, LectureHall>();
            _subjects = new ConcurrentDictionary<int, Subject>();
            
            // Lecture Halls

            var lh101 = new LectureHall
            {
                Number = 101,
                Capacity = 100
            };

            var lh102 = new LectureHall
            {
                Number = 102,
                Capacity = 200
            };

            var lh105 = new LectureHall
            {
                Number = 105,
                Capacity = 30
            };

            var lh108 = new LectureHall
            {
                Number = 108,
                Capacity = 100
            };

            var lh201 = new LectureHall
            {
                Number = 201,
                Capacity = 200
            };

            var lh202 = new LectureHall
            {
                Number = 202,
                Capacity = 30
            };

            var lh210 = new LectureHall
            {
                Number = 210,
                Capacity = 30
            };

            var lh212 = new LectureHall
            {
                Number = 212,
                Capacity = 100
            };

            _lectureHalls.Add(lh101.Number, lh101);
            _lectureHalls.Add(lh102.Number, lh102);
            _lectureHalls.Add(lh105.Number, lh105);
            _lectureHalls.Add(lh108.Number, lh108);
            _lectureHalls.Add(lh201.Number, lh201);
            _lectureHalls.Add(lh202.Number, lh202);
            _lectureHalls.Add(lh210.Number, lh210);
            _lectureHalls.Add(lh212.Number, lh212);


            // Subjects

            var s1 = new Subject
            {
                Id = 1,
                Name = "Statistics",
                Size = 4,
                Lecturers = new List<Lecturer>()
            };

            var s2 = new Subject
            {
                Id = 2,
                Name = "Algebra",
                Size = 4,
                Lecturers = new List<Lecturer>()
            };

            var s3 = new Subject
            {
                Id = 3,
                Name = "Logic",
                Size = 2,
                Lecturers = new List<Lecturer>()
            };

            var s4 = new Subject
            {
                Id = 4,
                Name = "Analysis",
                Size = 5,
                Lecturers = new List<Lecturer>()
            };

            // Lecturers

            var l1 = new Lecturer()
            {
                Id = 1,
                Name = "John",
                Surname = "Nash",
                Title = "prof. ",
                ConductedLecture = s1
            };

            var l2 = new Lecturer()
            {
                Id = 2,
                Name = "Steve",
                Surname = "Wozniak",
                Title = "dr ",
                ConductedLecture = s1
            };

            var l3 = new Lecturer()
            {
                Id = 3,
                Name = "Jim",
                Surname = "Morrisson",
                Title = "prof. ",
                ConductedLecture = s2
            };

            var l4 = new Lecturer()
            {
                Id = 4,
                Name = "Ronnie",
                Surname = "O'Sullivan",
                Title = "prof. ",
                ConductedLecture = s2
            };

            var l5 = new Lecturer()
            {
                Id = 5,
                Name = "James",
                Surname = "Milner",
                Title = string.Empty,
                ConductedLecture = s3
            };

            var l6 = new Lecturer()
            {
                Id = 6,
                Name = "Roger",
                Surname = "Schmidt",
                Title = "prof. ",
                ConductedLecture = s4
            };

            var l7 = new Lecturer()
            {
                Id = 7,
                Name = "Julian",
                Surname = "Archibald",
                Title = "dr ",
                ConductedLecture = s4
            };

            var l8 = new Lecturer()
            {
                Id = 8,
                Name = "Christian",
                Surname = "Vogelsang",
                Title = string.Empty,
                ConductedLecture = s4
            };

            s1.Lecturers.Add(l1);
            s1.Lecturers.Add(l2);
            s2.Lecturers.Add(l3);
            s2.Lecturers.Add(l4);
            s3.Lecturers.Add(l5);
            s4.Lecturers.Add(l6);
            s4.Lecturers.Add(l7);
            s4.Lecturers.Add(l8);

            _subjects.Add(s1.Id, s1);
            _subjects.Add(s2.Id, s2);
            _subjects.Add(s3.Id, s3);
            _subjects.Add(s4.Id, s4);

            _lecturers.Add(l1.Id, l1);
            _lecturers.Add(l2.Id, l2);
            _lecturers.Add(l3.Id, l3);
            _lecturers.Add(l4.Id, l4);
            _lecturers.Add(l5.Id, l5);
            _lecturers.Add(l6.Id, l6);
            _lecturers.Add(l7.Id, l7);
            _lecturers.Add(l8.Id, l8);


            // Reservations

            var r1 = new Reservation
            {
                Id = 1,
                From = new DateTime(2015, 1, 2, 8, 0, 0),
                To = new DateTime(2015, 1, 2, 8, 0, 0).AddHours(2),
                Hall = lh202,
                Lecturer = l5
            };

            var r2 = new Reservation
            {
                Id = 2,
                From = new DateTime(2015, 1, 2, 11, 0, 0),
                To = new DateTime(2015, 1, 2, 11, 0, 0).AddHours(1),
                Hall = lh202,
                Lecturer = l2
            };

            var r3 = new Reservation
            {
                Id = 3,
                From = new DateTime(2015, 1, 2, 16, 0, 0),
                To = new DateTime(2015, 1, 5, 16, 0, 0).AddHours(2),
                Hall = lh202,
                Lecturer = l8
            };

            _reservations.Add(r1.Id, r1);
            _reservations.Add(r2.Id, r2);
            _reservations.Add(r3.Id, r3);
        }

        private static void SetInitialDataForStatistics()
        {
            _reservations = new ConcurrentDictionary<int, Reservation>();
            _lecturers = new ConcurrentDictionary<int, Lecturer>();
            _lectureHalls = new ConcurrentDictionary<int, LectureHall>();
            _subjects = new ConcurrentDictionary<int, Subject>();


            // Lecture Halls

            var lh101 = new LectureHall
            {
                Number = 101,
                Capacity = 100
            };

            var lh102 = new LectureHall
            {
                Number = 102,
                Capacity = 200
            };

            var lh105 = new LectureHall
            {
                Number = 105,
                Capacity = 30
            };

            var lh108 = new LectureHall
            {
                Number = 108,
                Capacity = 100
            };

            var lh201 = new LectureHall
            {
                Number = 201,
                Capacity = 200
            };

            var lh202 = new LectureHall
            {
                Number = 202,
                Capacity = 30
            };

            var lh210 = new LectureHall
            {
                Number = 210,
                Capacity = 30
            };

            var lh212 = new LectureHall
            {
                Number = 212,
                Capacity = 100
            };

            _lectureHalls.Add(lh101.Number, lh101);
            _lectureHalls.Add(lh102.Number, lh102);
            _lectureHalls.Add(lh105.Number, lh105);
            _lectureHalls.Add(lh108.Number, lh108);
            _lectureHalls.Add(lh201.Number, lh201);
            _lectureHalls.Add(lh202.Number, lh202);
            _lectureHalls.Add(lh210.Number, lh210);
            _lectureHalls.Add(lh212.Number, lh212);


            // Subjects

            var s1 = new Subject
            {
                Id = 1,
                Name = "Statistics",
                Size = 4,
                Lecturers = new List<Lecturer>()
            };

            var s2 = new Subject
            {
                Id = 2,
                Name = "Algebra",
                Size = 4,
                Lecturers = new List<Lecturer>()
            };

            var s3 = new Subject
            {
                Id = 3,
                Name = "Logic",
                Size = 2,
                Lecturers = new List<Lecturer>()
            };

            var s4 = new Subject
            {
                Id = 4,
                Name = "Analysis",
                Size = 5,
                Lecturers = new List<Lecturer>()
            };

            // Lecturers

            var l1 = new Lecturer()
            {
                Id = 1,
                Name = "John",
                Surname = "Nash",
                Title = "prof. ",
                ConductedLecture = s1
            };

            var l2 = new Lecturer()
            {
                Id = 2,
                Name = "Steve",
                Surname = "Wozniak",
                Title = "dr ",
                ConductedLecture = s1
            };

            var l3 = new Lecturer()
            {
                Id = 3,
                Name = "Jim",
                Surname = "Morrisson",
                Title = "prof. ",
                ConductedLecture = s2
            };

            var l4 = new Lecturer()
            {
                Id = 4,
                Name = "Ronnie",
                Surname = "O'Sullivan",
                Title = "prof. ",
                ConductedLecture = s2
            };

            var l5 = new Lecturer()
            {
                Id = 5,
                Name = "James",
                Surname = "Milner",
                Title = string.Empty,
                ConductedLecture = s3
            };

            var l6 = new Lecturer()
            {
                Id = 6,
                Name = "Roger",
                Surname = "Schmidt",
                Title = "prof. ",
                ConductedLecture = s4
            };

            var l7 = new Lecturer()
            {
                Id = 7,
                Name = "Julian",
                Surname = "Archibald",
                Title = "dr ",
                ConductedLecture = s4
            };

            var l8 = new Lecturer()
            {
                Id = 8,
                Name = "Christian",
                Surname = "Vogelsang",
                Title = string.Empty,
                ConductedLecture = s4
            };

            s1.Lecturers.Add(l1);
            s1.Lecturers.Add(l2);
            s2.Lecturers.Add(l3);
            s2.Lecturers.Add(l4);
            s3.Lecturers.Add(l5);
            s4.Lecturers.Add(l6);
            s4.Lecturers.Add(l7);
            s4.Lecturers.Add(l8);

            _subjects.Add(s1.Id, s1);
            _subjects.Add(s2.Id, s2);
            _subjects.Add(s3.Id, s3);
            _subjects.Add(s4.Id, s4);

            _lecturers.Add(l1.Id, l1);
            _lecturers.Add(l2.Id, l2);
            _lecturers.Add(l3.Id, l3);
            _lecturers.Add(l4.Id, l4);
            _lecturers.Add(l5.Id, l5);
            _lecturers.Add(l6.Id, l6);
            _lecturers.Add(l7.Id, l7);
            _lecturers.Add(l8.Id, l8);


            // Reservations

            var day1 = DateTime.Today.AddDays(1);
            var day2 = DateTime.Today.AddDays(2);

            var r1 = new Reservation
            {
                Id = 1,
                From = new DateTime(day1.Year, day1.Month, day1.Day, 8, 0, 0),
                To = new DateTime(day1.Year, day1.Month, day1.Day, 11, 0, 0),
                Hall = lh202,
                Lecturer = l5
            };

            var r2 = new Reservation
            {
                Id = 2,
                From = new DateTime(day1.Year, day1.Month, day1.Day, 10, 0, 0),
                To = new DateTime(day1.Year, day1.Month, day1.Day, 12, 0, 0),
                Hall = lh105,
                Lecturer = l5
            };

            var r3 = new Reservation
            {
                Id = 3,
                From = new DateTime(day2.Year, day2.Month, day2.Day, 8, 0, 0),
                To = new DateTime(day2.Year, day2.Month, day2.Day, 10, 0, 0),
                Hall = lh202,
                Lecturer = l2
            };

            var r4 = new Reservation
            {
                Id = 4,
                From = new DateTime(day2.Year, day2.Month, day2.Day, 10, 0, 0),
                To = new DateTime(day2.Year, day2.Month, day2.Day, 13, 0, 0),
                Hall = lh202,
                Lecturer = l8
            };

            var r5 = new Reservation
            {
                Id = 5,
                From = new DateTime(day2.Year, day2.Month, day2.Day, 13, 0, 0),
                To = new DateTime(day2.Year, day2.Month, day2.Day, 15, 0, 0),
                Hall = lh202,
                Lecturer = l8
            };

            var r6 = new Reservation
            {
                Id = 6,
                From = new DateTime(day2.Year, day2.Month, day2.Day, 15, 0, 0),
                To = new DateTime(day2.Year, day2.Month, day2.Day, 18, 0, 0),
                Hall = lh202,
                Lecturer = l8
            };

            _reservations.Add(r1.Id, r1);
            _reservations.Add(r2.Id, r2);
            _reservations.Add(r3.Id, r3);
            _reservations.Add(r4.Id, r4);
            _reservations.Add(r5.Id, r5);
            _reservations.Add(r6.Id, r6);
        }
    }
}