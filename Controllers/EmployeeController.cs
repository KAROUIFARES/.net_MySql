using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using MySql.Model;
using repositorie;
namespace DepartementController
{
    [ApiController]
    [Route("Employees")]
    [EnableCors("AllowOrigin")]
    public class DepartmentController : ControllerBase
    {
        private readonly IEmployeeRepository employeeRepository;

        public DepartmentController(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }
        [HttpGet]
        public async Task<IEnumerable<Employee>> GetAllEmpoyeeAsync()
        {
            var employees = await employeeRepository.GetAllEmployeeAsync();
            return employees;
        }

    }
}