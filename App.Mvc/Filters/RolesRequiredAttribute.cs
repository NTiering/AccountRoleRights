namespace App.Mvc.Filters
{
    using System.Web.Mvc;
    using System.Linq;
    using System.Collections.Generic;
    using System.Web;

    public class RolesRequiredAttribute : AuthorizeAttribute
    {
        private IEnumerable<string> rolesRequired;

        public RolesRequiredAttribute(params string[] rolesRequired)
        {
            this.rolesRequired = rolesRequired ?? Enumerable.Empty<string>();
        }

        /// <summary>
        /// Authorizes the core.
        /// </summary>
        /// <param name="httpContext">The HTTP context.</param>
        /// <returns></returns>
        /// <exception cref="System.Security.SecurityException">User does not have the roles required</exception>
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var authToken = GetAuthToken(httpContext);
            var roles = GetRolesByAuthToken(authToken);
            if (roles.Any(x => rolesRequired.Any(y => y == x)))
            {
                return true;
            }

            throw new System.Security.SecurityException("User does not have the roles required");
        }

        /// <summary>
        /// Gets the authentication token.
        /// </summary>
        /// <param name="httpContext">The HTTP context.</param>
        /// <returns></returns>
        private static string GetAuthToken(HttpContextBase httpContext)
        {
            // todo get the authtoken from the header, session , cookie or other E.G
            //var headerValue = filterContext.RequestContext.HttpContext.Request.Headers.GetValues("x-auth");
            //var sessionValue = filterContext.RequestContext.HttpContext.Session["x-auth"];
            //var cookieValue = filterContext.RequestContext.HttpContext.Request.Cookies.Get("x-auth");
            return string.Empty;
        }
        
        /// <summary>
        /// Gets the roles by authentication token.
        /// </summary>
        /// <param name="authToken">The authentication token.</param>
        /// <returns></returns>
        private static IEnumerable<string> GetRolesByAuthToken(string authToken)
        {
            // todo : Get the roles held by the user's auth token
            return new string[] { "Admin" };
        }

        /// <summary>
        /// Gets the authentication token.
        /// </summary>
        /// <param name="filterContext">The filter context.</param>
        /// <returns></returns>
        private static string GetAuthToken(AuthorizationContext filterContext)
        {
            // todo get the authtoken from the header, session , cookie or other E.G
            //var headerValue = filterContext.RequestContext.HttpContext.Request.Headers.GetValues("x-auth");
            //var sessionValue = filterContext.RequestContext.HttpContext.Session["x-auth"];
            //var cookieValue = filterContext.RequestContext.HttpContext.Request.Cookies.Get("x-auth");
            return string.Empty;
        }
    }

}