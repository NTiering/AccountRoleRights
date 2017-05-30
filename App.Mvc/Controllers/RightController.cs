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
        private IRoleService roleService;

        public RightController(IRightService service , IRoleService roleService )
        {
            this.service = service;
            this.roleService = roleService;
                        
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
        
            if(result) // make a connection between the new Right and an existing Role 
            {				
                roleService.AddRoleToRightForRoleRight(model.Id,model.RoleRightId);
            }            
        
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
                
                
        // Supports the one to many relationship (RoleRight) between Right (one) Role (many)
        //[Authorize(Roles = "Admin,ListRoleRight")]
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