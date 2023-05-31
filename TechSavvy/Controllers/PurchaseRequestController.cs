using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TechSavvy.Data;
using TechSavvy.Models;
using TechSavvy.ViewModels;
using TechSavvy.Enums;

namespace TechSavvy.Controllers
{
    public class PurchaseRequestController : Controller
    {
        private readonly TechSavvyContext _dbContext;

        public PurchaseRequestController(TechSavvyContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IActionResult> Index()
        {
            var list = _dbContext.Purchase_Requests;
            return View( await list.ToListAsync());
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _dbContext.Purchase_Requests ==  null)
            {
                return NotFound();
            }
            var pr = await _dbContext.Purchase_Requests
                .FirstOrDefaultAsync(r => r.RequestId == id);

            if(pr == null)
            {
                return NotFound();
            }
            return View(pr);
        }
        public IActionResult Create()
        {
            
            ViewData["ProductId"] = new SelectList(_dbContext.Products, "ProductId", "description");
           return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <IActionResult> Create(PurchaseRequestVM vm)
        {
            

            if (ModelState.IsValid)
            {
                

                if (vm.requestDate != null)
                {
                    var purchase = new Purchase_Request
                    {
                                               
                        requestDate = vm.requestDate,
                        PRStatus = Enums.PurchaseRequest.Pending.ToString(),


                    };
                    _dbContext.Add(purchase);
                    await _dbContext.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }

                 
            }

            return View(vm);


            
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _dbContext.Purchase_Requests == null)
            {
                return NotFound();
            }

            var pRequest = await _dbContext.Purchase_Requests.FindAsync(id);
            if(pRequest == null)
            {
                return NotFound();
            }
            return View(pRequest);
        }
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PRStatus, requestDate")] Purchase_Request purchRequest)
        {
            if(id != purchRequest.RequestId)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _dbContext.Update(purchRequest);
                    await _dbContext.SaveChangesAsync();
                }catch(DbUpdateConcurrencyException) {

                    if (!PurchaseRequestExists(purchRequest.RequestId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(purchRequest);
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if(id == null || _dbContext.Purchase_Requests == null)
            {
                return NotFound();
            }
            var purchaseReq = await _dbContext.Purchase_Requests.FirstOrDefaultAsync(p => p.RequestId == id);   
            if(purchaseReq == null)
            {
                return NotFound();  
            }
            return View(purchaseReq);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if(_dbContext.Purchase_Requests == null)
            {
                return Problem("Entity set 'TechSavvyContext' is null");
            }
            var purchReq = await _dbContext.Purchase_Requests.FindAsync(id);
            if(purchReq != null)
            {
                _dbContext.Purchase_Requests.Remove(purchReq);
            }
            await _dbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }

        private bool PurchaseRequestExists(int id)
        {
            return _dbContext.Purchase_Requests.Any(i => i.RequestId == id);
        }
    }
}
