using System.Collections.Generic;

namespace CFM_Technical_Assessment.Models
{
    public class Department
    {
        public int ID { get; set; }
        public string Name { get; set; }

        // Navigation property for related employees
        public ICollection<Employee> Employees { get; set; } = new List<Employee>();
    }
}
