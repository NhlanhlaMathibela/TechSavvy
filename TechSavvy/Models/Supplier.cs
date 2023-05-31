using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TechSavvy.Models
{
    public class Supplier
    {

        [Key]
        public int SupplierId { get; set; }

        [Required(ErrorMessage ="Supplier name required!")]
        [DisplayName("Supplier Name")]
        public string ?SupplierName { get; set; }

        [Required(ErrorMessage = "Supplier email required!")]
        [DisplayName("Email")]
        public string ?Email { get; set; }

        public ICollection<Product>? Products { get; set;}

    }
}
