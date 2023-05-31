using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechSavvy.Areas.Identity.Data;
using TechSavvy.Data;
using TechSavvy.Models;

namespace TechSavvy.Controllers
{
    public class SuppliersController : Controller
    {
        private TechSavvyContext _context;
        public SuppliersController(TechSavvyContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var suppliers = _context.Suppliers.ToList();
            
            
            return View(suppliers);
        }
        [HttpGet]
        public IActionResult Create() 
        { 
            Supplier supplier = new Supplier(); 
            return View(supplier);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Supplier sup) 
        { 

            if(ModelState.IsValid)
            {
                _context.Suppliers.Add(sup);
                _context.SaveChanges();
                TempData["AlertMessage"] = "Record created successfully!";
                return RedirectToAction("Index", "Suppliers");
            }
            return View(sup);
        }
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            var sup = _context.Suppliers.Where(x => x.SupplierId == id).FirstOrDefault();
            return View(sup);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Supplier supplier)
        {
            if(ModelState.IsValid)
            {
                _context.Suppliers.Update(supplier);
                _context.SaveChanges();
                TempData["AlertMessage"] = "Record updated succesfully!";
            }
            return RedirectToAction("Index", supplier);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var sup = _context.Suppliers.Where(x => x.SupplierId == id).FirstOrDefault();
            return View(sup);
        }
        [HttpDelete]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Supplier supplier)
        {
            if(ModelState.IsValid)
            {
                _context.Suppliers.Remove(supplier);
                _context.SaveChanges();
                TempData["AlertMessage"] = "Record deleted successfully!";
            }
            return RedirectToAction("Index", supplier);
        }
    }
}
