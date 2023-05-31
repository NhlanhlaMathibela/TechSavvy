using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using TechSavvy.Models;

namespace TechSavvy.ViewModels
{
    public class PurchaseRequestVM
    {
        //[DisplayName("Product")]
        //public int productId { get; set; }
        //[NotMapped]
        //public IList<Product> Products { get; set; }

        //[DisplayName("Description")]
        //public string? description { get; set; }  


        //public int? Quantity { get; set; }

        //public virtual Employee? Employee { get; set; }

        [DisplayName("Request Date")]
        public DateTime requestDate { get; set; }
        [DisplayName("Status")]
        public string? PRStatus { get; set; }

    }
}
