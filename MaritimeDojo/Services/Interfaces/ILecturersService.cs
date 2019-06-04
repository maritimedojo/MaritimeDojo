using System.Collections.Generic;
using MaritimeDojo.Models;

namespace MaritimeDojo.Services.Interfaces
{
    /// <summary>
    /// Interface for business logic methods concerning lecturers
    /// </summary>
    public interface ILecturersService
    {
        IEnumerable<LecturerItem> All();
    }
}
