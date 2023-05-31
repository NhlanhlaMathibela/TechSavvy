using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechSavvy.Models
{
    public class Category
    {

        [Key]
        public int CategoryId { get; set; }


        [Required( ErrorMessage ="Enter the category Name")]
        [DisplayName("Category Name")]
        public string? CategoryName { get; set; }
        public ICollection<Product>? Products { get; set; }
    }
}
