namespace App.Contracts.Dals
{
    using DataModels;
    using System;
    using System.Collections.Generic;
	using System.Linq;
	
    public interface IRightDal : IDal<IRightDataModel>
    {

		/// <summary>
        /// Supports the many to many relationship (RoleRight) between 
        /// Right (parent) Role (child)
        /// </summary>
        /// <param name="rightId"></param>
        /// <param name="roleId"></param>
        /// <param name="context"></param>
        /// <returns></returns>
		IQueryable<IRightDataModel> GetRoleRight(int roleId, IModelContext context = null);

		/// <summary>
        /// Supports the many to many relationship (RoleRight) between 
        /// Right (parent) Role (child)
        /// </summary>
        /// <param name="rightId"></param>
        /// <param name="roleId"></param>
        /// <param name="context"></param>
        /// <returns></returns>
		void AddRoleRight(int rightId, int roleId, IModelContext context = null);

		/// <summary>
        /// Supports the many to many relationship (RoleRight) between 
        /// Right (parent) Role (child)
        /// </summary>
        /// <param name="rightId"></param>
        /// <param name="roleId"></param>
        /// <param name="context"></param>
        /// <returns></returns>
		void RemoveRoleRight(int rightId, int roleId, IModelContext context = null);
			

    }
}