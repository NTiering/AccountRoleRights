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
    /// Service to provide atomic opertaion for a Right data object
    /// </summary>
    class RightService : IRightService
    {    
		private readonly ILogProvider log ; 
		
		private const string LogName = "Right";
		       
		private readonly IRightDal dal ;

        private readonly IRightChangeHandler changeHandler ;

        private readonly IRightValidator validator ;
		
        public RightService(ILogProvider log, IRightDal dal, IRightValidator validator, IRightChangeHandler changeHandler )
        {
			this.log = log; 
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
				log.Exception(LogName, ex);	
                throw new InvalidOperationException("Unable to delete IRightDataModel", ex);
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
        public bool TrySave(IRightDataModel item, List<IModelError> errors, IModelContext context = null)
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
        public IRightDataModel Get(Func<IRightDataModel, bool> filter, IModelContext context = null)
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
        public IRightDataModel Get(int id, List<IModelError> errors, IModelContext context = null)
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
        public IRightDataModel Get(Func<IRightDataModel, bool> filter, List<IModelError> errors, IModelContext context = null)
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
        public IQueryable<IRightDataModel> GetAll(Func<IRightDataModel, bool> filter, List<IModelError> errors, IModelContext context = null, Func<IRightDataModel, int> order = null, int skip = 0, int take = 999)
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
        public bool TryValidate(IRightDataModel item, string propertyName, List<IModelError> errors, IModelContext context = null)
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
        private bool TryUpdate(IRightDataModel item, List<IModelError> errors, IModelContext context = null)
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
				log.Exception(LogName, ex);	
                throw new InvalidOperationException("Unable to update IRightDataModel", ex);
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
        /// <exception cref="InvalidOperationException">Unable to update IRightDataModel"</exception>
        private bool TryCreate(IRightDataModel item, List<IModelError> errors, IModelContext context = null)
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
                log.Exception(LogName, ex);	
                throw new InvalidOperationException("Unable to create IRightDataModel", ex);
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
        private bool TryValidateModel(IRightDataModel item, Operation operation, List<IModelError> errors, IModelContext context = null)
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

			
		#region 'RoleRight' (One to many - Right (o))       
		/// <summary>
        /// Gets the single Right by Role id for RoleRight relationship.
        /// </summary>
        public IRightDataModel GetSingleRightByRoleForRoleRight(int roleId, IModelContext context = null)
		{
			changeHandler.BeforeGetSingleRightByRoleForRoleRight(roleId, context);
			var rtn = dal.GetSingleRightByRoleForRoleRight(roleId, context);
			changeHandler.AfterGetSingleRightByRoleForRoleRight(rtn, roleId, context);
			return rtn ;
		} 

		/// <summary>
        /// Connects a Right to a Role for RoleRight relationship.
        /// </summary>
        public void AddRightToRoleForRoleRight(int rightId, int roleId, IModelContext context = null)
		{
			changeHandler.BeforeAddRightToRoleForRoleRight(rightId, roleId, context);
			dal.AddRightToRoleForRoleRight(rightId, roleId, context);
			changeHandler.AfterAddRightToRoleForRoleRight(rightId, roleId, context);
			
		}   

		/// <summary>
        /// Unconnect a Right to a Role for RoleRight relationship.
        /// </summary>
		public void RemoveRightFromRoleForRoleRight(int roleId, IModelContext context = null)
		{
			changeHandler.BeforeRemoveRightFromRoleForRoleRight(roleId, context);
			dal.RemoveRightFromRoleForRoleRight(roleId, context);
			changeHandler.AfterRemoveRightFromRoleForRoleRight(roleId, context); 
		}  

		#endregion 
		            }
}