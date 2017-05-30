namespace  App.Contracts.ChangeHandlers
{
    using DataModels;
    using Contracts;
	using System.Linq;

    public interface IRoleChangeHandler
    {
        /// <summary>
        /// Called when [create].
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="context">The context.</param>
        void BeforeCreate(IRoleDataModel item, IModelContext context);

        /// <summary>
        /// Called when [create].
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="context">The context.</param>
        void AfterCreate(IRoleDataModel item, IModelContext content);
       
        /// <summary>
        /// Called after a Role is deleted
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="context">The context.</param>
        void BeforeDelete(int id, IModelContext context);
                
        /// <summary>
        /// Called before a Role is deleted
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="context">The context.</param>        
        void AfterDelete(int id, IModelContext context);

        /// <summary>
        /// Called before a Role is updated
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="context">The context.</param>
        void BeforeUpdate(IRoleDataModel item, IModelContext context);

        /// <summary>
        /// Called after a Role is updated
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="context">The context.</param>
        void AfterUpdate(IRoleDataModel item, IModelContext context);        

		
		#region 'RoleRight'
		/// <summary>
        /// Returns all Role connected to a single Right For the 'RoleRight' relationship
        /// </summary>        
		void BeforeGetAllRoleByRightForRoleRight(int rightId, IModelContext context);

		/// <summary>
        /// Returns all Role connected to a single Right For the 'RoleRight' relationship
        /// </summary>        
		void AfterGetAllRoleByRightForRoleRight(IQueryable<IRoleDataModel> results, int rightId, IModelContext context);

		/// <summary>
        /// Connects a Role to a Right for RoleRight relationship.
        /// </summary>
        void BeforeAddRoleToRightForRoleRight(int roleId, int rightId, IModelContext context);

		/// <summary>
        /// Connects a Role to a Right for RoleRight relationship.
        /// </summary>
        void AfterAddRoleToRightForRoleRight(int roleId, int rightId, IModelContext context);

		/// <summary>
        /// Unconnects a Role to a Right for RoleRight relationship.
        /// </summary>
        void BeforeRemoveRoleFromRightForRoleRight(int roleId, IModelContext context);

		/// <summary>
        /// Unconnects a Role to a Right for RoleRight relationship.
        /// </summary>
        void AfterRemoveRoleFromRightForRoleRight(int roleId, IModelContext context);
		#endregion 
		        		
		#region 'AccountRole'	
		/// <summary>
        /// Adds the role to account for 'AccountRole' relationship.
        /// </summary>
		void BeforeAddAccountToRoleForAccountRole(int roleId, int accountId, IModelContext context);

		/// <summary>
        /// Adds the role to account for 'AccountRole' relationship.
        /// </summary>
		void AfterAddAccountToRoleForAccountRole(int roleId, int accountId, IModelContext context);

		/// <summary>
        /// Removes the role from account for 'AccountRole' relationship.
        /// </summary>
		void BeforeRemoveAccountFromRoleForAccountRole(int roleId, int accountId, IModelContext context);

		/// <summary>
        /// Removes the role from account for 'AccountRole' relationship.
        /// </summary>
		void AfterRemoveAccountFromRoleForAccountRole(int roleId, int accountId, IModelContext context); 

		/// <summary>
        /// Get all Role for 'AccountRole' relationship.
        /// </summary>
		void BeforeGetAllForAccountRole(int accountId, IModelContext context);
		
		/// <summary>
        /// Get all Role for 'AccountRole' relationship.
        /// </summary>
		void AfterGetAllForAccountRole(IQueryable<IRoleDataModel> results, int accountId, IModelContext context);
		#endregion 	
    }
}