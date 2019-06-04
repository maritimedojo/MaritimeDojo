using System.Collections.Generic;
using MaritimeDojo.Models;

namespace MaritimeDojo.Services.Interfaces
{
    /// <summary>
    /// Interface for business logic methods concerning subjects
    /// </summary>
    public interface ISubjectsService
    {
        IEnumerable<SubjectItem> All();
    }
}
