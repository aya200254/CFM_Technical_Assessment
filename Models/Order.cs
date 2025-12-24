using System.ComponentModel.DataAnnotations.Schema;

namespace CFM_Technical_Assessment.Models
{
    public class Order
    {
        public string ID { get; set; }

        [ForeignKey("Customer")] // مهم لتحديد الـ FK الصحيح
        public string Customer_Id { get; set; }

        [ForeignKey("Product")]  // مهم لتحديد الـ FK الصحيح
        public int Product_Id { get; set; }

        public int Amount { get; set; }

        // Navigation properties
        public Customer Customer { get; set; }
        public Product Product { get; set; }
    }
}
