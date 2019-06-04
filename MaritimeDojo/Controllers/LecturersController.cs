using System.Collections.Generic;
using System.Web.Http;
using MaritimeDojo.Models;
using MaritimeDojo.Services.Interfaces;

namespace MaritimeDojo.Controllers
{
    /// <summary>
    /// API controller to manage listing lecturers
    /// </summary>
    public class LecturersController : ApiController
    {
        private readonly ILecturersService service;

        public LecturersController(ILecturersService service)
        {
            this.service = service;
        }

        // GET: api/Lecturers
        public IEnumerable<LecturerItem> Get()
        {
            return service.All();
        }
    }
}
