using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TechSavvy.Areas.Identity.Data;
using TechSavvy.Models;

namespace TechSavvy.Models
{
    public class Quote
    {
        [Key]
        public int QuoteId { get; set; }

        [ForeignKey("CustomerId")]
        public virtual TechSavvyUser? TechSavvyUser { get; set; }

        [Required(ErrorMessage ="Valid Date Required!")]
        [DisplayName("Quote Date")]
        public DateTime quoteDate { get; set;}

        [DisplayName("Expiry Date")]
        [Required(ErrorMessage = "Valid Date Required!")]
        public DateTime expiryDate { get; set; }

        public ICollection<Quote_Details>? Quotes_Details { get; set; }
        public ICollection<Sale_Order> ?Sale_Orders { get; set; }
    }
}
