using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using TechSavvy.Models;
using System.ComponentModel.DataAnnotations;

namespace TechSavvy.Areas.Identity.Data;

// Add profile data for application users by adding properties to the TechSavvyUser class
public class TechSavvyUser : IdentityUser
{


    public int UserId { get; set; }
    //public string? UserName { get; set; }
    public string? Surname { get; set; }
    public string? FirstName { get; set; }
    public string? UserEmail { get; set; }

    public bool IsActive { get; set; }

    public ICollection<Customer>? Customers { get; set; }
}
public class ApplicationRole : IdentityRole
{

}

