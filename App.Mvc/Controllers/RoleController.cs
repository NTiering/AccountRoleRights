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
            var models = service.GetAllForAccountRole(id);
            ViewBag.ToolButtons = "VP"; // View Pick 
            ViewBag.PickState = true;
            return View("RoleList", models);
        }

        // Add a relationship (AccountRole) between Account (parent) Role (child)
        //[Authorize(Roles = "Admin,SaveAccountRole")]
        public ActionResult AddAccountRole()
        {
            ViewBag.Readonly = false;
            ViewBag.ShowRelationships = false;
            return View("Form", new RoleViewModel());
        }

        // Add a relationship (AccountRole) between Account (parent) and a NEW Role (child)
        [HttpPost]
        //[Authorize(Roles = "Admin,SaveAccountRole")]
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
        //[Authorize(Roles = "Admin,SaveAccountRole")]
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
        //[Authorize(Roles = "Admin,SaveAccountRole")]
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
        //[Authorize(Roles = "Admin,ListRoleRight")]
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