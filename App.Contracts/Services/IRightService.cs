namespace  App.Contracts.Services
{
    using Contracts;
    using System;
    using System.Collections.Generic;
    using DataModels;
    using System.Linq;

    /// <summary>
    /// Service to provvide atomic operation for a Right data object
    /// </summary>
    public interface IRightService 
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
        bool TrySave(IRightDataModel item, List<IModelError> errors, IModelContext context = null);

		/// <summary>
        /// Gets the first item that fufills the filter.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <returns></returns>
        IRightDataModel Get(Func<IRightDataModel, bool> filter, IModelContext context = null);

        /// <summary>
        /// Gets the specified item by id.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="errors"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        IRightDataModel Get(int id, List<IModelError> errors, IModelContext context = null);

        /// <summary>
        /// Gets the first item that fufills the filter.
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="errors"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        IRightDataModel Get(Func<IRightDataModel, bool> filter, List<IModelError> errors, IModelContext context = null);

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
        IQueryable<IRightDataModel> GetAll(Func<IRightDataModel, bool> filter, List<IModelError> errors, IModelContext context = null, Func<IRightDataModel, int> order = null, int skip = 0, int take = 999);

		/// <summary>
        /// Checks the validation of a single property
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="errors">The errors.</param>
        /// <param name="context">The context.</param>
        /// <returns></returns>
        bool TryValidate(IRightDataModel item, string propertyName, List<IModelError> errors, IModelContext context = null);
    
			
		#region 'RoleRight'        
		/// <summary>
        /// Gets the single Right by Role id for RoleRight relationship.
        /// </summary>
        IRightDataModel GetSingleRightByRoleForRoleRight(int roleId, IModelContext context = null);

		/// <summary>
        /// Connects a Right to a Role for RoleRight relationship.
        /// </summary>
        void AddRightToRoleForRoleRight(int rightId, int roleId, IModelContext context = null);

		/// <summary>
        /// Unconnect a Right to a Role for RoleRight relationship.
        /// </summary>
		void RemoveRightFromRoleForRoleRight(int roleId, IModelContext context = null);

		#endregion 
		
    }
}