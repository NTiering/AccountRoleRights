namespace App.Services.Interfaces
{
    using System.Collections.Generic;
    using Contracts;
    using Contracts.Models;

    public interface IValidator<T>
        where T : IDataModel
    {
        /// <summary>
        /// Returns true if the model is valid
        /// </summary>
        bool IsValid(T model, Operation action, List<IModelError> errors);
    }
}