using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechSavvy.Areas.Identity.Data;
using TechSavvy.Data;
using TechSavvy.Models;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace TechSavvy.Controllers
{
    public class SalesPersonController : Controller
    {
        private readonly TechSavvyContext _context;
        private readonly IWebHostEnvironment webHostEnvironment;
        public SalesPersonController(TechSavvyContext context, IWebHostEnvironment webHost)
        {
            _context = context;
            webHostEnvironment= webHost;
        }
        [HttpGet]
        public IActionResult Dashboard()
        {
            return View();
        }
        public IActionResult Index2()
        {
            return View();
        }
        public IActionResult Index(string Search="")
        {

            var objList = _context.Products.ToList();
           if (Search!="" && Search != null)
            {
                objList = _context.Products.Where(p=>p.name.Contains(Search)).ToList();              
            }
           else
            
           objList = _context.Products.ToList();
           
            return View(objList);
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

    }
}
