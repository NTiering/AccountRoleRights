namespace App.Contracts.Services
{
    using Contracts;
    using Models;

    /// <summary>
    /// Called when an entity is changed
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IEntityChangeHandler<T>
        where T : IDataModel
    {
        /// <summary>
        /// Called when [update].
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="context">The context.</param>
        void BeforeUpdate(T item, IModelContext context = null);

        /// <summary>
        /// Called when [update].
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="context">The context.</param>
        void AfterUpdate(T item, IModelContext context = null);

        /// <summary>
        /// Called when [delete].
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="context">The context.</param>
        void BeforeDelete(T item, IModelContext context = null);

        /// <summary>
        /// Called when [delete].
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="context">The context.</param>
        void AfterDelete(int id, IModelContext context = null);

        /// <summary>
        /// Called when [create].
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="context">The context.</param>
        void BeforeCreate(T item, IModelContext context = null);

        /// <summary>
        /// Called when [create].
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="context">The context.</param>
        void AfterCreate(T item, IModelContext context = null);

    }
}
