using System.Linq;
using MaritimeDojo.Db.Entities;

namespace MaritimeDojo.Db.Queries
{
    /// <summary>
    /// Object representation of query returning all reservations from db
    /// </summary>
    public class GetAllReservationsQuery
    {
        private readonly IDatabase db;

        public GetAllReservationsQuery(IDatabase db)
        {
            this.db = db;
        }

        public IQueryable<Reservation> Execute()
        {
            return db.Reservations.Values.AsQueryable();
        }
    }
}