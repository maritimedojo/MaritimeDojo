using System.Collections.Generic;
using System.Web.Http;
using MaritimeDojo.Models;
using MaritimeDojo.Services.Interfaces;

namespace MaritimeDojo.Controllers
{
    /// <summary>
    /// API controller to manage listing lecture halls
    /// </summary>
    public class LectureHallsController : ApiController
    {
        private readonly ILectureHallsService service;

        public LectureHallsController(ILectureHallsService service)
        {
            this.service = service;
        }

        // GET: api/LectureHalls
        public IEnumerable<LectureHallItem> Get()
        {
            return service.All();
        }
    }
}
