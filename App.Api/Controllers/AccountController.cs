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

    public class AccountController : ApiController
    {
        private IAccountService service; 
	    public AccountController(IAccountService service)
        {
            this.service = service;
	    }

        /// <summary>
        /// Gets all Account.
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
        /// Gets the specified Account.
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
        /// Posts the specified Account.
        /// </summary>
        /// <param name="value">The value.</param>
        public HttpResponseMessage Post(AccountViewModel model)
        {
            var errors = new List<IModelError>();
            var result = service.TrySave(model, errors);

            return errors.Any() ?
                Request.CreateResponse(HttpStatusCode.BadRequest, errors) :
                Request.CreateResponse(HttpStatusCode.OK, model);
        }

        /// <summary>
        /// Puts the specified Account.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        [Route("Api/Account/Validate/")]
        [HttpPost]
        public HttpResponseMessage Validate(AccountViewModel model, string propertyName)
        {
            var errors = new List<IModelError>();
            var result = service.TryValidate(model, propertyName, errors);

            return errors.Any() ?
                Request.CreateResponse(HttpStatusCode.BadRequest, errors) :
                Request.CreateResponse(HttpStatusCode.OK, result);
        }

        /// <summary>
        /// Deletes the specified Account.
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
        /// Account (parent) Role (child)
        /// </summary>
        /// <param name="accountId"></param>
        /// <param name="roleId"></param>
        /// <param name="context"></param>
        /// <returns></returns>
		[Route("Api/Account/{roleId}/AccountRole")]
		[HttpGet]
		public HttpResponseMessage GetAccountRole(int roleId)
		{
			var errors = new List<IModelError>();
			var result = service.GetAccountRole(roleId ,errors)
				.AsParallel()
                .Select(x=> x.ToViewModel())
                .ToArray();		

			return errors.Any() ?
                Request.CreateResponse(HttpStatusCode.BadRequest, errors):
                Request.CreateResponse(HttpStatusCode.OK, result);
		}

		/// <summary>
        /// Supports the many to many relationship (AccountRole) between 
        /// Account (parent) Role (child)
        /// </summary>
        /// <param name="accountId"></param>
        /// <param name="roleId"></param>
        /// <param name="context"></param>
        /// <returns></returns>
		[Route("Api/Account/AccountRole")]
		[HttpPost]		
		public HttpResponseMessage AddAccountRole(int accountId, int roleId)
		{
			var errors = new List<IModelError>();
			var result = service.TryAddAccountRole(accountId, roleId, errors);

			return errors.Any() ?
                Request.CreateResponse(HttpStatusCode.BadRequest, errors):
                Request.CreateResponse(HttpStatusCode.OK, result);
		}

		/// <summary>
        /// Supports the many to many relationship (AccountRole) between 
        /// Account (parent) Role (child)
        /// </summary>
        /// <param name="accountId"></param>
        /// <param name="roleId"></param>
        /// <param name="context"></param>
        /// <returns></returns>
		[Route("Api/Account/AccountRole")]
		[HttpDelete]	
		public HttpResponseMessage RemoveAccountRole(int accountId, int roleId)
		{
			var errors = new List<IModelError>();
			var result = service.TryRemoveAccountRole(accountId, roleId, errors);

			return errors.Any() ?
                Request.CreateResponse(HttpStatusCode.BadRequest, errors):
                Request.CreateResponse(HttpStatusCode.OK, result);
		}
					
	  }
}