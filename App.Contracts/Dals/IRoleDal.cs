namespace App.Contracts.Dals
{
    using DataModels;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    public interface IRoleDal : IDal<IRoleDataModel>
    {
		
		#region 'RoleRight'
		/// <summary>
        /// Returns all Role connected to a single Right For the 'RoleRight' relationship
        /// </summary>        
		IQueryable<IRoleDataModel> GetAllRoleByRightForRoleRight(int rightId, IModelContext context);
		
		/// <summary>
        /// Connects a Role to a Right for RoleRight relationship.
        /// </summary>
        void AddRoleToRightForRoleRight(int roleId, int rightId, IModelContext context);
		
		/// <summary>
        /// Unconnects a Role to a Right for RoleRight relationship.
        /// </summary>
        void RemoveRoleFromRightForRoleRight(int roleId, IModelContext context);
		#endregion 
		
		
		#region 'AccountRole'	
		/// <summary>
        /// Adds the role to account for 'AccountRole' relationship.
        /// </summary>
		void AddAccountToRoleForAccountRole(int roleId, int accountId, IModelContext context);
		
		/// <summary>
        /// Removes the role from account for 'AccountRole' relationship.
        /// </summary>
		void RemoveAccountFromRoleForAccountRole(int roleId, int accountId, IModelContext context);
		
		/// <summary>
        /// Get all Role for 'AccountRole' relationship.
        /// </summary>
		IQueryable<IRoleDataModel> GetAllForAccountRole(int accountId, IModelContext context);
		#endregion 		
		    }
}