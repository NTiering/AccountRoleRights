namespace App.Services.Interceptors
{
    using Contracts;
    using Contracts.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public abstract class BaseServiceInterceptor<T> : IService<T>
        where T : class, IDataModel
    {
        protected IService<T> service { get; private set; }
        private TaskFactory taskFactory = new TaskFactory();

        protected BaseServiceInterceptor(IService<T> service)
        {
            this.service = service;
        }

        #region Delete

        public bool TryDelete(int id, List<IModelError> errors, IModelContext context = null)
        {
            BeforeDelete(id, errors, context);
            var rtn = service.TryDelete(id, errors, context);
            taskFactory.StartNew(() => AfterDelete(rtn, id, errors, context));
            return rtn;
        }

        virtual public void BeforeDelete(int id, List<IModelError> errors, IModelContext context = null)
        {

        }

        virtual public void AfterDelete(bool result, int id, List<IModelError> errors, IModelContext context = null)
        {

        }

        #endregion

        #region Get by id

        public T Get(int id, List<IModelError> errors, IModelContext context = null)
        {
            BeforeGet(id, errors, context);
            var result = service.Get(id, errors, context);
            taskFactory.StartNew(() => { AfterGet(result, id, errors, context); });
            return result;
        }


        virtual public void BeforeGet(int id, List<IModelError> errors, IModelContext context = null)
        {

        }

        virtual public void AfterGet(T result, int id, List<IModelError> errors, IModelContext context = null)
        {

        }

        #endregion
        #region Get by lambda

        public T Get(Func<T, bool> filter, List<IModelError> errors, IModelContext context = null)
        {
            BeforeGet(filter, errors, context);
            var result = service.Get(filter, errors, context);
            taskFactory.StartNew(() => { AfterGet(result, filter, errors, context); });
            return result;
        }

        virtual public void BeforeGet(Func<T, bool> filter, List<IModelError> errors, IModelContext context = null)
        {

        }

        virtual public void AfterGet(T result, Func<T, bool> filter, List<IModelError> errors, IModelContext context = null)
        {

        }

        #endregion

        #region Get all 

        public IQueryable<T> GetAll(Func<T, bool> filter, List<IModelError> errors, IModelContext context = null, Func<T, int> order = null, int skip = 0, int take = 999)
        {
            BeforeGetAll(filter, errors, context, order, skip, take);
            var result = service.GetAll(filter, errors, context, order, skip, take);
            taskFactory.StartNew(() => { AfterGetAll(result, filter, errors, context, order, skip, take); });
            return result;
        }

        virtual public void BeforeGetAll(Func<T, bool> filter, List<IModelError> errors, IModelContext context = null, Func<T, int> order = null, int skip = 0, int take = 999)
        {
        }

        virtual public void AfterGetAll(IQueryable<T> results, Func<T, bool> filter, List<IModelError> errors, IModelContext context = null, Func<T, int> order = null, int skip = 0, int take = 999)
        {
        }

        #endregion

        #region Validate property

        /// <summary>
        /// Tries validation on a single property.
        /// </summary>
        /// <param name="item"></param>
        /// <param name="propertyName"></param>
        /// <param name="errors"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public bool TryValidate(T item, string propertyName, List<IModelError> errors, IModelContext context = null)
        {
            BeforeTryValidate(item, propertyName, errors, context);
            var rtn = service.TrySave(item, errors, context);
            AfterTryValidate(rtn, item, propertyName, errors, context);
            return rtn;

        }

        /// <summary>
        /// Befores the try validate.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="errors">The errors.</param>
        /// <param name="context">The context.</param>
        virtual protected void BeforeTryValidate(T item, string propertyName, List<IModelError> errors, IModelContext context = null)
        {

        }

        /// <summary>
        /// Afters the try validate.
        /// </summary>
        /// <param name="result">if set to <c>true</c> [result].</param>
        /// <param name="item">The item.</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="errors">The errors.</param>
        /// <param name="context">The context.</param>
        virtual protected void AfterTryValidate(bool result, T item, string propertyName, List<IModelError> errors, IModelContext context = null)
        {

        }
        #endregion

        #region Save model
        /// <summary>
        /// Tries to save the itme.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="errors">The errors.</param>
        /// <param name="context"></param>
        /// <returns></returns>
        public virtual bool TrySave(T item, List<IModelError> errors, IModelContext context = null)
        {
            BeforeTrySave(item, errors, context);
            var rtn = service.TrySave(item, errors, context);
            AfterTrySave(rtn, item, errors, context);
            return rtn;
        }

        /// <summary>
        /// Afters the try save.
        /// </summary>
        /// <param name="rtn">if set to <c>true</c> [RTN].</param>
        /// <param name="item">The item.</param>
        /// <param name="errors">The errors.</param>
        /// <param name="context">The context.</param>
        virtual protected void AfterTrySave(bool rtn, T item, List<IModelError> errors, IModelContext context)
        {
        }

        /// <summary>
        /// Befores the try save.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="errors">The errors.</param>
        /// <param name="context">The context.</param>
        virtual protected void BeforeTrySave(T item, List<IModelError> errors, IModelContext context)
        {
        }

        #endregion

    }
}
