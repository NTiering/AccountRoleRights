namespace App.Services.ChangeHandlers
{
    using Contracts.DataModels;
    using Contracts;
    using Contracts.Services;

    abstract class BaseRoleChangeHandler : IEntityChangeHandler<IRoleDataModel>
    {
        /// <summary>
        /// Called when [create].
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="context">The context.</param>
        public void BeforeCreate(IRoleDataModel item, IModelContext context = null)
        {
            BeforeRoleCreate(item, context);
        }

        /// <summary>
        /// When overriden, called when a customer is created
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="context">The context.</param>
        protected virtual void BeforeRoleCreate(IRoleDataModel item, IModelContext context)
        {
            
        }

		/// <summary>
        /// Called when [create].
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="context">The context.</param>
        public void AfterCreate(IRoleDataModel item, IModelContext context = null)
        {
            AfterRoleCreate(item, context);
        }

        /// <summary>
        /// When overriden, called when a customer is created
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="context">The context.</param>
        protected virtual void AfterRoleCreate(IRoleDataModel item, IModelContext context)
        {
            
        }

		/// <summary>
        /// When overriden, called before a customer is deleted
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="context">The context.</param>        
        public void BeforeDelete(IRoleDataModel item, IModelContext context = null)
        {
            BeforeRoleDelete(item, context);
        }
		
        /// <summary>
        /// When overriden, called when a customer is deleted
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="context">The context.</param>
        protected virtual void BeforeRoleDelete(IRoleDataModel item, IModelContext context)
        {
            
        }
				
		/// <summary>
        /// When overriden, called before a customer is deleted
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="context">The context.</param>        
        public void AfterDelete(int id, IModelContext context = null)
        {
            AfterRoleDelete(id, context);
        }
		
        /// <summary>
        /// When overriden, called when a customer is deleted
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="context">The context.</param>
        protected virtual void AfterRoleDelete(int id, IModelContext context)
        {
            
        }

        /// <summary>
        /// Called when [update].
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="context">The context.</param>
        public void BeforeUpdate(IRoleDataModel item, IModelContext context = null)
        {
            BeforeRoleUpdate(item, context);
        }

        /// <summary>
        /// Called when [customer update].
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="context">The context.</param>
        protected virtual void BeforeRoleUpdate(IRoleDataModel item, IModelContext context)
        {

        }

		/// <summary>
        /// Called when [update].
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="context">The context.</param>
        public void AfterUpdate(IRoleDataModel item, IModelContext context = null)
        {
            AfterRoleUpdate(item, context);
        }

        /// <summary>
        /// Called when [customer update].
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="context">The context.</param>
        protected virtual void AfterRoleUpdate(IRoleDataModel item, IModelContext context)
        {

        }
    }
}