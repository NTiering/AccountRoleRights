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
    public class RoleController : Controller
    {
		private readonly ILogProvider log ; 
		private const string LogName = "Role";
        private readonly IRoleService service ;   

        public RoleController(ILogProvider log, IRoleService service )
        {
            this.service = service;
			this.log = log;
            
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
			log.LogActionExecuting(LogName,filterContext);
			ViewBag.Title = "App";
            ViewBag.SectionTitle = "Role";
        }

        // GET: Role
		[RolesRequired("Admin","ListRole")]
        public ActionResult Index()
        {
            var errors = new List<IModelError>();
            var models = service.GetAll(x => x != null, errors);
            ViewBag.Errors = errors;
            ViewBag.ToolButtons = "VED"; // View Edit Delete 
			ViewBag.Title = "List Role" ; 
            return View(models);            
        }

        // Display a form for viewing Role
		[RolesRequired("Admin","ViewRole")]
        public ActionResult View(int id = -1)
        {			 
            var errors = new List<IModelError>();
            ViewBag.Readonly = true;
            ViewBag.ButtonFlag = "";
			ViewBag.Title = "View Role" ; 
            var model = GetViewModel(id,errors);
            return View("Form",model);
        }

        // Display a form for editing Role
		[RolesRequired("Admin","SaveRole")]        
        public ActionResult Edit(int id = -1)
        {
            var errors = new List<IModelError>();
            ViewBag.Readonly = false;
			ViewBag.ButtonFlag = "RS"; // Relationship Submit
			ViewBag.Title = "Edit Role" ; 
            var model = GetViewModel(id,errors);
            return View("Form",model);
        }

		[RolesRequired("Admin","SaveRole")]   
        [HttpPost]
        public ActionResult Edit(RoleViewModel model)
        {
            var errors = new List<IModelError>();
            service.TrySave(model, errors);          

			if (errors.Any())
            {
                this.AddModelErrors(errors);
                ViewBag.Readonly = false;
				ViewBag.ButtonFlag = "RS"; // Relationship Submit
				ViewBag.Title = "Edit Role" ; 
                return View("Form", model);
            }
            else
            {
                return RedirectToAction("index", new { updated = model.Id });
            } 
        }

        // Display a form for creating Role
		[RolesRequired("Admin","SaveRole")]   
        public ActionResult Create(int id = -1)
        {
            var errors = new List<IModelError>();
            ViewBag.Readonly = false;
			ViewBag.ButtonFlag = "S"; // Submit
			ViewBag.Title = "New Role" ; 
            var model = GetViewModel(id,errors);
            return View("Form",model);
        }

		[RolesRequired("Admin","SaveRole")]   
        [HttpPost]
        public ActionResult Create(RoleViewModel model)
        {
            var errors = new List<IModelError>();

			service.TrySave(model, errors);  
			if (errors.Any())
            {
                this.AddModelErrors(errors);
                ViewBag.Readonly = false;
                ViewBag.ButtonFlag = "S"; // Submit
				ViewBag.Title = "New Role" ; 
                return View("Form", model);
            }
            else
            {
                return RedirectToAction("index", new { creaated = model.Id });
            } 
        }

        // Display a form for deleting Role
		[RolesRequired("Admin","DeleteRole")]   
        public ActionResult Delete(int id = -1)
        {
            var errors = new List<IModelError>();
            ViewBag.Readonly = true;
            ViewBag.ShowRelationships = false;
			ViewBag.Title = "Delete Role" ; 
            var model = GetViewModel(id,errors);
            return View("Form",model);
        }

		[RolesRequired("Admin", "DeleteRole")]
        [HttpPost]
        public ActionResult Delete(RoleViewModel model, int _post)
        {
            var errors = new List<IModelError>();
            var result = service.TryDelete(model.Id, errors);
            ViewBag.Title = "Delete Role";
            if (errors.Any())
            {
                model = GetViewModel(model.Id, errors);
                this.AddModelErrors(errors);
                ViewBag.Readonly = false;
                ViewBag.ButtonFlag = "S"; // Submit
                ViewBag.Title = "Delete Role";
                return View("Form", model);
            }
            else
            {
                return RedirectToAction("index", new { deleted = model.Id });
            }
        }
		
        // list all Role entities
		[RolesRequired("Admin","ListRole")]  
        public ActionResult List() 
        {
            var errors = new List<IModelError>();
            var models = service.GetAll(x =>x != null, errors);
            ViewBag.Errors = errors;
            ViewBag.ToolButtons = "VP"; // View Pick 
            ViewBag.PickState = false;
            return View("RoleList", models);
        }
                
        
        // Supports the many to many relationship (AccountRole) between Role (child) Account (parent)
        [RolesRequired("Admin","ListAccountRole")]  
        public ActionResult GetAccountRole(int id) 
        {
            var models = service.GetAllForAccountRole(id);
            ViewBag.ToolButtons = "VP"; // View Pick 
            ViewBag.PickState = true;
            return View("RoleList", models);
        }

        // Add a relationship (AccountRole) between Account (parent) Role (child)
        [RolesRequired("Admin","SaveAccountRole")] 
        public ActionResult AddAccountRole()
        {
            ViewBag.Readonly = false;
            ViewBag.ShowRelationships = false;
            return View("Form", new RoleViewModel());
        }

        // Add a relationship (AccountRole) between Account (parent) and a NEW Role (child)
        [HttpPost]
		[RolesRequired("Admin","SaveAccountRole")]          
        public ActionResult SaveAccountRole(RoleViewModel model, int modelId)
        {
            var errors = new List<IModelError>();
            model.Id = 0 ; // force a new object regardless
            var result = false;

            if (service.TrySave(model, errors))
            {
				service.AddAccountToRoleForAccountRole(model.Id, modelId);  
				result = true ;             
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
                    service.RemoveAccountFromRoleForAccountRole(modelId, i);
                });
            }
            catch // rollback
            {
				items.DefaultIfNull().AsParallel().ToList().ForEach(i => {
                    
					service.AddAccountToRoleForAccountRole(modelId, i);
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
                    service.AddAccountToRoleForAccountRole(modelId, i);
                });
            }
            catch // rollback
            {
				items.DefaultIfNull().AsParallel().ToList().ForEach(i => {
                    service.RemoveAccountFromRoleForAccountRole(modelId, i);
                });
                result = false;  
            }
                                   
            return Json(new
            {
                Success = result
            });

        }
                
    
        // Supports the one to many relationship (RoleRight) between Right (one) Role (many)
        [RolesRequired("Admin","ListRoleRight")]  
        public ActionResult GetRoleRight(int id)
        {
            var models = service.GetAllRoleByRightForRoleRight(id);
            ViewBag.ToolButtons = "VP"; // View Pick 
            ViewBag.PickState = true;
            return View("RoleList",models);
        }
        
        // return a fully populated view model
        private RoleViewModel GetViewModel(int id, List<IModelError> errors)
        {
            var rtn = new RoleViewModel();
            rtn.Load(service.Get(id,errors));

            return rtn;
        }
    }
}