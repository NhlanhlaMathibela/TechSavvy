using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechSavvy.Data;

namespace TechSavvy.Controllers
{
    public class CustomerController : Controller
    {
        private readonly TechSavvyContext _context;
        public CustomerController(TechSavvyContext context)
        {
            _context = context;
            
        }
        public IActionResult Dashboard() 
        {
            return View();
        }

        public IActionResult Index(string Search = "")
        {

            var objList = _context.Products.ToList();
            if (Search != "" && Search != null)
            {
                objList = _context.Products.Where(p => p.name.Contains(Search)).ToList();
            }
            else

                objList = _context.Products.ToList();

            return View(objList);
         
        }

    }
}
