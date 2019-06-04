using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Common;
using FluentAssertions;

namespace Common.Tests
{
    [TestClass]
    public class DateTimeExtensionsTests
    {
        [TestMethod]
        public void GetPreviousSaturday_TodayIsTuesday()
        {
            var date = DateTime.Parse("2019/06/04").GetPreviousDayOfWeek(DayOfWeek.Saturday);
            date.Should().Be(DateTime.Parse("2019/06/01"));
        }

        [TestMethod]
        public void GetPreviousSunday_TodayIsTuesday()
        {
            var date = DateTime.Parse("2019/06/04").GetPreviousDayOfWeek(DayOfWeek.Sunday);
            date.Should().Be(DateTime.Parse("2019/06/02"));
        }

        [TestMethod]
        public void GetPreviousMonday_TodayIsTuesday()
        {
            var date = DateTime.Parse("2019/06/04").GetPreviousDayOfWeek(DayOfWeek.Monday);
            date.Should().Be(DateTime.Parse("2019/06/03"));
        }

        [TestMethod]
        public void GetPreviousTuesday_TodayIsTuesday()
        {
            var date = DateTime.Parse("2019/06/04").GetPreviousDayOfWeek(DayOfWeek.Tuesday);
            date.Should().Be(DateTime.Parse("2019/05/28"));
        }

        [TestMethod]
        public void GetPreviousWednesday_TodayIsTuesday()
        {
            var date = DateTime.Parse("2019/06/04").GetPreviousDayOfWeek(DayOfWeek.Wednesday);
            date.Should().Be(DateTime.Parse("2019/05/29"));
        }

        [TestMethod]
        public void GetPreviousThursday_TodayIsTuesday()
        {
            var date = DateTime.Parse("2019/06/04").GetPreviousDayOfWeek(DayOfWeek.Thursday);
            date.Should().Be(DateTime.Parse("2019/05/30"));
        }

        [TestMethod]
        public void GetPreviousFriday_TodayIsTuesday()
        {
            var date = DateTime.Parse("2019/06/04").GetPreviousDayOfWeek(DayOfWeek.Friday);
            date.Should().Be(DateTime.Parse("2019/05/31"));
        }

        [TestMethod]
        public void GetNextSaturday_TodayIsTuesday()
        {
            var date = DateTime.Parse("2019/06/04").GetNextDayOfWeek(DayOfWeek.Saturday);
            date.Should().Be(DateTime.Parse("2019/06/08"));
        }

        [TestMethod]
        public void GetNextSunday_TodayIsTuesday()
        {
            var date = DateTime.Parse("2019/06/04").GetNextDayOfWeek(DayOfWeek.Sunday);
            date.Should().Be(DateTime.Parse("2019/06/09"));
        }

        [TestMethod]
        public void GetNextMonday_TodayIsTuesday()
        {
            var date = DateTime.Parse("2019/06/04").GetNextDayOfWeek(DayOfWeek.Monday);
            date.Should().Be(DateTime.Parse("2019/06/10"));
        }

        [TestMethod]
        public void GetNextTuesday_TodayIsTuesday()
        {
            var date = DateTime.Parse("2019/06/04").GetNextDayOfWeek(DayOfWeek.Tuesday);
            date.Should().Be(DateTime.Parse("2019/06/11"));
        }

        [TestMethod]
        public void GetNextWednesday_TodayIsTuesday()
        {
            var date = DateTime.Parse("2019/06/04").GetNextDayOfWeek(DayOfWeek.Wednesday);
            date.Should().Be(DateTime.Parse("2019/06/05"));
        }

        [TestMethod]
        public void GetNextThursday_TodayIsTuesday()
        {
            var date = DateTime.Parse("2019/06/04").GetNextDayOfWeek(DayOfWeek.Thursday);
            date.Should().Be(DateTime.Parse("2019/06/06"));
        }

        [TestMethod]
        public void GetNextFriday_TodayIsTuesday()
        {
            var date = DateTime.Parse("2019/06/04").GetNextDayOfWeek(DayOfWeek.Friday);
            date.Should().Be(DateTime.Parse("2019/06/07"));
        }
    }
}
