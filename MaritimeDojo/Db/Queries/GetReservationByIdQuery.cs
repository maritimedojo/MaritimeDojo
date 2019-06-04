using MaritimeDojo.Db.Entities;

namespace MaritimeDojo.Db.Queries
{
    /// <summary>
    /// Object representation of query returning reservation by its id from db
    /// </summary>
    public class GetReservationByIdQuery
    {
        private readonly IDatabase db;

        public GetReservationByIdQuery(IDatabase db)
        {
            this.db = db;
        }

        public Reservation Execute(int id)
        {
            return db.Reservations.ContainsKey(id) ? db.Reservations[id] : null;
        }
    }
}