namespace App.Services.Validators
{
    using Contracts;
    using Contracts.DataModels;
    using System.Collections.Generic;
    using System.Linq;
    using Contracts.Validators;
    using Contracts.Interfaces;

    class AccountValidator : IAccountValidator 
    {
        /// <summary>
        /// Returns true if the model is valid
        /// </summary> 
        public bool IsValid(IAccountDataModel model, Operation op, List<IModelError> errors)
        {
            var e = new List<IModelError>();
            // check for required properties
            if (model.Username.IsPresent() == false) e.Add(new ModelError { Property = "Username", ErrorMessage = "account_username_missing" });
            if (model.Password.IsPresent() == false) e.Add(new ModelError { Property = "Password", ErrorMessage = "account_password_missing" });
            if (model.AccountValidFrom.IsPresent() == false) e.Add(new ModelError { Property = "AccountValidFrom", ErrorMessage = "account_accountvalidfrom_missing" });
            if (model.AccountValidTo.IsPresent() == false) e.Add(new ModelError { Property = "AccountValidTo", ErrorMessage = "account_accountvalidto_missing" });
            // check supplied properties are valid
            
            errors.CombineOrReplace(e);
            return (e.Any() == false);    
        }        
    }
}