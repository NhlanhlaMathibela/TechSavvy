using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using TechSavvy.Models;

namespace TechSavvy.Models
{
    public class Department
    {
        [Key]
        public int deptId { get; set; }

        [Required(ErrorMessage ="Department Name Required!")]
        [DisplayName("Department Name")]
        public string? name { get; set; }

        [Required(ErrorMessage = "Department Description Required!")]
        [DisplayName("Department description")]
        public string? description { get; set; }

    }
}
