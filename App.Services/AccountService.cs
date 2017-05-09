namespace App.Services
{
    using Contracts;
    using System;
    using System.Collections.Generic;
    using Interfaces;
    using Contracts.DataModels;
    using Contracts.Dals;
    using System.Linq;
    using Contracts.Services;
    using Encryption;

    /// <summary>
    /// Service to provide atomic opertaion for a Account data object
    /// </summary>
    class AccountService : BaseService<IAccountDataModel>, IService<IAccountDataModel> , IAccountService
    {    
        
        private IAccountDal serviceDal ; 
        
        private IRoleDal roleDal ;

        private IRightDal rightDal ;

        private ICryptoProvider cryptoProvider ;

        public AccountService(IAccountDal dal, IRoleDal roleDal , IRightDal rightDal , ICryptoProvider cryptoProvider , IValidator<IAccountDataModel> validator, IEntityChangeHandler<IAccountDataModel>[] changeHandler = null)
         :base(dal, validator, changeHandler)
        {
            serviceDal = dal; // keep a local copy as it's more specialized than IDal<Account>
            
            this.roleDal = roleDal ;

            this.rightDal = rightDal ;

            this.cryptoProvider = cryptoProvider ;
        }

        
        /// <summary>
        /// Saves the Account entity using encryption where required
        /// </summary>
        override public bool TrySave(IAccountDataModel item, List<IModelError> errors, IModelContext context = null)
        {
            var isValid = TryValidateModel(item, (item.IsNew ? Operation.Create : Operation.Update) , errors, context);
            
            if (isValid == false) return false;


            if (item != null && item.Password != null)
            {
                item.Password = cryptoProvider.CreateHash(item.Password);
            }
                        
            return base.TrySave(item, errors, context);
        }
        

            /// <summary>
            /// Returns true if the model exists and the values supplied matches a hashed version of Password
            /// </summary>
            public bool MatchesPassword(int id , string password, List<IModelError> errors, IModelContext context = null)
            {
                var model = Get(id, errors, context);
                if(model == null) return false;
                var rtn = (String.Compare(password, cryptoProvider.CreateHash(model.Password)) == 0);
                return rtn;
            } 
            

        /// <summary>
        /// Supports the many to many relationship (AccountRole) between 
        /// Account (parent) Role (child)
        /// </summary>
        /// <param name="roleId"></param>
        /// <param name="context"></param>
        /// <returns></returns> 
        public IQueryable<IAccountDataModel> GetAccountRole(int roleId, List<IModelError> errors, IModelContext context = null)
        {
            if (roleDal.Get(roleId, context) == null) // check roleId exists
            {
                errors.Add(new ModelError{Property = "roleId", ErrorMessage = "roleId_notfound" });
                return Enumerable.Empty<IAccountDataModel>().AsQueryable();
            }

            var rtn = serviceDal.GetAccountRole(roleId, context);
            return rtn;
        }
        
        /// <summary>
        /// Supports the many to many relationship (AccountRole) between 
        /// Account (parent) Role (child)
        /// </summary>
        /// <param name="accountId"></param>
        /// <param name="roleId"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public bool TryAddAccountRole(int accountId, int roleId,  List<IModelError> errors, IModelContext context = null)
        {
            if (serviceDal.Get(accountId, context) == null) // check accountId exists
            {
                errors.Add(new ModelError{Property = "accountId", ErrorMessage = "accountId_notfound" });
                return false;
            }

            serviceDal.AddAccountRole(accountId, roleId, context);
            return true; 
        }

        /// <summary>
        /// Supports the many to many relationship (AccountRole) between 
        /// Account (parent) Role (child)
        /// </summary>
        /// <param name="accountId"></param>
        /// <param name="roleId"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public bool TryRemoveAccountRole(int accountId, int roleId,  List<IModelError> errors, IModelContext context = null)
        {
            if (serviceDal.Get(accountId, context) == null) // check accountId exists
            {
                errors.Add(new ModelError{Property = "accountId", ErrorMessage = "accountId_notfound" });
                return false;
            }

            serviceDal.RemoveAccountRole(accountId, roleId, context);
            return true; 
        }
                    

    }
}