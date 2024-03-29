using System;
using System.Collections.Generic;
using MaritimeDojo.Models;

namespace MaritimeDojo.Services.Interfaces
{
    /// <summary>
    /// Interface for business logic methods concerning reservations
    /// </summary>
    public interface IReservationsService
    {
        IEnumerable<ReservationItem> All();
        ReservationItem GetById(int id);
        IEnumerable<ReservationItem> GetByDay(DateTime day, int hallNumber);
        IEnumerable<HallFreeHoursStatisticsItem> GetHallsFreeHoursByDay(DateTime day);
        ValidationResult ValidateNewReservation(NewReservationItem reservation);
        ValidationResult Add(NewReservationItem reservation);
        void Delete(int id);
    }
}
