using System;
using System.Linq;
using System.Collections.Generic;
using App.Mvc.App_Start;
using App.Mvc.Models;
using Ninject;
using System.Web;
using System.Web.Mvc;

namespace App.Mvc.Filters
{

    public class SetSelectItemFilter : ActionFilterAttribute
    {
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            base.OnResultExecuting(context);
            context.Controller.ViewBag.BoolSelectItems = new SelectListItem[] {
                new SelectListItem { Value = "false" , Text = "No" },
                new SelectListItem { Value = "true" , Text = "Yes" }
            };
        }
    }

}