using school.ApplicationCore.Entities;
using school.ApplicationCore.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace school.ApplicationCore.Services
{
    public class ApplicationsServices : IApplicationsServices
    {
        private readonly IAsyncRepository<Application> _applicationsServices;

        public ApplicationsServices(IAsyncRepository<Application> applicationsServices)
        {
            _applicationsServices = applicationsServices;
        }

        public async Task<List<Application>> GetAllApplications()
        {
            return await _applicationsServices.ListAllAsync();
        }

        public async Task<Application> GetAllApplicationsById(long id)
        {
            return await _applicationsServices.GetByIdAsync(id);
        }
    }
}
