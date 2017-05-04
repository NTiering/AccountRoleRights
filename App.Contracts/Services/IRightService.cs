namespace  App.Contracts.Services
{
	using Contracts;
	using DataModels;
	using System;
	using System.Collections.Generic;
	using System.Linq;

    /// <summary>
    /// Service to provvide atomic opertaion for a Right data object
    /// </summary>
    public interface IRightService : IService<IRightDataModel>
    {	

		/// <summary>
        /// Supports the many to many relationship (RoleRight) between 
        /// Right (parent) Role (child)
        /// </summary>
        /// <param name="roleId"></param>
        /// <param name="context"></param>
        /// <returns></returns>
		IQueryable<IRightDataModel> GetRoleRight(int roleId, List<IModelError> errors, IModelContext context = null);

		/// <summary>
        /// Supports the many to many relationship (RoleRight) between 
        /// Right (parent) Role (child)
        /// </summary>
        /// <param name="rightId"></param>
        /// <param name="roleId"></param>
        /// <param name="context"></param>
        /// <returns></returns>
		bool TryAddRoleRight(int rightId, int roleId,  List<IModelError> errors, IModelContext context = null);

		/// <summary>
        /// Supports the many to many relationship (RoleRight) between 
        /// Right (parent) Role (child)
        /// </summary>
        /// <param name="rightId"></param>
        /// <param name="roleId"></param>
        /// <param name="context"></param>
        /// <returns></returns>
		bool TryRemoveRoleRight(int rightId, int roleId,  List<IModelError> errors, IModelContext context = null);
		
		

		

    }
}