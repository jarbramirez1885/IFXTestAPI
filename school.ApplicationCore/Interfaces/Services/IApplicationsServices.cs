using school.ApplicationCore.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace school.ApplicationCore.Services
{
    public interface IApplicationsServices
    {
        Task<List<Application>> GetAllApplications();
        Task<Application> GetAllApplicationsById(long id);
    }
}