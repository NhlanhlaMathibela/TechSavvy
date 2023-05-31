using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TechSavvy.Areas.Identity.Data;
using TechSavvy.Models;

namespace TechSavvy.Models
{
    public class Customer
    {

        [ForeignKey("CustomerId")]
        public virtual TechSavvyUser? TechSavvyUser { get; set; }

        [Required(ErrorMessage = "Address Line 1 Required!")]
        [DisplayName("Address Line 1")]
        public string? address1 { get; set; }

        [Required(ErrorMessage = "Address Line 2 Required!")]
        [DisplayName("Address Line 2")]
        public string? address2 { get; set; }

        [Required(ErrorMessage = "Address Line 3 Required!")]
        [DisplayName("Address Line 3")]
        public string? address3 { get; set; }

        [Required(ErrorMessage = "Postal Required!")]
        [DisplayName("Postal Code")]
        public string ?PostalCode { get; set; }

        [Required(ErrorMessage = "Department Description Required!")]
        [DisplayName("Email")]
        public string? email { get; set; }

        public ICollection<Quote> ?Quotes { get; set; }
    }
}
