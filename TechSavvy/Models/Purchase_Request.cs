using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TechSavvy.Areas.Identity.Data;
using TechSavvy.Enums;

namespace TechSavvy.Models
{
    public class Purchase_Request
    {
        [Key]
        public int RequestId { get; set; }

        public virtual TechSavvyUser User { get; set; }


        //[Required(ErrorMessage = "Please select a product!")]
        //[DisplayName("Product")]
        //public int productId { get; set; }
        //public virtual Product Products { get; set; }

        //[Required(ErrorMessage = "Product description required!")]
        //[DisplayName("Description")]
        //public string? description { get; set; }

        //[Required(ErrorMessage = "Please enter quantity!")]
        //[DisplayName("Quantity")]
        //public int? Quantity { get; set; }


        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Please select date!")]
        [DisplayName("Request Date")]
        public DateTime requestDate { get; set; }
      
        [DisplayName("Status")]
        public string PRStatus { get; set; }

        public ICollection<Purchase_Order>? Purchase_Orders { get; set; }
    }
}
