using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechSavvy.Models
{
    public class PurchaseRequest_Details
    {

        [Key]
        public int Id { get; set; }

        [ForeignKey("RequestId")]
        public int RequestId { get; set; }
        public virtual Purchase_Request? Purchase_Request { get; set; }

        [ForeignKey("ProductId")]
        public int ProductId { get; set; }
        public virtual Product? Product { get; set; }

        [Required(ErrorMessage = "Quantity Required!")]
        [DisplayName("Quantity")]
        public int quantity { get; set; }
    }
}
