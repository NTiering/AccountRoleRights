using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace App.Mvc.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult Security()
        {
            ViewBag.Message = "You are not allowed to view this area";
            return View("Error");
        }

        public ActionResult NotFound()
        {
            ViewBag.Message = "Page not found";
            return View("Error");
        }

        public ActionResult Misc()
        {
            ViewBag.Message = "An error occurred";
            return View("Error");
        }
    }
}