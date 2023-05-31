using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechSavvy.Models
{
    public class Purchase_Order
    {
        [Key]
        public int OrderID { get; set; }

        [Required(ErrorMessage ="Order Date Required!")]
        [DisplayName("Order Date")]
        public DateTime orderDate { get; set; }

        [ForeignKey("RequestId")]
        public virtual Purchase_Request? Purchase_Request { get; set; }

        [Required(ErrorMessage = "Purchase Order Total Required!")]
        [DisplayName("Purchase Order Total")]
        public double POTotal { get; set; }

        [ForeignKey("SupllierId")]
        public virtual Supplier ?Supplier { get; set; }

        [Required(ErrorMessage = "Purchase Order Progress Required!")]
        [DisplayName("Purchase Order Progress Total")]
        public string ?POProgress { get; set; }


    }
}
