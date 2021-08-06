using Exam.Api.Models;
using Exam.Service.DTO;
using Exam.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Exam.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly ILogger<EmployeeController> _logger;

        public EmployeeController(IEmployeeService customerService, ILogger<EmployeeController> logger)
        {
            _employeeService = customerService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _employeeService.GetAllEmployeeAsync();
            return Ok(result);
        }

        [HttpGet("{employeeId}")]
        public async Task<IActionResult> GetEmployeeById(int employeeId)
        {
            var result = await _employeeService.GetEmployeeByIdAsync(employeeId);
            return Ok(result);
        }

        [HttpPost("SaveEmployeeDetails")]
        public async Task<IActionResult> SaveEmployeerDetails([FromBody] CreateEmployeeRequest employee)
        {            
            EmployeeDTO employeeDto = new EmployeeDTO()
            {
                FirstName = employee.FirstName,
                MiddleName = employee.MiddleName,
                LastName = employee.LastName
            };
            var result = await _employeeService.AddEmployeeAsync(employeeDto);
            return Ok(result);
        }

        [HttpPut("UpdateEmployeeDetails")]
        public async Task<IActionResult> UpdateEmployeeDetails([FromBody] UpdateEmployeeRequest employee)
        {
            EmployeeDTO employeeDto = new EmployeeDTO()
            {
                Id = employee.Id,
                FirstName = employee.FirstName,
                MiddleName = employee.MiddleName,
                LastName = employee.LastName
            };
            var result = await _employeeService.UpdateEmployeeAsync(employeeDto);
            return Ok(result);
        }

        [HttpDelete("DeleteEmployeeById/{employeeId}")]
        public async Task<IActionResult> DeleteEmployeeById(int employeeId)
        {
            var result = await _employeeService.DeleteEmployeeByIdAsync(employeeId);
            return Ok(result);
        }
    }
}
