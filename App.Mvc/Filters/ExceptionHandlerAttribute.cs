namespace App.Mvc.Filters
{
    using App_Start;
    using Contracts;
    using Ninject;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;

    public class ExceptionHandlerAttribute : HandleErrorAttribute
    {
        private const string SecurityHtmlAction = "Security";
        private const string NotFoundAction = "NotFound";
        private const string MiscErrorAction = "Misc";
        private const string LogName = "App";

        public override void OnException(ExceptionContext filterContext)
        {
            Log(filterContext);
            if (filterContext.ExceptionHandled) return;
#if DEBUG
            return ;
#endif
            if (IsSecurityException(filterContext))
            {
                SendTo(filterContext, SecurityHtmlAction);
            }
            else if (IsHttpException(filterContext))
            {
                SendTo(filterContext, NotFoundAction);
            }
            else
            {
                SendTo(filterContext, SecurityHtmlAction);
            }
        }

        /// <summary>
        /// Logs the exception.
        /// </summary>
        /// <param name="filterContext">The filter context.</param>
        private static void Log(ExceptionContext filterContext)
        {
            if (NinjectWebCommon.Kernel.CanResolve<ILogProvider>())
            {
                NinjectWebCommon.Kernel.Get<ILogProvider>().Exception(LogName, filterContext.Exception);
            }
        }

        /// <summary>
        /// Determines whether exception is http type
        /// </summary>   
        private static bool IsHttpException(ExceptionContext filterContext)
        {
            var rtn = filterContext.Exception is System.Web.HttpException;
            return rtn;
        }

        /// <summary>
        /// Determines whether exception is security type
        /// </summary>        
        private static bool IsSecurityException(ExceptionContext filterContext)
        {
            var rtn = filterContext.Exception is System.Security.SecurityException;
            return rtn;
        }

        /// <summary>
        /// sends request to an error action
        /// </summary>
        /// <param name="filterContext">The filter context.</param>
        /// <param name="action">The action.</param>
        private static void SendTo(ExceptionContext filterContext, string action)
        {
            var helper = new UrlHelper(filterContext.RequestContext);
            string url = helper.Action(action, "Error");
            filterContext.Result = new RedirectResult(url);
            filterContext.ExceptionHandled = true;
        }
    }
  }