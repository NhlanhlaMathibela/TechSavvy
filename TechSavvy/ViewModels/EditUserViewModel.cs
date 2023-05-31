using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Build.Framework;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using TechSavvy.Areas.Identity.Data;


namespace TechSavvy.ViewModels
{
    public class EditUserViewModel
    {
        
        public string? Id { get; set; }


        [DisplayName("First name")]
        public string ?FirstName { get; set; }


       
        [DisplayName("Surname")]
        public string? Surname { get; set; }


     

        [DisplayName("Email")]
        [EmailAddress]
        
        public string? Email { get; set; }


       
        [DisplayName("Roles")]

        public IList<SelectListItem> ?Roles {  get; set; }


    }
}
