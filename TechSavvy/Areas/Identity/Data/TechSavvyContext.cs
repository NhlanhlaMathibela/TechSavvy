using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TechSavvy.Areas.Identity.Data;
using TechSavvy.Models;

namespace TechSavvy.Data;

public class TechSavvyContext : IdentityDbContext<TechSavvyUser>
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public TechSavvyContext(DbContextOptions<TechSavvyContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
    public DbSet<Customer>?Customers { get; set; }
    public DbSet<Department>? Departments { get; set; }
    public DbSet<Employee>? Employees { get; set; }
    public DbSet<Order_Details>? Order_Details { get; set; }
    public DbSet<Product> ?Products { get; set; }
    public DbSet<Purchase_Order>? Purchase_Orders { get; set; }
    public DbSet<Purchase_Request> ?Purchase_Requests { get; set; }
    public DbSet<PurchaseOrder_Details> ?PurchaseOrder_Details { get; set; }
    public DbSet<PurchaseRequest_Details>? PurchaseRequest_Details { get; set; }
    public DbSet<Quote>? Quotes { get; set; }
    public DbSet<Quote_Details>? Quote_Details { get; set; }
    public DbSet<Supplier> ?Suppliers { get; set; }
  
    public DbSet<Category>? Categories { get; set; }


}
