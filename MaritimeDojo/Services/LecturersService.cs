using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using MaritimeDojo.Db.Queries;
using MaritimeDojo.Models;
using MaritimeDojo.Services.Interfaces;

namespace MaritimeDojo.Services
{
    /// <summary>
    /// Implementation of business logic methods concerning lecturers
    /// </summary>
    public class LecturersService : ILecturersService
    {
        private readonly GetAllLecturersQuery query;

        public LecturersService(GetAllLecturersQuery query)
        {
            this.query = query;
        }

        /// <summary>
        /// Lists all lecturers that exist in db
        /// </summary>
        public IEnumerable<LecturerItem> All()
        {
            var lecturers = query.Execute().ToList();
            return Mapper.Map<IEnumerable<LecturerItem>>(lecturers);
        }
    }
}