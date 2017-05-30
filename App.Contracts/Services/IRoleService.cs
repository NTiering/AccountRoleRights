namespace  App.Contracts.Services
{
    using Contracts;
    using System;
    using System.Collections.Generic;
    using DataModels;
    using System.Linq;

    /// <summary>
    /// Service to provvide atomic operation for a Role data object
    /// </summary>
    public interface IRoleService 
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
        bool TrySave(IRoleDataModel item, List<IModelError> errors, IModelContext context = null);

		/// <summary>
        /// Gets the first item that fufills the filter.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <returns></returns>
        IRoleDataModel Get(Func<IRoleDataModel, bool> filter, IModelContext context = null);

        /// <summary>
        /// Gets the specified item by id.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="errors"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        IRoleDataModel Get(int id, List<IModelError> errors, IModelContext context = null);

        /// <summary>
        /// Gets the first item that fufills the filter.
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="errors"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        IRoleDataModel Get(Func<IRoleDataModel, bool> filter, List<IModelError> errors, IModelContext context = null);

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
        IQueryable<IRoleDataModel> GetAll(Func<IRoleDataModel, bool> filter, List<IModelError> errors, IModelContext context = null, Func<IRoleDataModel, int> order = null, int skip = 0, int take = 999);

		/// <summary>
        /// Checks the validation of a single property
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="errors">The errors.</param>
        /// <param name="context">The context.</param>
        /// <returns></returns>
        bool TryValidate(IRoleDataModel item, string propertyName, List<IModelError> errors, IModelContext context = null);
    
				
		#region 'RoleRight'
		/// <summary>
        /// Returns all Role connected to a single Right For the 'RoleRight' relationship
        /// </summary>        
		IQueryable<IRoleDataModel> GetAllRoleByRightForRoleRight(int rightId, IModelContext context = null);

		/// <summary>
        /// Connects a Role to a Right for RoleRight relationship.
        /// </summary>
        void AddRoleToRightForRoleRight(int roleId, int rightId, IModelContext context = null);

		/// <summary>
        /// Unconnects a Role to a Right for RoleRight relationship.
        /// </summary>
        void RemoveRoleFromRightForRoleRight(int roleId, IModelContext context = null);
		#endregion 
		
		
		#region 'AccountRole'	
		/// <summary>
        /// Adds the role to account for 'AccountRole' relationship.
        /// </summary>
		void AddAccountToRoleForAccountRole(int roleId, int accountId, IModelContext context = null);

		/// <summary>
        /// Removes the role from account for 'AccountRole' relationship.
        /// </summary>
		void RemoveAccountFromRoleForAccountRole(int roleId, int accountId, IModelContext context = null);

		/// <summary>
        /// Get all Role for 'AccountRole' relationship.
        /// </summary>
		IQueryable<IRoleDataModel> GetAllForAccountRole(int accountId, IModelContext context = null);
		#endregion 		
		    }
}