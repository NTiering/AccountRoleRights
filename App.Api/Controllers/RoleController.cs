namespace App.Api.Controllers
{
    using App.Contracts;
    using App.Contracts.Services;
    using Contracts.DataModels;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using ViewModels;

    public class RoleController : ApiController
    {
        private IRoleService service; 
        public RoleController(IRoleService service)
        {
            this.service = service;
        }

        /// <summary>
        /// Gets all Role.
        /// </summary>
        /// <returns></returns>
        public HttpResponseMessage Get()
        {
            var errors = new List<IModelError>();
            var result = service.GetAll((x => x != null), errors)
                .AsParallel()
                .Select(x=> x.ToViewModel())
                .ToArray();

            return errors.Any() ?
                Request.CreateResponse(HttpStatusCode.BadRequest, errors) :
                Request.CreateResponse(HttpStatusCode.OK, result);
        }

        /// <summary>
        /// Gets the specified Role.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public HttpResponseMessage Get(int id)
        {
            var errors = new List<IModelError>();
            var result = service.Get(id, errors)?.ToViewModel();

            return errors.Any() ?
                Request.CreateResponse(HttpStatusCode.BadRequest, errors) :
                Request.CreateResponse(HttpStatusCode.OK, result);
        }

        /// <summary>
        /// Posts the specified Role.
        /// </summary>
        /// <param name="value">The value.</param>
        public HttpResponseMessage Post(RoleViewModel model)
        {
            var errors = new List<IModelError>();
            var result = service.TrySave(model, errors);

            return errors.Any() ?
                Request.CreateResponse(HttpStatusCode.BadRequest, errors) :
                Request.CreateResponse(HttpStatusCode.OK, model);
        }

        /// <summary>
        /// Puts the specified Role.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        [Route("Api/Role/Validate/")]
        [HttpPost]
        public HttpResponseMessage Validate(RoleViewModel model, string propertyName)
        {
            var errors = new List<IModelError>();
            var result = service.TryValidate(model, propertyName, errors);

            return errors.Any() ?
                Request.CreateResponse(HttpStatusCode.BadRequest, errors) :
                Request.CreateResponse(HttpStatusCode.OK, result);
        }

        /// <summary>
        /// Deletes the specified Role.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public HttpResponseMessage Delete(int id)
        {
            var errors = new List<IModelError>();
            var result = service.TryDelete(id, errors);

            return errors.Any() ?
                Request.CreateResponse(HttpStatusCode.BadRequest, errors) :
                Request.CreateResponse(HttpStatusCode.OK, result);
        }

    
        /// <summary>
        /// Supports the many to many relationship (AccountRole) between 
        /// Role (child) Account (parent)
        /// </summary>
        /// <param name="roleId"></param>
        /// <param name="accountId"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        [Route("Api/Role/{roleId}/AccountRole/")]
        [HttpGet]    
        public HttpResponseMessage GetAccountRole(int roleId)
        {
            var errors = new List<IModelError>();
            var result = service.GetAccountRole(roleId, errors)
                .AsParallel()
                .Select(x=> x.ToViewModel())
                .ToArray();

            return errors.Any() ?
                Request.CreateResponse(HttpStatusCode.BadRequest, errors):
                Request.CreateResponse(HttpStatusCode.OK, result);
        }
        
        /// <summary>
        /// Supports the many to many relationship (AccountRole) between 
        /// Role (child) Account (parent)
        /// </summary>
        /// <param name="roleId"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        [Route("Api/Role/AccountRole")]
        [HttpPost]    
        public HttpResponseMessage AddAccountRole(int roleId, int accountId)
        {            
            var errors = new List<IModelError>();
            var result = service.TryAddAccountRole(roleId, accountId, errors);

            return errors.Any() ?
                Request.CreateResponse(HttpStatusCode.BadRequest, errors):
                Request.CreateResponse(HttpStatusCode.OK, result);
        }

        /// <summary>
        /// Supports the many to many relationship (AccountRole) between 
        /// Role (child) Account (parent)
        /// </summary>
        /// <param name="roleId"></param>
        /// <param name="accountId"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        [Route("Api/Role/AccountRole")]
        [HttpDelete]    
        public HttpResponseMessage RemoveAccountRole(int roleId, int accountId)
        {
            var errors = new List<IModelError>();
            var result = service.TryRemoveAccountRole(roleId, accountId, errors);

            return errors.Any() ?
                Request.CreateResponse(HttpStatusCode.BadRequest, errors):
                Request.CreateResponse(HttpStatusCode.OK, result);
        }
        
        /// <summary>
        /// Supports the many to many relationship (RoleRight) between 
        /// Role (child) Right (parent)
        /// </summary>
        /// <param name="roleId"></param>
        /// <param name="rightId"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        [Route("Api/Role/{roleId}/RoleRight/")]
        [HttpGet]    
        public HttpResponseMessage GetRoleRight(int roleId)
        {
            var errors = new List<IModelError>();
            var result = service.GetRoleRight(roleId, errors)
                .AsParallel()
                .Select(x=> x.ToViewModel())
                .ToArray();

            return errors.Any() ?
                Request.CreateResponse(HttpStatusCode.BadRequest, errors):
                Request.CreateResponse(HttpStatusCode.OK, result);
        }
        
        /// <summary>
        /// Supports the many to many relationship (RoleRight) between 
        /// Role (child) Right (parent)
        /// </summary>
        /// <param name="roleId"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        [Route("Api/Role/RoleRight")]
        [HttpPost]    
        public HttpResponseMessage AddRoleRight(int roleId, int rightId)
        {            
            var errors = new List<IModelError>();
            var result = service.TryAddRoleRight(roleId, rightId, errors);

            return errors.Any() ?
                Request.CreateResponse(HttpStatusCode.BadRequest, errors):
                Request.CreateResponse(HttpStatusCode.OK, result);
        }

        /// <summary>
        /// Supports the many to many relationship (RoleRight) between 
        /// Role (child) Right (parent)
        /// </summary>
        /// <param name="roleId"></param>
        /// <param name="rightId"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        [Route("Api/Role/RoleRight")]
        [HttpDelete]    
        public HttpResponseMessage RemoveRoleRight(int roleId, int rightId)
        {
            var errors = new List<IModelError>();
            var result = service.TryRemoveRoleRight(roleId, rightId, errors);

            return errors.Any() ?
                Request.CreateResponse(HttpStatusCode.BadRequest, errors):
                Request.CreateResponse(HttpStatusCode.OK, result);
        }
                
      }
}