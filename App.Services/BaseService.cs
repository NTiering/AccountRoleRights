namespace App.Services
{
    using Contracts;
    using Contracts.Models;
    using Contracts.Services;
    using Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    abstract partial class BaseService<T> : IService<T> where T : class, IDataModel
    {
        protected List<IEntityChangeHandler<T>> changeHandler { get; private set; }

        protected IDal<T> dal { get; private set; }
        
        protected IValidator<T> validator { get; private set; }

        protected BaseService(IDal<T> dal, IValidator<T> validator, IEntityChangeHandler<T>[] changeHandler = null)
        {
            this.dal = dal;         
            this.validator = validator;
            this.changeHandler = ((changeHandler ?? new IEntityChangeHandler<T>[0]).ToList()).Where(x => x != null).ToList();
        }

        #region create update and delete (CrUD)

        /// <summary>
        /// Deletes the specified item that contains the id.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="errors"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        virtual public bool TryDelete(int id, List<IModelError> errors, IModelContext context = null)
        {
            var exists = Exists(id, context);
            if (!exists)
            {
                AddNotExistsError(errors);
                return false;
            }

            try
            {
                changeHandler.ForEach(x => x.BeforeDelete(Get(d=> d.Id == id), context));
                dal.Delete(id, context);
                changeHandler.ForEach(x => x.AfterDelete(id, context));
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Unable to update " + typeof(T).FullName, ex);
            }
            
            return true;
        }

        /// <summary>
        /// Tries to save the item.
        /// </summary>
        /// <param name="item"></param>
        /// <param name="errors"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        virtual public bool TrySave(T item, List<IModelError> errors, IModelContext context = null)
        {
            if (item == default(T))
            {
                AddNullModelError(errors);
                return false;
            }

            return item.IsNew ?
                TryCreate(item, errors, context) :
                TryUpdate(item, errors, context);
        }

        /// <summary>
        /// Checks the validation of a single property
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="errors">The errors.</param>
        /// <param name="context">The context.</param>
        /// <returns></returns>
        virtual public bool TryValidate(T item, string propertyName, List<IModelError> errors, IModelContext context = null)
        {
            var rtn = TryValidateModel(item, Operation.View, errors, context);
            errors.RemoveAll(x => string.Compare(x.Property, propertyName, true) != 0);
            return rtn;
        }

        /// <summary>
        /// Tries the update.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="errors">The errors.</param>
        /// <param name="context">The context.</param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException">Unable to update " + typeof(T).FullName</exception>
        virtual protected bool TryUpdate(T item, List<IModelError> errors, IModelContext context)
        {
            if (TryValidateModel(item, Operation.Update, errors, context) == false)
            {
                return false;
            }

            try
            {
                changeHandler.ForEach(x => x.BeforeUpdate(item, context));
                dal.Update(item, context);
                changeHandler.ForEach(x => x.AfterUpdate(item, context));
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Unable to update " + typeof(T).FullName, ex);
            }

            return true;
        }

        /// <summary>
        /// Tries the create.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="errors">The errors.</param>
        /// <param name="context">The context.</param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException">Unable to update " + typeof(T).FullName</exception>
        virtual protected bool TryCreate(T item, List<IModelError> errors, IModelContext context)
        {
            if (TryValidateModel(item, Operation.Create, errors, context) == false)
            {
                return false;
            }

            try
            {
                changeHandler.ForEach(x => x.BeforeCreate(item, context));
                dal.Create(item, context);
                changeHandler.ForEach(x => x.AfterCreate(item, context));
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Unable to create " + typeof(T).FullName, ex);
            }

            return true;
        }

        #endregion

        #region find and get 
        /// <summary>
        /// Gets the first item that fufills the filter.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <returns></returns>
        virtual public T Get(Func<T, bool> filter, IModelContext context = null)
        {
            return dal.Get(filter, context);
        }

        /// <summary>
        /// Gets the specified item by id.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="errors"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        virtual public T Get(int id, List<IModelError> errors, IModelContext context = null)
        {
            var rtn = dal.Get(id, context);
            return rtn;
        }

        /// <summary>
        /// Gets the first item that fufills the filter.
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="errors"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        virtual public T Get(Func<T, bool> filter, List<IModelError> errors, IModelContext context = null)
        {
            var rtn = dal.Get(filter, context);
            return rtn;
        }

        /// <summary>
        /// Gets all the items that fufills the filter.
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="errors"></param>
        /// <param name="context"></param>
        /// <param name="order"></param>
        /// <param name="skip"></param>
        /// <param name="take"></param>
        /// <returns></returns>
        virtual public IQueryable<T> GetAll(Func<T, bool> filter, List<IModelError> errors, IModelContext context = null, Func<T, int> order = null, int skip = 0, int take = 999)
        {
            var rtn = dal.GetAll(filter, context)
                .Skip(skip)
                .Take(take);

            if (order != null)
            {
                rtn = rtn.OrderBy(order)
                    .AsQueryable();
            }
            return rtn;
        }
        #endregion

        /// <summary>
        /// Adds the not allowed error.
        /// </summary>
        /// <param name="errors">The errors.</param>
        /// <exception cref="NotImplementedException"></exception>
        virtual protected void AddNotAllowedError(List<IModelError> errors)
        {
            errors.Add(new ModelError { Property = "", ErrorMessage = "notallowed" });
        }

        /// <summary>
        /// Adds the not exists error.
        /// </summary>
        /// <param name="errors">The errors.</param>
        virtual protected void AddNotExistsError(List<IModelError> errors)
        {
            errors.Add(new ModelError { Property = "", ErrorMessage = "notexisting" });
        }

        /// <summary>
        /// Adds the null model error.
        /// </summary>
        /// <param name="errors">The errors.</param>
        virtual protected void AddNullModelError(List<IModelError> errors)
        {
            errors.Add(new ModelError { Property = "", ErrorMessage = "nomodel" });
        }

        /// <summary>
        /// Exitses the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="context">The context.</param>
        /// <returns></returns>
        virtual protected bool Exists(int id, IModelContext context)
        {
            return dal.Get(id, context) != null;
        }

        /// <summary>
        /// Determines whether the specified identifier is unique.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="filter">The filter.</param>
        /// <param name="context">The context.</param>
        /// <returns>
        ///   <c>true</c> if the specified identifier is unique; otherwise, <c>false</c>.
        /// </returns>
        virtual protected bool IsUnique(int id, Func<T, bool> filter, IModelContext context)
        {
            var possible = dal.Get(filter, context);
            return possible == null ? true : possible.Id != id;
        }

        /// <summary>
        /// Validates the model.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="operation">The operation.</param>
        /// <param name="errors">The errors.</param>
        /// <param name="context">The context.</param>
        /// <returns></returns>
        virtual protected bool TryValidateModel(T item, Operation operation, List<IModelError> errors, IModelContext context)
        {
            if (item == null)
            {
                AddNullModelError(errors);
                return false;
            }

            return IsValid(item, operation, errors);
        }

        /// <summary>
        /// Returns true if item is valid.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="errors">The errors.</param>
        /// <returns>
        ///   <c>true</c> if the specified item is valid; otherwise, <c>false</c>.
        /// </returns>
        virtual protected bool IsValid(T item, Operation op, List<IModelError> errors)
        {
            return validator.IsValid(item, op, errors);
        }

    }

}