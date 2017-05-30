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

    public class AccountController : Controller
    {
        private IAccountService service ;   

        public AccountController(IAccountService service )
        {
            this.service = service;
            
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            ViewBag.Title = "App";
            ViewBag.SectionTitle = "Account";
        }

        // GET: Account
        //[Authorize(Roles = "Admin,ListAccount")]
        public ActionResult Index()
        {
            var errors = new List<IModelError>();
            var models = service.GetAll(x => x != null, errors);
            ViewBag.Errors = errors;
            ViewBag.ToolButtons = "VED"; // View Edit Delete 
            return View(models);            
        }

        // Display a form for viewing Account
        //[Authorize(Roles = "Admin,ViewAccount")]
        public ActionResult View(int id = -1)
        {
            var errors = new List<IModelError>();
            ViewBag.Readonly = true;
            ViewBag.ShowRelationships = false;
            var model = GetViewModel(id,errors);
            return View("Form",model);
        }

        // Display a form for editing Account
        //[Authorize(Roles = "Admin,SaveAccount")]
        public ActionResult Edit(int id = -1)
        {
            var errors = new List<IModelError>();
            ViewBag.Readonly = false;
            ViewBag.ShowRelationships = true;
            var model = GetViewModel(id,errors);
            return View("Form",model);
        }

        // Display a form for creating Account
        //[Authorize(Roles = "Admin,SaveAccount")]
        public ActionResult Create(int id = -1)
        {
            var errors = new List<IModelError>();
            ViewBag.Readonly = false;
            ViewBag.ShowRelationships = false;
            var model = GetViewModel(id,errors);
            return View("Form",model);
        }

        // Display a form for deleting Account
        //[Authorize(Roles = "Admin,DeleteAccount")]
        public ActionResult Delete(int id = -1)
        {
            var errors = new List<IModelError>();
            ViewBag.Readonly = true;
            ViewBag.ShowRelationships = false;
            var model = GetViewModel(id,errors);
            return View("Form",model);
        }

        // Add Account via json post
        [HttpPost]
        //[Authorize(Roles = "Admin,SaveAccount")]
        public ActionResult Save(AccountViewModel model)
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

        // Delete Account via json post
        [HttpPost]
        //[Authorize(Roles = "Admin,DeleteAccount")]
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

        // list all Account entities
        //[Authorize(Roles = "Admin,ListAccount")]
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
        public ActionResult GetAccountRole(int id, bool selected = false) 
        {
            var models = service.GetAllForAccountRole(id);
            ViewBag.ToolButtons = "VP"; // View Pick 
            ViewBag.PickState = selected;
            return View("AccountList", models);
        }

        // Add a relationship (AccountRole) between Account (parent) Role (child)
        //[Authorize(Roles = "Admin,SaveAccountRole")]
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
        //[Authorize(Roles = "Admin,SaveAccountRole")]
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
        //[Authorize(Roles = "Admin,SaveAccountRole")]        
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