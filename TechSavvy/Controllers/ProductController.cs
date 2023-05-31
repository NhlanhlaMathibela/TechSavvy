using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechSavvy.Data;
using TechSavvy.Models;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

namespace TechSavvy.Controllers
{
    public class ProductController : Controller
    {
        private readonly IWebHostEnvironment webHostEnvironment;
        private TechSavvyContext _context;
        public ProductController(TechSavvyContext context, IWebHostEnvironment webHost)
        {
            _context = context;
            webHostEnvironment = webHost;
        }

        public IActionResult Index(string search)
        {
            List<Product> Products = _context.Products.ToList();
            //var get = _context.Products.Include(c => c.supplier).ToList();
            return View(Products);
        }
        //private List<SelectListItem> GetCategory()
        //{
        //    var lstCategories = new List<SelectListItem>();
        //    lstCategories = _context.Categories.Select(ct=> new SelectListItem()
        //    {
        //        Value = ct.CategoryId.ToString(),

        //        Text = ct.CategoryName
        //    }).ToList();

        //    var dmyItem = new SelectListItem()
        //    {
        //        Value = null,
        //         Text ="Select Category"
              
        //    };
        //    lstCategories.Insert(0,dmyItem);

        //    return lstCategories;
        //}

        [HttpGet]
        public IActionResult Create() 
        {
            //ViewBag.Category = GetCategory();
            //Product Products = new Product();

            //ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryName");
            //ViewData["SupplierId"] = new SelectList(_context.Suppliers, "SupplierId", "SupplierName");
            
            return View();
        
        }
        private string UploadedFile(Product Products)
        {
            string uniqueFileName = null;
            if (Products.FrontImage != null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + Products.FrontImage.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    Products.FrontImage.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }

        [HttpPost]
        public ActionResult Create(Product Products)
        {
            string uniqueFileName=UploadedFile(Products);
            Products.ImageUrl = uniqueFileName;  
            _context.Attach(Products);
            _context.Entry(Products).State=EntityState.Added;
            _context.SaveChanges();
            TempData["AlertMessage"] = "Record created successfully!";
            //ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryName", Products.CategoryId);
            //ViewData["SupplierId"] = new SelectList(_context.Suppliers, "SupplierId", "SupplierName", Products.SupplierId);
            return RedirectToAction(nameof(Index));
            
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            var Products = _context.Products.Where(x => x.ProductId == id).FirstOrDefault();
            return View(Products);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Product Products)
        {

            string uniqueFileName = UploadedFile(Products);
            Products.ImageUrl = uniqueFileName;
            _context.Attach(Products);
            _context.Entry(Products).State = EntityState.Added;
            _context.SaveChanges();
            TempData["AlertMessage"] = "Record updated successfully!";
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "name");
            return RedirectToAction(nameof(Index));

        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }
            var prod = await _context.Products.FirstOrDefaultAsync(p => p.ProductId == id);
            if (prod == null)
            {
                return NotFound();
            }
            return View(prod);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Products == null)
            {
                return Problem("Entity set 'TechSavvyContext' is null");
            }
            var purchReq = await _context.Products.FindAsync(id);
            if (purchReq != null)
            {
                _context.Products.Remove(purchReq);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }



    }
}
