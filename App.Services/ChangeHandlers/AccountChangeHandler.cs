namespace App.Services.ChangeHandlers
{
    using Contracts;
    using Contracts.DataModels;
    using Contracts.ChangeHandlers;
    using System.Linq;

    class AccountChangeHandler : IAccountChangeHandler
    {
        /// <summary>
        /// Called when [create].
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="context">The context.</param>
        public virtual void BeforeCreate(IAccountDataModel item, IModelContext context = null)
        {
        }

        /// <summary>
        /// Called when [create].
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="context">The context.</param>
        public virtual void AfterCreate(IAccountDataModel item, IModelContext content)
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
        public virtual void BeforeUpdate(IAccountDataModel item, IModelContext context)
        {
        }

        /// <summary>
        /// Called when [update].
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="context">The context.</param>
        public virtual void AfterUpdate(IAccountDataModel item, IModelContext context)
        {
        }

        

        	
		#region 'AccountRole'	
		/// <summary>
        /// Adds the role to account for 'AccountRole' relationship.
        /// </summary>
		public virtual void BeforeAddRoleToAccountForAccountRole(int roleId, int accountId, IModelContext context)
		{	
		}
			
		/// <summary>
        /// Adds the role to account for 'AccountRole' relationship.
        /// </summary>
		public virtual void AfterAddRoleToAccountForAccountRole(int roleId, int accountId, IModelContext context)
		{	
		}

		/// <summary>
        /// Removes the role from account for 'AccountRole' relationship.
        /// </summary>
		public virtual void BeforeRemoveRoleFromAccountForAccountRole(int roleId, int accountId, IModelContext context)
		{	
		}

		/// <summary>
        /// Removes the role from account for 'AccountRole' relationship.
        /// </summary>
		public virtual void AfterRemoveRoleFromAccountForAccountRole(int roleId, int accountId, IModelContext context)
		{	
		}

		/// <summary>
        /// Get all Account for 'AccountRole' relationship.
        /// </summary>
		public virtual void BeforeGetAllForAccountRole(int roleId, IModelContext context)
		{	
		}

		/// <summary>
        /// Get all Account for 'AccountRole' relationship.
        /// </summary>
		public virtual void AfterGetAllForAccountRole(IQueryable<IAccountDataModel> results, int roleId, IModelContext context)
		{	
		}
		#endregion 		
		
    }
}