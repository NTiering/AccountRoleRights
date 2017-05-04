namespace App.Mvc.Controllers
{
	using App.Contracts;
	using App.Contracts.DataModels;
	using App.Contracts.Services;
	using App.Mvc.Models;
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Web;
	using System.Web.Mvc;

    public class RoleController : Controller
    {
		private IRoleService service ;   

        public RoleController(IRoleService service )
        {
            this.service = service;
			
        }

		protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            ViewBag.Title = "App";
			ViewBag.SectionTitle = "Role";
        }

        // GET: Role
		//[Authorize(Roles = "Admin,ListRole")]
        public ActionResult Index()
        {
            var errors = new List<IModelError>();
            var models = service.GetAll(x => x != null, errors);
            ViewBag.Errors = errors;
			ViewBag.ToolButtons = "VED"; // View Edit Delete 
            return View(models);            
        }

		// Display a form for viewing Role
		//[Authorize(Roles = "Admin,ViewRole")]
		public ActionResult View(int id = -1)
        {
			var errors = new List<IModelError>();
			ViewBag.Readonly = true;
			ViewBag.ShowRelationships = false;
			var model = GetViewModel(id,errors);
			return View("Form",model);
        }

		// Display a form for editing Role
		//[Authorize(Roles = "Admin,SaveRole")]
		public ActionResult Edit(int id = -1)
        {
			var errors = new List<IModelError>();
			ViewBag.Readonly = false;
			ViewBag.ShowRelationships = true;
			var model = GetViewModel(id,errors);
			return View("Form",model);
        }

		// Display a form for creating Role
		//[Authorize(Roles = "Admin,SaveRole")]
		public ActionResult Create(int id = -1)
        {
			var errors = new List<IModelError>();
			ViewBag.Readonly = false;
			ViewBag.ShowRelationships = false;
			var model = GetViewModel(id,errors);
			return View("Form",model);
        }

		// Display a form for deleting Role
		//[Authorize(Roles = "Admin,DeleteRole")]
		public ActionResult Delete(int id = -1)
        {
			var errors = new List<IModelError>();
			ViewBag.Readonly = true;
			ViewBag.ShowRelationships = false;
			var model = GetViewModel(id,errors);
			return View("Form",model);
        }

		// Add Role via json post
		[HttpPost]
		//[Authorize(Roles = "Admin,SaveRole")]
        public ActionResult Save(RoleViewModel model)
        {
            var errors = new List<IModelError>();
            var result = service.TrySave(model, errors);

            return Json(new
            {
				Model = model,
                Success = result,
                Errors = errors
            });
        }

		// Delete Role via json post
        [HttpPost]
		//[Authorize(Roles = "Admin,DeleteRole")]
        public ActionResult Remove(int id)
        {
			var errors = new List<IModelError>();
            var result = service.TryDelete(id, errors);
            return Json(new
            {
                Success = result ,
                Errors = errors
            });
        }

		// list all Role entities
		//[Authorize(Roles = "Admin,ListRole")]
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
        //[Authorize(Roles = "Admin,ListAccountRole")]
		public ActionResult GetAccountRole(int id) 
        {
			var errors = new List<IModelError>();
            var models = service.GetAccountRole(id, errors);
			ViewBag.Errors = errors;
			ViewBag.ToolButtons = "VP"; // View Pick 
			ViewBag.PickState = true;
			return View("RoleList", models);
        }

		// Add a relationship (AccountRole) between Account (parent) Role (child)
        //[Authorize(Roles = "Admin,SaveAccountRole")]
		public ActionResult AddAccountRole()
        {
            var errors = new List<IModelError>();
            ViewBag.Readonly = false;
            ViewBag.ShowRelationships = false;
            return View("Form");
        }

		// Add a relationship (AccountRole) between Account (parent) and a NEW Role (child)
        [HttpPost]
		//[Authorize(Roles = "Admin,SaveAccountRole")]
		public ActionResult SaveAccountRole(RoleViewModel model, int modelId)
        {
            var errors = new List<IModelError>();
			model.Id = 0 ; // force a new object regardless
            var result = service.TrySave(model, errors);

            if (result)
            {
                result = service.TryAddAccountRole(model.Id, modelId, errors);
				if (result == false && model != null) // failed to make the AccountRole relationship ?
                {
                    service.TryDelete(model.Id, errors);
                }
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
		//[Authorize(Roles = "Admin,SaveAccountRole")]
		public ActionResult UnLinkAccountRole(int modelId , int[] items)
        {
            var errors = new List<IModelError>();
            var result = true;

            items.DefaultIfNull().ToList().ForEach(i =>
            {
                if (result)
                {
                    if (service.TryRemoveAccountRole(modelId, i, errors) == false) // try roll-back if failed
                    {
                        service.TryAddAccountRole(modelId, i, errors);
                        result = false;
                    }
                }
            });
                       
            return Json(new
            {
                Success = result,
                Errors = errors
            });
        }
		
		// add a relationship (AccountRole) between existing Account (parent) Role (child) 
        [HttpPost]
		//[Authorize(Roles = "Admin,SaveAccountRole")]
		public ActionResult LinkAccountRole(int modelId , int[] items)
        {
            var errors = new List<IModelError>();
            var result = true;

            items.DefaultIfNull().ToList().ForEach(i =>
            {
                if (result)
                {
                    if (service.TryAddAccountRole(modelId, i, errors) == false) // try roll-back if failed
                    {
                        service.TryRemoveAccountRole(modelId, i, errors);
                        result = false;
                    }
                }
            });
                       
            return Json(new
            {
                Success = result,
                Errors = errors
            });
        }
		
		// Supports the many to many relationship (RoleRight) between Role (child) Right (parent)
        //[Authorize(Roles = "Admin,ListRoleRight")]
		public ActionResult GetRoleRight(int id) 
        {
			var errors = new List<IModelError>();
            var models = service.GetRoleRight(id, errors);
			ViewBag.Errors = errors;
			ViewBag.ToolButtons = "VP"; // View Pick 
			ViewBag.PickState = true;
			return View("RoleList", models);
        }

		// Add a relationship (RoleRight) between Right (parent) Role (child)
        //[Authorize(Roles = "Admin,SaveRoleRight")]
		public ActionResult AddRoleRight()
        {
            var errors = new List<IModelError>();
            ViewBag.Readonly = false;
            ViewBag.ShowRelationships = false;
            return View("Form");
        }

		// Add a relationship (RoleRight) between Right (parent) and a NEW Role (child)
        [HttpPost]
		//[Authorize(Roles = "Admin,SaveRoleRight")]
		public ActionResult SaveRoleRight(RoleViewModel model, int modelId)
        {
            var errors = new List<IModelError>();
			model.Id = 0 ; // force a new object regardless
            var result = service.TrySave(model, errors);

            if (result)
            {
                result = service.TryAddRoleRight(model.Id, modelId, errors);
				if (result == false && model != null) // failed to make the RoleRight relationship ?
                {
                    service.TryDelete(model.Id, errors);
                }
            }

            return Json(new
            {
                Model = model,
                Success = result,
                Errors = errors
            });
        }
		
		// remove a relationship (RoleRight) between Right (parent) Role (child) 
		[HttpPost]
		//[Authorize(Roles = "Admin,SaveRoleRight")]
		public ActionResult UnLinkRoleRight(int modelId , int[] items)
        {
            var errors = new List<IModelError>();
            var result = true;

            items.DefaultIfNull().ToList().ForEach(i =>
            {
                if (result)
                {
                    if (service.TryRemoveRoleRight(modelId, i, errors) == false) // try roll-back if failed
                    {
                        service.TryAddRoleRight(modelId, i, errors);
                        result = false;
                    }
                }
            });
                       
            return Json(new
            {
                Success = result,
                Errors = errors
            });
        }
		
		// add a relationship (RoleRight) between existing Right (parent) Role (child) 
        [HttpPost]
		//[Authorize(Roles = "Admin,SaveRoleRight")]
		public ActionResult LinkRoleRight(int modelId , int[] items)
        {
            var errors = new List<IModelError>();
            var result = true;

            items.DefaultIfNull().ToList().ForEach(i =>
            {
                if (result)
                {
                    if (service.TryAddRoleRight(modelId, i, errors) == false) // try roll-back if failed
                    {
                        service.TryRemoveRoleRight(modelId, i, errors);
                        result = false;
                    }
                }
            });
                       
            return Json(new
            {
                Success = result,
                Errors = errors
            });
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