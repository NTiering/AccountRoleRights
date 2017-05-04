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

    public class RightController : Controller
    {
		private IRightService service ;   

        public RightController(IRightService service )
        {
            this.service = service;
			
        }

		protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            ViewBag.Title = "App";
			ViewBag.SectionTitle = "Right";
        }

        // GET: Right
		//[Authorize(Roles = "Admin,ListRight")]
        public ActionResult Index()
        {
            var errors = new List<IModelError>();
            var models = service.GetAll(x => x != null, errors);
            ViewBag.Errors = errors;
			ViewBag.ToolButtons = "VED"; // View Edit Delete 
            return View(models);            
        }

		// Display a form for viewing Right
		//[Authorize(Roles = "Admin,ViewRight")]
		public ActionResult View(int id = -1)
        {
			var errors = new List<IModelError>();
			ViewBag.Readonly = true;
			ViewBag.ShowRelationships = false;
			var model = GetViewModel(id,errors);
			return View("Form",model);
        }

		// Display a form for editing Right
		//[Authorize(Roles = "Admin,SaveRight")]
		public ActionResult Edit(int id = -1)
        {
			var errors = new List<IModelError>();
			ViewBag.Readonly = false;
			ViewBag.ShowRelationships = true;
			var model = GetViewModel(id,errors);
			return View("Form",model);
        }

		// Display a form for creating Right
		//[Authorize(Roles = "Admin,SaveRight")]
		public ActionResult Create(int id = -1)
        {
			var errors = new List<IModelError>();
			ViewBag.Readonly = false;
			ViewBag.ShowRelationships = false;
			var model = GetViewModel(id,errors);
			return View("Form",model);
        }

		// Display a form for deleting Right
		//[Authorize(Roles = "Admin,DeleteRight")]
		public ActionResult Delete(int id = -1)
        {
			var errors = new List<IModelError>();
			ViewBag.Readonly = true;
			ViewBag.ShowRelationships = false;
			var model = GetViewModel(id,errors);
			return View("Form",model);
        }

		// Add Right via json post
		[HttpPost]
		//[Authorize(Roles = "Admin,SaveRight")]
        public ActionResult Save(RightViewModel model)
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

		// Delete Right via json post
        [HttpPost]
		//[Authorize(Roles = "Admin,DeleteRight")]
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

		// list all Right entities
		//[Authorize(Roles = "Admin,ListRight")]
		public ActionResult List() 
        {
            var errors = new List<IModelError>();
            var models = service.GetAll(x =>x != null, errors);
            ViewBag.Errors = errors;
            ViewBag.ToolButtons = "VP"; // View Pick 
            ViewBag.PickState = false;
            return View("RightList", models);
        }
				
		
        // Supports the many to many relationship (RoleRight) between Right (parent) Role (child)
		//[Authorize(Roles = "Admin,ListRoleRight")]
		public ActionResult GetRoleRight(int id, bool selected = false) 
        {
			var errors = new List<IModelError>();
            var models = service.GetRoleRight(id, errors);
			ViewBag.Errors = errors;
			ViewBag.ToolButtons = "VP"; // View Pick 
			ViewBag.PickState = selected;
			return View("RightList", models);
        }

		// Add a relationship (RoleRight) between Right (parent) Role (child)
        //[Authorize(Roles = "Admin,SaveRoleRight")]
		public ActionResult AddRoleRight(int id)
        {
            var errors = new List<IModelError>();
            ViewBag.Readonly = false;
            ViewBag.ShowRelationships = false;
			ViewBag.ModelId = new int?(id);
            return View("Form");
        }

        // Add a relationship (RoleRight) between Right (parent) Role (child)
        [HttpPost]
        //[Authorize(Roles = "Admin,SaveRoleRight")]
		public ActionResult SaveRoleRight(RightViewModel model, int modelId)
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
		private RightViewModel GetViewModel(int id, List<IModelError> errors)
		{
			var rtn = new RightViewModel();
			rtn.Load(service.Get(id,errors));

			return rtn;
		}
    }
}