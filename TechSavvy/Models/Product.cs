using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechSavvy.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Barcode Required!")]
        [DisplayName("Bar Code")]
        public string? barCode { get; set; }

        [Required(ErrorMessage = "Product Name Required!")]
        [DisplayName("Name")]
        public string? name { get; set; }

        [Required(ErrorMessage = "Product Description Required!")]
        [DisplayName("Product Description")]
        public string? description { get; set; }

        [Required(ErrorMessage = "Product Price Required!")]
        [DisplayName("Price")]
        public double price { get; set; }

        
        //[ForeignKey("CategoryId")]
        //[DisplayName("Category")]
        //public int CategoryId { get; set; }
        //public virtual Category? category { get; set; }



        //[ForeignKey("SupplierId")]
        //[DisplayName("Supplier")]
        //public int SupplierId { get; set; }
        //public virtual Supplier? supplier { get; set; }


        public string? ImageUrl { get; set; }
       
        [Required(ErrorMessage ="Please an Image")]
        [Display(Name="Front Image")]
        [NotMapped]
        public IFormFile? FrontImage { get;set; }
        public ICollection<PurchaseOrder_Details>? PurchaseOrder_Details { get; set; }
        public ICollection<PurchaseRequest_Details>? PurchaseRequest_Details { get; set; }
        public ICollection<Order_Details> ?Order_Details { get; set; }
        public ICollection<Quote_Details> ?Quote_Details { get; set; }
        public ICollection<Purchase_Order>? Purchase_Orders { get; set; }
        public ICollection<Purchase_Request>? Purchase_Requests { get; set; }

        internal static Product Find(int productID)
        {
            throw new NotImplementedException();
        }
    }
}
