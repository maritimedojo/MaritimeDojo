using System.Linq;
using MaritimeDojo.Db.Entities;

namespace MaritimeDojo.Db.Queries
{
    /// <summary>
    /// Object representation of query returning all subjects from db
    /// </summary>
    public class GetAllSubjectsQuery
    {
        private readonly IDatabase db;

        public GetAllSubjectsQuery(IDatabase db)
        {
            this.db = db;
        }

        public IQueryable<Subject> Execute()
        {
            return db.Subjects.Values.AsQueryable();
        }
    }
}