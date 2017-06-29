namespace App.Mvc.Controllers
{
    using Contracts;
    using Contracts.Search;
    using Models;
    using Services;
    using System.Collections.Generic;
    using System.Web.Mvc;

    public class SearchController : Controller
    {
        private ISearchService service ;   

        public SearchController(ISearchService service)
        {
            this.service = service;                        
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            ViewBag.Title = "App";
            ViewBag.SectionTitle = "Search";
        }

		// GET: CustomerSearch
        //[Authorize(Roles = "Admin,CustomerSearch")]
        public ActionResult CustomerSearch(string filter = "")
        {
            var errors = new List<IModelError>();
			var request = new CustomerSearchRequestModel { SearchFilter = filter };            
            var models = service.GetCustomerSearch(request, errors);
            ViewBag.Errors = errors;
            return View(models);            
        }
		 

		// GET: CustomerUsernameSearch
        //[Authorize(Roles = "Admin,CustomerUsernameSearch")]
        public ActionResult CustomerUsernameSearch(string filter = "")
        {
            var errors = new List<IModelError>();
			var request = new CustomerUsernameSearchRequestModel { SearchFilter = filter };            
            var models = service.GetCustomerUsernameSearch(request, errors);
            ViewBag.Errors = errors;
            return View(models);            
        }
		 
        
    }
}