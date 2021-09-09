using EmployeesApi.Data;
using EmployeesApi.Models.Employees;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesApi.Controllers
{
    public class EmployeesController : ControllerBase
    {
        private readonly IManageEmployeeData _employeeData;

        public EmployeesController(IManageEmployeeData employeeData)
        {
            _employeeData = employeeData;
        }


        [HttpPost("employees")]
        public async Task<ActionResult> AddAnEmployee([FromBody] PostEmployeeRequest request)
        {
            // validate.
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            // hire them.
            GetEmployeeDetailsResponse response = await _employeeData.HireAsync(request);
            /// return a 201.
            /// return a Location header
            /// add the url of the new thing to the location header
            /// send them a copy of the new employees
            return CreatedAtRoute("employees#getbyid", new { id = response.Id }, response);
        }

        [HttpGet("employees")]
        public async Task<ActionResult> GetAllEmployees()
        {
            GetEmployeesResponse response = await _employeeData.GetAllActiveEmployeesAsync();

            return Ok(response);
        }

        // GET /employees/19 -> 200 or NotFound
        [HttpGet("/employees/{id:int}", Name ="employees#getbyid")]
        public async Task<ActionResult> GetAnEmployee(int id)
        {
            GetEmployeeDetailsResponse response = await _employeeData.GetEmployeeDetailsAsync(id);

            if(response == null)
            {
                return NotFound();
            } else
            {
                return Ok(response);
            }
        }
    }
}
