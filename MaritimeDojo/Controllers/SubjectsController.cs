using System.Collections.Generic;
using System.Web.Http;
using MaritimeDojo.Models;
using MaritimeDojo.Services.Interfaces;

namespace MaritimeDojo.Controllers
{
    /// <summary>
    /// API controller to manage listing subjects
    /// </summary>
    public class SubjectsController : ApiController
    {
        private readonly ISubjectsService service;

        public SubjectsController(ISubjectsService service)
        {
            this.service = service;
        }

        // GET: api/Subjects
        public IEnumerable<SubjectItem> Get()
        {
            return service.All();
        }
    }
}
