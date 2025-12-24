using CFM_Technical_Assessment.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore; // مهم عشان Include

namespace CFM_Technical_Assessment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly CompanyContext _context;

        public EmployeesController(CompanyContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAllEmployees()
        {
            var employees = _context.Employees
                .Include(e => e.Department)
                .Select(e => new
                {
                    Employee_Id = e.ID,
                    Employee_Name = e.Name,
                    Department_Name = e.Department.Name
                }).ToList();

            return Ok(employees);
        }
    }
}
