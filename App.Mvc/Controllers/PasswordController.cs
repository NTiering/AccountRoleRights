using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace App.Mvc.Controllers
{
    public class PasswordController : Controller
    {
        // GET: Password
        public ActionResult Form()
        {
            return View();
        }
    }
}