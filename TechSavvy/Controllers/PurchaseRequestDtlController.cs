using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TechSavvy.Data;
using TechSavvy.Models;
using TechSavvy.ViewModels;

namespace TechSavvy.Controllers
{
    public class PurchaseRequestDtlController : Controller
    {
        private readonly TechSavvyContext _dbContext;

        public PurchaseRequestDtlController(TechSavvyContext dbContext)
        {
             _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            var list = _dbContext.PurchaseRequest_Details.Include(s => s.Product).Include(x => x.Purchase_Request);

            return View(list.ToList());
        }
        public async Task<IActionResult> Create()
        {
            
            ViewData["RequestId"] = new SelectList(_dbContext.Purchase_Requests, "RequestId", "requestDate");
            ViewData["ProductId"] = new SelectList(_dbContext.Products, "ProductId", "name");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PurchaseRequest_Details purchReqDetails)
        {

            _dbContext.Add(purchReqDetails);
            _dbContext.SaveChanges();

            //if (ModelState.IsValid)
            //{


            //    if (purchReqDetails.Product != null || purchReqDetails.Purchase_Request !=null || purchReqDetails.quantity != null)
            //    {
            //        var purchase = new PurchaseRequest_Details
            //        {
            //           Purchase_Request = purchReqDetails.Purchase_Request,
            //           Product = purchReqDetails.Product,   
            //           quantity = purchReqDetails.quantity
                   
            //        };
            //        _dbContext.Add(purchase);
            //        await _dbContext.SaveChangesAsync();
            //        return RedirectToAction(nameof(Index));
            //    }


            //}
            ViewData["RequestId"] = new SelectList(_dbContext.Purchase_Requests, "RequestId", "requestDate", purchReqDetails.RequestId);
            ViewData["ProductId"] = new SelectList(_dbContext.Products, "ProductId", "name", purchReqDetails.ProductId);

            return View(purchReqDetails);


            
            
        }
    }
}
