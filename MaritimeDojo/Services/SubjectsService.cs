using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using MaritimeDojo.Db.Queries;
using MaritimeDojo.Models;
using MaritimeDojo.Services.Interfaces;

namespace MaritimeDojo.Services
{
    /// <summary>
    /// Implementation of business logic methods concerning subjects
    /// </summary>
    public class SubjectsService : ISubjectsService
    {
        private readonly GetAllSubjectsQuery query;

        public SubjectsService(GetAllSubjectsQuery query)
        {
            this.query = query;
        }

        /// <summary>
        /// Lists all subjects that exist in db
        /// </summary>
        public IEnumerable<SubjectItem> All()
        {
            return Mapper.Map<IEnumerable<SubjectItem>>(query.Execute().ToList());
        }
    }
}