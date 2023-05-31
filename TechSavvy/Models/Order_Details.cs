using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechSavvy.Models
{
    public class Order_Details
    {
        [Key]
        public int Id { get; set; } 

        [ForeignKey("OrderId")]
        public virtual Sale_Order? SaleOrder { get; set; }

        [ForeignKey("ProductId")]
        public virtual Product? Product { get; set; }

        [Required(ErrorMessage ="Quantity Required!")]
        [DisplayName("Quantity")]
        public double quantity { get; set; }

        [Required(ErrorMessage = "Price Required!")]
        [DisplayName("Price")]
        public double price { get; set; }
    }
}
