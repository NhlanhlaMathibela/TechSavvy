using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TechSavvy.Areas.Identity.Data;
using TechSavvy.Models;

namespace TechSavvy.Models
{
    public class Sale_Order
    {
        [Key]
        public int OrderId { get; set; }

        [Required(ErrorMessage ="Order date required!")]
        [DisplayName("Order Date")]
        public DateTime orderDate { get; set; }

        [ForeignKey("QuoteId")]
        public virtual Quote? Quote { get; set; }

        [ForeignKey("CustomerId")]
        public virtual Customer? Customer { get; set; }

        [Required(ErrorMessage = "Total required!")]
        [DisplayName("Total")]
        public double total { get; set; }

        [Required(ErrorMessage = "Total required!")]
        [DisplayName("Order Status")]
        public string ?orderStatus { get; set; }

        public ICollection<Order_Details> ?Order_Details { get; set; }

    }
}
