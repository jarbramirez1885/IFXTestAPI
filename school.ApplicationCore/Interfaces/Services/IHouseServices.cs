using school.ApplicationCore.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace school.ApplicationCore.Services
{
    public interface IHouseServices
    {
        Task<List<DataHouse>> GetAllHouses();
    }
}