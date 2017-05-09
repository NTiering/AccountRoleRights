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

    public class RightController : ApiController
    {
        private IRightService service; 
        public RightController(IRightService service)
        {
            this.service = service;
        }

        /// <summary>
        /// Gets all Right.
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
        /// Gets the specified Right.
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
        /// Posts the specified Right.
        /// </summary>
        /// <param name="value">The value.</param>
        public HttpResponseMessage Post(RightViewModel model)
        {
            var errors = new List<IModelError>();
            var result = service.TrySave(model, errors);

            return errors.Any() ?
                Request.CreateResponse(HttpStatusCode.BadRequest, errors) :
                Request.CreateResponse(HttpStatusCode.OK, model);
        }

        /// <summary>
        /// Puts the specified Right.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        [Route("Api/Right/Validate/")]
        [HttpPost]
        public HttpResponseMessage Validate(RightViewModel model, string propertyName)
        {
            var errors = new List<IModelError>();
            var result = service.TryValidate(model, propertyName, errors);

            return errors.Any() ?
                Request.CreateResponse(HttpStatusCode.BadRequest, errors) :
                Request.CreateResponse(HttpStatusCode.OK, result);
        }

        /// <summary>
        /// Deletes the specified Right.
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
        /// Supports the many to many relationship (RoleRight) between 
        /// Right (parent) Role (child)
        /// </summary>
        /// <param name="rightId"></param>
        /// <param name="roleId"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        [Route("Api/Right/{roleId}/RoleRight")]
        [HttpGet]
        public HttpResponseMessage GetRoleRight(int roleId)
        {
            var errors = new List<IModelError>();
            var result = service.GetRoleRight(roleId ,errors)
                .AsParallel()
                .Select(x=> x.ToViewModel())
                .ToArray();        

            return errors.Any() ?
                Request.CreateResponse(HttpStatusCode.BadRequest, errors):
                Request.CreateResponse(HttpStatusCode.OK, result);
        }

        /// <summary>
        /// Supports the many to many relationship (RoleRight) between 
        /// Right (parent) Role (child)
        /// </summary>
        /// <param name="rightId"></param>
        /// <param name="roleId"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        [Route("Api/Right/RoleRight")]
        [HttpPost]        
        public HttpResponseMessage AddRoleRight(int rightId, int roleId)
        {
            var errors = new List<IModelError>();
            var result = service.TryAddRoleRight(rightId, roleId, errors);

            return errors.Any() ?
                Request.CreateResponse(HttpStatusCode.BadRequest, errors):
                Request.CreateResponse(HttpStatusCode.OK, result);
        }

        /// <summary>
        /// Supports the many to many relationship (RoleRight) between 
        /// Right (parent) Role (child)
        /// </summary>
        /// <param name="rightId"></param>
        /// <param name="roleId"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        [Route("Api/Right/RoleRight")]
        [HttpDelete]    
        public HttpResponseMessage RemoveRoleRight(int rightId, int roleId)
        {
            var errors = new List<IModelError>();
            var result = service.TryRemoveRoleRight(rightId, roleId, errors);

            return errors.Any() ?
                Request.CreateResponse(HttpStatusCode.BadRequest, errors):
                Request.CreateResponse(HttpStatusCode.OK, result);
        }
                    
      }
}