using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using MaritimeDojo.Db.Queries;
using MaritimeDojo.Models;
using MaritimeDojo.Services.Interfaces;

namespace MaritimeDojo.Services
{
    /// <summary>
    /// Implementation of business logic methods concerning lecture halls
    /// </summary>
    public class LectureHallsService : ILectureHallsService
    {
        private readonly GetAllLectureHallsQuery query;

        public LectureHallsService(GetAllLectureHallsQuery query)
        {
            this.query = query;
        }

        /// <summary>
        /// Lists all lecture halls that exist in db
        /// </summary>
        public IEnumerable<LectureHallItem> All()
        {
            return Mapper.Map<IEnumerable<LectureHallItem>>(query.Execute().ToList()); 
        }
    }
}