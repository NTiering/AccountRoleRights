namespace App.Services.ChangeHandlers
{
    using Contracts.DataModels;
    using Contracts;
    using Contracts.Services;

    abstract class BaseRightChangeHandler : IEntityChangeHandler<IRightDataModel>
    {
        /// <summary>
        /// Called when [create].
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="context">The context.</param>
        public void BeforeCreate(IRightDataModel item, IModelContext context = null)
        {
            BeforeRightCreate(item, context);
        }

        /// <summary>
        /// When overriden, called when a customer is created
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="context">The context.</param>
        protected virtual void BeforeRightCreate(IRightDataModel item, IModelContext context)
        {
            
        }

        /// <summary>
        /// Called when [create].
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="context">The context.</param>
        public void AfterCreate(IRightDataModel item, IModelContext context = null)
        {
            AfterRightCreate(item, context);
        }

        /// <summary>
        /// When overriden, called when a customer is created
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="context">The context.</param>
        protected virtual void AfterRightCreate(IRightDataModel item, IModelContext context)
        {
            
        }

        /// <summary>
        /// When overriden, called before a customer is deleted
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="context">The context.</param>        
        public void BeforeDelete(IRightDataModel item, IModelContext context = null)
        {
            BeforeRightDelete(item, context);
        }
        
        /// <summary>
        /// When overriden, called when a customer is deleted
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="context">The context.</param>
        protected virtual void BeforeRightDelete(IRightDataModel item, IModelContext context)
        {
            
        }
                
        /// <summary>
        /// When overriden, called before a customer is deleted
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="context">The context.</param>        
        public void AfterDelete(int id, IModelContext context = null)
        {
            AfterRightDelete(id, context);
        }
        
        /// <summary>
        /// When overriden, called when a customer is deleted
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="context">The context.</param>
        protected virtual void AfterRightDelete(int id, IModelContext context)
        {
            
        }

        /// <summary>
        /// Called when [update].
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="context">The context.</param>
        public void BeforeUpdate(IRightDataModel item, IModelContext context = null)
        {
            BeforeRightUpdate(item, context);
        }

        /// <summary>
        /// Called when [customer update].
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="context">The context.</param>
        protected virtual void BeforeRightUpdate(IRightDataModel item, IModelContext context)
        {

        }

        /// <summary>
        /// Called when [update].
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="context">The context.</param>
        public void AfterUpdate(IRightDataModel item, IModelContext context = null)
        {
            AfterRightUpdate(item, context);
        }

        /// <summary>
        /// Called when [customer update].
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="context">The context.</param>
        protected virtual void AfterRightUpdate(IRightDataModel item, IModelContext context)
        {

        }
    }
}