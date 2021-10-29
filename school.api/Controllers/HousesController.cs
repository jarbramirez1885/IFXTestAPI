using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using school.api.Entities;
using school.ApplicationCore.Services;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace school.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HousesController : ControllerBase
    {
        public readonly ApplicationDBContext dbContext;

        public HousesController(ApplicationDBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        /// <summary>
        /// Get list of Houses
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("getAllHouses")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [SwaggerOperation(
            Summary = "Get list of Houses",
            Description = "Get list of Houses")
        ]
        public ActionResult<IEnumerable<Application>> Get()
        {
            List<House> _listHouses = new List<House>
            {
                new House() { Id = 1, HouseName = "Gryffindor" },
                new House() { Id = 2, HouseName = "Hufflepuff" },
                new House() { Id = 3, HouseName = "Ravenclaw" },
                new House() { Id = 4, HouseName = "Slytherin" }
            };

            return Ok(_listHouses.ToList());
        }

    }
}
