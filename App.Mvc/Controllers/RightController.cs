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
    public class RightController : Controller
    {
		private readonly ILogProvider log ; 
		private const string LogName = "Right";
        private readonly IRightService service ;   
        private readonly IRoleService roleService;

        public RightController(ILogProvider log, IRightService service , IRoleService roleService )
        {
            this.service = service;
			this.log = log;
            this.roleService = roleService;
                        
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
			log.LogActionExecuting(LogName,filterContext);
			ViewBag.Title = "App";
            ViewBag.SectionTitle = "Right";
        }

        // GET: Right
		[RolesRequired("Admin","ListRight")]
        public ActionResult Index()
        {
            var errors = new List<IModelError>();
            var models = service.GetAll(x => x != null, errors);
            ViewBag.Errors = errors;
            ViewBag.ToolButtons = "VED"; // View Edit Delete 
			ViewBag.Title = "List Right" ; 
            return View(models);            
        }

        // Display a form for viewing Right
		[RolesRequired("Admin","ViewRight")]
        public ActionResult View(int id = -1)
        {			 
            var errors = new List<IModelError>();
            ViewBag.Readonly = true;
            ViewBag.ButtonFlag = "";
			ViewBag.Title = "View Right" ; 
            var model = GetViewModel(id,errors);
            return View("Form",model);
        }

        // Display a form for editing Right
		[RolesRequired("Admin","SaveRight")]        
        public ActionResult Edit(int id = -1)
        {
            var errors = new List<IModelError>();
            ViewBag.Readonly = false;
			ViewBag.ButtonFlag = "RS"; // Relationship Submit
			ViewBag.Title = "Edit Right" ; 
            var model = GetViewModel(id,errors);
            return View("Form",model);
        }

		[RolesRequired("Admin","SaveRight")]   
        [HttpPost]
        public ActionResult Edit(RightViewModel model)
        {
            var errors = new List<IModelError>();
            service.TrySave(model, errors);          

			if (errors.Any())
            {
                this.AddModelErrors(errors);
                ViewBag.Readonly = false;
				ViewBag.ButtonFlag = "RS"; // Relationship Submit
				ViewBag.Title = "Edit Right" ; 
                return View("Form", model);
            }
            else
            {
                return RedirectToAction("index", new { updated = model.Id });
            } 
        }

        // Display a form for creating Right
		[RolesRequired("Admin","SaveRight")]   
        public ActionResult Create(int id = -1)
        {
            var errors = new List<IModelError>();
            ViewBag.Readonly = false;
			ViewBag.ButtonFlag = "S"; // Submit
			ViewBag.Title = "New Right" ; 
            var model = GetViewModel(id,errors);
            return View("Form",model);
        }

		[RolesRequired("Admin","SaveRight")]   
        [HttpPost]
        public ActionResult Create(RightViewModel model)
        {
            var errors = new List<IModelError>();

			service.TrySave(model, errors);  
			if (errors.Any())
            {
                this.AddModelErrors(errors);
                ViewBag.Readonly = false;
                ViewBag.ButtonFlag = "S"; // Submit
				ViewBag.Title = "New Right" ; 
                return View("Form", model);
            }
            else
            {
                return RedirectToAction("index", new { creaated = model.Id });
            } 
        }

        // Display a form for deleting Right
		[RolesRequired("Admin","DeleteRight")]   
        public ActionResult Delete(int id = -1)
        {
            var errors = new List<IModelError>();
            ViewBag.Readonly = true;
            ViewBag.ShowRelationships = false;
			ViewBag.Title = "Delete Right" ; 
            var model = GetViewModel(id,errors);
            return View("Form",model);
        }

		[RolesRequired("Admin", "DeleteRight")]
        [HttpPost]
        public ActionResult Delete(RightViewModel model, int _post)
        {
            var errors = new List<IModelError>();
            var result = service.TryDelete(model.Id, errors);
            ViewBag.Title = "Delete Right";
            if (errors.Any())
            {
                model = GetViewModel(model.Id, errors);
                this.AddModelErrors(errors);
                ViewBag.Readonly = false;
                ViewBag.ButtonFlag = "S"; // Submit
                ViewBag.Title = "Delete Right";
                return View("Form", model);
            }
            else
            {
                return RedirectToAction("index", new { deleted = model.Id });
            }
        }
		
        // list all Right entities
		[RolesRequired("Admin","ListRight")]  
        public ActionResult List() 
        {
            var errors = new List<IModelError>();
            var models = service.GetAll(x =>x != null, errors);
            ViewBag.Errors = errors;
            ViewBag.ToolButtons = "VP"; // View Pick 
            ViewBag.PickState = false;
            return View("RightList", models);
        }
                
                
        // Supports the one to many relationship (RoleRight) between Right (one) Role (many)
        [RolesRequired("Admin","ListRoleRight")]  
        public ActionResult GetRoleRight(int id) 
        {
            var models = new[] { service.GetSingleRightByRoleForRoleRight(id)};
            ViewBag.ToolButtons = "VE"; // View Edit 
            ViewBag.PickState = true;
            return View("RightList", models);
        }

        // return a fully populated view model
        private RightViewModel GetViewModel(int id, List<IModelError> errors)
        {
            var rtn = new RightViewModel();
            rtn.Load(service.Get(id,errors));

            var rolerightModel = service.GetSingleRightByRoleForRoleRight(id);
            if (rolerightModel != null)
            {
                rtn.RoleRightId = rolerightModel.Id;
            }
            
            return rtn;
        }
    }
}