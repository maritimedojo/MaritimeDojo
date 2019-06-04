using System.Linq;
using MaritimeDojo.Db.Entities;

namespace MaritimeDojo.Db.Queries
{
    /// <summary>
    /// Object representation of query adding new reservation entry to db
    /// </summary>
    public class AddReservationQuery
    {
        private readonly IDatabase db;

        public AddReservationQuery(IDatabase db)
        {
            this.db = db;
        }

        public void Execute(Reservation newReservation)
        {
            var id = db.Reservations.Keys.Max() + 1;        
            newReservation.Id = id;

            db.Reservations.Add(id, newReservation);
        }
    }
}