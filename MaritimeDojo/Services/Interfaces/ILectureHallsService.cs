using System.Collections.Generic;
using MaritimeDojo.Models;

namespace MaritimeDojo.Services.Interfaces
{
    /// <summary>
    /// Interface for business logic methods concerning lecture halls
    /// </summary>
    public interface ILectureHallsService
    {
        IEnumerable<LectureHallItem> All();
    }
}
