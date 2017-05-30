namespace  App.Contracts.ChangeHandlers
{
    using DataModels;
    using Contracts;
	using System.Linq;

    public interface IAccountChangeHandler
    {
        /// <summary>
        /// Called when [create].
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="context">The context.</param>
        void BeforeCreate(IAccountDataModel item, IModelContext context);

        /// <summary>
        /// Called when [create].
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="context">The context.</param>
        void AfterCreate(IAccountDataModel item, IModelContext content);
       
        /// <summary>
        /// Called after a Account is deleted
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="context">The context.</param>
        void BeforeDelete(int id, IModelContext context);
                
        /// <summary>
        /// Called before a Account is deleted
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="context">The context.</param>        
        void AfterDelete(int id, IModelContext context);

        /// <summary>
        /// Called before a Account is updated
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="context">The context.</param>
        void BeforeUpdate(IAccountDataModel item, IModelContext context);

        /// <summary>
        /// Called after a Account is updated
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="context">The context.</param>
        void AfterUpdate(IAccountDataModel item, IModelContext context);        

        	
		#region 'AccountRole'	
		/// <summary>
        /// Adds the role to account for 'AccountRole' relationship.
        /// </summary>
		void BeforeAddRoleToAccountForAccountRole(int roleId, int accountId, IModelContext context);
			
		/// <summary>
        /// Adds the role to account for 'AccountRole' relationship.
        /// </summary>
		void AfterAddRoleToAccountForAccountRole(int roleId, int accountId, IModelContext context);

		/// <summary>
        /// Removes the role from account for 'AccountRole' relationship.
        /// </summary>
		void BeforeRemoveRoleFromAccountForAccountRole(int roleId, int accountId, IModelContext context);

		/// <summary>
        /// Removes the role from account for 'AccountRole' relationship.
        /// </summary>
		void AfterRemoveRoleFromAccountForAccountRole(int roleId, int accountId, IModelContext context);

		/// <summary>
        /// Get all Account for 'AccountRole' relationship.
        /// </summary>
		void BeforeGetAllForAccountRole(int roleId, IModelContext context);

		/// <summary>
        /// Get all Account for 'AccountRole' relationship.
        /// </summary>
		void AfterGetAllForAccountRole(IQueryable<IAccountDataModel> results, int roleId, IModelContext context);
		#endregion 		
		    }
}