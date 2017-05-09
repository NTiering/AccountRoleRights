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

            context.Controller.ViewBag.TimeSelectItems = new SelectListItem[] {
                new SelectListItem { Value = "00:00" , Text = "00:00 midnight" },
                new SelectListItem { Value = "00:15" , Text = "00:15" },
                new SelectListItem { Value = "00:30" , Text = "00:30" },
                new SelectListItem { Value = "00:45" , Text = "00:45" },

                new SelectListItem { Value = "01:00" , Text = "01:00" },
                new SelectListItem { Value = "01:15" , Text = "01:15" },
                new SelectListItem { Value = "01:30" , Text = "01:30" },
                new SelectListItem { Value = "01:45" , Text = "01:45" },

                new SelectListItem { Value = "02:00" , Text = "02:00" },
                new SelectListItem { Value = "02:15" , Text = "02:15" },
                new SelectListItem { Value = "02:30" , Text = "02:30" },
                new SelectListItem { Value = "02:45" , Text = "02:45" },

                new SelectListItem { Value = "03:00" , Text = "03:00" },
                new SelectListItem { Value = "03:15" , Text = "03:15" },
                new SelectListItem { Value = "03:30" , Text = "03:30" },
                new SelectListItem { Value = "03:45" , Text = "03:45" },

                new SelectListItem { Value = "04:00" , Text = "04:00" },
                new SelectListItem { Value = "04:15" , Text = "04:15" },
                new SelectListItem { Value = "04:30" , Text = "04:30" },
                new SelectListItem { Value = "04:45" , Text = "04:45" },

                new SelectListItem { Value = "05:00" , Text = "05:00" },
                new SelectListItem { Value = "05:15" , Text = "05:15" },
                new SelectListItem { Value = "05:30" , Text = "05:30" },
                new SelectListItem { Value = "05:45" , Text = "05:45" },

                new SelectListItem { Value = "06:00" , Text = "06:00" },
                new SelectListItem { Value = "06:15" , Text = "06:15" },
                new SelectListItem { Value = "06:30" , Text = "06:30" },
                new SelectListItem { Value = "06:45" , Text = "06:45" },

                new SelectListItem { Value = "07:00" , Text = "07:00" },
                new SelectListItem { Value = "07:15" , Text = "07:15" },
                new SelectListItem { Value = "07:30" , Text = "07:30" },
                new SelectListItem { Value = "07:45" , Text = "07:45" },

                new SelectListItem { Value = "08:00" , Text = "08:00" },
                new SelectListItem { Value = "08:15" , Text = "08:15" },
                new SelectListItem { Value = "08:30" , Text = "08:30" },
                new SelectListItem { Value = "08:45" , Text = "08:45" },

                new SelectListItem { Value = "09:00" , Text = "09:00" },
                new SelectListItem { Value = "09:15" , Text = "09:15" },
                new SelectListItem { Value = "09:30" , Text = "09:30" },
                new SelectListItem { Value = "09:45" , Text = "09:45" },

                new SelectListItem { Value = "10:00" , Text = "10:00" },
                new SelectListItem { Value = "10:15" , Text = "10:15" },
                new SelectListItem { Value = "10:30" , Text = "10:30" },
                new SelectListItem { Value = "10:45" , Text = "10:45" },

                new SelectListItem { Value = "11:00" , Text = "11:00" },
                new SelectListItem { Value = "11:15" , Text = "11:15" },
                new SelectListItem { Value = "11:30" , Text = "11:30" },
                new SelectListItem { Value = "11:45" , Text = "11:45" },

                new SelectListItem { Value = "12:00" , Text = "12:00 midday" },
                new SelectListItem { Value = "12:15" , Text = "12:15" },
                new SelectListItem { Value = "12:30" , Text = "12:30" },
                new SelectListItem { Value = "12:45" , Text = "12:45" },

                new SelectListItem { Value = "13:00" , Text = "13:00" },
                new SelectListItem { Value = "13:15" , Text = "13:15" },
                new SelectListItem { Value = "13:30" , Text = "13:30" },
                new SelectListItem { Value = "13:45" , Text = "13:45" },

                new SelectListItem { Value = "14:00" , Text = "14:00" },
                new SelectListItem { Value = "14:15" , Text = "14:15" },
                new SelectListItem { Value = "14:30" , Text = "14:30" },
                new SelectListItem { Value = "14:45" , Text = "14:45" },

                new SelectListItem { Value = "15:00" , Text = "15:00" },
                new SelectListItem { Value = "15:15" , Text = "15:15" },
                new SelectListItem { Value = "15:30" , Text = "15:30" },
                new SelectListItem { Value = "15:45" , Text = "15:45" },

                new SelectListItem { Value = "16:00" , Text = "16:00" },
                new SelectListItem { Value = "16:15" , Text = "16:15" },
                new SelectListItem { Value = "16:30" , Text = "16:30" },
                new SelectListItem { Value = "16:45" , Text = "16:45" },

                new SelectListItem { Value = "17:00" , Text = "17:00" },
                new SelectListItem { Value = "17:15" , Text = "17:15" },
                new SelectListItem { Value = "17:30" , Text = "17:30" },
                new SelectListItem { Value = "17:45" , Text = "17:45" },

                new SelectListItem { Value = "18:00" , Text = "18:00" },
                new SelectListItem { Value = "18:15" , Text = "18:15" },
                new SelectListItem { Value = "18:30" , Text = "18:30" },
                new SelectListItem { Value = "18:45" , Text = "18:45" },

                new SelectListItem { Value = "19:00" , Text = "19:00" },
                new SelectListItem { Value = "19:15" , Text = "19:15" },
                new SelectListItem { Value = "19:30" , Text = "19:30" },
                new SelectListItem { Value = "19:45" , Text = "19:45" },

                new SelectListItem { Value = "20:00" , Text = "20:00" },
                new SelectListItem { Value = "20:15" , Text = "20:15" },
                new SelectListItem { Value = "20:30" , Text = "20:30" },
                new SelectListItem { Value = "20:45" , Text = "20:45" },

                new SelectListItem { Value = "21:00" , Text = "21:00" },
                new SelectListItem { Value = "21:15" , Text = "21:15" },
                new SelectListItem { Value = "21:30" , Text = "21:30" },
                new SelectListItem { Value = "21:45" , Text = "21:45" },

                new SelectListItem { Value = "22:00" , Text = "22:00" },
                new SelectListItem { Value = "22:15" , Text = "22:15" },
                new SelectListItem { Value = "22:30" , Text = "22:30" },
                new SelectListItem { Value = "22:45" , Text = "22:45" },

                new SelectListItem { Value = "23:00" , Text = "23:00" },
                new SelectListItem { Value = "23:15" , Text = "23:15" },
                new SelectListItem { Value = "23:30" , Text = "23:30" },
                new SelectListItem { Value = "23:45" , Text = "23:45" }
               
            };
        }
    }

}