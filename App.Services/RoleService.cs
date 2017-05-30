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
    /// Service to provide atomic opertaion for a Role data object
    /// </summary>
    class RoleService : IRoleService
    {    
        		       
		private readonly IRoleDal dal ;

        private readonly IRoleChangeHandler changeHandler ;

        private readonly IRoleValidator validator ;
		
        public RoleService(IRoleDal dal, IRoleValidator validator, IRoleChangeHandler changeHandler )
        {
            this.dal = dal; 
			this.changeHandler = changeHandler;
            this.validator = validator;

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
                throw new InvalidOperationException("Unable to delete IRoleDataModel", ex);
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
        public bool TrySave(IRoleDataModel item, List<IModelError> errors, IModelContext context = null)
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
        public IRoleDataModel Get(Func<IRoleDataModel, bool> filter, IModelContext context = null)
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
        public IRoleDataModel Get(int id, List<IModelError> errors, IModelContext context = null)
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
        public IRoleDataModel Get(Func<IRoleDataModel, bool> filter, List<IModelError> errors, IModelContext context = null)
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
        public IQueryable<IRoleDataModel> GetAll(Func<IRoleDataModel, bool> filter, List<IModelError> errors, IModelContext context = null, Func<IRoleDataModel, int> order = null, int skip = 0, int take = 999)
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
        public bool TryValidate(IRoleDataModel item, string propertyName, List<IModelError> errors, IModelContext context = null)
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
        private bool TryUpdate(IRoleDataModel item, List<IModelError> errors, IModelContext context = null)
        {
            if (TryValidateModel(item, Operation.Update, errors, context) == false)
            {
                return false;
            }
                        
			try
            {
                changeHandler.BeforeUpdate(item, context);
                dal.Update(item, context);
                changeHandler.AfterUpdate(item, context);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Unable to update IRoleDataModel", ex);
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
        /// <exception cref="InvalidOperationException">Unable to update IRoleDataModel"</exception>
        private bool TryCreate(IRoleDataModel item, List<IModelError> errors, IModelContext context = null)
        {
            if (TryValidateModel(item, Operation.Create, errors, context) == false)
            {
                return false;
            }
                        
			try
            {
                changeHandler.BeforeCreate(item, context);
                dal.Create(item, context);
                changeHandler.AfterCreate(item, context);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Unable to create IRoleDataModel", ex);
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
        private bool TryValidateModel(IRoleDataModel item, Operation operation, List<IModelError> errors, IModelContext context = null)
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

				
		#region 'RoleRight ' (One to many - Role (m))
		/// <summary>
        /// Returns all Role connected to a single Right For the 'RoleRight' relationship
        /// </summary>        
		public IQueryable<IRoleDataModel> GetAllRoleByRightForRoleRight(int rightId, IModelContext context = null)
		{
			changeHandler.BeforeGetAllRoleByRightForRoleRight(rightId, context);
			var rtn = dal.GetAllRoleByRightForRoleRight(rightId, context);
			changeHandler.AfterGetAllRoleByRightForRoleRight(rtn, rightId, context);
			return rtn ;
		} 

		/// <summary>
        /// Connects a Role to a Right for RoleRight relationship.
        /// </summary>
        public void AddRoleToRightForRoleRight(int roleId, int rightId, IModelContext context = null)
		{
			changeHandler.BeforeAddRoleToRightForRoleRight(roleId, rightId, context);
			dal.AddRoleToRightForRoleRight(roleId, rightId, context);
			changeHandler.AfterAddRoleToRightForRoleRight(roleId, rightId, context);
		} 

		/// <summary>
        /// Unconnects a Role to a Right for RoleRight relationship.
        /// </summary>
        public void RemoveRoleFromRightForRoleRight(int roleId, IModelContext context = null)
		{
			changeHandler.BeforeRemoveRoleFromRightForRoleRight(roleId, context);
			dal.RemoveRoleFromRightForRoleRight(roleId, context);
			changeHandler.AfterRemoveRoleFromRightForRoleRight(roleId, context);
		} 
		#endregion 
		        		
		#region 'AccountRole' (Many to many - Role (c))  	
		/// <summary>
        /// Adds the role to account for 'AccountRole' relationship.
        /// </summary>
		public void AddAccountToRoleForAccountRole(int roleId, int accountId, IModelContext context = null)
		{
			changeHandler.BeforeAddAccountToRoleForAccountRole(roleId, accountId, context);
			dal.AddAccountToRoleForAccountRole(roleId, accountId, context);
			changeHandler.AfterAddAccountToRoleForAccountRole(roleId, accountId, context);
		}

		/// <summary>
        /// Removes the role from account for 'AccountRole' relationship.
        /// </summary>
		public void RemoveAccountFromRoleForAccountRole(int roleId, int accountId, IModelContext context = null)
		{
			changeHandler.BeforeRemoveAccountFromRoleForAccountRole(roleId, accountId, context);
			dal.RemoveAccountFromRoleForAccountRole(roleId, accountId, context);	
			changeHandler.AfterRemoveAccountFromRoleForAccountRole(roleId, accountId, context);
		}

		/// <summary>
        /// Get all Role for 'AccountRole' relationship.
        /// </summary>
		public IQueryable<IRoleDataModel> GetAllForAccountRole(int accountId, IModelContext context = null)
		{
			changeHandler.BeforeGetAllForAccountRole(accountId, context);
			var rtn = dal.GetAllForAccountRole(accountId, context);
			changeHandler.AfterGetAllForAccountRole(rtn, accountId, context);
			return rtn;
		}
		#endregion 		
		    }
}