using System.ComponentModel.DataAnnotations.Schema;

namespace CFM_Technical_Assessment.Models
{
    public class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public decimal Salary { get; set; }

        [ForeignKey("Department")] // يخبر EF أن هذا هو الـ FK للـ Department
        public int Department_Id { get; set; }

        public Department Department { get; set; }
    }
}
