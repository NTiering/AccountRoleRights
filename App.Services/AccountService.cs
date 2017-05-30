namespace App.Services
{
    using Contracts;
    using System;
    using System.Collections.Generic;
    using Contracts.DataModels;
    using Contracts.Dals;
    using System.Linq;
    using Contracts.Services;
    using Encryption;
    using Contracts.ChangeHandlers;
    using Contracts.Validators;
    using Contracts.Interfaces;

    /// <summary>
    /// Service to provide atomic opertaion for a Account data object
    /// </summary>
    class AccountService : IAccountService
    {    
        
		private readonly ICryptoProvider cryptoProvider ;
				       
		private readonly IAccountDal dal ;

        private readonly IAccountChangeHandler changeHandler ;

        private readonly IAccountValidator validator ;
		
        public AccountService(IAccountDal dal, IAccountValidator validator, IAccountChangeHandler changeHandler , ICryptoProvider cryptoProvider)
        {
            this.dal = dal; 
			this.changeHandler = changeHandler;
            this.validator = validator;
			this.cryptoProvider = cryptoProvider;
        }	   
		
		/// <summary>
        /// Deletes the specified item that contains the id.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="errors"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public bool TryDelete(int id, List<IModelError> errors, IModelContext context = null)
        {
            var exists = Exists(id, context);
            if (!exists)
            {
                AddNotExistsError(errors);
                return false;
            }

            try
            {
                changeHandler.BeforeDelete(id, context);
                dal.Delete(id, context);
                changeHandler.AfterDelete(id, context);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Unable to delete IAccountDataModel", ex);
            }
            
            return true;
        }

		/// <summary>
        /// Tries to save the item.
        /// </summary>
        /// <param name="item"></param>
        /// <param name="errors"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public bool TrySave(IAccountDataModel item, List<IModelError> errors, IModelContext context = null)
        {
            return item.IsNew ?
                TryCreate(item, errors, context) :
                TryUpdate(item, errors, context);
        }

		/// <summary>
        /// Gets the first item that fufills the filter.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <returns></returns>
        public IAccountDataModel Get(Func<IAccountDataModel, bool> filter, IModelContext context = null)
        {
            return dal.Get(filter, context);
        }

        /// <summary>
        /// Gets the specified item by id.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="errors"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public IAccountDataModel Get(int id, List<IModelError> errors, IModelContext context = null)
        {
            var rtn = dal.Get(id, context);
            return rtn;
        }

        /// <summary>
        /// Gets the first item that fufills the filter.
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="errors"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public IAccountDataModel Get(Func<IAccountDataModel, bool> filter, List<IModelError> errors, IModelContext context = null)
        {
            var rtn = dal.Get(filter, context);
            return rtn;
        }

        /// <summary>
        /// Gets all the items that fufills the filter.
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="errors"></param>
        /// <param name="context"></param>
        /// <param name="order"></param>
        /// <param name="skip"></param>
        /// <param name="take"></param>
        /// <returns></returns>
        public IQueryable<IAccountDataModel> GetAll(Func<IAccountDataModel, bool> filter, List<IModelError> errors, IModelContext context = null, Func<IAccountDataModel, int> order = null, int skip = 0, int take = 999)
        {
            var rtn = dal.GetAll(filter, context)
                .Skip(skip)
                .Take(take);

            if (order != null)
            {
                rtn = rtn.OrderBy(order)
                    .AsQueryable();
            }
            return rtn;
        }

		/// <summary>
        /// Checks the validation of a single property
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="errors">The errors.</param>
        /// <param name="context">The context.</param>
        /// <returns></returns>
        public bool TryValidate(IAccountDataModel item, string propertyName, List<IModelError> errors, IModelContext context = null)
        {
            var rtn = TryValidateModel(item, Operation.View, errors, context);
            errors.RemoveAll(x => string.Compare(x.Property, propertyName, true) != 0);
            return rtn;
        }

		/// <summary>
        /// Tries to update the item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="errors">The errors.</param>
        /// <param name="context">The context.</param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        private bool TryUpdate(IAccountDataModel item, List<IModelError> errors, IModelContext context = null)
        {
            if (TryValidateModel(item, Operation.Update, errors, context) == false)
            {
                return false;
            }

            if (item != null && item.Password != null)
            {
                item.Password = cryptoProvider.CreateHash(item.Password);
            }
                                    
			try
            {
                changeHandler.BeforeUpdate(item, context);
                dal.Update(item, context);
                changeHandler.AfterUpdate(item, context);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Unable to update IAccountDataModel", ex);
            }

            return true;
        }

		/// <summary>
        /// Tries to create a new item
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="errors">The errors.</param>
        /// <param name="context">The context.</param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException">Unable to update IAccountDataModel"</exception>
        private bool TryCreate(IAccountDataModel item, List<IModelError> errors, IModelContext context = null)
        {
            if (TryValidateModel(item, Operation.Create, errors, context) == false)
            {
                return false;
            }

            if (item != null && item.Password != null)
            {
                item.Password = cryptoProvider.CreateHash(item.Password);
            }
                                    
			try
            {
                changeHandler.BeforeCreate(item, context);
                dal.Create(item, context);
                changeHandler.AfterCreate(item, context);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Unable to create IAccountDataModel", ex);
            }

            return true;
        }

		/// <summary>
        /// Returns true if the an item has this id
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="context">The context.</param>
        /// <returns></returns>
        private bool Exists(int id, IModelContext context = null)
        {
            return dal.Get(id, context) != null;
        }

		/// <summary>
        /// Adds the not exists error.
        /// </summary>
        /// <param name="errors">The errors.</param>
        private void AddNotExistsError(List<IModelError> errors)
        {
            errors.Add(new ModelError { Property = "", ErrorMessage = "notexisting" });
        }

		/// <summary>
        /// Validates the model.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="operation">The operation.</param>
        /// <param name="errors">The errors.</param>
        /// <param name="context">The context.</param>
        /// <returns></returns>
        private bool TryValidateModel(IAccountDataModel item, Operation operation, List<IModelError> errors, IModelContext context = null)
        {
            if (item == null)
            {
                AddNullModelError(errors);
                return false;
            }

            return validator.IsValid(item, operation, errors);
        }

        /// <summary>
        /// Adds the null model error.
        /// </summary>
        /// <param name="errors">The errors.</param>
        private void AddNullModelError(List<IModelError> errors)
        {
            errors.Add(new ModelError { Property = "", ErrorMessage = "nomodel" });
        }


        /// <summary>
        /// Returns true if the model exists and the values supplied matches a hashed version of Password
        /// </summary>
        public bool MatchesPassword(int id , string password, List<IModelError> errors, IModelContext context = null)
        {
            var model = Get(id, errors, context);
            if(model == null) return false;
            var rtn = (String.Compare(password, cryptoProvider.CreateHash(model.Password)) == 0);
            return rtn;
        } 
        		        	
		#region 'AccountRole' (Many to many - Account (p))  		
		/// <summary>
        /// Adds the role to account for 'AccountRole' relationship.
        /// </summary>
		public void AddRoleToAccountForAccountRole(int roleId, int accountId, IModelContext context = null)
		{
			changeHandler.BeforeAddRoleToAccountForAccountRole(roleId, accountId, context);
			dal.AddRoleToAccountForAccountRole(roleId, accountId, context);
			changeHandler.AfterAddRoleToAccountForAccountRole(roleId, accountId, context);
		}

		/// <summary>
        /// Removes the role from account for 'AccountRole' relationship.
        /// </summary>
		public void RemoveRoleFromAccountForAccountRole(int roleId, int accountId, IModelContext context = null)
		{
			changeHandler.BeforeRemoveRoleFromAccountForAccountRole(roleId, accountId, context);
			dal.RemoveRoleFromAccountForAccountRole(roleId, accountId, context);
			changeHandler.AfterRemoveRoleFromAccountForAccountRole(roleId, accountId, context);
		}

		/// <summary>
        /// Get all Account for 'AccountRole' relationship.
        /// </summary>
		public IQueryable<IAccountDataModel> GetAllForAccountRole(int roleId, IModelContext context = null)
		{
			changeHandler.BeforeGetAllForAccountRole(roleId, context);
			var rtn = dal.GetAllForAccountRole(roleId, context);	
			changeHandler.AfterGetAllForAccountRole(rtn, roleId, context);
			return rtn ;
		}
		#endregion 
    }
}