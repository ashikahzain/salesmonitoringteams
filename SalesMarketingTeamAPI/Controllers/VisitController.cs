using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SalesMarketingTeamAPI.Models;
using SalesMarketingTeamAPI.Repository;
using SalesMarketingTeamAPI.ViewModel;

namespace SalesMarketingTeamAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VisitController : ControllerBase
    {
        IVisitTableRepository visitRepository;
        IConfiguration _config;

        public VisitController(IVisitTableRepository visitRepository, IConfiguration config)
        {
            this.visitRepository = visitRepository;
            _config = config;
        }

        //Get all Employees
        [HttpGet]
        public async Task<IActionResult> GetVisits()
        {
            try
            {
                var visits = await visitRepository.GetVisits();
                if (visits == null)
                {
                    return NotFound();
                }
                return Ok(visits);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        //Get visit by Id
        [HttpGet("{id}")]

        public async Task<ActionResult<Visittable>> GetVisitbyId(int id)
        {

            var result = await visitRepository.GetVisitbyId(id);

            if (result == null)
            {
                return null;
            }
            return result;


        }
        //View Model for visit using datetime
        [HttpGet("getbydate/{date}")]

        public async Task<List<VisitViewModel>> GetVisitbyDate(DateTime date)
        {

            var result = await visitRepository.GetVisitbyDate(date);

            if (result == null)
            {
                return null;
            }
            return result;

        }

        //Add a visit
        [HttpPost]
        public async Task<IActionResult> AddVisit([FromBody] Visittable visit)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var visitId = await visitRepository.AddVisit(visit);
                    if (visitId > 0)
                    {
                        return Ok(visitId);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception)
                {
                    return BadRequest();
                }

            }
            return BadRequest();
        }
        //Update Visit
        [HttpPut]
        public async Task<IActionResult> UpdateVisit([FromBody] Visittable visit)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await visitRepository.UpdateVisit(visit);

                    return Ok();


                }
                catch (Exception)
                {
                    return BadRequest();
                }

            }
            return BadRequest();
        }

       

        [HttpPatch("disablevisit/id")]
        public async Task<IActionResult> DisableVisit([FromBody] Visittable visit)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await visitRepository.UpdateVisit(visit);

                    return Ok();


                }
                catch (Exception)
                {
                    return BadRequest();
                }

            }
            return BadRequest();
        }
        [HttpPut("deletevisit/{id}")]
        public async Task<IActionResult> DeleteVisit([FromBody] int id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await visitRepository.DeleteVisit(id);

                    return Ok();


                }
                catch (Exception)
                {
                    return BadRequest();
                }

            }
            return BadRequest();
        }
    }
}
