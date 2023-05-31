using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TechSavvy.Areas.Identity.Data;
using TechSavvy.Models;



namespace TechSavvy.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("EmployeeId")]
        public virtual TechSavvyUser? TechSavvyUser { get; set; }

        [Required(ErrorMessage = "Department Description Required!")]
        [DisplayName("Grade Level")]
        public string ?GradeLevel { get; set;}

        [ForeignKey("DepartmentID")]
        [Required(ErrorMessage = "Department Description Required!")]
        [DisplayName("Department Name")]
        public virtual Department? Department { get; set; }

        public ICollection<Purchase_Request> ?Purchase_Requests { get; set; }

    }
}
