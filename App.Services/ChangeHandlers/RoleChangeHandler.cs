namespace App.Services.ChangeHandlers
{
    using Contracts;
    using Contracts.DataModels;
    using Contracts.ChangeHandlers;
    using System.Linq;

    class RoleChangeHandler : IRoleChangeHandler
    {
        /// <summary>
        /// Called when [create].
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="context">The context.</param>
        public virtual void BeforeCreate(IRoleDataModel item, IModelContext context = null)
        {
        }

        /// <summary>
        /// Called when [create].
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="context">The context.</param>
        public virtual void AfterCreate(IRoleDataModel item, IModelContext content)
        {
        }
       
        /// <summary>
        /// When overriden, called when a customer is deleted
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="context">The context.</param>
        public virtual void BeforeDelete(int id, IModelContext context)
        {            
        }
                
        /// <summary>
        /// When overriden, called before a customer is deleted
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="context">The context.</param>        
        public virtual void AfterDelete(int id, IModelContext context)
        {
        }

        /// <summary>
        /// Called when [customer update].
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="context">The context.</param>
        public virtual void BeforeUpdate(IRoleDataModel item, IModelContext context)
        {
        }

        /// <summary>
        /// Called when [update].
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="context">The context.</param>
        public virtual void AfterUpdate(IRoleDataModel item, IModelContext context)
        {
        }

        

		
		#region 'RoleRight'
		/// <summary>
        /// Returns all Role connected to a single Right For the 'RoleRight' relationship
        /// </summary>        
		public virtual void BeforeGetAllRoleByRightForRoleRight(int rightId, IModelContext context)
		{
		} 

		/// <summary>
        /// Returns all Role connected to a single Right For the 'RoleRight' relationship
        /// </summary>        
		public virtual void AfterGetAllRoleByRightForRoleRight(IQueryable<IRoleDataModel> results, int rightId, IModelContext context)
		{
		} 

		/// <summary>
        /// Connects a Role to a Right for RoleRight relationship.
        /// </summary>
        public virtual void BeforeAddRoleToRightForRoleRight(int roleId, int rightId, IModelContext context)
		{
		} 

		/// <summary>
        /// Connects a Role to a Right for RoleRight relationship.
        /// </summary>
        public virtual void AfterAddRoleToRightForRoleRight(int roleId, int rightId, IModelContext context)
		{
		} 

		/// <summary>
        /// Unconnects a Role to a Right for RoleRight relationship.
        /// </summary>
        public virtual void BeforeRemoveRoleFromRightForRoleRight(int roleId, IModelContext context)
		{
		} 

		/// <summary>
        /// Unconnects a Role to a Right for RoleRight relationship.
        /// </summary>
        public virtual void AfterRemoveRoleFromRightForRoleRight(int roleId, IModelContext context)
		{
		} 
		#endregion 
		        		
		#region 'AccountRole'	
		/// <summary>
        /// Adds the role to account for 'AccountRole' relationship.
        /// </summary>
		public virtual void BeforeAddAccountToRoleForAccountRole(int roleId, int accountId, IModelContext context)
		{			
		}

		/// <summary>
        /// Adds the role to account for 'AccountRole' relationship.
        /// </summary>
		public virtual void AfterAddAccountToRoleForAccountRole(int roleId, int accountId, IModelContext context)
		{			
		}

		/// <summary>
        /// Removes the role from account for 'AccountRole' relationship.
        /// </summary>
		public virtual void BeforeRemoveAccountFromRoleForAccountRole(int roleId, int accountId, IModelContext context)
		{			
		}

		/// <summary>
        /// Removes the role from account for 'AccountRole' relationship.
        /// </summary>
		public virtual void AfterRemoveAccountFromRoleForAccountRole(int roleId, int accountId, IModelContext context)
		{			
		}
		
		/// <summary>
        /// Get all Role for 'AccountRole' relationship.
        /// </summary>
		public virtual void BeforeGetAllForAccountRole(int accountId, IModelContext context)
		{			
		}

		/// <summary>
        /// Get all Role for 'AccountRole' relationship.
        /// </summary>
		public virtual void AfterGetAllForAccountRole(IQueryable<IRoleDataModel> results, int accountId, IModelContext context)
		{			
		}
		#endregion 		
		
    }
}