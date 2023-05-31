using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TechSavvy.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.Web;

namespace TechSavvy.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public IActionResult SaleEmployeeDashboard()
        {
            return View();
        }
        public IActionResult DepartmentEmployeeDashboard()
        {
            return View();
        }
        public IActionResult PurchasingEmployeeDashboard()
        {
            return View();
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Help()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult StockManagerDashboard()
        {
            return View();
        }



    }
}