using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace TechSavvy.Models
{
    public class ProductView
    {
        [Key]
        public int ProductId { get; set; }

        public string? name { get; set; }
      
        public decimal price { get; set; }

      
        public virtual Category? category { get; set; }
        public string? ImageUrl { get; set; }
        public string? returnUrl { get; set; }
        public int Quantity { get; set; }
        public IFormFile? FrontImage { get; set; }
    }
}
