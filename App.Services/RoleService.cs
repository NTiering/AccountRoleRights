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
    /// Service to provide atomic opertaion for a Role data object
    /// </summary>
    class RoleService : BaseService<IRoleDataModel>, IService<IRoleDataModel> , IRoleService
    {    
        
        private IRoleDal serviceDal ; 
        
        private IAccountDal accountDal ;

        private IRightDal rightDal ;

        public RoleService(IRoleDal dal, IAccountDal accountDal , IRightDal rightDal , IValidator<IRoleDataModel> validator, IEntityChangeHandler<IRoleDataModel>[] changeHandler = null)
         :base(dal, validator, changeHandler)
        {
            serviceDal = dal; // keep a local copy as it's more specialized than IDal<Role>
            
            this.accountDal = accountDal ;

            this.rightDal = rightDal ;

        }

        

    
        /// <summary>
        /// Supports the many to many relationship (AccountRole) between 
        /// Role (child) Account (parent)
        /// </summary>
        /// <param name="accountId"></param>
        /// <param name="context"></param>
        /// <returns></returns> 
        public IQueryable<IRoleDataModel> GetAccountRole(int accountId, List<IModelError> errors, IModelContext context = null)
        {
            if (accountDal.Get(accountId, context) == null) // check accountId exists
            {
                errors.Add(new ModelError{Property = "accountId", ErrorMessage = "accountId_notfound" });
                return Enumerable.Empty<IRoleDataModel>().AsQueryable();
            }

            var rtn = serviceDal.GetAccountRole(accountId, context);
            return rtn;
        }
        
        /// <summary>
        /// Supports the many to many relationship (AccountRole) between 
        /// Role (child) Account (parent)
        /// </summary>
        /// <param name="roleId"></param>
        /// <param name="accountId"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public bool TryAddAccountRole(int roleId, int accountId, List<IModelError> errors, IModelContext context = null)
        {            
            if (serviceDal.Get(roleId, context) == null) // check roleId exists
            {
                errors.Add(new ModelError{Property = "roleId", ErrorMessage = "roleId_notfound" });
                return false;
            }

            if (accountDal.Get(accountId, context) == null) // check accountId exists
            {
                errors.Add(new ModelError{Property = "accountId", ErrorMessage = "accountId_notfound" });
                return false;
            }

            serviceDal.AddAccountRole(roleId, accountId, context);
            return true; 
        }

        /// <summary>
        /// Supports the many to many relationship (AccountRole) between 
        /// Role (child) Account (parent)
        /// </summary>
        /// <param name="roleId"></param>
        /// <param name="accountId"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public bool TryRemoveAccountRole(int roleId, int accountId, List<IModelError> errors, IModelContext context = null)
        {
            if (serviceDal.Get(roleId, context) == null) // check roleId exists
            {
                errors.Add(new ModelError{Property = "roleId", ErrorMessage = "roleId_notfound" });
                return false;
            }

            if (accountDal.Get(accountId, context) == null) // check accountId exists
            {
                errors.Add(new ModelError{Property = "accountId", ErrorMessage = "accountId_notfound" });
                return false;
            }

            serviceDal.RemoveAccountRole(roleId, accountId, context);
            return true; 
        }
        
        /// <summary>
        /// Supports the many to many relationship (RoleRight) between 
        /// Role (child) Right (parent)
        /// </summary>
        /// <param name="rightId"></param>
        /// <param name="context"></param>
        /// <returns></returns> 
        public IQueryable<IRoleDataModel> GetRoleRight(int rightId, List<IModelError> errors, IModelContext context = null)
        {
            if (rightDal.Get(rightId, context) == null) // check rightId exists
            {
                errors.Add(new ModelError{Property = "rightId", ErrorMessage = "rightId_notfound" });
                return Enumerable.Empty<IRoleDataModel>().AsQueryable();
            }

            var rtn = serviceDal.GetRoleRight(rightId, context);
            return rtn;
        }
        
        /// <summary>
        /// Supports the many to many relationship (RoleRight) between 
        /// Role (child) Right (parent)
        /// </summary>
        /// <param name="roleId"></param>
        /// <param name="rightId"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public bool TryAddRoleRight(int roleId, int rightId, List<IModelError> errors, IModelContext context = null)
        {            
            if (serviceDal.Get(roleId, context) == null) // check roleId exists
            {
                errors.Add(new ModelError{Property = "roleId", ErrorMessage = "roleId_notfound" });
                return false;
            }

            if (rightDal.Get(rightId, context) == null) // check rightId exists
            {
                errors.Add(new ModelError{Property = "rightId", ErrorMessage = "rightId_notfound" });
                return false;
            }

            serviceDal.AddRoleRight(roleId, rightId, context);
            return true; 
        }

        /// <summary>
        /// Supports the many to many relationship (RoleRight) between 
        /// Role (child) Right (parent)
        /// </summary>
        /// <param name="roleId"></param>
        /// <param name="rightId"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public bool TryRemoveRoleRight(int roleId, int rightId, List<IModelError> errors, IModelContext context = null)
        {
            if (serviceDal.Get(roleId, context) == null) // check roleId exists
            {
                errors.Add(new ModelError{Property = "roleId", ErrorMessage = "roleId_notfound" });
                return false;
            }

            if (rightDal.Get(rightId, context) == null) // check rightId exists
            {
                errors.Add(new ModelError{Property = "rightId", ErrorMessage = "rightId_notfound" });
                return false;
            }

            serviceDal.RemoveRoleRight(roleId, rightId, context);
            return true; 
        }
                

    }
}