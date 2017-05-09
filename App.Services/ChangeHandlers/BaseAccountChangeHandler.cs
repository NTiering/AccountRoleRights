namespace App.Services.ChangeHandlers
{
    using Contracts.DataModels;
    using Contracts;
    using Contracts.Services;

    abstract class BaseAccountChangeHandler : IEntityChangeHandler<IAccountDataModel>
    {
        /// <summary>
        /// Called when [create].
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="context">The context.</param>
        public void BeforeCreate(IAccountDataModel item, IModelContext context = null)
        {
            BeforeAccountCreate(item, context);
        }

        /// <summary>
        /// When overriden, called when a customer is created
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="context">The context.</param>
        protected virtual void BeforeAccountCreate(IAccountDataModel item, IModelContext context)
        {
            
        }

        /// <summary>
        /// Called when [create].
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="context">The context.</param>
        public void AfterCreate(IAccountDataModel item, IModelContext context = null)
        {
            AfterAccountCreate(item, context);
        }

        /// <summary>
        /// When overriden, called when a customer is created
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="context">The context.</param>
        protected virtual void AfterAccountCreate(IAccountDataModel item, IModelContext context)
        {
            
        }

        /// <summary>
        /// When overriden, called before a customer is deleted
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="context">The context.</param>        
        public void BeforeDelete(IAccountDataModel item, IModelContext context = null)
        {
            BeforeAccountDelete(item, context);
        }
        
        /// <summary>
        /// When overriden, called when a customer is deleted
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="context">The context.</param>
        protected virtual void BeforeAccountDelete(IAccountDataModel item, IModelContext context)
        {
            
        }
                
        /// <summary>
        /// When overriden, called before a customer is deleted
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="context">The context.</param>        
        public void AfterDelete(int id, IModelContext context = null)
        {
            AfterAccountDelete(id, context);
        }
        
        /// <summary>
        /// When overriden, called when a customer is deleted
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="context">The context.</param>
        protected virtual void AfterAccountDelete(int id, IModelContext context)
        {
            
        }

        /// <summary>
        /// Called when [update].
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="context">The context.</param>
        public void BeforeUpdate(IAccountDataModel item, IModelContext context = null)
        {
            BeforeAccountUpdate(item, context);
        }

        /// <summary>
        /// Called when [customer update].
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="context">The context.</param>
        protected virtual void BeforeAccountUpdate(IAccountDataModel item, IModelContext context)
        {

        }

        /// <summary>
        /// Called when [update].
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="context">The context.</param>
        public void AfterUpdate(IAccountDataModel item, IModelContext context = null)
        {
            AfterAccountUpdate(item, context);
        }

        /// <summary>
        /// Called when [customer update].
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="context">The context.</param>
        protected virtual void AfterAccountUpdate(IAccountDataModel item, IModelContext context)
        {

        }
    }
}