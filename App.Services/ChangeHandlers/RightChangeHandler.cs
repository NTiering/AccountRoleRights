namespace App.Services.ChangeHandlers
{
    using Contracts;
    using Contracts.DataModels;
    using Contracts.ChangeHandlers;
    using System.Linq;

    class RightChangeHandler : IRightChangeHandler
    {
        /// <summary>
        /// Called when [create].
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="context">The context.</param>
        public virtual void BeforeCreate(IRightDataModel item, IModelContext context = null)
        {
        }

        /// <summary>
        /// Called when [create].
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="context">The context.</param>
        public virtual void AfterCreate(IRightDataModel item, IModelContext content)
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
        public virtual void BeforeUpdate(IRightDataModel item, IModelContext context)
        {
        }

        /// <summary>
        /// Called when [update].
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="context">The context.</param>
        public virtual void AfterUpdate(IRightDataModel item, IModelContext context)
        {
        }

        

	
		#region 'RoleRight'        
		/// <summary>
        /// Gets the single Right by Role id for RoleRight relationship.
        /// </summary>
        public virtual void AfterGetSingleRightByRoleForRoleRight(IRightDataModel result, int roleId, IModelContext context)
		{
		} 

		/// <summary>
        /// Gets the single Right by Role id for RoleRight relationship.
        /// </summary>
        public virtual void BeforeGetSingleRightByRoleForRoleRight(int roleId, IModelContext context)
		{
		} 


		/// <summary>
        /// Connects a Right to a Role for RoleRight relationship.
        /// </summary>
        public virtual void BeforeAddRightToRoleForRoleRight(int rightId, int roleId, IModelContext context)
		{
		}
		
		/// <summary>
        /// Connects a Right to a Role for RoleRight relationship.
        /// </summary>
        public virtual void AfterAddRightToRoleForRoleRight(int rightId, int roleId, IModelContext context)
		{
		}   

		/// <summary>
        /// Unconnect a Right to a Role for RoleRight relationship.
        /// </summary>
		public virtual void BeforeRemoveRightFromRoleForRoleRight(int roleId, IModelContext context)
		{
		}
		
		/// <summary>
        /// Unconnect a Right to a Role for RoleRight relationship.
        /// </summary>
		public virtual void AfterRemoveRightFromRoleForRoleRight(int roleId, IModelContext context)
		{
		}  

		#endregion 
		        
    }
}