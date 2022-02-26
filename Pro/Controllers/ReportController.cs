using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pro.Common;
using Pro.DataAccess;
using Pro.Entities;
using Pro.ViewModels.DynamicAccess;
using Pro.ViewModels.Owner;
using Pro.ViewModels.Report;

namespace Pro.Controllers
{
    [DisplayName("راپورها")]
    [Authorize]
    public class ReportController : Controller
    {
        private readonly DataBaseContext _context;
        public ReportController(DataBaseContext context)
        {
            _context = context;
        }




        [HttpGet, DisplayName("  گزارش تعداد ریکارد کاربران ")]
        [Authorize(Policy = ConstantPolicies.DynamicPermission)]
        public IActionResult UserRecord()
        {
            return View();
        }
        [HttpGet]
        public IActionResult UserRecordTable()
        {
            return PartialView("_UserRecordTable");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UserRecord( string Date1Farsi, string Date2Farsi)
        {
            DateTime dateFirst;
            DateTime dateSecond;
            List<UserRecordViewModel> userList = new List<UserRecordViewModel>();
            if (Date1Farsi != null && Date2Farsi != null)
            {
                dateFirst = Date1Farsi.ConvertShamsiToMiladi();
                dateSecond = Date2Farsi.ConvertShamsiToMiladi();
                var users = await _context.Users.ToListAsync();


                foreach (var item in users)
                {
                    var RentRecords = await _context.Rents.Where(a => a.UserId == item.Id && a.RegisterDateTime.Date >= dateFirst.Date && a.RegisterDateTime.Date <= dateSecond.Date).ToListAsync();
                    var OwnerRecords = await _context.Owners.Where(a => a.UserId == item.Id && a.RegisterDateTime.Date >= dateFirst.Date && a.RegisterDateTime.Date <= dateSecond.Date).ToListAsync();
                    var person = new UserRecordViewModel
                    {

                        UserName = item.FirstName + ' ' + item.LastName,
                        qtyRent = RentRecords.Count(),
                        qtyOwner = OwnerRecords.Count(),
                        TotalQty = RentRecords.Count() + OwnerRecords.Count(),
                    };
                    userList.Add(person);
                }


            }
            
            return PartialView("_UserRecordTable", userList);

        }


        ////////////////////////////////////////////////////////////////////////////////////////////


        [HttpGet, DisplayName("  مالکان ")]
        [Authorize(Policy = ConstantPolicies.DynamicPermission)]
        public IActionResult Owner()
        {
         
            return View();
        }
        [HttpGet]
        public IActionResult OwnerTable()
        {
            return PartialView("_OwnerTable");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Owner(string Date1Farsi, string Date2Farsi)
        {
            DateTime dateFirst;
            DateTime dateSecond;
            List<Owner> ownerRecords = new List<Owner>();
            if (Date1Farsi != null && Date2Farsi != null)
            {
                dateFirst = Date1Farsi.ConvertShamsiToMiladi();
                dateSecond = Date2Farsi.ConvertShamsiToMiladi();
                ViewBag.Date1 = dateFirst;
                ViewBag.Date2 = dateSecond;
                ownerRecords = await _context.Owners.Where(a => a.RegisterDateTime.Date >= dateFirst.Date && a.RegisterDateTime.Date <= dateSecond.Date).ToListAsync();
                ViewBag.Count = ownerRecords.Count();
                return PartialView("_OwnerTable", ownerRecords);
            }
            

         
          
            return PartialView("_OwnerTable");
        }



        ////////////////////////////////////////////////////////////////////////////////////////////


        [HttpGet, DisplayName("  کرایه نشینان/مستاجر ")]
        [Authorize(Policy = ConstantPolicies.DynamicPermission)]
        public IActionResult Rent()
        {

            return View();
        }
        [HttpGet]
        public IActionResult RentTable()
        {
            return PartialView("_RentTable");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Rent(string Date1Farsi, string Date2Farsi)
        {
            DateTime dateFirst;
            DateTime dateSecond;
            List<Rent> ownerRecords = new List<Rent>();
            if (Date1Farsi != null && Date2Farsi != null)
            {
                dateFirst = Date1Farsi.ConvertShamsiToMiladi();
                dateSecond = Date2Farsi.ConvertShamsiToMiladi();
                ViewBag.Date1 = dateFirst;
                ViewBag.Date2 = dateSecond;
                ownerRecords = await _context.Rents.Where(a => a.RegisterDateTime.Date >= dateFirst.Date && a.RegisterDateTime.Date <= dateSecond.Date).ToListAsync();
                ViewBag.Count = ownerRecords.Count();
                return PartialView("_RentTable", ownerRecords);
            }




            return PartialView("_RentTable");
        }



    }
}
