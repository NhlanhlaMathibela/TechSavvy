using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechSavvy.Models
{
    public class PurchaseOrder_Details
    {

        [Key]
        public int Id { get; set; }

        [ForeignKey("RequestId")]
        [DisplayName("Request Date")]
        public int RequestId { get; set; }
        public virtual Purchase_Request? Purchase_Request { get; set; }

        [ForeignKey("ProductId")]
        [DisplayName("Product Name")]
        public int ProductId { get; set; }
        public virtual Product? Product { get; set; }

        [Required(ErrorMessage ="Quantity Required!")]
        [DisplayName("Quantity")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "Price Required!")]
        [DisplayName("Price")]
        public double Price { get; set; }
    }
}
