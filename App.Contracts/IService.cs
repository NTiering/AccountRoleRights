namespace App.Contracts
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public partial interface IService<T> where T : class, IDataModel
    {
        /// <summary>
        /// Deletes the specified item that contains the id.
        /// </summary>
        bool TryDelete(int id, List<IModelError> errors, IModelContext context = null);

        /// <summary>
        /// Gets the specified item by id.
        /// </summary>
        T Get(int id, List<IModelError> errors, IModelContext context = null);

        /// <summary>
        /// Gets the first item that fufills the filter.
        /// </summary>
        T Get(Func<T, bool> filter, List<IModelError> errors, IModelContext context = null);

        /// <summary>
        /// Gets all the items that fufills the filter.
        /// </summary>
        IQueryable<T> GetAll(Func<T, bool> filter, List<IModelError> errors, IModelContext context = null, Func<T, int> order = null, int skip = 0, int take = 999);

        /// <summary>
        /// Tries to save the itme.
        /// </summary>
        bool TrySave(T item, List<IModelError> errors, IModelContext context = null);

        /// <summary>
        /// Tries validation on a single property.
        /// </summary>
        bool TryValidate(T item, string propertyName, List<IModelError> errors, IModelContext context = null);

    }
}