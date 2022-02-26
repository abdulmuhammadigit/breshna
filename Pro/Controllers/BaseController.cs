using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pro.Common.Attributes;
using Microsoft.AspNetCore.Mvc;


namespace Pro.Controllers
{
    public class BaseController : Controller
    {
        public const string InsertSuccess = "درج اطلاعات با موفقیت انجام شد.";
        public const string EditSuccess = "ویرایش اطلاعات با موفقیت انجام شد.";
        public const string DeleteSuccess = "حذف اطلاعات با موفقیت انجام شد.";
        public const string OperationSuccess = "عملیات با موفقیت انجام شد.";

        public IActionResult Notification()
        {
            return Content(TempData["notification"].ToString());
        }

        [HttpGet, AjaxOnly]
        public IActionResult PrintGroup()
        {
            return PartialView("_PrintGroup");
        }

    }
}