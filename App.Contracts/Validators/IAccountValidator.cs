namespace App.Contracts.Validators
{
    using Contracts;
    using DataModels;
    using Interfaces;
    using System.Collections.Generic;

    public interface IAccountValidator 
    {
        /// <summary>
        /// Returns true if the model is valid
        /// </summary> 
        bool IsValid(IAccountDataModel model, Operation op, List<IModelError> errors);
    }
}