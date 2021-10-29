using school.ApplicationCore.Entities;
using school.ApplicationCore.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace school.ApplicationCore.Services
{
    public class HouseServices : IHouseServices
    {
        private readonly IAsyncRepository<DataHouse> _houseServices;

        public HouseServices(IAsyncRepository<DataHouse> houseServices)
        {
            _houseServices = houseServices;
        }

        public async Task<List<DataHouse>> GetAllHouses()
        {
            var x = new List<DataHouse>();
            await _houseServices.ListAllAsync();
            return x;
        }
    }
}
