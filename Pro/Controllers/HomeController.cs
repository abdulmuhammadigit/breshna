using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Pro.DataAccess;
using Pro.Models;

namespace Pro.Controllers
{
    [Authorize]
    [DisplayName("داشبورد")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DataBaseContext _context;

        public HomeController(ILogger<HomeController> logger, DataBaseContext context)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.QtyUsers = _context.Users.Count();
            ViewBag.Rent = _context.Rents.Where(a=>a.RegisterDateTime.Date==DateTime.Now.Date).Count();
            ViewBag.Owner = _context.Owners.Where(a => a.RegisterDateTime.Date == DateTime.Now.Date).Count();
            ViewBag.ListRecord = ViewBag.Rent+ ViewBag.Owner;
            return View();

        }
        [HttpGet]
        public IActionResult Dashboard()
        {
            return RedirectToAction("Index");

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





        [HttpGet]
        public IActionResult Error404()
        {
            return View();
        }

  


    }
}
