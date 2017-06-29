namespace App.Mvc.Controllers
{
    using Contracts;
    using Mvc;
    using Contracts.Services;
    using Models;
    using Filters;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using System.Web;

	[Filters.ExceptionHandler]
    public class AccountController : Controller
    {
		private readonly ILogProvider log ; 
		private const string LogName = "Account";
        private readonly IAccountService service ;   

        public AccountController(ILogProvider log, IAccountService service )
        {
            this.service = service;
			this.log = log;
            
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
			log.LogActionExecuting(LogName,filterContext);
			ViewBag.Title = "App";
            ViewBag.SectionTitle = "Account";
        }

        // GET: Account
		[RolesRequired("Admin","ListAccount")]
        public ActionResult Index()
        {
            var errors = new List<IModelError>();
            var models = service.GetAll(x => x != null, errors);
            ViewBag.Errors = errors;
            ViewBag.ToolButtons = "VED"; // View Edit Delete 
			ViewBag.Title = "List Account" ; 
            return View(models);            
        }

        // Display a form for viewing Account
		[RolesRequired("Admin","ViewAccount")]
        public ActionResult View(int id = -1)
        {			 
            var errors = new List<IModelError>();
            ViewBag.Readonly = true;
            ViewBag.ButtonFlag = "";
			ViewBag.Title = "View Account" ; 
            var model = GetViewModel(id,errors);
            return View("Form",model);
        }

        // Display a form for editing Account
		[RolesRequired("Admin","SaveAccount")]        
        public ActionResult Edit(int id = -1)
        {
            var errors = new List<IModelError>();
            ViewBag.Readonly = false;
			ViewBag.ButtonFlag = "RS"; // Relationship Submit
			ViewBag.Title = "Edit Account" ; 
            var model = GetViewModel(id,errors);
            return View("Form",model);
        }

		[RolesRequired("Admin","SaveAccount")]   
        [HttpPost]
        public ActionResult Edit(AccountViewModel model)
        {
            var errors = new List<IModelError>();
            service.TrySave(model, errors);          

			if (errors.Any())
            {
                this.AddModelErrors(errors);
                ViewBag.Readonly = false;
				ViewBag.ButtonFlag = "RS"; // Relationship Submit
				ViewBag.Title = "Edit Account" ; 
                return View("Form", model);
            }
            else
            {
                return RedirectToAction("index", new { updated = model.Id });
            } 
        }

        // Display a form for creating Account
		[RolesRequired("Admin","SaveAccount")]   
        public ActionResult Create(int id = -1)
        {
            var errors = new List<IModelError>();
            ViewBag.Readonly = false;
			ViewBag.ButtonFlag = "S"; // Submit
			ViewBag.Title = "New Account" ; 
            var model = GetViewModel(id,errors);
            return View("Form",model);
        }

		[RolesRequired("Admin","SaveAccount")]   
        [HttpPost]
        public ActionResult Create(AccountViewModel model)
        {
            var errors = new List<IModelError>();

			service.TrySave(model, errors);  
			if (errors.Any())
            {
                this.AddModelErrors(errors);
                ViewBag.Readonly = false;
                ViewBag.ButtonFlag = "S"; // Submit
				ViewBag.Title = "New Account" ; 
                return View("Form", model);
            }
            else
            {
                return RedirectToAction("index", new { creaated = model.Id });
            } 
        }

        // Display a form for deleting Account
		[RolesRequired("Admin","DeleteAccount")]   
        public ActionResult Delete(int id = -1)
        {
            var errors = new List<IModelError>();
            ViewBag.Readonly = true;
            ViewBag.ShowRelationships = false;
			ViewBag.Title = "Delete Account" ; 
            var model = GetViewModel(id,errors);
            return View("Form",model);
        }

		[RolesRequired("Admin", "DeleteAccount")]
        [HttpPost]
        public ActionResult Delete(AccountViewModel model, int _post)
        {
            var errors = new List<IModelError>();
            var result = service.TryDelete(model.Id, errors);
            ViewBag.Title = "Delete Account";
            if (errors.Any())
            {
                model = GetViewModel(model.Id, errors);
                this.AddModelErrors(errors);
                ViewBag.Readonly = false;
                ViewBag.ButtonFlag = "S"; // Submit
                ViewBag.Title = "Delete Account";
                return View("Form", model);
            }
            else
            {
                return RedirectToAction("index", new { deleted = model.Id });
            }
        }
		
        // list all Account entities
		[RolesRequired("Admin","ListAccount")]  
        public ActionResult List() 
        {
            var errors = new List<IModelError>();
            var models = service.GetAll(x =>x != null, errors);
            ViewBag.Errors = errors;
            ViewBag.ToolButtons = "VP"; // View Pick 
            ViewBag.PickState = false;
            return View("AccountList", models);
        }
                
        
        // Supports the many to many relationship (AccountRole) between Account (parent) Role (child)
        //[Authorize(Roles = "Admin,ListAccountRole")]
		[RolesRequired("Admin","ListAccountRole")]  
        public ActionResult GetAccountRole(int id, bool selected = false) 
        {
            var models = service.GetAllForAccountRole(id);
            ViewBag.ToolButtons = "VP"; // View Pick 
            ViewBag.PickState = selected;
            return View("AccountList", models);
        }

        // Add a relationship (AccountRole) between Account (parent) Role (child)
        //[Authorize(Roles = "Admin,SaveAccountRole")]
		[RolesRequired("Admin","SaveAccountRole")]  
        public ActionResult AddAccountRole(int id)
        {
            ViewBag.Readonly = false;
            ViewBag.ShowRelationships = false;
            ViewBag.ModelId = new int?(id);
            return View("Form", new AccountViewModel());
        }

        // Add a relationship (AccountRole) between Account (parent) Role (child)
        [HttpPost]
        //[Authorize(Roles = "Admin,SaveAccountRole")]
		[RolesRequired("Admin","SaveAccountRole")]
        public ActionResult SaveAccountRole(AccountViewModel model, int modelId)
        {
            var errors = new List<IModelError>();
            model.Id = 0 ; // force a new object regardless
            var result = service.TrySave(model, errors);

            if (result)
            {
                service.AddRoleToAccountForAccountRole(model.Id, modelId);
            }

            return Json(new
            {
                Model = model,
                Success = result,
                Errors = errors
            });
        }

        // remove a relationship (AccountRole) between Account (parent) Role (child) 
        [HttpPost]
		[RolesRequired("Admin","SaveAccountRole")]       
        public ActionResult UnLinkAccountRole(int modelId , int[] items)
        {
            var result = true;

            try
            {
                items.DefaultIfNull().AsParallel().ToList().ForEach(i => {
					service.RemoveRoleFromAccountForAccountRole(modelId, i);					                  
                });
            }
            catch 
            {
				items.DefaultIfNull().AsParallel().ToList().ForEach(i => {                    
					service.AddRoleToAccountForAccountRole(modelId, i);  
                });
                result = false;  
            }
                                   
            return Json(new
            {
                Success = result
            });
        }

        // add a relationship (AccountRole) between existing Account (parent) Role (child) 
        [HttpPost]
        [RolesRequired("Admin","SaveAccountRole")]  
        public ActionResult LinkAccountRole(int modelId , int[] items)
        {
            var result = true;

            try
            {
                items.DefaultIfNull().AsParallel().ToList().ForEach(i => {
					service.AddRoleToAccountForAccountRole(modelId, i);                    
                });
            }
            catch 
            {
				items.DefaultIfNull().AsParallel().ToList().ForEach(i => {                    
					service.RemoveRoleFromAccountForAccountRole(modelId, i);
                });
                result = false;  
            }
                                   
            return Json(new
            {
                Success = result
            });
        }
                        

        // return a fully populated view model
        private AccountViewModel GetViewModel(int id, List<IModelError> errors)
        {
            var rtn = new AccountViewModel();
            rtn.Load(service.Get(id,errors));

            return rtn;
        }
    }
}