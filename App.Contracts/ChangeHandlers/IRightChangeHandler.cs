namespace  App.Contracts.ChangeHandlers
{
    using DataModels;
    using Contracts;
	using System.Linq;

    public interface IRightChangeHandler
    {
        /// <summary>
        /// Called when [create].
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="context">The context.</param>
        void BeforeCreate(IRightDataModel item, IModelContext context);

        /// <summary>
        /// Called when [create].
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="context">The context.</param>
        void AfterCreate(IRightDataModel item, IModelContext content);
       
        /// <summary>
        /// Called after a Right is deleted
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="context">The context.</param>
        void BeforeDelete(int id, IModelContext context);
                
        /// <summary>
        /// Called before a Right is deleted
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="context">The context.</param>        
        void AfterDelete(int id, IModelContext context);

        /// <summary>
        /// Called before a Right is updated
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="context">The context.</param>
        void BeforeUpdate(IRightDataModel item, IModelContext context);

        /// <summary>
        /// Called after a Right is updated
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="context">The context.</param>
        void AfterUpdate(IRightDataModel item, IModelContext context);        

	
		#region 'RoleRight'        
		/// <summary>
        /// Gets the single Right by Role id for RoleRight relationship.
        /// </summary>
        void AfterGetSingleRightByRoleForRoleRight(IRightDataModel result, int roleId, IModelContext context);

		/// <summary>
        /// Gets the single Right by Role id for RoleRight relationship.
        /// </summary>
        void BeforeGetSingleRightByRoleForRoleRight(int roleId, IModelContext context);

		/// <summary>
        /// Connects a Right to a Role for RoleRight relationship.
        /// </summary>
        void BeforeAddRightToRoleForRoleRight(int rightId, int roleId, IModelContext context);
		
		/// <summary>
        /// Connects a Right to a Role for RoleRight relationship.
        /// </summary>
        void AfterAddRightToRoleForRoleRight(int rightId, int roleId, IModelContext context);

		/// <summary>
        /// Unconnect a Right to a Role for RoleRight relationship.
        /// </summary>
		void BeforeRemoveRightFromRoleForRoleRight(int roleId, IModelContext context);

		/// <summary>
        /// Unconnect a Right to a Role for RoleRight relationship.
        /// </summary>
		void AfterRemoveRightFromRoleForRoleRight(int roleId, IModelContext context);
		#endregion 
		            }
}