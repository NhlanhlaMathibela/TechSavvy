using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;
using TechSavvy.Data;
using TechSavvy.Models;
using static iTextSharp.text.pdf.AcroFields;

namespace TechSavvy.Controllers
{
    public class CartController : Controller
    {
        private readonly TechSavvyContext _context;
        public CartController(TechSavvyContext context)
        {
            _context = context;

        }
        //public List<CartIndexViewModel> Products(List<Product> product)
        //{
        //    List<CartIndexViewModel> data = new List<CartIndexViewModel>(); 
        //    foreach(var productItem in product) {

        //        CartIndexViewModel model = new CartIndexViewModel();  
        //        if(productItem != null)
        //        {
        //            model.
        //        }

        //    }
        //}
      
        public IActionResult Index(string Search = " ")
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
        
        //return View(new CartIndexViewModel
            //{
               
            //    Cart = GetCart(),
            //    ReturnUrl = returnUrl,
            //});
        
    
        //[AllowAnonymous]
        //public async Task<RedirectToActionResult> AddToCart(ProductView product)
        //{
        //    string returnUrl = product.returnUrl;
        //    if (product.Quantity < 1)
        //    {
        //        return RedirectToAction("Index", new { returnUrl });//alert message product not add to chart
        //    }

        //    Product produ= _context.Products.FirstOrDefault(a => a.ProductId == product.ProductId);
        //    if (product == null)
        //    {
        //        return RedirectToAction("Index", new { returnUrl });
        //    }

        //    {
        //        Cart cart = GetCart();
        //        int c = 0;
        //        var Clara = cart.Lines.FirstOrDefault(p => p.product.ProductId == product.ProductId);
            
        //            cart.AddItem(produ, product.Quantity);
        //            SaveCart(cart);
        //    }
        //    return RedirectToAction("Index", new { returnUrl });
        //}


        //public RedirectToActionResult RemoveFromCart(int ProductId, string returnUrl)
        //{
        //  Product product = new Product();
        //    if (ProductId>0)
        //    {

        //        product = _context.Products.FirstOrDefault(a=>a.ProductId== ProductId);
        //    }
        //    if (product != null)
        //    {
        //        Cart cart = GetCart();
        //        cart.RemoveLine(product);
        //        SaveCart(cart);
        //    }
        //    return RedirectToAction("Index", new { returnUrl });
        //}
        //private Cart GetCart()
        //{
        //    Cart cart = HttpContext.Session.GetJson<Cart>("Cart") ?? new Cart();
        //    return cart;
        //}
        //private void SaveCart(Cart cart)
        //{
        //    HttpContext.Session.SetJson("Cart", cart);
        //}

        //public ActionResult AddToCart(int ProductID)
        //{
        //    if (Session["cart"] == null)
        //    {
        //        List<Item> cart = new List<Item>();
        //        Item item = new Item();
        //        item.product = Product.Find(ProductID);
        //        item.Quantity = 1;
        //        cart.Add(item);
        //        Session["cart"] = cart;

        //    }
        //    else
        //    {
        //        List<Item> cart = (List<Item>)Session["cart"];
        //    }
        //    return RedirectToAction("Index");
        //}
        //public int IsInCart(int ProductID)
        //{
        //    List<Item> cart = (List<Item>)Session["cart"];
        //    for (int i = 0; i < cart.Count; i++)
        //    {
        //        if (cart[i].product.ProductId == ProductID)
        //        {
        //            return i;

        //        }

        //    }
        //    return -1;
        //}
    }
}
