namespace App.Contracts.Dals
{
    using DataModels;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    public interface IAccountDal : IDal<IAccountDataModel>
    {

		
		#region 'AccountRole'		
		// add child to parent ( Role Account )
		/// <summary>
        /// Adds the role to account for 'AccountRole' relationship.
        /// </summary>
		void AddRoleToAccountForAccountRole(int roleId, int accountId, IModelContext context);
		
		/// <summary>
        /// Removes the role from account for 'AccountRole' relationship.
        /// </summary>
		void RemoveRoleFromAccountForAccountRole(int roleId, int accountId, IModelContext context);
		
		/// <summary>
        /// Get all Account for 'AccountRole' relationship.
        /// </summary>
		IQueryable<IAccountDataModel> GetAllForAccountRole(int roleId, IModelContext context);
		#endregion 		
		    }
}