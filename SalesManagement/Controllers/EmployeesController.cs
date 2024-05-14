using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SalesManagement.Core.Models;
using SalesManagement.Infrastructure;
using SalesManagement.Services.Interfaces;

namespace SalesManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService employeeService;

        public EmployeesController(IEmployeeService context)
        {
            employeeService = context;
        }

        // GET: api/Employees
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {
            var employees = await employeeService.GetAllEmployees();
            if (employees != null)
            {
                return Ok(employees);
            }
            else
                return NotFound("No Employee Found");
        }

        // GET: api/Employees/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            var employee = await employeeService.GetEmployeeById(id);
            if (employee != null)
            {
                return Ok(employee);
            }
            return BadRequest("Not Found");
        }

        // PUT: api/Employees/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployee(Employee employee)
        {
            var isUpdated = await employeeService.UpdateEmployee(employee);
            if (isUpdated)
            {
                return Ok("Update Successful");
            }
            return BadRequest();
        }

        // POST: api/Employees
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Employee>> PostEmployee(Employee employee)
        {
            var isCreated = await employeeService.CreateEmployee(employee);
            if (isCreated)
            {
                return Ok("Created Successfully");
            }
            return BadRequest();
        }

        // DELETE: api/Employees/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var isDeleted = await employeeService.DeleteEmployee(id);
            if (isDeleted)
            {
                return Ok("Delete Successful");
            }
            return BadRequest();
        }
    }
}
