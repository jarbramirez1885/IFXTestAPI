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
    public class ApplicationsController : ControllerBase
    {
        public readonly ApplicationDBContext dbContext;
        public readonly IApplicationsServices _applicationServices;

        public ApplicationsController(ApplicationDBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        /// <summary>
        /// Get list of Applications
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("getAllApplications")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [SwaggerOperation(
            Summary = "Get list of Applications",
            Description = "Get list of Applications")
        ]
        public ActionResult<IEnumerable<Application>> Get()
        {
            return Ok(dbContext.Applications.ToList());
        }

        /// <summary>
        /// Get an Application by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("getApplicationById/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [SwaggerOperation(
            Summary = "Get an Application by Id",
            Description = "Get an Applications by Id")
        ]
        public ActionResult Get(int id)
        {
            var result = dbContext.Applications.Where(x => x.Id == id).FirstOrDefault();

            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }

        /// <summary>
        /// Input a new Application.
        /// </summary>
        /// <param name="apply"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("addNewApplication")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [SwaggerOperation(
            Summary = "Input a new Application.",
            Description = "Input a new Application.")
        ]
        public ActionResult Post([FromBody] Application apply)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                dbContext.Applications.Add(apply);
                dbContext.SaveChanges();
                return Ok(StatusCodes.Status200OK);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }

        /// <summary>
        /// Update an Application.
        /// </summary>
        /// <param name="newApply"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("updateApplication")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [SwaggerOperation(
            Summary = "Update an Application.",
            Description = "Update an Application.")
        ]
        public ActionResult Put([FromBody] Application newApply)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                Application result = dbContext.Applications.Where(x => x.Id == newApply.Id).FirstOrDefault();

                if (result != null)
                {
                    result.Name = newApply.Name;
                    result.LastName = newApply.LastName;
                    result.Age = newApply.Age;
                    result.House = newApply.House;
                    result.Identification = newApply.Identification;

                    dbContext.Applications.Update(result);
                    dbContext.SaveChanges();
                    return Ok(StatusCodes.Status200OK);
                }
                else
                {
                    return NotFound("Register not found");
                }

            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Delete an Application.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("deleteApplication/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [SwaggerOperation(
            Summary = "Delete an Application.",
            Description = "Delete an Application.")
        ]
        public ActionResult Delete(int id)
        {
            try
            {
                Application result = new Application();

                result = dbContext.Applications.Where(x => x.Id == id).FirstOrDefault();

                if (result != null)
                {
                    dbContext.Applications.Remove(result);
                    dbContext.SaveChanges();
                    return Ok(StatusCodes.Status200OK);
                }
                else
                {
                    return NotFound("Register not found");
                }
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
