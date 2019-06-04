namespace MaritimeDojo.Db.Queries
{
    /// <summary>
    /// Object representation of query deleting reservation entry from db
    /// </summary>
    public class DeleteReservationQuery
    {
        private readonly IDatabase db;

        public DeleteReservationQuery(IDatabase db)
        {
            this.db = db;
        }

        public void Execute(int id)
        {
            if (db.Reservations.ContainsKey(id))
            {
                db.Reservations.Remove(id);
            }
        }
    }
}