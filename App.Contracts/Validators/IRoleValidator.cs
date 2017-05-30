namespace App.Contracts.Validators
{
    using Contracts;
    using DataModels;
    using Interfaces;
    using System.Collections.Generic;

    public interface IRoleValidator 
    {
        /// <summary>
        /// Returns true if the model is valid
        /// </summary> 
        bool IsValid(IRoleDataModel model, Operation op, List<IModelError> errors);
    }
}