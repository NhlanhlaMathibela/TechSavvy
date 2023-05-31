using Microsoft.AspNetCore.Mvc;
using TechSavvy.Data;
using TechSavvy.Models;

namespace TechSavvy.Controllers
{
    public class CategoryController : Controller
    {
        private TechSavvyContext _context;
        public CategoryController(TechSavvyContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {

            var category= _context.Categories.ToList();


            return View(category);
        }

        [HttpGet]
        public IActionResult Create()
        {
            Category category = new Category();
            return View(category);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category cat)
        {

            if (ModelState.IsValid)
            {
                _context.Categories.Add(cat);
                _context.SaveChanges();
                TempData["AlertMessage"] = "Record created successfully!";
                return RedirectToAction("Index", "Category");
            }
            return View(cat);
        }
    }
}
