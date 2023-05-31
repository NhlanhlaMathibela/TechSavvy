using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TechSavvy.Models;

namespace TechSavvy.ViewModels
{
    public class PurchaseRequestDtlVM
    {
        [ForeignKey("RequestId")]
        [DisplayName("Request Date")]
        public int RequestId { get; set; }
        public virtual Purchase_Request? Purchase_Request { get; set; }

        [ForeignKey("ProductId")]
        [DisplayName("Product Name")]
        public int ProductId { get; set; }
        public virtual Product? Product { get; set; }

        [Required(ErrorMessage = "Quantity Required!")]
        [DisplayName("Quantity")]
        public int quantity { get; set; }

    }
}
