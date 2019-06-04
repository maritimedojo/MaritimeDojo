using System.Linq;
using MaritimeDojo.Db.Entities;

namespace MaritimeDojo.Db.Queries
{
    /// <summary>
    /// Object representation of query returning all lecture halls from db
    /// </summary>
    public class GetAllLectureHallsQuery
    {
        private readonly IDatabase db;

        public GetAllLectureHallsQuery(IDatabase db)
        {
            this.db = db;
        }

        public IQueryable<LectureHall> Execute()
        {
            return db.LectureHalls.Values.AsQueryable();
        }
    }
}