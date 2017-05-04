namespace  App.Contracts.Services
{
	using Contracts;
	using DataModels;
	using System;
	using System.Collections.Generic;
	using System.Linq;

    /// <summary>
    /// Service to provvide atomic opertaion for a Role data object
    /// </summary>
    public interface IRoleService : IService<IRoleDataModel>
    {	



		/// <summary>
        /// Supports the many to many relationship (AccountRole) between 
        /// Role (child) Account (parent)
        /// </summary>
        /// <param name="accountId"></param>
        /// <param name="context"></param>
        /// <returns></returns>
		IQueryable<IRoleDataModel> GetAccountRole(int accountId, List<IModelError> errors, IModelContext context = null);
		
		/// <summary>
        /// Supports the many to many relationship (AccountRole) between 
        /// Role (child) Account (parent)
        /// </summary>
        /// <param name="roleId"></param>
        /// <param name="accountId"></param>
        /// <param name="context"></param>
        /// <returns></returns>
		bool TryAddAccountRole(int roleId, int accountId, List<IModelError> errors, IModelContext context = null);

		/// <summary>
        /// Supports the many to many relationship (AccountRole) between 
        /// Role (child) Account (parent)
        /// </summary>
        /// <param name="roleId"></param>
        /// <param name="accountId"></param>
        /// <param name="context"></param>
        /// <returns></returns>
		bool TryRemoveAccountRole(int roleId, int accountId, List<IModelError> errors, IModelContext context = null);
		/// <summary>
        /// Supports the many to many relationship (RoleRight) between 
        /// Role (child) Right (parent)
        /// </summary>
        /// <param name="rightId"></param>
        /// <param name="context"></param>
        /// <returns></returns>
		IQueryable<IRoleDataModel> GetRoleRight(int rightId, List<IModelError> errors, IModelContext context = null);
		
		/// <summary>
        /// Supports the many to many relationship (RoleRight) between 
        /// Role (child) Right (parent)
        /// </summary>
        /// <param name="roleId"></param>
        /// <param name="rightId"></param>
        /// <param name="context"></param>
        /// <returns></returns>
		bool TryAddRoleRight(int roleId, int rightId, List<IModelError> errors, IModelContext context = null);

		/// <summary>
        /// Supports the many to many relationship (RoleRight) between 
        /// Role (child) Right (parent)
        /// </summary>
        /// <param name="roleId"></param>
        /// <param name="rightId"></param>
        /// <param name="context"></param>
        /// <returns></returns>
		bool TryRemoveRoleRight(int roleId, int rightId, List<IModelError> errors, IModelContext context = null);		

    }
}