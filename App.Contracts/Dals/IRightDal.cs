namespace App.Contracts.Dals
{
    using DataModels;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    public interface IRightDal : IDal<IRightDataModel>
    {
		
		#region 'RoleRight'        
		/// <summary>
        /// Gets the single Right by Role id for RoleRight relationship.
        /// </summary>
        IRightDataModel GetSingleRightByRoleForRoleRight(int roleId, IModelContext context);
		
		/// <summary>
        /// Connects a Right to a Role for RoleRight relationship.
        /// </summary>
        void AddRightToRoleForRoleRight(int rightId, int roleId, IModelContext context);
		
		/// <summary>
        /// Unconnect a Right to a Role for RoleRight relationship.
        /// </summary>
		void RemoveRightFromRoleForRoleRight(int roleId, IModelContext context);
		
		#endregion 
		
    }
}