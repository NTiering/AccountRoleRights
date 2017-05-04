namespace App.Services.Validators
{
    using Contracts;
    using Contracts.DataModels;
    using Interfaces;
    using System.Collections.Generic;
    using System.Linq;

    class RightValidator : IValidator<IRightDataModel> 
    {
		/// <summary>
        /// Returns true if the model is valid
        /// </summary> // here 
		public bool IsValid(IRightDataModel model, Operation op, List<IModelError> errors)
		{
	        var e = new List<IModelError>();
			// check for required properties

            if (model.Name.IsPresent() == false) e.Add(new ModelError { Property = "Name", ErrorMessage = "right_name_missing" });
            if (model.Key.IsPresent() == false) e.Add(new ModelError { Property = "Key", ErrorMessage = "right_key_missing" });			// check supplied properties are valid
			
			errors.CombineOrReplace(e);
            return (e.Any() == false);    
		}		
    }
}