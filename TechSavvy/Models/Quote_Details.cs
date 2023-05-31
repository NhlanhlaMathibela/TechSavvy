using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechSavvy.Models
{
    public class Quote_Details
    {
        [Key]
        public int Id { get; set; } 

        [ForeignKey("RequestId")]
        public virtual Quote? Quote { get; set; }

        [ForeignKey("ProductId")]
        public virtual Product? Product { get; set; }

        [Required(ErrorMessage = "Quantity Required!")]
        [DisplayName("Quantity")]
        public int? quantity { get; set; }

        [Required(ErrorMessage = "Quote Price Required!")]
        [DisplayName("Price")]
        public double price { get; set; }

       

    }
}
