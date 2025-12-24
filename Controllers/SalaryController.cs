using CFM_Technical_Assessment.Data;
using Microsoft.AspNetCore.Mvc;

namespace CFM_Technical_Assessment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalaryController : ControllerBase
    {
        private readonly CompanyContext _context;

        public SalaryController(CompanyContext context)
        {
            _context = context;
        }

        [HttpGet("salary-sum")]
        public IActionResult GetSalarySumByDepartment()
        {
            var salarySum = _context.Departments
                .Select(d => new
                {
                    Department_Id = d.ID,
                    Department_Name = d.Name,
                    Sum_Salary = d.Employees.Sum(e => (decimal?)e.Salary) ?? 0
                }).ToList();

            return Ok(salarySum);
        }
    }

}
