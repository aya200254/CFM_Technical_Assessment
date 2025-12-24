using CFM_Technical_Assessment.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CFM_Technical_Assessment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly CompanyContext _context;

        public CustomersController(CompanyContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAllCustomersWithOrders()
        {
            var customers = _context.Customers
                .Include(c => c.Orders)
                .ThenInclude(o => o.Product)
                .Select(c => new
                {
                    Customer_Id = c.ID,
                    Customer_Name = c.Name,
                    Orders = c.Orders.Select(o => new
                    {
                        Order_Id = o.ID,
                        Amount = o.Amount,
                        Product_Name = o.Product.Name,
                        Total_Cost = o.Amount * o.Product.Cost
                    }).ToList()
                })
                .ToList();

            return Ok(customers);
        }
    }
}
