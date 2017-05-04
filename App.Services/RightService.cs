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
    /// Service to provide atomic opertaion for a Right data object
    /// </summary>
    class RightService : BaseService<IRightDataModel>, IService<IRightDataModel> , IRightService
    {	
		
		private IRightDal serviceDal ; 
		
        private IAccountDal accountDal ;

        private IRoleDal roleDal ;

		public RightService(IRightDal dal, IAccountDal accountDal , IRoleDal roleDal , IValidator<IRightDataModel> validator, IEntityChangeHandler<IRightDataModel>[] changeHandler = null)
		 :base(dal, validator, changeHandler)
		{
			serviceDal = dal; // keep a local copy as it's more specialized than IDal<Right>
			
            this.accountDal = accountDal ;

            this.roleDal = roleDal ;

		}

		


		/// <summary>
        /// Supports the many to many relationship (RoleRight) between 
        /// Right (parent) Role (child)
        /// </summary>
        /// <param name="roleId"></param>
        /// <param name="context"></param>
        /// <returns></returns> 
		public IQueryable<IRightDataModel> GetRoleRight(int roleId, List<IModelError> errors, IModelContext context = null)
		{
			if (roleDal.Get(roleId, context) == null) // check roleId exists
            {
                errors.Add(new ModelError{Property = "roleId", ErrorMessage = "roleId_notfound" });
				return Enumerable.Empty<IRightDataModel>().AsQueryable();
			}

			var rtn = serviceDal.GetRoleRight(roleId, context);
			return rtn;
		}
		
		/// <summary>
        /// Supports the many to many relationship (RoleRight) between 
        /// Right (parent) Role (child)
        /// </summary>
        /// <param name="rightId"></param>
        /// <param name="roleId"></param>
        /// <param name="context"></param>
        /// <returns></returns>
		public bool TryAddRoleRight(int rightId, int roleId,  List<IModelError> errors, IModelContext context = null)
		{
			if (serviceDal.Get(rightId, context) == null) // check rightId exists
            {
                errors.Add(new ModelError{Property = "rightId", ErrorMessage = "rightId_notfound" });
				return false;
			}

			serviceDal.AddRoleRight(rightId, roleId, context);
			return true; 
		}

		/// <summary>
        /// Supports the many to many relationship (RoleRight) between 
        /// Right (parent) Role (child)
        /// </summary>
        /// <param name="rightId"></param>
        /// <param name="roleId"></param>
        /// <param name="context"></param>
        /// <returns></returns>
		public bool TryRemoveRoleRight(int rightId, int roleId,  List<IModelError> errors, IModelContext context = null)
		{
			if (serviceDal.Get(rightId, context) == null) // check rightId exists
            {
                errors.Add(new ModelError{Property = "rightId", ErrorMessage = "rightId_notfound" });
				return false;
			}

			serviceDal.RemoveRoleRight(rightId, roleId, context);
			return true; 
		}
					

	}
}