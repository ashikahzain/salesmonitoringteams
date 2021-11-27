using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SalesMarketingTeamAPI.Models;
using SalesMarketingTeamAPI.Repository;

namespace SalesMarketingTeamAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        IEmployeeRepository _employeeRepository;
        private IConfiguration _config;

        public EmployeeController(IEmployeeRepository employeeRepository, IConfiguration config)
        {
            _employeeRepository = employeeRepository;
            _config = config;
        }

        //Get all Employees
        [HttpGet]
        public async Task<IActionResult> GetEmployees()
        {
            try
            {
                var employees = await _employeeRepository.GetEmployees();
                if (employees == null)
                {
                    return NotFound();
                }
                return Ok(employees);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        //Get Employee by Id
        [HttpGet("{id}")]

        public async Task<ActionResult<Employeeregistration>> GetEmployeebyId(int id)
        {

            var result = await _employeeRepository.GetEmployeebyId(id);

            if (result == null)
            {
                return null;
            }
            return result;


        }
        //Add an employee
        [HttpPost]
        public async Task<IActionResult> AddEmployee([FromBody] Employeeregistration employee)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var EmployeeId = await _employeeRepository.AddEmployee(employee);
                    if (EmployeeId > 0)
                    {
                        return Ok(EmployeeId);
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
        //Update Employee
        [HttpPut]
        public async Task<IActionResult> UpdateEmployee([FromBody] Employeeregistration model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _employeeRepository.UpdateEmployee(model);

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
