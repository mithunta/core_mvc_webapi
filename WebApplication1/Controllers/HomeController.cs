using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            ViewData["TodaysDate"] = "Welcome to .NET Training " + DateTime.Now;
            ViewBag.WebsiteName = ".NET Training website";
            string temp = string.Empty;
            if (TempData["SendDataToAnotherPage"] != null) 
            { 
                temp = TempData["SendDataToAnotherPage"].ToString();
                ViewData["temp"] = temp;
            }
            else
            {
                ViewData["temp"] = string.Empty;
            }
            
            return View();
        }

        [HttpPost]
        public IActionResult Confirmation(IFormCollection collection)
        {
            string firstname = collection["firstname"][0];
            string lastname = collection["lastname"][0];
            
            string numbers = collection["numbers"][0];
            string selectednumberText = collection["hdnSeletedNumberText"][0];
             //We are inserting into database - In Real world
            ViewBag.FirstName = firstname;
            ViewBag.LastName = lastname;
            ViewBag.Number = numbers;
            ViewBag.SelectedNumberText = selectednumberText;
            return View();
        }
        public IActionResult Privacy()
        {
           
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult NavigateToIndex()
        {
            TempData["SendDataToAnotherPage"] = "Carry Data";
            return RedirectToAction("Index","Home");
        }

        public IActionResult Contact(int id, string name)
        {
            ViewData["id"] = id;
            ViewData["name"] = name;
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
