using System;
using System.Collections.Generic;
using System.Web.Http;
using MaritimeDojo.Models;
using MaritimeDojo.Services.Interfaces;

namespace MaritimeDojo.Controllers
{
    /// <summary>
    /// API controller to manage reservations
    /// </summary>
    public class ReservationsController : ApiController
    {
        private readonly IReservationsService service;

        public ReservationsController(IReservationsService service)
        {
            this.service = service;
        }

        // GET: api/Reservations
        public IEnumerable<ReservationItem> Get()
        {
            return service.All();
        }

        // GET: api/Reservations/5
        public ReservationItem Get(int id)
        {
            return service.GetById(id);
        }

        // GET: api/Reservations?day=2015-01-02&hallNumber=202
        public IEnumerable<ReservationItem> Get(DateTime day, int hallNumber)
        {
            return service.GetByDay(day, hallNumber);
        }

        // GET: api/Reservations?day=2015-01-02
        public IEnumerable<HallFreeHoursStatisticsItem> Get(DateTime day)
        {
            return service.GetHallsFreeHoursByDay(day);
        }

        // POST: api/Reservations
        // Reservation item must be specified in request body
        public ValidationResult Post([FromBody]NewReservationItem item)
        {
            return service.Add(item);
        }

        // DELETE: api/Reservations/5
        public void Delete(int id)
        {
            service.Delete(id);
        }
    }
}
