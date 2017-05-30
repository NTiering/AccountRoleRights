namespace App.Contracts.Validators
{
    using Contracts;
    using DataModels;
    using Interfaces;
    using System.Collections.Generic;

    public interface IRightValidator 
    {
        /// <summary>
        /// Returns true if the model is valid
        /// </summary> 
        bool IsValid(IRightDataModel model, Operation op, List<IModelError> errors);
    }
}