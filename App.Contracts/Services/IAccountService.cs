namespace  App.Contracts.Services
{
    using Contracts;
    using System;
    using System.Collections.Generic;
    using DataModels;
    using System.Linq;

    /// <summary>
    /// Service to provvide atomic operation for a Account data object
    /// </summary>
    public interface IAccountService 
    {   
		/// <summary>
        /// Deletes the specified item that contains the id.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="errors"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        bool TryDelete(int id, List<IModelError> errors, IModelContext context = null);

		/// <summary>
        /// Tries to save the item.
        /// </summary>
        /// <param name="item"></param>
        /// <param name="errors"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        bool TrySave(IAccountDataModel item, List<IModelError> errors, IModelContext context = null);

		/// <summary>
        /// Gets the first item that fufills the filter.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <returns></returns>
        IAccountDataModel Get(Func<IAccountDataModel, bool> filter, IModelContext context = null);

        /// <summary>
        /// Gets the specified item by id.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="errors"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        IAccountDataModel Get(int id, List<IModelError> errors, IModelContext context = null);

        /// <summary>
        /// Gets the first item that fufills the filter.
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="errors"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        IAccountDataModel Get(Func<IAccountDataModel, bool> filter, List<IModelError> errors, IModelContext context = null);

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
        IQueryable<IAccountDataModel> GetAll(Func<IAccountDataModel, bool> filter, List<IModelError> errors, IModelContext context = null, Func<IAccountDataModel, int> order = null, int skip = 0, int take = 999);

		/// <summary>
        /// Checks the validation of a single property
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="errors">The errors.</param>
        /// <param name="context">The context.</param>
        /// <returns></returns>
        bool TryValidate(IAccountDataModel item, string propertyName, List<IModelError> errors, IModelContext context = null);
    

        /// <summary>
        /// Returns true if the model exists and the values supplied matches a hashed version of Password
        /// </summary>
        bool MatchesPassword(int id, string password, List<IModelError> errors, IModelContext context = null);
        		
	
		#region 'AccountRole'		
		/// <summary>
        /// Adds the role to account for 'AccountRole' relationship.
        /// </summary>
		void AddRoleToAccountForAccountRole(int roleId, int accountId, IModelContext context = null);

		/// <summary>
        /// Removes the role from account for 'AccountRole' relationship.
        /// </summary>
		void RemoveRoleFromAccountForAccountRole(int roleId, int accountId, IModelContext context = null);

		/// <summary>
        /// Get all Account for 'AccountRole' relationship.
        /// </summary>
		IQueryable<IAccountDataModel> GetAllForAccountRole(int roleId, IModelContext context = null);
		#endregion 		
		    }
}