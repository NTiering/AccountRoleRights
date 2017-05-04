using App.Mvc.App_Start;
using App.Mvc.Models;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace App.Mvc.Filters
{
    public class SetSectionsFilter : ActionFilterAttribute
    {
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            base.OnResultExecuting(context);
            context.Controller.ViewBag.Sections = NinjectWebCommon.Kernel.GetAll<SectionViewModel>();



        }
    }
}