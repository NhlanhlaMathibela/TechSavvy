using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using TechSavvy.Data;

namespace TechSavvy.Controllers
{
    public class AdminController : Controller
    {

        private readonly TechSavvyContext _context;
        public AdminController(TechSavvyContext context)
        {
            _context = context;
         
        }
        public IActionResult Dashboard()
        {
            return View();
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
