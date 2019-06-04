using System.Linq;
using MaritimeDojo.Db.Entities;

namespace MaritimeDojo.Db.Queries
{
    /// <summary>
    /// Object representation of query returning all lecturers from db
    /// </summary>
    public class GetAllLecturersQuery
    {
        private readonly IDatabase db;

        public GetAllLecturersQuery(IDatabase db)
        {
            this.db = db;
        }

        public IQueryable<Lecturer> Execute()
        {
            return db.Lecturers.Values.AsQueryable();
        }
    }
}